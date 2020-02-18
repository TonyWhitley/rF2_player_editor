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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int tab(Dictionary<string, dynamic> player,
            string section,
            TableLayoutPanel panel,
            TextBox[] textBoxes,
            Label[] labels,
            ToolTip[] toolTips,
            ComboBox[] comboBoxes,
            int width,
            int i)
        {
            string lastval = null;

            foreach (var entry in player[section])
            {
                string name = entry.Name;
                string val = entry.Value;

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
        public Form1(Dictionary<string, dynamic> player)
        {
            TextBox[] textBoxes = new TextBox[1200];
            Label[] labels = new Label[1200];
            ToolTip[] toolTips = new ToolTip[1200];
            ComboBox[] comboBoxes = new ComboBox[1200];

            InitializeComponent();
            for (int u = 0; u < textBoxes.Count(); u++)
            {
                textBoxes[u] = new TextBox();
                labels[u] = new Label();
                toolTips[u] = new ToolTip();
                comboBoxes[u] = new ComboBox();
            }

            this.tableLayoutPanelChat.RowCount = 12;
            int i = 0;
            foreach (var entry in player["CHAT"])
            //foreach (Label txt in lbls)
            {
                // then they're not sorted string name = entry.Name;
                string name = "Quick Chat #" + (i+1).ToString();
                labels[i].Name = name;
                labels[i].Text = name;
                labels[i].Visible = true;
                this.tableLayoutPanelChat.Controls.Add(labels[i]);
                textBoxes[i].Name = Name;
                textBoxes[i].Text = player["CHAT"][name];
                textBoxes[i].Width = 200;
                this.tableLayoutPanelChat.Controls.Add(textBoxes[i]);
                i++;
            }

            i = tab(player, "DRIVING AIDS",
                this.tableLayoutPanelDrivingAids,
                textBoxes,
                labels,
                toolTips,
                comboBoxes,
                50,
                i);
            i = tab(player, "Graphic Options",
                this.tableLayoutPanelGraphicOptions,
                textBoxes,
                labels,
                toolTips,
                comboBoxes,
                50,
                i);
            i = tab(player, "Race Conditions",
                this.tableLayoutPanelRaceConditions,
                textBoxes,
                labels,
                toolTips,
                comboBoxes,
                50,
                i);
            i = tab(player, "Sound Options",
                this.tableLayoutPanelSoundOptions,
                textBoxes,
                labels,
                toolTips,
                comboBoxes,
                130,
                i);
        }
    }
}
