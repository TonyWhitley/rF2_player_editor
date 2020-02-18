using System;
using System.IO;

using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    static class PrormaSC
    {
        static string filepath = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        public static Dictionary<string, dynamic> ReadJsonFile()
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
        public static void WriteJsonFile()
        {
            string writeResult = string.Empty;
            File.WriteAllText(filepath, writeResult);
        }
    }
}