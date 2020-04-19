using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace rF2_player_editor.Tests
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

    [TestClass()]
    public class JsonFilesTests
    {
        private readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        private readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        /// <summary>Read Player.JSON</summary>
        public void ReadPlayerJsonFileTest()
        {
            dict player = JsonFiles.ReadJsonFile(playerJson);
            Assert.IsNotNull(player["CHAT"]);
        }
        [TestMethod()]
        ///<summary>Read the config file</summary>
        public void ReadrF2PlayerEditorFilterJsonFileTest()
        {
            dict player = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Assert.IsNotNull(player["Chat"]);
        }
        [TestMethod()]
        ///<summary>
        ///Text to JSON test
        ///Convert text back to an object, serialize the object, check that the
        ///format is as expected
        ///</summary>
        public void TextToJsonTest()
        {
            string key;
            string value;
            string testString;
            object JsonObj;
            dict testDict = new dict { };

            key = "Quick Chat #10";
            value = "true";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual(true, JsonObj);
            testDict[key] = JsonObj;
            testString = JsonFiles.SerializeObject(testDict);
            Assert.AreEqual("{\r\n  \"Quick Chat #10\":true\r\n}", testString);
            testDict.Remove(key);

            key = "Antilock Brakes";
            value = "0";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual((long)0, JsonObj);
            testDict[key] = JsonObj;
            testString = JsonFiles.SerializeObject(testDict);
            Assert.AreEqual("{\r\n  \"Antilock Brakes\":0\r\n}", testString);
            testDict.Remove(key);

            value = "Some text";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual(value, JsonObj);

            key = "Quick Chat #10";
            value = "/vote yes";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual(value, JsonObj);
            testDict[key] = JsonObj;
            testString = JsonFiles.SerializeObject(testDict);
            Assert.AreEqual("{\r\n  \"Quick Chat #10\":\"\\/vote yes\"\r\n}", testString);
            testDict.Remove(key);

            key = "Look Up/Down Angle";
            value = "0";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual((long)0, JsonObj);
            testDict[key] = JsonObj;
            testString = JsonFiles.SerializeObject(testDict);
            Assert.AreEqual("{\r\n  \"Look Up/Down Angle\":0\r\n}", testString);
            testDict.Remove(key);


            key = "pixel/seconds";
            value = "550";
            JsonObj = WriteDict.TextToObject(value);
            Assert.AreEqual((long)550, JsonObj);
            testDict[key] = JsonObj;
            testString = JsonFiles.SerializeObject(testDict);
            Assert.AreEqual("{\r\n  \"pixel/seconds\":550\r\n}", testString);
            testDict.Remove(key);
        }
    }
    [TestClass()]
    public class DictTests
    {
        private dict GetRF2PlayerEditorFilterTabsFromJsonFile()
        {
            /// <summary> Read the filter JSON file and split it </summary>
            dict playerFilter = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            dict tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            return tabs;
        }

        private readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        private readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        public void SplitRF2PlayerEditorFilterJsonFileTest()
        {
            /// <summary> Read the filter JSON file and split it. Check the first tab exists </summary>
            dict tabs = GetRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);
        }
        [TestMethod()]
        public void SplitTabsTest()
        {
            /// <summary> Split the filter file into tabs and check the contents of the first tab </summary>
            dict tabs = GetRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);

            dict tab = tabs["Chat"];
            Assert.IsNotNull(tab["CHAT"]);
        }
        [TestMethod()]
        public void DictCopyTest()
        {
            /// <summary> Copy the values from one dict into the same keys of another </summary>
            dict player = JsonFiles.ReadJsonFile(playerJson);
            dict tabs = GetRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);
            tabs["Chat"]["CHAT"]["Quick Chat #1"] = ""; // Delete the string
            dict tabChat = tabs["Chat"];
            JsonFiles.CopyDictValues(ref player, ref tabChat);
            string res = tabChat["CHAT"]["Quick Chat #1"];
            Assert.AreEqual("Slowing to pit", res);
        }
        [TestMethod()]
        public void JsonCopyTest()
        {
            /// <summary> Copy the values from Player.JSON into the same keys of
            /// of rF2PlayerEditorFilter.JSON </summary>
            dict player = JsonFiles.ReadJsonFile(playerJson);
            dict tabs = GetRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);
            string res = tabs["Chat"]["CHAT"]["Quick Chat #1"];
            Assert.AreEqual("", res);
            JsonFiles.CopyAllValuesToFilter(ref player, ref tabs);
            res = tabs["Chat"]["CHAT"]["Quick Chat #1"];
            Assert.AreEqual("Slowing to pit", res);
        }
        [TestMethod()]
        public void WriteFailTest()
        {
            dict tabs = JsonFiles.ReadJsonFile(playerJson);
            WriteDict.writeDict = tabs;
            bool ret = WriteDict.WriteValue("HELLO", "WORLD");
            Assert.IsFalse(ret);
        }
        [TestMethod()]
        public void WriteSucceedTest()
        {
            dict tabs = JsonFiles.ReadJsonFile(playerJson);
            WriteDict.writeDict = tabs;
            bool ret = WriteDict.WriteValue("Quick Chat #1", "Please pass");
            Assert.IsTrue(ret);
        }
    }
    [TestClass()]
    public class StringTests
    {
        [TestMethod()]
        public void WrapTest()
        {
            string input = "Details and visible vehicles will be automatically reduced (by up to half) if framerate is under this threshold (0 to disable)";
            string wrapped = TextUtils.WrapText(input, 40);
            Assert.AreEqual("Details and visible vehicles will be automatically \nreduced (by up to half) if framerate is under \nthis threshold (0 to disable) ", wrapped);
        }
    }
}