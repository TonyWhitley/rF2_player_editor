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
            TextBox[] txtOptionValue,
            Label[] lbls,
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
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].AutoSize = true;
                    lbls[i].Visible = true;
                    panel.Controls.Add(lbls[i]);
                    if (val == "True" || val == "False")
                    {
                        comboBoxes[i].Name = name;
                        comboBoxes[i].Items.AddRange(new object[] { "True", "False" });
                        comboBoxes[i].Text = val;
                        comboBoxes[i].Width = width;
                        panel.Controls.Add(comboBoxes[i]);
                    }
                    else
                    {
                        txtOptionValue[i].Name = name;
                        txtOptionValue[i].Text = val;
                        txtOptionValue[i].Width = width;
                        panel.Controls.Add(txtOptionValue[i]);
                    }
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    if (lastval == "True" || lastval == "False")
                    {
                        toolTips[i - 1].SetToolTip(comboBoxes[i - 1], tip);
                    }
                    else
                    {
                        toolTips[i - 1].SetToolTip(txtOptionValue[i - 1], tip);
                    }
                }
                lastval = val;
            }
            return i;
        }
        public Form1(Dictionary<string, dynamic> player)
        {
            TextBox[] txtOptionValue = new TextBox[1200];
            Label[] lbls = new Label[1200];
            ToolTip[] toolTips = new ToolTip[1200];
            ComboBox[] comboBoxes = new ComboBox[1200];

            InitializeComponent();
            for (int u = 0; u < txtOptionValue.Count(); u++)
            {
                txtOptionValue[u] = new TextBox();
                lbls[u] = new Label();
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
                lbls[i].Name = name;
                lbls[i].Text = name;
                //txt.Location = new Point(0, 32 + (i * 28));
                lbls[i].Visible = true;
                this.tableLayoutPanelChat.Controls.Add(lbls[i]);
                txtOptionValue[i].Name = Name;
                // txtTeamNames[i].Text = entry.Value;
                txtOptionValue[i].Text = player["CHAT"][name];
                txtOptionValue[i].Width = 200;
                this.tableLayoutPanelChat.Controls.Add(txtOptionValue[i]);
                i++;
            }

            string lastval = null;

            i = tab(player, "DRIVING AIDS", this.tableLayoutPanelDrivingAids, txtOptionValue, lbls, toolTips, comboBoxes, 50, i);
            i = tab(player, "Graphic Options", this.tableLayoutPanelGraphicOptions, txtOptionValue, lbls, toolTips, comboBoxes, 50, i);
            i = tab(player, "Race Conditions", this.tableLayoutPanelRaceConditions, txtOptionValue, lbls, toolTips, comboBoxes, 50, i);
            i = tab(player, "Sound Options", this.tableLayoutPanelSoundOptions, txtOptionValue, lbls, toolTips, comboBoxes, 130, i);
            /*
            foreach (var entry in player["DRIVING AIDS"])
            {
                string name = entry.Name;
                string val = entry.Value;

                if (name.Last() != '#')
                {
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].Visible = true;
                    this.tableLayoutPanelDrivingAids.Controls.Add(lbls[i]);
                    if (val == "True" || val == "False")
                    {
                        comboBoxes[i].Name = name;
                        comboBoxes[i].Items.AddRange(new object[] { "True", "False" });
                        comboBoxes[i].Text = val;
                        comboBoxes[i].Width = 50;
                        this.tableLayoutPanelDrivingAids.Controls.Add(comboBoxes[i]);
                    }
                    else
                    {
                        txtOptionValue[i].Name = name;
                        txtOptionValue[i].Text = val;
                        txtOptionValue[i].Width = 50;
                        this.panel.Controls.Add(txtOptionValue[i]);
                    }
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    if (lastval == "True" || lastval == "False")
                    {
                        toolTips[i - 1].SetToolTip(comboBoxes[i-1], tip);
                    }
                    else
                    {
                        toolTips[i - 1].SetToolTip(txtOptionValue[i-1], tip);
                    }
                }
                lastval = val;
            }

            foreach (var entry in player["Graphic Options"])
            {
                string name = entry.Name;
                if (name.Last() != '#')
                {
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].Visible = true;
                    lbls[i].AutoSize = true;
                    this.tableLayoutPanelGraphicOptions.Controls.Add(lbls[i]);
                    txtOptionValue[i].Name = Name;
                    txtOptionValue[i].Text = entry.Value;
                    txtOptionValue[i].Width = 50;
                    this.tableLayoutPanelGraphicOptions.Controls.Add(txtOptionValue[i]);
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    toolTips[i - 1].SetToolTip(txtOptionValue[i - 1], tip);
                }
            }

            foreach (var entry in player["Race Conditions"])
            {
                string name = entry.Name;
                if (name.Last() != '#')
                {
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].Visible = true;
                    lbls[i].AutoSize = true;
                    this.tableLayoutPanelRaceConditions.Controls.Add(lbls[i]);
                    txtOptionValue[i].Name = Name;
                    txtOptionValue[i].Text = entry.Value;
                    txtOptionValue[i].Width = 50;
                    this.tableLayoutPanelRaceConditions.Controls.Add(txtOptionValue[i]);
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    toolTips[i - 1].SetToolTip(txtOptionValue[i - 1], tip);
                }
            }

            foreach (var entry in player["Sound Options"])
            {
                string name = entry.Name;
                if (name.Last() != '#')
                {
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].Visible = true;
                    lbls[i].AutoSize = true;
                    this.tableLayoutPanelSoundOptions.Controls.Add(lbls[i]);
                    txtOptionValue[i].Name = Name;
                    txtOptionValue[i].Text = entry.Value;
                    txtOptionValue[i].Width = 100;
                    this.tableLayoutPanelSoundOptions.Controls.Add(txtOptionValue[i]);
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    toolTips[i - 1].SetToolTip(txtOptionValue[i - 1], tip);
                }
            }
            */
        }
    }
}
