﻿using System;
using System.Windows.Forms;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

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
    public static class Config
    {
        public static string playerPath =
            @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player";

        public static string playerJson = @"player.JSON";

        public static string playerJsonPath =
            System.IO.Path.Combine(playerPath, playerJson);

        public static string playerJsonFilter = @"rF2PlayerEditorFilter.JSON";

        public static string rF2PlayerEditorFilterJson =
            System.IO.Path.Combine(GetTheDataFilePath(),
                playerJsonFilter);

        /// <summary> Get the path of this source file </summary>
        private static string GetThisFilesPath(
            [System.Runtime.CompilerServices.CallerFilePath]
            string sourceFilePath = "")
        {
            return System.IO.Directory.GetParent(sourceFilePath).ToString();
        }

        /// <summary> Get the path of the exe file </summary>
        private static string GetThisExesPath()
        {
            return System.IO.Directory.GetParent(Application.ExecutablePath)
                .ToString();
        }

        /// <summary> Get the path of the data file - the same as the exe
        /// if we're running as a program, the same as the source file if
        /// we're running under VS
        /// </summary>
        public static string GetTheDataFilePath()
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
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable S101 // Naming Styles
    internal static class rF2_player_editor
#pragma warning restore S101 // Naming Styles
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="script">The path to the JSON file containing edits.</param>
        /// <param name="PlayerJson">The Player.JSON file to be edited</param>
        [STAThread]
        private static void
            Main() //(System.IO.FileInfo script, System.IO.FileInfo PlayerJson)
        {
            var player = JsonFiles.ReadJsonFile(Config.playerJsonPath);
            var playerFilter =
                JsonFiles.ReadJsonFile(Config.rF2PlayerEditorFilterJson);
            WriteDict.writeDict = player;
            // Get Player.JSON path from the file then remove it from the dictionary
            Config.playerJsonPath = playerFilter["Player.JSON"];
            playerFilter.Remove("Player.JSON");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            // Copy values from Player.JSON to the dict used to display entries
            JsonFiles.CopyAllValuesToFilter(ref player, ref tabs);

            Application.Run(new Form1(tabs));
        }

        public static void SaveChanges()
        {
            JsonFiles.WriteJsonFile(Config.playerJsonPath, WriteDict.writeDict);
        }
    }
}