using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScoobyNET.UI
{
    public static class Data
    {
        [StructLayout(LayoutKind.Sequential)]
        public class Margins
        {
            public int Left, Right, Top, Bottom;
        }
    }
}
