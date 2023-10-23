using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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
            using (var r = new StreamReader(filepath))
            {
                json = r.ReadToEnd();
            }

            var player = JsonConvert.DeserializeObject<dict>(json);
            return player;
        }

        /// <summary>
        /// Create a dict of dicts, one for each tab, from the filter file
        /// </summary>
        public static dict ParseRF2PlayerEditorFilter(
            dict rF2PlayerEditorFilter)
        {
            var tabs = new dict();
            // Throw away the prepended Player.JSON key
            rF2PlayerEditorFilter.Remove("Player.JSON");
            foreach (var tabName in rF2PlayerEditorFilter)
            {
                //foreach (var f in rF2PlayerEditorFilter[tabName.Key].Children())
                tabs[tabName.Key] = rF2PlayerEditorFilter[tabName.Key]
                    .ToObject<dict>();
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
            JsonString = JsonString.Replace("Look Up\\/Down Angle",
                "Look Up/Down Angle");
            JsonString = JsonString.Replace("pixel\\/seconds", "pixel/seconds");
            return JsonString;
        }

        /// <summary>
        /// Write a dict to JSON file.
        /// </summary>
        public static void WriteJsonFile(string filepath, dict dictionary)
        {
            foreach (var section in dictionary)
            {
                foreach (var entry in dictionary[section.Key])
                {
                    if (entry.Name.Contains(" Version"))
                    {
                        // Version entries are strings not doubles "
                        dictionary[section.Key][entry.Name] = entry.Value;
                    }
                    else
                    {
                        dictionary[section.Key][entry.Name] =
                            WriteDict.TextToObject(entry.Value.ToString());
                    }
                }
            }

            var jsonString =
                JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            jsonString = JsonToRF2(jsonString);
            File.WriteAllText(filepath, jsonString);
        }

        /// <summary>
        /// Serialize object into a JSON string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>JSON string</returns>
        public static string SerializeObject(object obj)
        {
            var jsonString =
                JsonConvert.SerializeObject(obj, Formatting.Indented);
            jsonString = JsonToRF2(jsonString);
            return jsonString;
        }

        /// <summary>
        /// Copy the values from a dict to a another dict
        /// </summary>
        public static void CopyDictValues(ref dict fromDict, ref dict toDict)
        {
            foreach (var entry in toDict
            ) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                var name = entry.Key;
                foreach (var key in toDict[name])
                {
                    if (!key.Name.EndsWith("#") && // If it's not a comment
                        fromDict[name][key.Name] != null
                    ) // and from_dict has the key
                    {
                        toDict[name][key.Name] = fromDict[name][key.Name];
                    }
                }
            }
        }

        /// <summary>
        /// Copy the values from a dict to this program's filter dict
        /// </summary>
        public static void CopyAllValuesToFilter(ref dict fromDict,
            ref dict toDict)
        {
            foreach (var entry in toDict
            ) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = toDict[entry.Key];
                CopyDictValues(ref fromDict, ref tabDict);
            }
        }

        /// <summary>
        /// Copy the values from this program's filter dict to a another dict
        /// </summary>
        public static void CopyAllValuesFromFilter(ref dict fromDict,
            ref dict toDict)
        {
            foreach (var entry in fromDict
            ) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = fromDict[entry.Key];
                CopyDictValues(ref tabDict, ref toDict);
            }
        }

        /// <summary>
        /// Copy the values from a tab's dict to the Player dict
        /// </summary>
        public static void CopyAllValuesFromTab(ref dict fromDict,
            ref dict toDict)
        {
            foreach (var entry in fromDict
            ) // to_dict[to_dict.Keys].ToObject<dict>())
            {
                dict tabDict = fromDict[entry.Key];
                CopyDictValues(ref tabDict, ref toDict);
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
            if (bool.TryParse(value, out var boolResult))
            {
                return boolResult;
            }

            if (long.TryParse(value, out var longResult))
            {
                return longResult;
            }

            if (double.TryParse(value, out var doubleResult))
            {
                return doubleResult;
            }

            if (float.TryParse(value, out var floatResult))
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
            foreach (var tabData in writeDict) // HACKERY!!!
            {
                var group = tabData.Key;
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

        /// <summary>
        /// We have two dictionaries, dict1 and dict2, both of type <string, dynamic>. 
        /// The GetDictionaryDifference method takes these dictionaries as 
        /// input and returns a new dictionary, diff, that contains the differences
        /// between the two dictionaries.

        /// The AreValuesEqual method is introduced to perform dynamic comparison
        /// of the values. It uses the equality operator (==) to compare the 
        /// values.
        /// </summary>
        /// <param name="dict1"></param>
        /// <param name="dict2"></param>
        /// <returns>the differences between the two dictionaries.</returns>
        public static Dictionary<string, dynamic> GetDictionaryDifference(Dictionary<string, dynamic> dict1, Dictionary<string, dynamic> dict2)
    {
        // Create a new dictionary to store the differences
            Dictionary<string, dynamic> diff = new Dictionary<string, dynamic>();

        // Iterate over the keys in dict1
            foreach (var kvp in dict1)
            {
                string key = kvp.Key;
                dynamic value1 = kvp.Value;

                // Check if dict2 contains the key
                if (dict2.TryGetValue(key, out dynamic value2))
                {
                    // The key exists in both dictionaries, compare the values
                    if (!AreValuesEqual(value1, value2))
                    {
                        // Values are different, add to the diff dictionary
                        diff.Add(key, value2);
                    }
                }
                else
                {
                    // The key doesn't exist in dict2, add to the diff dictionary
                    diff.Add(key, value1);
                }
            }

            // Check for keys in dict2 that don't exist in dict1
            foreach (var kvp in dict2)
            {
                string key = kvp.Key;

                if (!dict1.ContainsKey(key))
                {
                    // The key doesn't exist in dict1, add to the diff dictionary
                    diff.Add(key, kvp.Value);
                }
            }

            return diff;
        }

        static bool AreValuesEqual(dynamic value1, dynamic value2)
        {
            // Compare the values using dynamic comparison
            return value1 == value2;
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
            var originalWords = text.Split(new string[] {" "},
                StringSplitOptions.None);
            var result = new StringBuilder();
            var lineWidth = 0;

            foreach (var word in originalWords)
            {
                /*if (lineWidth != 0 && word.Contains("="))
                {
                    result.Append("\n");
                    lineWidth = 0;
                }*/
                result.Append(word + " ");
                lineWidth += word.Length + 1;

                if (lineWidth > width ||
                    (word.EndsWith(",")))
                {
                    result.Append("\n");
                    lineWidth = 0;
                }
            }

            return result.ToString();
        }
    }
}