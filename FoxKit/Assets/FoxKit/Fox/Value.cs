using Fox.Core;
using System;
using UnityEngine;

namespace Fox
{
    public class Value
    {
        private object value;

        public Value(sbyte v)
        {
            this.value = v;
        }

        public Value(IEntityPtr entity)
        {
            this.value = entity;
        }

        public Value(FilePtr<File> filePtr)
        {
            this.value = filePtr;
        }

        public Value(Color color)
        {
            this.value = color;
        }

        public Value(Matrix4x4 matrix4x4)
        {
            this.value = matrix4x4;
        }

        public Value(Quaternion quaternion)
        {
            this.value = quaternion;
        }

        public Value(Vector3 vector3)
        {
            this.value = vector3;
        }
        public Value(Vector4 vector3)
        {
            this.value = vector3;
        }

        public Value(bool v1)
        {
            this.value = v1;
        }

        public Value(double v2)
        {
            this.value = v2;
        }

        public Value(float v2)
        {
            this.value = v2;
        }
        public Value(uint v2)
        {
            this.value = v2;
        }
        public Value(int v2)
        {
            this.value = v2;
        }
        public Value(byte v2)
        {
            this.value = v2;
        }
        public Value(String @string)
        {
            this.value = @string;
        }

        public Value(EntityLink entityLink)
        {
            this.value = entityLink;
        }

        public Value(EntityHandle entityHandle)
        {
            this.value = entityHandle;
        }

        public Value(object entityLink1)
        {
            this.value = entityLink1;
        }

        public bool GetValueAsBool()
        {
            return (bool)this.value;
        }

        internal float GetValueAsFloat()
        {
            return (float)this.value;
        }

        internal Path GetValueAsPath()
        {
            return (Path)this.value;
        }

        internal FilePtr<File> GetValueAsFilePtr()
        {
            return (FilePtr<File>)this.value;
        }

        internal int GetValueAsInt32()
        {
            return (int)this.value;
        }

        internal Color GetValueAsColor()
        {
            return (Color)this.value;
        }

        internal EntityPtr<T> GetValueAsEntityPtr<T>() where T : Entity
        {
            return (EntityPtr<T>)this.value;
        }

        internal uint GetValueAsUInt32()
        {
            return (uint)this.value;
        }

        internal byte GetValueAsUInt8()
        {
            return (byte)this.value;
        }

        internal EntityLink GetValueAsEntityLink()
        {
            return (EntityLink)this.value;
        }

        internal ushort GetValueAsUInt16()
        {
            return (ushort)this.value;
        }

        internal Vector3 GetValueAsVector3()
        {
            return (Vector3)this.value;
        }

        internal String GetValueAsString()
        {
            return (String)this.value;
        }

        internal EntityHandle GetValueAsEntityHandle()
        {
            return (EntityHandle)this.value;
        }

        internal short GetValueAsInt16()
        {
            return (short)this.value;
        }

        internal object GetValueAsWideVector3()
        {
            throw new NotImplementedException();
        }

        internal ulong GetValueAsUInt64()
        {
            return (ulong)this.value;
        }

        internal Vector4 GetValueAsVector4()
        {
            return (Vector4)this.value;
        }

        internal Quaternion GetValueAsQuat()
        {
            return (Quaternion)this.value;
        }

        internal double GetValueAsDouble()
        {
            return (double)this.value;
        }

        internal object GetValueAsMatrix3()
        {
            throw new NotImplementedException();
        }

        internal sbyte GetValueAsInt8()
        {
            return (sbyte)this.value;
        }

        internal Matrix4x4 GetValueAsMatrix4()
        {
            return (Matrix4x4)this.value;
        }

        internal long GetValueAsInt64()
        {
            return (long)this.value;
        }
    }

    /*public class Value<T> : Value
    {
        private T Data;

        public static explicit operator T(Value<T> d) => d.Data;
        public static explicit operator Value<T>(T d) => new Value<T> { Data = d };
    }*/
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