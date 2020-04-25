using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

    /// <summary>
    /// The main form
    /// </summary>
    public partial class Form1 : Form
    {
        private const int NumberOfEntries = 1200;
        private const int MaxRows = 20;
        private readonly TextBox[] _textBoxes = new TextBox[NumberOfEntries];
        private readonly Label[] _labels = new Label[NumberOfEntries];
        private readonly ToolTip[] _toolTips = new ToolTip[NumberOfEntries];
        private readonly ComboBox[] _comboBoxes = new ComboBox[NumberOfEntries];
        private int _entryCount;

        private void Tab(dict tabData,
            string section,
            TabPage tabPage,
            TableLayoutPanel panel,
            int width)
        {
            // Fill in tab 'section' with data from 'tabData'
            var entriesInThisTab = 0;
            string lastval = null;

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
                    _labels[_entryCount] = new Label
                    {
                        Name = name,
                        Text = name,
                        AutoSize = true,
                        Visible = true
                    };
                    panel.Controls.Add(_labels[_entryCount]);

                    if (val == "True" || val == "False")
                    {
                        // Use a combobox for booleans
                        _comboBoxes[_entryCount] = new ComboBox
                        {
                            Name = name
                        };
                        _comboBoxes[_entryCount].Items.AddRange(new object[]
                            {"True", "False"});
                        _comboBoxes[_entryCount].Text = val;
                        _comboBoxes[_entryCount].Width = width;
                        _comboBoxes[_entryCount].Leave += ComboBoxValueChanged;
                        panel.Controls.Add(_comboBoxes[_entryCount]);
                    }
                    else
                    {
                        // Use a textbox for general values
                        _textBoxes[_entryCount] = new TextBox
                        {
                            Name = name,
                            Text = val,
                            Width = width
                        };
                        _textBoxes[_entryCount].Leave += TextBoxValueChanged;
                        panel.Controls.Add(_textBoxes[_entryCount]);
                    }

                    _entryCount++;
                    entriesInThisTab++;
                }
                else
                {
                    // JSON keys ending in # are comments, use them for tooltips
                    string tip = entry.Value;
                    if (tip.Length > 45) // If more than 45 chars wrap every 40
                    {
                        tip = TextUtils.WrapText(tip, 40);
                    }

                    _toolTips[_entryCount - 1] = new ToolTip();
                    _toolTips[_entryCount - 1]
                        .SetToolTip(_labels[_entryCount - 1], tip);
                    _toolTips[_entryCount - 1].IsBalloon = true;
                    if (lastval == "True" || lastval == "False")
                    {
                        // this.keyCount-1 is not necessarily correct, should find the matching key
                        _toolTips[_entryCount - 1]
                            .SetToolTip(_comboBoxes[_entryCount - 1], tip);
                    }
                    else
                    {
                        _toolTips[_entryCount - 1]
                            .SetToolTip(_textBoxes[_entryCount - 1], tip);
                    }
                }

                lastval = val;
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
                new Size(50, 60); // Set the size of the tab labels
            TabControl1.Padding =
                new Point(1, 0); //Padding round the tab labels
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WriteDict.changed)
            {
                var message = string.Format(
                    "You have made changes, do you want to save them in {0}?",
                    Config.playerJson);
                const string caption = "Closing down";
                var result = MessageBox.Show(message, caption,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    rF2_player_editor.SaveChanges();
                }
            }
        }

        private void FileMenuItemOpenClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var editsFile = openFileDialog.FileName;
                MessageBox.Show(string.Format("Open {0}", editsFile));
            }
        }

        private void FileMenuItemSaveClick(object sender, EventArgs e)
        {
            MessageBox.Show("File menu save item clicked");
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
    }
}