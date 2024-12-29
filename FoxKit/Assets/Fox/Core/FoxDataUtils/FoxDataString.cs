using Fox;
using System;
using System.Runtime.InteropServices;

namespace Fox.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct FoxDataString
    {
        public StrCode32 Hash;
        public uint StringOffset;

        private FoxDataString* GetSelfPointer()
        {
            fixed (FoxDataString* selfPtr = &this)
            {
                return selfPtr;
            }
        }

        public String ReadStringFromRelativeOffset()
        {
            if (StringOffset == 0)
                return null;

            var intPtr = new IntPtr((byte*)GetSelfPointer() + StringOffset);
            return new String(Marshal.PtrToStringAnsi(intPtr));
        }
    }
}