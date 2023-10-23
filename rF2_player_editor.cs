using System;
using System.CommandLine;
using System.IO;
using System.Windows.Forms;

using CommandLine.Text;
using CommandLine;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

    internal class Config
    {
        internal string playerPath;

        internal string playerJson;

        internal string playerJsonPath;

        internal string playerJsonFilter;

        internal string rF2PlayerEditorFilterJson;

        internal Config()
        {
            playerPath =
                @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player";
            playerJson = @"player.JSON";
            playerJsonPath =
                System.IO.Path.Combine(playerPath, playerJson);
            playerJsonFilter = @"rF2PlayerEditorFilter.JSON";

            rF2PlayerEditorFilterJson =
            System.IO.Path.Combine(GetTheDataFilePath(),
                playerJsonFilter);
        }

    /// <summary> Get the path of this source file </summary>
    internal static string GetThisFilesPath(
            [System.Runtime.CompilerServices.CallerFilePath]
            string sourceFilePath = "")
        {
            return System.IO.Directory.GetParent(sourceFilePath).ToString();
        }

        /// <summary> Get the path of the exe file </summary>
        internal static string GetThisExesPath()
        {
            return System.IO.Directory.GetParent(Application.ExecutablePath)
                .ToString();
        }

        /// <summary> Get the path of the data file - the same as the exe
        /// if we're running as a program, the same as the source file if
        /// we're running under VS
        /// </summary>
        public string GetTheDataFilePath()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return GetThisFilesPath();
            }
            else
            {
                return GetThisExesPath();
            }
        }
    }

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
    #pragma warning disable IDE1006 // Naming Styles
#pragma warning disable S101 // Naming Styles
    internal static class rF2_player_editor
#pragma warning restore S101 // Naming Styles
#pragma warning restore IDE1006 // Naming Styles
    {
        public static Config cfg;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param args>The command line args.</param>
        [STAThread]
        private static void
            Main(string[] args)
        {
            cfg = ParseCommandLine(args);


            //(System.IO.FileInfo script, System.IO.FileInfo PlayerJson)
            //{
            var player = JsonFiles.ReadJsonFile(cfg.playerJsonPath);
            var playerFilter =
                JsonFiles.ReadJsonFile(cfg.rF2PlayerEditorFilterJson);
            WriteDict.writeDict = player;
            // Get Player.JSON path from the file then remove it from the dictionary
            cfg.playerJsonPath = playerFilter["Player.JSON"];
            playerFilter.Remove("Player.JSON");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            // Copy values from Player.JSON to the dict used to display entries
            JsonFiles.CopyAllValuesToFilter(ref player, ref tabs);

            Application.Run(new Form1(tabs));
        }

        internal class Options
        {
            [Option('s', "script", Required = false, HelpText = "The path to the JSON file containing edits.")]
            internal string Script { get; set; }
            [Option('j', "json", Required = false, HelpText = "The path to the JSON file to be edited.")]
            internal string Json { get; set; }
        }

        private static Config ParseCommandLine(string[] args)
        {
            var config = new Config();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (!String.IsNullOrEmpty(o.Script))
                    {
                        Console.WriteLine($"Script input enabled. Current Arguments: --script {o.Script}");
                    }
                    if (!String.IsNullOrEmpty(o.Json))
                    {
                        Console.WriteLine($"JSON file to be edited. Current Arguments: --script {o.Json}");
                        config.playerJson = o.Json;
                    }
                });
            return config;
        }

        public static void SaveChanges()
        {
            JsonFiles.WriteJsonFile(cfg.playerJsonPath, WriteDict.writeDict);
        }
    }
}