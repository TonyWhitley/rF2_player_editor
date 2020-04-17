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
        public dict tabDictCopy;


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

            foreach (var entry in tabData[tabData.First().Key].ToObject<dict>())
            {
                string name = entry.Key;
                string val;
                if (entry.Value is string)
                    val = entry.Value;
                else
                    val = entry.Value.ToString();

                if (name.Last() != '#')
                {
                    this.labels[this.entryCount] = new Label
                    {
                        Name = name,
                        Text = name,
                        AutoSize = true,
                        Visible = true
                    };
                    panel.Controls.Add(this.labels[this.entryCount]);

                    if (val == "True" || val == "False")
                    {   // Use a combobox for booleans
                        this.comboBoxes[this.entryCount] = new ComboBox
                        {
                            Name = name
                        };
                        this.comboBoxes[this.entryCount].Items.AddRange(new object[] { "True", "False" });
                        this.comboBoxes[this.entryCount].Text = val;
                        this.comboBoxes[this.entryCount].Width = width;
                        panel.Controls.Add(this.comboBoxes[this.entryCount]);
                    }
                    else
                    {   // Use a textbox for general values
                        this.textBoxes[this.entryCount] = new TextBox
                        {
                            Name = name,
                            Text = val,
                            Width = width
                        };
                        panel.Controls.Add(this.textBoxes[this.entryCount]);
                    }
                    this.entryCount++;
                    entriesInThisTab++;
                }
                else
                {   // JSON keys ending in # are comments, use them for tooltips
                    string tip = entry.Value;
                    if (tip.Length > 45) // If more than 45 chars wrap every 40
                        tip = TextUtils.WrapText(tip, 40);
                    this.toolTips[this.entryCount - 1] = new ToolTip();
                    this.toolTips[this.entryCount - 1].SetToolTip(this.labels[this.entryCount - 1], tip);
                    this.toolTips[this.entryCount - 1].IsBalloon = true;
                    if (lastval == "True" || lastval == "False")
                    {
                        // this.keyCount-1 is not necessarily correct, should find the matching key
                        this.toolTips[this.entryCount - 1].SetToolTip(this.comboBoxes[this.entryCount - 1], tip);
                    }
                    else
                    {
                        this.toolTips[this.entryCount - 1].SetToolTip(this.textBoxes[this.entryCount - 1], tip);
                    }
                }
                lastval = val;
            }

            // Set the number of columns of label/entry pairs
            panel.ColumnCount = ((entriesInThisTab / maxRows) + 1) * 2;
        }
        /// <summary>
        /// The main (only) form
        /// </summary>
        public Form1(dict tabDict)
        {
            int tabCount = tabDict.Count;
            this.panels = new TableLayoutPanel[tabCount];
            this.tabPages = new TabPage[tabCount];
            int width;

            this.tabDictCopy = tabDict;

            InitializeComponent();

            for (int u = 0; u < tabCount; u++)
            {
                this.panels[u] = new TableLayoutPanel
                {
                    //this.panels[u].Size = new System.Drawing.Size(228, 200);
                    AutoSize = true
                };
                this.tabPages[u] = new TabPage();
                this.tabPages[u].Controls.Add(this.panels[u]);
            }

            int panelCount = 0;
            foreach (var entry in tabDict)
            {
                if (entry.Key == "Chat")
                    width = 150;
                else
                    width = 60;

                Tab(entry.Value,
                    entry.Key,
                    this.tabPages[panelCount],
                    this.panels[panelCount],
                    width);

                TabControl1.Controls.Add(this.tabPages[panelCount]);
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
            int tabCount = tabDictCopy.Count;

            int panelCount = 0;
            foreach (var tabData in tabDictCopy) // HACKERY!!!
            {
                dict entriesThing = (dict)tabData.Value; //Value.Values;
                var section = entriesThing.Keys;
                foreach (var entries in entriesThing.Values)
                    foreach (var entry in entries)
                    {
                        string name = entry.Name;
                        string val;

                        if (name.Last() != '#')
                        { // It's an item, not a comment
                            if (entry.Value is string)
                                val = entry.Value;
                            else
                                val = entry.Value.ToString();
                            //this.panels
                            //this.tabPages
                        }
                    }
                panelCount++;
            }

        }
    }
}
