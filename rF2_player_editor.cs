using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace rF2_player_editor
{
    static class rF2_player_editor
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
            string rF2PlayerEditorFilterJson = "rF2PlayerEditorFilter.JSON";
            //dynamic jobj = PrormaSC.ReadJsonFile();
            Dictionary<string, dynamic> player = JsonFiles.ReadJsonFile(playerJson);
            //Dictionary<string, dynamic> filter = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(player));

        }
    }
}

#if fred
private void Button1_Click(System.Object sender, System.EventArgs e)
{
    SendKeys.Send("Hello world");
}
#endif