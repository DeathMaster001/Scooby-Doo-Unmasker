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
        /* gametype
        0 - Unmasked! NTSC (G5DE78)
        1 - Unmasked! PAL (G5DP78)*/
        public static int gametype = 0;

        public static uint getHealth()
        {
            uint addr = 0x559900;

            if(gametype == 1)
            {
                addr = addr+0x1E500;
            }

            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(addr, ref buff, 4, true);

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 4, true))
            {
                DolphinAccessor.unHook();
                return BitConverter.ToUInt32(buff, 0);
            }
            return BitConverter.ToUInt32(buff, 0);
        }

        public static uint getMubber()
        {
            uint addr = 0x559908;

            if (gametype == 1)
            {
                addr = addr + 0x1E500;
            }

            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(addr, ref buff, 4, true);

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 4, true))
            {
                DolphinAccessor.unHook();
                return BitConverter.ToUInt32(buff, 0);
            }
            return BitConverter.ToUInt32(buff, 0);
        }

        public static uint getProgression()
        {
            uint addr = 0x5599CC;

            if (gametype == 1)
            {
                addr = addr + 0x1E500;
            }

            byte[] buff = new byte[4];
            DolphinAccessor.readFromRAM(addr, ref buff, 4, true);

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 4, true))
            {
                DolphinAccessor.unHook();
                return BitConverter.ToUInt32(buff, 0);
            }
            return BitConverter.ToUInt32(buff, 0);
        }

        public static uint getLevel()
        {
            uint addr = 0x5599F1;

            if (gametype == 1)
            {
                addr = addr + 0x1E500;
            }

            byte[] buff = new byte[1];
            DolphinAccessor.readFromRAM(addr, ref buff, 1, true);

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 1, true))
            {
                DolphinAccessor.unHook();
            }
            return buff[0];
        }

        public static uint setLevel()
        {
            uint addr = 0x5599F1;

            if (gametype == 1)
            {
                addr = addr + 0x1E500;
            }

            byte[] buff = new byte[1];
            DolphinAccessor.writeToRAM(addr, buff, 1, true);

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 1, true))
            {
                DolphinAccessor.unHook();
            }
            return buff[0];
        }

        public static float[] getPosition()
        {
            uint addr = 0x558854;

            if (gametype == 1)
            {
                addr = addr + 0x10F7800;
            }

            byte[] buff = new byte[4];

            if (!DolphinAccessor.readFromRAM(addr, ref buff, 4, true))
            {
                DolphinAccessor.unHook();
                return null;
            }
            uint baseaddr = BitConverter.ToUInt32(buff, 0);

            if (baseaddr == 0 || (baseaddr - 0x80000000) > 0x2000000)
                return new float[3];
            baseaddr -= 0x80000000;
            buff = new byte[12];

            if (!DolphinAccessor.readFromRAM(baseaddr + 0x30, ref buff, 12, true))
            {
                DolphinAccessor.unHook();
                return null;
            }

            float[] coordinates = new float[3];
            coordinates[0] = BitConverter.ToSingle(buff, 8);
            coordinates[1] = BitConverter.ToSingle(buff, 4);
            coordinates[2] = BitConverter.ToSingle(buff, 0);
            return coordinates;
        }
    }
}