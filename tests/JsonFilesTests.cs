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
            Assert.IsNotNull(player["CHAT"]);
        }
    }
    [TestClass()]
    public class DictTests
    {
        readonly string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
        readonly string rF2PlayerEditorFilterJson = "../../rF2PlayerEditorFilter.JSON";
        [TestMethod()]
        public void SplitRF2PlayerEditorFilterJsonFileTest()
        {
            Dictionary<string, dynamic> playerFilter = JsonFiles.ReadJsonFile(rF2PlayerEditorFilterJson);
            Dictionary<string, dynamic> tabs = JsonFiles.ParseRF2PlayerEditorFilter(playerFilter);
            Assert.IsNotNull(tabs["Chat"]);
        }
    }
}