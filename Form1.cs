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
        private int tab(Dictionary<string, dynamic> tabData,
            string section,
            TabPage tabPage,
            TableLayoutPanel panel,
            TextBox[] textBoxes,
            Label[] labels,
            ToolTip[] toolTips,
            ComboBox[] comboBoxes,
            int width,
            int i)
        {
            // Fill in tab 'section' with data from 'tabData'
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
                    labels[i].Name = name;
                    // Some of the key names are long, use tooltips to hold the
                    // full name which may get truncated in the form
                    toolTips[i].SetToolTip(labels[i], name);
                    labels[i].Text = name;
                    labels[i].AutoSize = true;
                    labels[i].Visible = true;
                    panel.Controls.Add(labels[i]);

                    if (val == "True" || val == "False")
                    {   // Use a combobox for booleans
                        comboBoxes[i].Name = name;
                        comboBoxes[i].Items.AddRange(new object[] { "True", "False" });
                        comboBoxes[i].Text = val;
                        comboBoxes[i].Width = width;
                        panel.Controls.Add(comboBoxes[i]);
                    }
                    else
                    {   // Use a textbox for general values
                        textBoxes[i].Name = name;
                        textBoxes[i].Text = val;
                        textBoxes[i].Width = width;
                        panel.Controls.Add(textBoxes[i]);
                    }
                    i++;
                }
                else
                {   // JSON keys ending in # are comments, use them for tooltips
                    string tip = entry.Value;
                    if (lastval == "True" || lastval == "False")
                    {
                        // i-1 is not necessarily correct, should find the matching key
                        toolTips[i - 1].SetToolTip(comboBoxes[i - 1], tip);
                    }
                    else
                    {
                        toolTips[i - 1].SetToolTip(textBoxes[i - 1], tip);
                    }
                }
                lastval = val;
            }
            return i;
        }
        public Form1(Dictionary<string, dynamic> tabDict)
        {
            TableLayoutPanel[] panels = new TableLayoutPanel[20]; // should be # entries in tabDict
            TabPage[] tabPages = new TabPage[20];
            TextBox[] textBoxes = new TextBox[1200];
            Label[] labels = new Label[1200];
            ToolTip[] toolTips = new ToolTip[1200];
            ComboBox[] comboBoxes = new ComboBox[1200];

            InitializeComponent();

            tabControl1.ItemSize = new Size(60, 40);    // Set the size of the tabs

            for (int u = 0; u < panels.Count(); u++)
            {
                panels[u] = new TableLayoutPanel();
                panels[u].ColumnCount = 2;
                //panels[u].Size = new System.Drawing.Size(228, 200);
                panels[u].AutoSize = true;
                panels[u].ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
                tabPages[u] = new TabPage();
                tabPages[u].Controls.Add(panels[u]);
            }
            for (int u = 0; u < textBoxes.Count(); u++)
            {
                textBoxes[u] = new TextBox();
                labels[u] = new Label();
                toolTips[u] = new ToolTip();
                comboBoxes[u] = new ComboBox();
            }

            int panelCount = 0;
            int i = 0;
            /*
            this.tableLayoutPanelChat.RowCount = 12;
            foreach (var entry in tabData["CHAT"])
            //foreach (Label txt in lbls)
            {
                // then they're not sorted string name = entry.Name;
                string name = "Quick Chat #" + (i+1).ToString();
                labels[i].Name = name;
                labels[i].Text = name;
                labels[i].Visible = true;
                this.tableLayoutPanelChat.Controls.Add(labels[i]);
                textBoxes[i].Name = Name;
                textBoxes[i].Text = tabData["CHAT"][name];
                textBoxes[i].Width = 200;
                this.tableLayoutPanelChat.Controls.Add(textBoxes[i]);
                i++;
            }
            */
            foreach (var entry in tabDict)
            {
                i = tab(entry.Value, entry.Key,
                tabPages[panelCount],
                panels[panelCount],
                textBoxes,
                labels,
                toolTips,
                comboBoxes,
                50,
                i);
                tabControl1.Controls.Add(tabPages[panelCount]);
                panelCount++;
            }
        }

        private void tabSoundOptions_Click(object sender, EventArgs e)
        {

        }
    }
}
