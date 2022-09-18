using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DolphinComm;
using System.Collections;

namespace ScoobyNET.Unmasked
{
    public class Input
    {
        private static Dictionary<string, int> gameInputs = new Dictionary<string, int>
        {
            ["A"] = 0,
            ["B"] = 0,         
            ["X"] = 0,
            ["Y"] = 0,
            ["Z"] = 0,
            ["Start"] = 0,
            ["LT"] = 0,
            ["RT"] = 0,
            ["UP"] = 0,
            ["DOWN"] = 0,
            ["LEFT"] = 0,
            ["RIGHT"] = 0,
        };

        private static Dictionary<string, int> igMappings = new Dictionary<string, int>
        {
            ["A"] = 7,
            ["B"] = 6,
            ["X"] = 5,
            ["Y"] = 4,
            ["Z"] = 11,
            ["Start"] = 3,
            ["LT"] = 9,
            ["RT"] = 10,
            ["UP"] = 12,
            ["DOWN"] = 13,
            ["LEFT"] = 15,
            ["RIGHT"] = 14,
        };

        public static Dictionary<string, int> processInputs()
        {
            byte[] buff = new byte[4];

            if (!DolphinAccessor.readFromRAM((uint)0x23380C, ref buff, 4, true))
            {
                DolphinAccessor.unHook();
            }

            BitArray inputBytes = new BitArray(buff);
            Helpers.reverseBits(inputBytes);

            foreach (var mappings in igMappings)
            {
                if (inputBytes[mappings.Value])
                {
                    gameInputs[mappings.Key] = 1;
                }
                else
                {
                    gameInputs[mappings.Key] = 0;
                }
            }

            return gameInputs;

        }

    }
}