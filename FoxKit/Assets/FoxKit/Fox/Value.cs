using System;

namespace Fox
{
    public struct Value<T>
    {
        private T Data;

        public static explicit operator T(Value<T> d) => d.Data;
        public static explicit operator Value<T>(T d) => new Value<T> { Data = d };
    }
}

//using System;
//using System.Runtime.InteropServices;

//namespace Fox
//{
//    [StructLayout(LayoutKind.Explicit)]
//    public struct Value
//    {
//        [FieldOffset(0)]
//        public sbyte Int8;

//        [FieldOffset(0)]
//        public byte UInt8;

//        [FieldOffset(0)]
//        public short Int16;

//        [FieldOffset(0)]
//        public ushort UInt16;

//        [FieldOffset(0)]
//        public int Int32;

//        [FieldOffset(0)]
//        public uint UInt32;

//        [FieldOffset(0)]
//        public long Int64;

//        [FieldOffset(0)]
//        public ulong UInt64;

//        [FieldOffset(0)]
//        public float Float;

//        [FieldOffset(0)]
//        public double Double;

//        [FieldOffset(0)]
//        public bool Bool;

//        [FieldOffset(0)]
//        public String String;

//        [FieldOffset(0)]
//        public Path Path;

//        [FieldOffset(0)]
//        public EntityPtr EntityPtr;
//    }
//}