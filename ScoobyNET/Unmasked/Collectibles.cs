// based on https://github.com/DeathMaster001/Scooby-Doo-Unmasked-Lua-Tool/blob/main/sdu/collectibles.lua

using System.Collections.Generic;
using DolphinComm;
using System.Collections;

namespace ScoobyNET.Unmasked
{
	public class Collectibles
	{
        //levelFoodMap for Unmasked! NTSC
        private static Dictionary<uint, uint?> levelFoodMap = new Dictionary<uint, uint?>
		{
			[2] = null,			//"Monster Profiles",
			[3] = null,			//"Bonus Art",
			[4] = null,			//"Main Menu",
			[6] = 0x559986,		//"MFM 1",
			[7] = 0x559987,		//"Chinatown Hub",
			[8] = 0x559988,		//"Cookie Factory",
			[9] = 0x559989,		//"Sewers",
			[10] = 0x55998A,	//"Sewers Autoscroll/End",
			[11] = 0x55998B,	//"Temple",
			[12] = null,		//"Warehouse/\nDragon",
			[13] = 0x55998D,	//"Theme Park Hub",
			[14] = 0x55998E,	//"Haunted House",
			[15] = 0x55998F,	//"Water Park",
			[16] = 0x559990,	//"Water Slide/End",
			[17] = 0x559991,	//"Circus",
			[18] = null,		//"House of Mirrors/\nGuitar Ghoul",
			[19] = 0x559993,	//"Museum Hub",
			[20] = 0x559994,	//"Dino",
			[21] = 0x559995,	//"Medieval",
			[22] = 0x559996,	//"Undersea",
			[23] = null,		//"Planetarium/\nCaveman",
			[25] = null,		//"MFM2",
			[26] = null,		//"MFM3/\nPterodactyl",
			[27] = null,		//"MFM2 Mystery Machine",
		};

        //levelFoodMap for Unmasked! PAL
        private static Dictionary<uint, uint?> levelFoodMap2 = new Dictionary<uint, uint?>
        {
            [2] = null,         //"Monster Profiles",
            [3] = null,         //"Bonus Art",
            [4] = null,         //"Main Menu",
            [6] = 0x577E86,     //"MFM 1",
            [7] = 0x577E87,     //"Chinatown Hub",
            [8] = 0x577E88,     //"Cookie Factory",
            [9] = 0x577E89,     //"Sewers",
            [10] = 0x577E8A,    //"Sewers Autoscroll/End",
            [11] = 0x577E8B,    //"Temple",
            [12] = null,        //"Warehouse/\nDragon",
            [13] = 0x577E8D,    //"Theme Park Hub",
            [14] = 0x577E8E,    //"Haunted House",
            [15] = 0x577E8F,    //"Water Park",
            [16] = 0x577E90,    //"Water Slide/End",
            [17] = 0x577E91,    //"Circus",
            [18] = null,        //"House of Mirrors/\nGuitar Ghoul",
            [19] = 0x577E93,    //"Museum Hub",
            [20] = 0x577E94,    //"Dino",
            [21] = 0x577E95,    //"Medieval",
            [22] = 0x577E96,    //"Undersea",
            [23] = null,        //"Planetarium/\nCaveman",
            [25] = null,        //"MFM2",
            [26] = null,        //"MFM3/\nPterodactyl",
            [27] = null,        //"MFM2 Mystery Machine",
        };

        private static Dictionary<uint, string[]> foodBitMap = new Dictionary<uint, string[]>
		{
			[6] = new string[] { "?", "?", "?", "?", "Ice Cream", "Cabbage", "Chocolate Bar", "Pepper" },					//"MFM 1",
			[7] = new string[] { "?", "?", "?", "Hub Pepper", "Shrimp", "Lobster", "Sausage", "Burger" },					//"Chinatown Hub",
			[8] = new string[] { "?", "?", "?", "?", "Cotton Candy", "Apple", "Eggplant", "Ham" },							//"Cookie Factory",
			[9] = new string[] { "?", "?", "?", "?", "Cheese", "Marshmallows", "Fish", "Pepperoni" },						//"Sewers",
			[10] = new string[] { "?", "?", "?", "?", "?", "?", "Pickle", "Cabbage" },										//"Sewers Autoscroll/End",
			[11] = new string[] { "?", "?", "?", "?", "Chocolate", "Cheese", "Onion", "Carrot" },							//"Temple",
			[13] = new string[] { "?", "?", "Broccoli", "Pickle", "Lobster", "Sausage", "Onion", "Carrot" },                //"Theme Park Hub",
			[14] = new string[] { "?", "?", "?", "?", "Broccoli", "Chocolate Bar", "Popcorn", "Shrimp" },                   //"Haunted House",
			[15] = new string[] { "?", "?", "?", "?", "Cheese", "Cabbage", "Fish", "Cotton Candy" },                        //"Water Park",
			[16] = new string[] { "?", "?", "?", "?", "?", "?", "Ham", "Marshmallows" },                                    //"Water Slide/End",
			[17] = new string[] { "?", "?", "?", "?", "Banana", "Apple", "Pepperoni", "Eggplant" },                         //"Circus",
			[19] = new string[] { "?", "Lobster", "Ice Cream", "Pickle", "Pepperoni", "Onion", "Ham", "Cheese" },			//"Museum Hub",
			[20] = new string[] { "?", "?", "?", "?", "Sausage", "Marshmallows", "Apple", "Chips" },						//"Dino",
			[21] = new string[] { "?", "?", "?", "?", "Burger", "Popcorn", "Fish", "Carrot" },								//"Medieval",
			[22] = new string[] { "?", "?", "Cotton Candy", "Cabbage", "Shrimp", "Broccoli", "Hot Pepper", "Eggplant" },	//"Undersea",
		};

		public static Dictionary<string, bool>getLevelFoods()
        {
            Dictionary<string, bool> levelFoods = new Dictionary<string, bool>();
			uint lvl;
			uint? lvlFlagAddr;

            if (Unmasked.Memory.gametype == 0)
            {
                lvl = Memory.getLevel();
                lvlFlagAddr = levelFoodMap[lvl];

                if (lvlFlagAddr == null)
                {
                    return levelFoods;
                }

                if (lvlFlagAddr.HasValue)
                {
                    byte[] buff = new byte[1];

                    DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

                    BitArray foodFlags = new BitArray(buff);
                    Helpers.reverseBits(foodFlags);

                    for (int i = 0; i <= 7; i++)
                    {
                        if (foodBitMap[lvl][i] != "?")
                        {
                            levelFoods.Add(foodBitMap[lvl][i], foodFlags[i]);
                        }
                    }
                }
                return levelFoods;
            }
			else
			{
                lvl = Memory.getLevel();
                lvlFlagAddr = levelFoodMap2[lvl];

                if (lvlFlagAddr == null)
                {
                    return levelFoods;
                }

                if (lvlFlagAddr.HasValue)
                {
                    byte[] buff = new byte[1];

                    DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

                    BitArray foodFlags = new BitArray(buff);
                    Helpers.reverseBits(foodFlags);

                    for (int i = 0; i <= 7; i++)
                    {
                        if (foodBitMap[lvl][i] != "?")
                        {
                            levelFoods.Add(foodBitMap[lvl][i], foodFlags[i]);
                        }
                    }
                }
                return levelFoods;
            }
		}

        //levelmubberFoodMap for Unmasked! NTSC
        private static Dictionary<uint, uint?> levelmubberFoodMap = new Dictionary<uint, uint?>
		{
			[2] = null,         //"Monster Profiles",
			[3] = null,         //"Bonus Art",
			[4] = null,         //"Main Menu",
			[6] = 0x559986,     //"MFM 1",
			[7] = null,         //"Chinatown Hub",
			[8] = 0x559988,     //"Cookie Factory",
			[9] = 0x559989,     //"Sewers",
			[10] = null,        //"Sewers Autoscroll/End",
			[11] = 0x55998B,    //"Temple",
			[12] = null,        //"Warehouse/\nDragon",
			[13] = null,        //"Theme Park Hub",
			[14] = 0x55998E,    //"Haunted House",
			[15] = null,        //"Water Park",
			[16] = null,        //"Water Slide/End",
			[17] = 0x559991,    //"Circus",
			[18] = null,        //"House of Mirrors/\nGuitar Ghoul",
			[19] = null,        //"Museum Hub",
			[20] = 0x559994,    //"Dino",
			[21] = null,    //"Medieval",
			[22] = 0x559996,    //"Undersea",
		};

        //levelmubberFoodMap for Unmasked! PAL
        private static Dictionary<uint, uint?> levelmubberFoodMap2 = new Dictionary<uint, uint?>
        {
            [2] = null,         //"Monster Profiles",
            [3] = null,         //"Bonus Art",
            [4] = null,         //"Main Menu",
            [6] = 0x577E86,     //"MFM 1",
            [7] = null,         //"Chinatown Hub",
            [8] = 0x577E88,     //"Cookie Factory",
            [9] = 0x577E89,     //"Sewers",
            [10] = null,        //"Sewers Autoscroll/End",
            [11] = 0x577E8B,    //"Temple",
            [12] = null,        //"Warehouse/\nDragon",
            [13] = null,        //"Theme Park Hub",
            [14] = 0x577E8E,    //"Haunted House",
            [15] = null,        //"Water Park",
            [16] = null,        //"Water Slide/End",
            [17] = 0x577E91,    //"Circus",
            [18] = null,        //"House of Mirrors/\nGuitar Ghoul",
            [19] = null,        //"Museum Hub",
            [20] = 0x577E94,    //"Dino",
            [21] = null,    //"Medieval",
            [22] = 0x577E96,    //"Undersea",
        };

        private static Dictionary<uint, string[]> mubberBitMap = new Dictionary<uint, string[]>
		{
			[6] = new string[] { "?", "?", "?", "?", "?", "?", "75", "?" },     //"MFM 1, Chocolate Bar is 75 Mubber"
			[8] = new string[] { "?", "?", "?", "?", "?", "65", "?", "?" },     //"Cookie Factory, Apple is 65 Mubber"
			[9] = new string[] { "?", "?", "?", "?", "?", "?", "?", "120" },    //"Sewers", Pepperoni is 120 Mubber"
			[11] = new string[] { "?", "?", "?", "?", "?", "?", "?", "275" },   //"Temple", Carrot is 275 Mubber"
			[14] = new string[] { "?", "?", "?", "?", "185", "?", "?", "?" },   //"Haunted House", Broccoli is 185 Mubber"
			[17] = new string[] { "?", "?", "?", "?", "?", "?", "?", "230" },   //"Circus", Eggplant is 230 Mubber"
			[20] = new string[] { "?", "?", "?", "?", "?", "190", "?", "?" },   //"Dino", Marshmallows is 190 Mubber"
			[22] = new string[] { "?", "?", "230", "?", "?", "?", "?", "?" },   //"Undersea", Cotton Candy is 230 Mubber"
		};

		public static Dictionary<string, bool> getLevelFoodsMubber()
		{
            Dictionary<string, bool> levelmubberFoods = new Dictionary<string, bool>();
            uint lvl;
            uint? lvlFlagAddr;

			if (Unmasked.Memory.gametype == 0)
			{
				lvl = Memory.getLevel();
				lvlFlagAddr = levelmubberFoodMap[lvl];

				if (lvlFlagAddr == null)
				{
					return levelmubberFoods;
				}

				if (lvlFlagAddr.HasValue)
				{
					byte[] buff = new byte[1];

					DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

					BitArray foodmubberFlags = new BitArray(buff);
					Helpers.reverseBits(foodmubberFlags);

					for (int i = 0; i <= 7; i++)
					{
						if (mubberBitMap[lvl][i] != "?")
						{
							levelmubberFoods.Add(mubberBitMap[lvl][i], foodmubberFlags[i]);
						}
					}
				}
				return levelmubberFoods;
			}
			else
			{
                lvl = Memory.getLevel();
                lvlFlagAddr = levelmubberFoodMap2[lvl];

                if (lvlFlagAddr == null)
                {
                    return levelmubberFoods;
                }

                if (lvlFlagAddr.HasValue)
                {
                    byte[] buff = new byte[1];

                    DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

                    BitArray foodmubberFlags = new BitArray(buff);
                    Helpers.reverseBits(foodmubberFlags);

                    for (int i = 0; i <= 7; i++)
                    {
                        if (mubberBitMap[lvl][i] != "?")
                        {
                            levelmubberFoods.Add(mubberBitMap[lvl][i], foodmubberFlags[i]);
                        }
                    }
                }
                return levelmubberFoods;
            }
		}

        //levelClueMap for Unmasked! NTSC
        private static Dictionary<uint, List<uint>> levelClueMap = new Dictionary<uint, List<uint>>
		{
			[2] = null,										//"Monster Profiles",
			[3] = null,										//"Bonus Art",
			[4] = null,										//"Main Menu",
			[6] = new List<uint> { 0x55999C },				//"MFM 1",
			[7] = new List<uint> { 0x55999C },				//"Chinatown Hub",
			[8] = new List<uint> { 0x55999C },				//"Cookie Factory",
			[9] = new List<uint> { 0x55999C },				//"Sewers",
			[10] = new List<uint> { 0x55999C },				//"Sewers Autoscroll/End",
			[11] = new List<uint> { 0x55999D },				//"Temple",
			[12] = null,									//"Warehouse/\nDragon",
			[13] = new List<uint> { 0x55999D },				//"Theme Park Hub",
			[14] = new List<uint> { 0x55999D },				//"Haunted House",
			[15] = new List<uint> { 0x55999D, 0x55999E },   //"Water Park",
			[16] = null,									//"Water Slide/End",
			[17] = new List<uint> { 0x55999E },				//"Circus",
			[18] = null,									//"House of Mirrors/\nGuitar Ghoul",
			[19] = new List<uint> { 0x55999E },				//"Museum Hub",
			[20] = new List<uint> { 0x55999F },				//"Dino",
			[21] = new List<uint> { 0x5599AF, 0x5599A0 },	//"Medieval",
			[22] = new List<uint> { 0x5599A0 },				//"Undersea",
			[23] = null,									//"Planetarium/\nCaveman",
			[25] = null,									//"MFM2",
			[26] = null,									//"MFM3/\nPterodactyl",
			[27] = null,									//"MFM2 Mystery Machine",
		};

		//levelClueMap for Unmasked! PAL
        private static Dictionary<uint, List<uint>> levelClueMap2 = new Dictionary<uint, List<uint>>
        {
            [2] = null,                                     //"Monster Profiles",
            [3] = null,                                     //"Bonus Art",
            [4] = null,                                     //"Main Menu",
            [6] = new List<uint> { 0x577E9C },              //"MFM 1",
            [7] = new List<uint> { 0x577E9C },              //"Chinatown Hub",
            [8] = new List<uint> { 0x577E9C },              //"Cookie Factory",
            [9] = new List<uint> { 0x577E9C },              //"Sewers",
            [10] = new List<uint> { 0x577E9C },             //"Sewers Autoscroll/End",
            [11] = new List<uint> { 0x577E9D },             //"Temple",
            [12] = null,                                    //"Warehouse/\nDragon",
            [13] = new List<uint> { 0x577E9D },             //"Theme Park Hub",
            [14] = new List<uint> { 0x577E9D },             //"Haunted House",
            [15] = new List<uint> { 0x577E9D, 0x577E9E },   //"Water Park",
            [16] = null,                                    //"Water Slide/End",
            [17] = new List<uint> { 0x577E9E },             //"Circus",
            [18] = null,                                    //"House of Mirrors/\nGuitar Ghoul",
            [19] = new List<uint> { 0x577E9E },             //"Museum Hub",
            [20] = new List<uint> { 0x577E9F },             //"Dino",
            [21] = new List<uint> { 0x577EAF, 0x577EA0 },   //"Medieval",
            [22] = new List<uint> { 0x577EA0 },             //"Undersea",
            [23] = null,                                    //"Planetarium/\nCaveman",
            [25] = null,                                    //"MFM2",
            [26] = null,                                    //"MFM3/\nPterodactyl",
            [27] = null,                                    //"MFM2 Mystery Machine",
        };

        private static Dictionary<uint, string[]> clueBitMap = new Dictionary<uint, string[]>
		{
            [6] = new string[] { "?", "?", "?", "?", "?", "?", "Beacon", "Keycard" },														//"MFM 1",
			[7] = new string[] { "?", "?", "?", "?", "?", "Cookie", "?", "?" },																//"Chinatown Hub",
			[8] = new string[] { "?", "?", "?", "Scale", "Key", "?", "?", "?" },															//"Cookie Factory",
			[9] = new string[] { "Stone", "Weight", "?", "?", "?", "?", "?", "?" },                                                         //"Sewers",
			[10] = new string[] { "?", "?", "Bell", "?", "?", "?", "?", "?" },                                                              //"Sewers Autoscroll/End",
			[11] = new string[] { "?", "?", "?", "?", "?", "Lever", "Menu", "UV slip" },                                                    //"Temple",
			[13] = new string[] { "?", "?", "?", "?", "Ticket", "?", "?", "?" },                                                            //"Theme Park Hub",
			[14] = new string[] { "?", "Photo", "Spring", "Tape", "?", "?", "?", "?" },                                                     //"Haunted House",
			[15] = new string[] { "Album", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "Key", "Knob", "Tomato" },           //"Water Park",
			[17] = new string[] { "?", "Brochure", "Hammer", "Tennis Ball", "Music", "?", "?", "?" },                                       //"Circus",
			[19] = new string[] { "Photo", "?", "?", "?", "?", "?", "?", "?" },                                                             //"Museum Hub",
			[20] = new string[] { "?", "?", "?", "?", "Key", "Chain", "Saturn", "Bone" },                                                   //"Dino",
			[21] = new string[] { "Contract", "Shield", "Fuse", "Sword", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "?", "Armor" },  //"Medieval",
			[22] = new string[] { "?", "Glasses", "Tripod", "Guide", "Building", "Light", "Video", "?" },                                   //"Undersea",
		};

		public static Dictionary<string, bool> getLevelClues()
		{
            Dictionary<string, bool> levelClues = new Dictionary<string, bool>();
            uint lvl;
            List<uint> lvlFlagAddr;

            if (Unmasked.Memory.gametype == 0)
			{
				lvl = Memory.getLevel();
				lvlFlagAddr = levelClueMap[lvl];

				if (lvlFlagAddr == null)
				{
					return levelClues;
				}
				else
				{
					BitArray clueFlags;

					if (lvlFlagAddr.Count == 1)
					{
						byte[] buff = new byte[1];
						DolphinAccessor.readFromRAM(lvlFlagAddr[0], ref buff, 1, false);

						clueFlags = new BitArray(buff);
						Helpers.reverseBits(clueFlags);
					}
					else
					{
						byte[] buff = new byte[1];
						byte[] buff2 = new byte[2];

						DolphinAccessor.readFromRAM(lvlFlagAddr[0], ref buff, 1, false);

						buff2[0] = buff[0];
						buff = new byte[1];

						DolphinAccessor.readFromRAM(lvlFlagAddr[1], ref buff, 1, false);

						buff2[1] = buff[0];

						clueFlags = new BitArray(buff2);
						Helpers.reverseBits(clueFlags);
					}

					for (int i = 0; i <= clueFlags.Length - 1; i++)
					{
						if (clueBitMap[lvl][i] != "?")
						{
							levelClues.Add(clueBitMap[lvl][i], clueFlags[i]);
						}
					}
				}
				return levelClues;
			}
			else
			{
                lvl = Memory.getLevel();
                lvlFlagAddr = levelClueMap2[lvl];

                if (lvlFlagAddr == null)
                {
                    return levelClues;
                }
                else
                {
                    BitArray clueFlags;

                    if (lvlFlagAddr.Count == 1)
                    {
                        byte[] buff = new byte[1];
                        DolphinAccessor.readFromRAM(lvlFlagAddr[0], ref buff, 1, false);

                        clueFlags = new BitArray(buff);
                        Helpers.reverseBits(clueFlags);
                    }
                    else
                    {
                        byte[] buff = new byte[1];
                        byte[] buff2 = new byte[2];

                        DolphinAccessor.readFromRAM(lvlFlagAddr[0], ref buff, 1, false);

                        buff2[0] = buff[0];
                        buff = new byte[1];

                        DolphinAccessor.readFromRAM(lvlFlagAddr[1], ref buff, 1, false);

                        buff2[1] = buff[0];

                        clueFlags = new BitArray(buff2);
                        Helpers.reverseBits(clueFlags);
                    }

                    for (int i = 0; i <= clueFlags.Length - 1; i++)
                    {
                        if (clueBitMap[lvl][i] != "?")
                        {
                            levelClues.Add(clueBitMap[lvl][i], clueFlags[i]);
                        }
                    }
                }
                return levelClues;
            }
		}

        //levelTrapMap for Unmasked! NTSC
        private static Dictionary<uint, uint?> levelTrapMap = new Dictionary<uint, uint?>
		{
			[2] = null,         //"Monster Profiles",
			[3] = null,         //"Bonus Art",
			[4] = null,         //"Main Menu",
			[6] = null,			//"MFM 1",
			[7] = null,			//"Chinatown Hub",
			[8] = 0x5599AF,     //"Cookie Factory",
			[9] = 0x5599AF,     //"Sewers",
			[10] = null,		//"Sewers Autoscroll/End",
			[11] = 0x5599AF,    //"Temple",
			[12] = null,        //"Warehouse/\nDragon",
			[13] = null,		//"Theme Park Hub",
			[14] = 0x5599AF,    //"Haunted House",
			[15] = 0x5599AF,	//"Water Park",
			[16] = null,		//"Water Slide/End",
			[17] = 0x5599AF,    //"Circus",
			[18] = null,        //"House of Mirrors/\nGuitar Ghoul",
			[19] = null,		//"Museum Hub",
			[20] = 0x5599AF,	//"Dino",
			[21] = 0x5599AF,	//"Medieval",
			[22] = 0x5599AE,    //"Undersea",
			[23] = null,        //"Planetarium/\nCaveman",
			[25] = null,        //"MFM2",
			[26] = null,        //"MFM3/\nPterodactyl",
			[27] = null,        //"MFM2 Mystery Machine",
		};

        //levelTrapMap for Unmasked! NTSC
        private static Dictionary<uint, uint?> levelTrapMap2 = new Dictionary<uint, uint?>
        {
            [2] = null,         //"Monster Profiles",
            [3] = null,         //"Bonus Art",
            [4] = null,         //"Main Menu",
            [6] = null,         //"MFM 1",
            [7] = null,         //"Chinatown Hub",
            [8] = 0x577EAF,     //"Cookie Factory",
            [9] = 0x577EAF,     //"Sewers",
            [10] = null,        //"Sewers Autoscroll/End",
            [11] = 0x577EAF,    //"Temple",
            [12] = null,        //"Warehouse/\nDragon",
            [13] = null,        //"Theme Park Hub",
            [14] = 0x577EAF,    //"Haunted House",
            [15] = 0x577EAF,    //"Water Park",
            [16] = null,        //"Water Slide/End",
            [17] = 0x577EAF,    //"Circus",
            [18] = null,        //"House of Mirrors/\nGuitar Ghoul",
            [19] = null,        //"Museum Hub",
            [20] = 0x577EAF,    //"Dino",
            [21] = 0x577EAF,    //"Medieval",
            [22] = 0x577EAE,    //"Undersea",
            [23] = null,        //"Planetarium/\nCaveman",
            [25] = null,        //"MFM2",
            [26] = null,        //"MFM3/\nPterodactyl",
            [27] = null,        //"MFM2 Mystery Machine",
        };

        private static Dictionary<uint, string[]> trapBitMap = new Dictionary<uint, string[]>
		{
            [8] = new string[] { "?", "?", "?", "?", "?", "?", "?", "Broom" },			//"Cookie Factory",
			[9] = new string[] { "?", "?", "?", "?", "?", "?", "Gas Can", "?" },		//"Sewers",
			[11] = new string[] { "?", "?", "?", "?", "?", "Rope", "?", "?" },			//"Temple",
			[14] = new string[] { "?", "?", "?", "?", "Lantern", "?", "?", "?" },	    //"Haunted House",
			[15] = new string[] { "?", "?", "?", "Umbrella", "?", "?", "?", "?" },	    //"Water Park",
			[17] = new string[] { "?", "?", "Shovel", "?", "?", "?", "?", "?" },		//"Circus",
			[20] = new string[] { "?", "Rake", "?", "?", "?", "?", "?", "?" },			//"Dino",
			[21] = new string[] { "Garbage Can", "?", "?", "?", "?", "?", "?", "?" },	//"Medieval",
			[22] = new string[] { "?", "?", "?", "?", "?", "?", "?", "Wrench" },		//"Undersea",
		};

		public static Dictionary<string, bool> getLevelTraps()
		{
            Dictionary<string, bool> levelTraps = new Dictionary<string, bool>();
            uint lvl;
            uint? lvlFlagAddr;

			if (Unmasked.Memory.gametype == 0)
			{

				lvl = Memory.getLevel();
				lvlFlagAddr = levelTrapMap[lvl];

				if (lvlFlagAddr.HasValue)
				{
					byte[] buff = new byte[1];

					DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

					BitArray trapFlags = new BitArray(buff);
					Helpers.reverseBits(trapFlags);

					for (int i = 0; i <= 7; i++)
					{
						if (trapBitMap[lvl][i] != "?")
						{
							levelTraps.Add(trapBitMap[lvl][i], trapFlags[i]);
						}
					}
				}
				return levelTraps;
			}
			else
			{
                lvl = Memory.getLevel();
                lvlFlagAddr = levelTrapMap2[lvl];

                if (lvlFlagAddr.HasValue)
                {
                    byte[] buff = new byte[1];

                    DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

                    BitArray trapFlags = new BitArray(buff);
                    Helpers.reverseBits(trapFlags);

                    for (int i = 0; i <= 7; i++)
                    {
                        if (trapBitMap[lvl][i] != "?")
                        {
                            levelTraps.Add(trapBitMap[lvl][i], trapFlags[i]);
                        }
                    }
                }
                return levelTraps;
            }
		}

		private static Dictionary<uint, uint?> levelCostumeMap = new Dictionary<uint, uint?>
		{
			[2] = null,			//"Monster Profiles",
			[3] = null,			//"Bonus Art",
			[4] = null,			//"Main Menu",
			[6] = null,			//"MFM 1",
			[7] = 0x5599B7,		//"Chinatown Hub",
			[8] = null,			//"Cookie Factory",
			[9] = null,			//"Sewers",
			[10] = null,		//"Sewers Autoscroll/End",
			[11] = null,		//"Temple",
			[12] = null,		//"Warehouse/\nDragon",
			[13] = 0x5599B7,	//"Theme Park Hub",
			[14] = null,		//"Haunted House",
			[15] = null,		//"Water Park",
			[16] = null,		//"Water Slide/End",
			[17] = null,		//"Circus",
			[18] = null,		//"House of Mirrors/\nGuitar Ghoul",
			[19] = 0x5599B7,    //"Museum Hub",
			[20] = null,		//"Dino",
			[21] = null,		//"Medieval",
			[22] = null,		//"Undersea",
			[23] = null,		//"Planetarium/\nCaveman",
			[25] = null,		//"MFM2",
			[26] = null,		//"MFM3/\nPterodactyl",
			[27] = null,		//"MFM2 Mystery Machine",
		};

        private static Dictionary<uint, uint?> levelCostumeMap2 = new Dictionary<uint, uint?>
        {
            [2] = null,         //"Monster Profiles",
            [3] = null,         //"Bonus Art",
            [4] = null,         //"Main Menu",
            [6] = null,         //"MFM 1",
            [7] = 0x577EB7,     //"Chinatown Hub",
            [8] = null,         //"Cookie Factory",
            [9] = null,         //"Sewers",
            [10] = null,        //"Sewers Autoscroll/End",
            [11] = null,        //"Temple",
            [12] = null,        //"Warehouse/\nDragon",
            [13] = 0x577EB7,    //"Theme Park Hub",
            [14] = null,        //"Haunted House",
            [15] = null,        //"Water Park",
            [16] = null,        //"Water Slide/End",
            [17] = null,        //"Circus",
            [18] = null,        //"House of Mirrors/\nGuitar Ghoul",
            [19] = 0x577EB7,    //"Museum Hub",
            [20] = null,        //"Dino",
            [21] = null,        //"Medieval",
            [22] = null,        //"Undersea",
            [23] = null,        //"Planetarium/\nCaveman",
            [25] = null,        //"MFM2",
            [26] = null,        //"MFM3/\nPterodactyl",
            [27] = null,        //"MFM2 Mystery Machine",
        };

        private static Dictionary<uint, string[]> costumeBitMap = new Dictionary<uint, string[]>
		{
			[7] = new string[] { "?", "?", "?", "?", "Gold Kung Fu", "Silver Kung Fu", "?", "?" },  //"Chinatown Hub",
			[13] = new string[] { "?", "?", "?", "?", "?", "?", "Gold Bat", "Silver Bat" },			//"Theme Park Hub",
			[19] = new string[] { "?", "?", "Gold Archer", "Silver Archer", "?", "?", "?", "?" },	//"Museum Hub",
		};

		public static Dictionary<string, bool> getLevelCostumes()
		{
			Dictionary<string, bool> levelCostumes = new Dictionary<string, bool>();

            uint lvl;
            uint? lvlFlagAddr;

			if (Unmasked.Memory.gametype == 0)
			{
				lvl = Memory.getLevel();
				lvlFlagAddr = levelCostumeMap[lvl];

				if (lvlFlagAddr.HasValue)
				{
					byte[] buff = new byte[1];

					DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

					BitArray costumeFlags = new BitArray(buff);
					Helpers.reverseBits(costumeFlags);

					for (int i = 0; i <= 7; i++)
					{
						if (costumeBitMap[lvl][i] != "?")
						{
							levelCostumes.Add(costumeBitMap[lvl][i], costumeFlags[i]);
						}
					}
				}

				return levelCostumes;
			}
			else
            {
                lvl = Memory.getLevel();
                lvlFlagAddr = levelCostumeMap2[lvl];

                if (lvlFlagAddr.HasValue)
                {
                    byte[] buff = new byte[1];

                    DolphinAccessor.readFromRAM((uint)lvlFlagAddr, ref buff, 1, false);

                    BitArray costumeFlags = new BitArray(buff);
                    Helpers.reverseBits(costumeFlags);

                    for (int i = 0; i <= 7; i++)
                    {
                        if (costumeBitMap[lvl][i] != "?")
                        {
                            levelCostumes.Add(costumeBitMap[lvl][i], costumeFlags[i]);
                        }
                    }
                }
                return levelCostumes;
            }
        }

	}
}
