using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace rF2_player_editor
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;
    using KVpair = System.Collections.Generic.KeyValuePair<string, dynamic>;
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
            dict tabs = new dict();
            // Throw away the prepended Player.JSON key
            rF2PlayerEditorFilter.Remove("Player.JSON");
            foreach (KVpair tabName in rF2PlayerEditorFilter)
            {
                //foreach (var f in rF2PlayerEditorFilter[tabName.Key].Children())
                tabs[tabName.Key] = rF2PlayerEditorFilter[tabName.Key].ToObject<dict>();
            }
            return tabs;
        }

        /// <summary>
        /// Tweak JSON to rF2's JSON format
        /// </summary>
        /// <param name="JsonString"></param>
        /// <returns>rF2 format JSON string</returns>
        private static string JsonToRF2(string JsonString)
        {
            JsonString = JsonString.Replace("\": ", "\":");
            JsonString = JsonString.Replace("/", "\\/");
            JsonString = JsonString.Replace("Look Up\\/Down Angle", "Look Up/Down Angle");
            JsonString = JsonString.Replace("pixel\\/seconds", "pixel/seconds");
            return JsonString;
        }
        /// <summary>
        /// Write a dict to JSON file.
        /// </summary>
        public static void WriteJsonFile(string filepath, dict dictionary)
        {
            foreach (KVpair section in dictionary)
            {
                foreach (dynamic entry in dictionary[section.Key])
                {
                    if (entry.Name.Contains(" Version"))
                    { // Version entries are strings not doubles "
                        dictionary[section.Key][entry.Name] = entry.Value;
                    }
                    else
                    {
                        dictionary[section.Key][entry.Name] = WriteDict.TextToObject(entry.Value.ToString());
                    }
                }
            }
            string JsonString = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            JsonString = JsonToRF2(JsonString);
            File.WriteAllText(filepath, JsonString);
        }

        /// <summary>
        /// Serialize object into a JSON string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>JSON string</returns>
        public static string SerializeObject(object obj)
        {
            string JsonString = JsonConvert.SerializeObject(obj, Formatting.Indented);
            JsonString = JsonToRF2(JsonString);
            return JsonString;
        }

        /// <summary>
        /// Copy the values from a dict to a another dict
        /// </summary>
        public static void CopyDictValues(ref dict from_dict, ref dict to_dict)
        {
            foreach (KVpair entry in to_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                string name = entry.Key;
                foreach (dynamic _key in to_dict[name])
                {
                    if (!_key.Name.EndsWith("#") &&  // If it's not a comment
                        from_dict[name][_key.Name] != null) // and from_dict has the key
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
            foreach (KVpair entry in to_dict) // to_dict[to_dict.Keys].ToObject<dict>())
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
            foreach (KVpair entry in from_dict) // to_dict[to_dict.Keys].ToObject<dict>())
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
            foreach (KVpair entry in from_dict) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = from_dict[entry.Key];
                CopyDictValues(ref tabDict, ref to_dict);
            }
        }
    }


    public static class WriteDict
    {
        public static dict writeDict;
        public static bool changed = false;

        /// <summary>
        /// Translate a string to an object
        /// </summary>
        /// <param name="value">int, bool, float, string</param>
        /// <returns></returns>
        public static object TextToObject(string value)
        {
            bool boolResult;
            if (bool.TryParse(value, out boolResult))
            {
                return boolResult;
            }
            long longResult;
            if (long.TryParse(value, out longResult))
            {
                return longResult;
            }
            double doubleResult;
            if (double.TryParse(value, out doubleResult))
            {
                return doubleResult;
            }
            float floatResult;
            if (float.TryParse(value, out floatResult))
            {
                return floatResult;
            }
            
            return value;
        }
        /// <summary>
        /// Write value to the key found somewhere in the dict
        /// </summary>
        /// <param name="key">key name</param>
        /// <param name="value">the text to be written</param>
        /// <returns></returns>
        public static bool WriteValue(string key, string value)
        {
            foreach (System.Collections.Generic.KeyValuePair<string, dynamic> tabData in writeDict) // HACKERY!!!
            {
                string group = tabData.Key;
                dict fred = tabData.Value.ToObject<dict>();
                if (fred.ContainsKey(key))
                {
                    writeDict[group][key] = value;
                    changed = true;
                    return true;
                }
            }
            return false; // didn't find the key
        }
    }

    /// <summary>
    /// Class to handle text! Nothing to do with JSON but there's only one method...
    /// </summary>
    public static class TextUtils
    {
        /// <summary>
        /// Put \n into 'text' if it goes over 'width' chars
        /// </summary>
        /// <param name="text">String to be wrapped</param>
        /// <param name="width">Max width of resulting text</param>
        public static string WrapText(string text, int width)
        {
            string[] originalWords = text.Split(new string[] { " " },
                StringSplitOptions.None);
            StringBuilder result = new StringBuilder();
            int lineWidth = 0;

            foreach (string word in originalWords)
            {
                result.Append(word + " ");
                lineWidth += word.Length + 1;

                if (lineWidth > width)
                {
                    result.Append("\n");
                    lineWidth = 0;
                }
            }
            return result.ToString();
        }
    }
}