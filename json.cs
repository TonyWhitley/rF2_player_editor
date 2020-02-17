using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApp1
{
    static class PrormaSC
    {
        static string filepath = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        public static JObject ReadJsonFile()
        {
            string readResult = string.Empty;
            string writeResult = string.Empty;
            JObject jobj;
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
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
            return jobj;
        }
        public static void WriteJsonFile()
        {
            string writeResult = string.Empty;
            File.WriteAllText(filepath, writeResult);
        }
    }
}