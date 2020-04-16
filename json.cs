using System;
using System.IO;

using Newtonsoft.Json;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;
    /// <summary>
    /// Class to handle JSON files!
    /// </summary>
    public static class JsonFiles
    {
        /// <summary>
        /// Read a JSON file, return a dict
        /// </summary>
        public static dict ReadJsonFile(string filepath)
        {
            string json;
            using (StreamReader r = new StreamReader(filepath))
            {
                json = r.ReadToEnd();
            }

            dict player = JsonConvert.DeserializeObject<dict>(json);
            return player;
        }

        /// <summary>
        /// Create a dict of dicts, one for each tab, from the filter file
        /// </summary>
        public static dict ParseRF2PlayerEditorFilter(
            dict rF2PlayerEditorFilter)
        {
            var tabs = new dict();
            foreach (var tabName in rF2PlayerEditorFilter)
            {
                //foreach (var f in rF2PlayerEditorFilter[tabName.Key].Children())
                tabs[tabName.Key] = rF2PlayerEditorFilter[tabName.Key].ToObject<dict>();
            }
            return tabs;
        }

        /// <summary>
        /// Write a dict to JSON file.
        /// </summary>
        public static void WriteJsonFile(string filepath)
        {
            string writeResult = string.Empty;
            File.WriteAllText(filepath, writeResult);
        }

        /// <summary>
        /// Copy the values from a dict to a another dict
        /// </summary>
        public static void CopyDictValues(ref dict from_dict, ref dict to_dict)
        {
            foreach (var entry in to_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                string name = entry.Key;
                foreach (var _key in to_dict[name])
                {
                    if (from_dict[name][_key.Name] != null) // If from_dict has the key
                    {
                        to_dict[name][_key.Name] = from_dict[name][_key.Name];
                    }
                }

            }
        }

        /// <summary>
        /// Copy the values from a dict to this program's filter dict
        /// </summary>
        public static void CopyAllValuesToFilter(ref dict from_dict, ref dict to_dict)
        {
            foreach (var entry in to_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = to_dict[entry.Key];
                CopyDictValues(ref from_dict, ref tabDict);
            }
        }

        /// <summary>
        /// Copy the values from this program's filter dict to a another dict
        /// </summary>
        public static void CopyAllValuesFromFilter(ref dict from_dict, ref dict to_dict)
        {
            foreach (var entry in from_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = from_dict[entry.Key];
                CopyDictValues(ref tabDict, ref to_dict);
            }
        }

        /// <summary>
        /// Copy the values from a tab's dict to the Player dict
        /// </summary>
        public static void CopyAllValuesFromTab(ref dict from_dict, ref dict to_dict)
        {
            foreach (var entry in from_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = from_dict[entry.Key];
                CopyDictValues(ref tabDict, ref to_dict);
            }
        }
    }
}