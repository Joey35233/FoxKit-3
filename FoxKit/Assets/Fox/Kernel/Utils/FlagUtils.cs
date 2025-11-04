namespace Fox
{
    public static class FlagUtils
    {
        public static bool GetFlag(uint flags, int index) => ((flags >> index) & 1) == 1;

        public static uint SetFlag(uint flags, int index, bool value)
        {
            unsafe
            {
                return flags ^ (uint)((-*(byte*)&value ^ flags) & (1u << index));
            }
        }
    }
}