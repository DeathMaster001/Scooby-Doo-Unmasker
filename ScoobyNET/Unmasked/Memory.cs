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

        public static uint setMubber()
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

        public static bool AllBytesEqualSafe(byte[] data)
        {
            if (data == null || data.Length <= 1)
                return true;

            byte first = data[0];
            foreach (byte b in data)
            {
                if (b != first)
                    return false;
            }
            return true;
        }

        public static float[] getObjectPosition(uint address)
        {
            // Starting at X address
            uint virtualAddress = address;
            uint emuAddress = virtualAddress - 0x80000000;

            byte[] buff = new byte[12];

            if (!DolphinAccessor.readFromRAM(emuAddress, ref buff, 12, true))
            {
                DolphinAccessor.unHook();
                return null;
            }

            if (AllBytesEqualSafe(buff))
            {
                return new float[3];
            }

            float[] coordinates = new float[3];
            coordinates[0] = BitConverter.ToSingle(buff, 8);
            coordinates[1] = BitConverter.ToSingle(buff, 4);
            coordinates[2] = BitConverter.ToSingle(buff, 0);
            return coordinates;
        }

        private static byte[] GetBigEndianBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes); // Convert to big-endian
            return bytes;
        }



        public static bool setObjectPosition(uint address, float x, float y, float z)
        {
            uint virtualAddress = address;
            uint emuAddress = virtualAddress - 0x80000000;

            byte[] buff = new byte[12];

            Array.Copy(GetBigEndianBytes(x), 0, buff, 0, 4);
            Array.Copy(GetBigEndianBytes(y), 0, buff, 4, 4);
            Array.Copy(GetBigEndianBytes(z), 0, buff, 8, 4);

            return DolphinAccessor.writeToRAM(emuAddress, buff, 12, true);
        }

    }
}