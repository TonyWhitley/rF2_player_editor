using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace rF2_player_editor
{
    using dict = Dictionary<string, dynamic>;

    /// <summary>
    /// The main form
    /// </summary>
    public partial class Form1 : Form
    {
        private const int MaxRows = 20;

        private readonly Dictionary<string, TextBox> _textBoxes =
            new Dictionary<string, TextBox>{};
        private readonly Dictionary<string, Label> _labels = new Dictionary<string, Label> { };
        private readonly Dictionary<string, ToolTip> _toolTips = new Dictionary<string, ToolTip> { };
        private readonly Dictionary<string, ComboBox> _comboBoxes = new Dictionary<string, ComboBox> {};

        private void Tab(dict tabData,
            string section,
            TabPage tabPage,
            TableLayoutPanel panel,
            int width)
        {
            // Fill in tab 'section' with data from 'tabData'
            var entriesInThisTab = 0;
            string lastVal = null;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tabPage.Text = section;

            foreach (var entry in tabData[tabData.First().Key].ToObject<dict>())
            {
                string name = entry.Key;
                string val;
                if (entry.Value is string)
                {
                    val = entry.Value;
                }
                else
                {
                    val = entry.Value.ToString();
                }

                if (name.Last() != '#')
                {
                    _labels[name] = new Label
                    {
                        Name = name,
                        Text = name,
                        AutoSize = true,
                        Visible = true
                    };
                    panel.Controls.Add(_labels[name]);

                    var defaultTip = $"No help available\nDefault: {val}";
                    if (val == "True" || val == "False")
                    {
                        // Use a combobox for booleans
                        _comboBoxes[name] = new ComboBox
                        {
                            Name = name
                        };
                        _comboBoxes[name].Items.AddRange(new object[]
                            {"True", "False"});
                        _comboBoxes[name].Text = val;
                        _comboBoxes[name].Width = width;
                        _comboBoxes[name].Leave += ComboBoxValueChanged;
                        _comboBoxes[name].DropDownClosed += ComboBoxValueChanged;
                        panel.Controls.Add(_comboBoxes[name]);
                        // default tooltip that with luck is overwritten with real help text
                        _toolTips[name] = new ToolTip();
                        _toolTips[name]
                                .SetToolTip(_comboBoxes[name], defaultTip);
                    }
                    else
                    {
                        // Use a textbox for general values
                        _textBoxes[name] = new TextBox
                        {
                            Name = name,
                            Text = val,
                            Width = width
                        };
                        _textBoxes[name].Validated += TextBoxValueChanged;
                        _textBoxes[name].KeyDown += TextBoxKeyDown;
                        panel.Controls.Add(_textBoxes[name]);
                        // default tooltip that with luck is overwritten with real help text
                        _toolTips[name] = new ToolTip();
                        _toolTips[name]
                                .SetToolTip(_textBoxes[name], defaultTip);
                    }
                    _toolTips[name]
                        .SetToolTip(_labels[name], defaultTip);
                    _toolTips[name].IsBalloon = true;

                    entriesInThisTab++;
                }
                else
                {
                    // JSON keys ending in # are comments, use them for tooltips
                    name = name.Trim('#');
                    string tip = entry.Value;
                    if (tip.Length > 45) // If more than 45 chars wrap every 40
                    {
                        tip = TextUtils.WrapText(tip, 40);
                    }
                    tip += tip.EndsWith("\n") ? null : "\n";
                    tip += $"Default: {lastVal}";

                    _toolTips[name]
                        .SetToolTip(_labels[name], tip);
                    _toolTips[name].IsBalloon = true;
                    if (lastVal == "True" || lastVal == "False")
                    {
                        _toolTips[name]
                            .SetToolTip(_comboBoxes[name], tip);
                    }
                    else
                    {
                        _toolTips[name]
                            .SetToolTip(_textBoxes[name], tip);
                    }
                }

                lastVal = val;
            }

            // Set the number of columns of label/entry pairs
            panel.ColumnCount = (entriesInThisTab / MaxRows + 1) * 2;
        }

        /// <summary> Event handler when a value is changed </summary>
        private void ComboBoxValueChanged(object sender, EventArgs e)
        {
            //write your event code here
            var key = ((Control) sender).Name;
            var value = ((ComboBox) sender).Text;
            WriteDict.WriteValue(key, value);
        }

        /// <summary> Event handler when a value is changed </summary>
        private void TextBoxValueChanged(object sender, EventArgs e)
        {
            //write your event code here
            var key = ((Control) sender).Name;
            var value = ((TextBox) sender).Text;
            WriteDict.WriteValue(key, value);
        }

        private void TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBoxValueChanged(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// The main (only) form
        /// </summary>
        public Form1(dict tabDict)
        {
            var tabCount = tabDict.Count;
            var panels = new TableLayoutPanel[tabCount];
            var tabPages = new TabPage[tabCount];
            int width;

            InitializeComponent();
            rFactorToolStripMenuItem_Click(null, null);

            for (var u = 0; u < tabCount; u++)
            {
                panels[u] = new TableLayoutPanel
                {
                    AutoSize = true
                };
                tabPages[u] = new TabPage();
                tabPages[u].Controls.Add(panels[u]);
            }

            var panelCount = 0;
            foreach (var entry in tabDict)
            {
                if (entry.Key == "Chat")
                {
                    width = 150;
                }
                else
                {
                    width = 60;
                }

                Tab(entry.Value,
                    entry.Key,
                    tabPages[panelCount],
                    panels[panelCount],
                    width);

                TabControl1.Controls.Add(tabPages[panelCount]);
                panels[panelCount].Padding =
                    new Padding(15, 15, 15, 15); //Padding round the panel
                panelCount++;
            }

            TabControl1.Height = 12000 / MaxRows;
            TabControl1.ItemSize =
                new Size(50, 70); // Set the size of the tab labels
            TabControl1.Padding =
                new Point(3, 0); //Padding round the tab labels
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        public void SaveChanges()
        {
            var message = string.Format(
                "You have made changes, do you want to save them?",
                rF2_player_editor.cfg.playerJson);
            const string caption = "Closing down";
            var result = MessageBox.Show(message, caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FileMenuItemSaveClick();
            }
        }

        private void FileMenuItemOpenClick(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = rF2_player_editor.cfg.GetTheDataFilePath();
            openFileDialog.FileName = rF2_player_editor.cfg.playerJsonFilter;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var editsFile = openFileDialog.FileName;
                // TBD: do something with it!
                //MessageBox.Show(string.Format("Open {0}", editsFile));
            }
        }

        private void FileMenuItemSaveClick(object sender = null, EventArgs e = null)
        {
            saveFileDialog.InitialDirectory = rF2_player_editor.cfg.playerPath;
            saveFileDialog.FileName = rF2_player_editor.cfg.playerJson;
            saveFileDialog.Filter = "JSON files|*.JSON";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rF2_player_editor.cfg.playerJsonPath = saveFileDialog.FileName;
                rF2_player_editor.SaveChanges();
                //MessageBox.Show(string.Format("Saved as {0}", Config.playerJsonPath));
            }
        }

        private void FileMenuItemExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void HelpMenuItemAboutClick(object sender, EventArgs e)
        {
            var about = new AboutBox1();
            about.ShowDialog();
        }

        private void rFactorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rFactorToolStripMenuItem.CheckState = CheckState.Checked;
            leMansUltimateToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.Text = "rFactor 2 Player Editor";
        }

        private void leMansUltimateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leMansUltimateToolStripMenuItem.CheckState = CheckState.Checked;
            rFactorToolStripMenuItem.CheckState = CheckState.Unchecked;
            this.Text = "Le Mans Ultimate Player Editor";
        }
    }
}
