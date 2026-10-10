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

        public string ReadStringFromRelativeOffset()
        {
            if (StringOffset == 0)
                return null;

            var intPtr = new IntPtr((byte*)GetSelfPointer() + StringOffset);
            return Marshal.PtrToStringAnsi(intPtr);
        }
    }
}