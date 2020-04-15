using Microsoft.VisualStudio.TestTools.UnitTesting;
using rF2_player_editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rF2_player_editor.Tests
{
    [TestClass()]
    public class JsonFilesTests
    {
        readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        public void ReadPlayerJsonFileTest()
        {
            Dictionary<string, dynamic> player = JsonFiles.ReadJsonFile(playerJson);
            Assert.IsNotNull(player["CHAT"]);
        }
        [TestMethod()]
        public void ReadrF2PlayerEditorFilterJsonFileTest()
        {
            Dictionary<string, dynamic> player = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Assert.IsNotNull(player["Chat"]);
        }
    }
    [TestClass()]
    public class DictTests
    {
        private Dictionary<string, dynamic> _getRF2PlayerEditorFilterTabsFromJsonFile()
        {
            /// <summary> Read the filter JSON file and split it </summary>
            Dictionary<string, dynamic> playerFilter = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Dictionary<string, dynamic> tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            return tabs;
        }

        readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        public void SplitRF2PlayerEditorFilterJsonFileTest()
        {
            /// <summary> Read the filter JSON file and split it. Check the first tab exists </summary>
            Dictionary<string, dynamic> tabs = _getRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);
        }
        [TestMethod()]
        public void SplitTabsTest()
        {
            /// <summary> Split the filter file into tabs and check the contents of the first tab </summary>
            Dictionary<string, dynamic> tabs = _getRF2PlayerEditorFilterTabsFromJsonFile();
            Assert.IsNotNull(tabs["Chat"]);

            Dictionary<string, dynamic> tab = tabs["Chat"];
            Assert.IsNotNull(tab["CHAT"]);
        }
    }
}