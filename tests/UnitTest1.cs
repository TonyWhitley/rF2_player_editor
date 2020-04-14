using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rF2_player_editor;

// redundant

namespace tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [Ignore]
        public void TestMethodReadPlayerJson()
        {
            string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
            //Dictionary<string, string> player = null;
            string cd = Directory.GetCurrentDirectory();
            Dictionary<string, dynamic> player = JsonFiles.ReadJsonFile(playerJson);
            //Assert.IsNull(player);
            Assert.IsNotNull(player["CHAT"]);
        }
    }
}
