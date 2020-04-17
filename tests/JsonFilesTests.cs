using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace rF2_player_editor.Tests
{
    using dict = System.Collections.Generic.Dictionary<string, dynamic>;

    [TestClass()]
    public class JsonFilesTests
    {
        readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        public void ReadPlayerJsonFileTest()
        {
            dict player = JsonFiles.ReadJsonFile(playerJson);
            Assert.IsNotNull(player["CHAT"]);
        }
        [TestMethod()]
        public void ReadrF2PlayerEditorFilterJsonFileTest()
        {
            dict player = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Assert.IsNotNull(player["Chat"]);
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

        readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
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