using System;
using System.Windows.Forms;

namespace rF2_player_editor
/// <summary>
/// This is an editor for rFactor 2's Player.json file.
/// It uses a second file rF2PlayerEditorFilter.json which can be modified
/// to change
/// a) Which keys are displayed
/// b) What tooltips are shown for each key
/// The values of the displayed keys are fetched from Player.json and
/// any changed values are written back there.
/// </summary>
/// <remarks>
/// ...how it does it...
/// 1) Read the JSON files into dicts player and filter
/// 2) Load values from player into keys in filter
/// 3) Split filter into a dict for each tab in the display
///     CHAT
///     DRIVING AIDS
///     Graphic Options
///         Detail levels   these breakdowns should be in rF2PlayerEditorFilter.json
///         Angles and sizes
///         Views
///     Race Conditions
///         General
///         CRNT
///         CHAMP
///         GPRIX
///         MULTI
///         RPLAY
///     Sound Options
/// </remarks>

{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;
#pragma warning disable IDE1006 // Naming Styles
    static class rF2_player_editor
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
            string rF2PlayerEditorFilterJson = "../../../rF2PlayerEditorFilter.JSON";
            //dynamic jobj = PrormaSC.ReadJsonFile();
            dict player = JsonFiles.ReadJsonFile(playerJson);
            dict playerFilter = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            dict tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            // Copy values from Player.JSON to the dict used to display entries
            JsonFiles.CopyAllValuesToFilter(ref player, ref tabs);

            Application.Run(new Form1(tabs));

        }
    }
}

