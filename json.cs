using System;
using System.IO;

using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace rF2_player_editor
{
    public static class JsonFiles
    {
        public static Dictionary<string, dynamic> ReadJsonFile(string filepath)
        {
            string readResult = string.Empty;
            string writeResult = string.Empty;
            JObject jobj;
            string json;
            using (StreamReader r = new StreamReader(filepath))
            {
                json = r.ReadToEnd();
                jobj = JObject.Parse(json);
                readResult = jobj.ToString();
                foreach (var item in jobj.Properties())
                {
                    item.Value = item.Value.ToString().Replace("v1", "v2");
                }
                writeResult = jobj.ToString();
                Console.WriteLine(writeResult);
            }
            Console.WriteLine(readResult);
            dynamic j = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(json);

            Dictionary<string, dynamic> player = JsonConvert.DeserializeObject <Dictionary<string, dynamic>>(json);
            return player;
        }

        public static Dictionary<string, dynamic> ParseRF2PlayerEditorFilter(
            Dictionary<string, dynamic> rF2PlayerEditorFilter)
        {
            /// <summary>
            /// Create a dict of dicts, one for each tab, from the filter file
            /// </summary>
            var tabs = new Dictionary<string, dynamic>();
            foreach (var tabName in rF2PlayerEditorFilter)
            {
                //foreach (var f in rF2PlayerEditorFilter[tabName.Key].Children())
                tabs[tabName.Key] = rF2PlayerEditorFilter[tabName.Key].ToObject<Dictionary<string, object>>();
            }
            return tabs;
        }

        public static void WriteJsonFile(string filepath)
        {
            string writeResult = string.Empty;
            File.WriteAllText(filepath, writeResult);
        }
    }
}