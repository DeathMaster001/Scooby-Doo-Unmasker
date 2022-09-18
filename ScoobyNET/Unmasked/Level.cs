//based on https://github.com/DeathMaster001/Scooby-Doo-Unmasked-Lua-Tool/blob/main/sdu/level.lua

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DolphinComm;

namespace ScoobyNET.Unmasked
{
    public class Level
    {
        private static Dictionary<uint, string> levelLookup= new Dictionary<uint, string>
		{
			[2] = "Monster Profiles",
			[3] = "Bonus Art",
			[4] = "Main Menu",
			[6] = "MFM 1",
			[7] = "Chinatown Hub",
			[8] = "Cookie Factory",
			[9] = "Sewers",
			[10] = "Sewers Autoscroll/End",
			[11] = "Temple",
			[12] = "Warehouse - Dragon",
			[13] = "Theme Park Hub",
			[14] = "Haunted House",
			[15] = "Water Park",
			[16] = "Water Slide/End",
			[17] = "Circus",
			[18] = "House of Mirrors - Guitar Ghoul",
			[19] = "Museum Hub",
			[20] = "Dino",
			[21] = "Medieval",
			[22] = "Undersea",
			[23] = "Planetarium - Caveman",
			[25] = "MFM2",
			[26] = "MFM3 - Pterodactyl",
			[27] = "MFM2 Mystery Machine"
		};

		public static string getLevelName()
        {
            if (levelLookup.TryGetValue(Memory.getLevel(), out string value))
            {
				return value;
			}
            else
            {
				DolphinAccessor.unHook();
				return "";
            }
		}
    }
}
