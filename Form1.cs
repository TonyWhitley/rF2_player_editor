using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace rF2_player_editor
{
    public partial class Form1 : Form
    {
        private const int numberOfEntries = 1200;
        private const int maxRows = 20;
        private TableLayoutPanel[] panels;
        private TabPage[] tabPages;
        private TextBox[] textBoxes = new TextBox[numberOfEntries];
        private Label[] labels = new Label[numberOfEntries];
        private ToolTip[] toolTips = new ToolTip[numberOfEntries];
        private ComboBox[] comboBoxes = new ComboBox[numberOfEntries];
        private int entryCount = 0;
        private int tab(Dictionary<string, dynamic> tabData,
            string section,
            TabPage tabPage,
            TableLayoutPanel panel,
            int width)
        {
            // Fill in tab 'section' with data from 'tabData'
            int entries = 0;
            string lastval = null;

            tabPage.Text = section;

            foreach (var entry in tabData[tabData.First().Key].ToObject<Dictionary<string, object>>())
            {
                string name = entry.Key;
                string val;
                if (entry.Value is string)
                    val = entry.Value;
                else
                    val = entry.Value.ToString();

                if (name.Last() != '#')
                {
                    this.labels[this.entryCount] = new Label();
                    this.labels[this.entryCount].Name = name;
                    this.labels[this.entryCount].Text = name;
                    this.labels[this.entryCount].AutoSize = true;
                    this.labels[this.entryCount].Visible = true;
                    panel.Controls.Add(this.labels[this.entryCount]);

                    if (val == "True" || val == "False")
                    {   // Use a combobox for booleans
                        this.comboBoxes[this.entryCount] = new ComboBox();
                        this.comboBoxes[this.entryCount].Name = name;
                        this.comboBoxes[this.entryCount].Items.AddRange(new object[] { "True", "False" });
                        this.comboBoxes[this.entryCount].Text = val;
                        this.comboBoxes[this.entryCount].Width = width;
                        panel.Controls.Add(this.comboBoxes[this.entryCount]);
                    }
                    else
                    {   // Use a textbox for general values
                        this.textBoxes[this.entryCount] = new TextBox();
                        this.textBoxes[this.entryCount].Name = name;
                        this.textBoxes[this.entryCount].Text = val;
                        this.textBoxes[this.entryCount].Width = width;
                        panel.Controls.Add(this.textBoxes[this.entryCount]);
                    }
                    this.entryCount++;
                    entries++;
                }
                else
                {   // JSON keys ending in # are comments, use them for tooltips
                    string tip = entry.Value;
                    this.toolTips[this.entryCount - 1] = new ToolTip();
                    this.toolTips[this.entryCount - 1].SetToolTip(this.labels[this.entryCount - 1], tip);
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

            panel.ColumnCount = ((entries / maxRows) + 1) * 2;

            return this.entryCount;
        }
        public Form1(Dictionary<string, dynamic> tabDict)
        {
            int tabCount = tabDict.Count;
            this.panels = new TableLayoutPanel[tabCount];
            this.tabPages = new TabPage[tabCount];
            int width;

            InitializeComponent();

            for (int u = 0; u < tabCount; u++)
            {
                this.panels[u] = new TableLayoutPanel();
                //this.panels[u].Size = new System.Drawing.Size(228, 200);
                this.panels[u].AutoSize = true;
                this.panels[u].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
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

                this.entryCount = tab(
                    entry.Value,
                    entry.Key,
                    this.tabPages[panelCount],
                    this.panels[panelCount],
                    width);
                
                tabControl1.Controls.Add(this.tabPages[panelCount]);
                panels[panelCount].Padding = new System.Windows.Forms.Padding(15, 15, 15, 15); //Padding round the panel
                panelCount++;
            }
            tabControl1.Height = 12000 / maxRows;
            tabControl1.ItemSize = new Size(50, 60);    // Set the size of the tab labels
            tabControl1.Padding = new System.Drawing.Point(1, 0); //Padding round the tab labels
            //Form1.Size = Point(100, 200);
        }

        private void tabSoundOptions_Click(object sender, EventArgs e)
        {

        }
    }
}
