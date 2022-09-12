using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DolphinComm;

namespace ScoobyNET.Unmasked
{
    public class Memory
    {
        public static uint getHealth()
        {
            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(0x559900, ref buff, 4, true);
            return BitConverter.ToUInt32(buff, 0);
        }

        public static uint getMubber()
        {
            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(0x559908, ref buff, 4, true);
            return BitConverter.ToUInt32(buff, 0);
        }

        public static uint getLevel()
        {
            byte[] buff = new byte[1];
            DolphinAccessor.readFromRAM(0x5599F1, ref buff, 1, true);
            return buff[0];
        }

        public static float[] getPosition()
        {
            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(0x558854, ref buff, 4, true);
            uint baseaddr = BitConverter.ToUInt32(buff, 0);

            if(baseaddr == 0)
                return new float[3];

            baseaddr -= 0x80000000;
            buff = new byte[12];

            DolphinAccessor.readFromRAM(baseaddr + 0x30, ref buff, 12, true);

            float[] coordinates = new float[3];
            coordinates[0] = BitConverter.ToSingle(buff, 8);
            coordinates[1] = BitConverter.ToSingle(buff, 4);
            coordinates[2] = BitConverter.ToSingle(buff, 0);

            return coordinates;
        }

    }
}
