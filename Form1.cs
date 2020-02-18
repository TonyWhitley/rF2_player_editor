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
            TextBox[] txtTeamNames = new TextBox[12]; 
            Label[] lbls = new Label[12];

            InitializeComponent();
            for (int u = 0; u < txtTeamNames.Count(); u++)
            {
                txtTeamNames[u] = new TextBox();
                lbls[u] = new Label();
            }
            
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
                this.tableLayoutPanel1.Controls.Add(lbls[i]);
                txtTeamNames[i].Name = Name;
                // txtTeamNames[i].Text = entry.Value;
                txtTeamNames[i].Text = player["CHAT"][name];
                txtTeamNames[i].Width = 200;
                this.tableLayoutPanel1.Controls.Add(txtTeamNames[i]);
                i++;
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
