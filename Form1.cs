using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

    public partial class Form1 : Form
    {
        private const int numberOfEntries = 1200;
        private const int maxRows = 20;
        private readonly TableLayoutPanel[] panels;
        private readonly TabPage[] tabPages;
        private readonly TextBox[] textBoxes = new TextBox[numberOfEntries];
        private readonly Label[] labels = new Label[numberOfEntries];
        private readonly ToolTip[] toolTips = new ToolTip[numberOfEntries];
        private readonly ComboBox[] comboBoxes = new ComboBox[numberOfEntries];
        private int entryCount = 0;

        private void Tab(dict tabData,
            string section,
            TabPage tabPage,
            TableLayoutPanel panel,
            int width)
        {
            // Fill in tab 'section' with data from 'tabData'
            int entriesInThisTab = 0;
            string lastval = null;

            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tabPage.Text = section;

            foreach (dynamic entry in tabData[tabData.First().Key].ToObject<dict>())
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
                    labels[entryCount] = new Label
                    {
                        Name = name,
                        Text = name,
                        AutoSize = true,
                        Visible = true
                    };
                    panel.Controls.Add(labels[entryCount]);

                    if (val == "True" || val == "False")
                    {   // Use a combobox for booleans
                        comboBoxes[entryCount] = new ComboBox
                        {
                            Name = name
                        };
                        comboBoxes[entryCount].Items.AddRange(new object[] { "True", "False" });
                        comboBoxes[entryCount].Text = val;
                        comboBoxes[entryCount].Width = width;
                        comboBoxes[entryCount].Leave += new EventHandler(ComboBoxValueChanged);
                        panel.Controls.Add(comboBoxes[entryCount]);
                    }
                    else
                    {   // Use a textbox for general values
                        textBoxes[entryCount] = new TextBox
                        {
                            Name = name,
                            Text = val,
                            Width = width
                        };
                        textBoxes[entryCount].Leave += new EventHandler(TextBoxValueChanged);
                        panel.Controls.Add(textBoxes[entryCount]);
                    }
                    entryCount++;
                    entriesInThisTab++;
                }
                else
                {   // JSON keys ending in # are comments, use them for tooltips
                    string tip = entry.Value;
                    if (tip.Length > 45) // If more than 45 chars wrap every 40
                    {
                        tip = TextUtils.WrapText(tip, 40);
                    }

                    toolTips[entryCount - 1] = new ToolTip();
                    toolTips[entryCount - 1].SetToolTip(labels[entryCount - 1], tip);
                    toolTips[entryCount - 1].IsBalloon = true;
                    if (lastval == "True" || lastval == "False")
                    {
                        // this.keyCount-1 is not necessarily correct, should find the matching key
                        toolTips[entryCount - 1].SetToolTip(comboBoxes[entryCount - 1], tip);
                    }
                    else
                    {
                        toolTips[entryCount - 1].SetToolTip(textBoxes[entryCount - 1], tip);
                    }
                }
                lastval = val;
            }

            // Set the number of columns of label/entry pairs
            panel.ColumnCount = ((entriesInThisTab / maxRows) + 1) * 2;
        }

        /// <summary> Event handler when a value is changed </summary>
        private void ComboBoxValueChanged(object sender, System.EventArgs e)
        {
            //write your event code here
            string key = ((System.Windows.Forms.Control)sender).Name;
            string value = ((System.Windows.Forms.ComboBox)sender).Text;
            bool ret = WriteDict.WriteValue(key, value);
        }

        /// <summary>
        /// <summary> Event handler when a value is changed </summary>
        private void TextBoxValueChanged(object sender, System.EventArgs e)
        {
            //write your event code here
            string key = ((System.Windows.Forms.Control)sender).Name;
            string value = ((System.Windows.Forms.TextBox)sender).Text;
            bool ret = WriteDict.WriteValue(key, value);
        }

        /// The main (only) form
        /// </summary>
        public Form1(dict tabDict)
        {
            int tabCount = tabDict.Count;
            panels = new TableLayoutPanel[tabCount];
            tabPages = new TabPage[tabCount];
            int width;

            InitializeComponent();

            for (int u = 0; u < tabCount; u++)
            {
                panels[u] = new TableLayoutPanel
                {
                    //this.panels[u].Size = new System.Drawing.Size(228, 200);
                    AutoSize = true
                };
                tabPages[u] = new TabPage();
                tabPages[u].Controls.Add(panels[u]);
            }

            int panelCount = 0;
            foreach (System.Collections.Generic.KeyValuePair<string, dynamic> entry in tabDict)
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
                panels[panelCount].Padding = new System.Windows.Forms.Padding(15, 15, 15, 15); //Padding round the panel
                panelCount++;
            }
            TabControl1.Height = 12000 / maxRows;
            TabControl1.ItemSize = new Size(50, 60);    // Set the size of the tab labels
            TabControl1.Padding = new System.Drawing.Point(1, 0); //Padding round the tab labels
            //Form1.Size = Point(100, 200);

            TabControl1.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged);
        }
        /// <summary>
        /// Different tab selected, copy all the entries to tabDictCopy
        /// UNFINISHED.   Well, barely started.
        /// Idea is that tabDictCopy will be copied to Player.JSON when user
        /// clicks Save button.
        /// </summary>
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;

            int tabCount = WriteDict.writeDict.Count;

            int panelCount = 0;

                panelCount++;
            }

        }
    }
}
