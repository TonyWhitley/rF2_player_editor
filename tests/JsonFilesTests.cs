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
        [TestMethod()]
        public void ReadJsonFileTest()
        {
            string playerJson = @"c:\Program Files (x86)\Steam\steamapps\common\rFactor 2\UserData\player\player.JSON";
            Dictionary<string, dynamic> player = JsonFiles.ReadJsonFile(playerJson);
            Assert.IsNotNull(player["CHAT"]);        }
        }
    }