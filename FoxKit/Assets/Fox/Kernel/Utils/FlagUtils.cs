using System;

namespace Fox.Kernel
{
    public static class FlagUtils
    {
        public static bool GetFlag(uint flags, int index)
        {
            return ((flags >> index) & 1) == 1;
        }

        public static uint SetFlag(uint flags, int index, bool value)
        {
            unsafe
            {
                return flags ^ (uint)((-((int)*(byte*)&value) ^ flags) & (1u << index));
            }
        }
    }
}