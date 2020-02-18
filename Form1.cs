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
        public Form1(Dictionary<string, dynamic> player)
        {
            TextBox[] txtOptionValue = new TextBox[1200]; 
            Label[] lbls = new Label[1200];
            ToolTip[] toolTips = new ToolTip[1200];

            InitializeComponent();
            for (int u = 0; u < txtOptionValue.Count(); u++)
            {
                txtOptionValue[u] = new TextBox();
                lbls[u] = new Label();
                toolTips[u] = new ToolTip();
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

            foreach (var entry in player["DRIVING AIDS"])
            {
                string name = entry.Name;
                if (name.Last() != '#')
                {
                    lbls[i].Name = name;
                    toolTips[i].SetToolTip(lbls[i], name);
                    lbls[i].Text = name;
                    lbls[i].Visible = true;
                    this.tableLayoutPanelDrivingAids.Controls.Add(lbls[i]);
                    txtOptionValue[i].Name = Name;
                    txtOptionValue[i].Text = entry.Value;
                    txtOptionValue[i].Width = 50;
                    this.tableLayoutPanelDrivingAids.Controls.Add(txtOptionValue[i]);
                    i++;
                }
                else
                {
                    string tip = entry.Value;
                    toolTips[i - 1].SetToolTip(txtOptionValue[i - 1], tip);
                }
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

            
            //this.textBox1.Text = "Hello";
            /*this.textBox1.Text = player["CHAT"]["Quick Chat #1"];
            this.textBox2.Text = player["CHAT"]["Quick Chat #2"];
            this.textBox3.Text = player["CHAT"]["Quick Chat #3"];*/



            /*var chat = jobj.SelectToken("CHAT").Children();
            var chat1 = chat[0]["['Quick Chat #1']"];
            var CHAT = jobj.CHAT;
            // UGLY!!!!!
            foreach (var chatt in CHAT)
            {
                var chattn = chatt.Name;
                var chattv = chatt.Value;
                if (chattn == "Quick Chat #1")
                {
                    this.textBox1.Text = chattv;
                }
                if (chattn == "Quick Chat #2")
                {
                    this.textBox2.Text = chattv;
                }
                if (chattn == "Quick Chat #3")
                {
                    this.textBox3.Text = chattv;
                }

            }
            */

        }
    }
}
