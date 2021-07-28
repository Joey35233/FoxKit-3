using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxKit.Utils
{
    public static class EndianessBitConverter
    {
        private static byte[] Reverse(byte[] b)
        {
            Array.Reverse(b);
            return b;
        }

        public static int FlipEndianess(int value)
        {
            return BitConverter.ToInt32(Reverse(BitConverter.GetBytes(value)), 0);
        }
    }
}
