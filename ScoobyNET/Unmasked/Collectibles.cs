// based on https://github.com/DeathMaster001/Scooby-Doo-Unmasked-Lua-Tool/blob/main/sdu/collectibles.lua

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using DolphinComm;
using System.Collections;

namespace ScoobyNET.Unmasked
{
	public class Collectibles
	{
		private static Dictionary<uint, uint?> levelFoodMap = new Dictionary<uint, uint?>
		{
			[2] = null,                 //"Monster Profiles",
			[3] = null,                 //"Bonus Art",
			[4] = null,                 //"Main Menu",
			[6] = 0x559986,         //"MFM 1",
			[7] = 0x559987,         //"Chinatown Hub",
			[8] = 0x559988,         //"Cookie Factory",
			[9] = 0x559989,         //"Sewers",
			[10] = 0x55998A,            //"Sewers Autoscroll/End",
			[11] = 0x55998B,            //"Temple",
			[12] = null,                    //"Warehouse/\nDragon",
			[13] = null,                //"Theme Park Hub",
			[14] = null,                    //"Haunted House",
			[15] = null,                    //"Water Park",
			[16] = null,                    //"Water Slide/End",
			[17] = null,                    //"Circus",
			[18] = null,                    //"House of Mirrors/\nGuitar Ghoul",
			[19] = 0x559993,            //"Museum Hub",
			[20] = 0x559994,            //"Dino",
			[21] = 0x559995,            //"Medieval",
			[22] = 0x559996,            //"Undersea",
			[23] = null,                    //"Planetarium/\nCaveman",
			[25] = null,                    //"MFM2",
			[26] = null,                    //"MFM3/\nPterodactyl",
			[27] = null,                    //"MFM2 Mystery Machine",
		};

		private static Dictionary<uint, string[]> foodBitMap = new Dictionary<uint, string[]>
		{
			[6] = new string[] { "?", "?", "?", "?", "Ice Cream", "Cabbage", "Chocolate Bar", "Pepper" },                   //"MFM 1",
			[7] = new string[] { "?", "?", "?", "Hub Pepper", "Shrimp", "Lobster", "Sausage", "Burger" },                   //"Chinatown Hub",
			[8] = new string[] { "?", "?", "?", "?", "Cotton Candy", "Apple", "Eggplant", "Ham" },                          //"Cookie Factory",
			[9] = new string[] { "?", "?", "?", "?", "Cheese", "Marshmallow", "Fish", "Pepperoni" },                        //"Sewers",
			[10] = new string[] { "?", "?", "?", "?", "?", "?", "Pickle", "Cabbage" },                                      //"Sewers Autoscroll/End",
			[11] = new string[] { "?", "?", "?", "?", "Chocolate", "Cheese", "Onion", "Carrot" },                           //"Temple",
			[19] = new string[] { "?", "Lobster", "Ice Cream", "Pickle", "Pepperoni", "Onion", "Ham", "Cheese" },           //"Museum Hub",
			[20] = new string[] { "?", "?", "?", "?", "Sausage", "Marshmallow", "Apple", "Chips" },                         //"Dino",
			[21] = new string[] { "?", "?", "?", "?", "Burger", "Popcorn", "Fish", "Carrot" },                              //"Medieval",
			[22] = new string[] { "?", "?", "Cotton Candy", "Cabbage", "Shrimp", "Broccoli", "Hot Pepper", "Eggplant" },    //"Undersea",
		};

		public static string getFoodTotals()
		{
			return "TODO: Collectibles.lua: getFoodTotals\n";
		}

		public static Dictionary<string, bool>getLevelFoods()
        {
			Dictionary<string, bool> levelFoods = new Dictionary<string, bool>();

			uint lvl = Memory.getLevel();
			uint? lvlFlagAddr = levelFoodMap[lvl];

			if (lvlFlagAddr.HasValue)
            {
				byte[] buff = new byte[1];
				DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

				BitArray foodFlags = new BitArray(buff);
				Helpers.reverseBits(foodFlags);

				for (int i = 0; i <= 7; i++ )
                {
					if (foodBitMap[lvl][i] != "?")
                    {
						levelFoods.Add(foodBitMap[lvl][i],  foodFlags[i]);
                    }
                }
            }


			return levelFoods;

		}

    }
}
