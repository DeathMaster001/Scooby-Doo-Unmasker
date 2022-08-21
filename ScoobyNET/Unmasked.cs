using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DolphinComm;

namespace ScoobyNET
{
    public class Unmasked
    {
        public static uint getHealth()
        {
            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(0x559900, ref buff, 4, false);
            Array.Reverse(buff);
            return BitConverter.ToUInt32(buff, 0);
        }
        public static uint getTotalHealth()
        {
            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(0x5598FC, ref buff, 4, false);
            Array.Reverse(buff);
            return BitConverter.ToUInt32(buff, 0);
        }
    }
}
