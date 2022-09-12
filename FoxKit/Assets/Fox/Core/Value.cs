using Fox.Core;
using System;
using Fox.Kernel;
using String = Fox.Kernel.String;
using UnityEngine;

namespace Fox.Core
{
    public class Value
    {
        private object value;

        public Value(bool v1)
        {
            this.value = v1;
        }

        public Value(sbyte v)
        {
            this.value = v;
        }
        public Value(byte v2)
        {
            this.value = v2;
        }

        public Value(short v)
        {
            this.value = v;
        }
        public Value(ushort v2)
        {
            this.value = v2;
        }

        public Value(int v2)
        {
            this.value = v2;
        }
        public Value(uint v2)
        {
            this.value = v2;
        }

        public Value(long v2)
        {
            this.value = v2;
        }
        public Value(ulong v2)
        {
            this.value = v2;
        }

        public Value(float v2)
        {
            this.value = v2;
        }

        public Value(double v2)
        {
            this.value = v2;
        }

        public Value(IEntityPtr entity)
        {
            this.value = entity;
        }

        public Value(EntityLink entityLink)
        {
            this.value = entityLink;
        }

        public Value(EntityHandle entityHandle)
        {
            this.value = entityHandle;
        }

        public Value(FilePtr filePtr)
        {
            this.value = filePtr;
        }

        public Value(Color color)
        {
            this.value = color;
        }

        public Value(Vector3 vector3)
        {
            this.value = vector3;
        }
        public Value(Vector4 vector3)
        {
            this.value = vector3;
        }

        public Value(Quaternion quaternion)
        {
            this.value = quaternion;
        }

        public Value(Matrix4x4 matrix4x4)
        {
            this.value = matrix4x4;
        }

        public Value(String @string)
        {
            this.value = @string;
        }

        public Value(Path path)
        {
            this.value = path;
        }

        public bool GetValueAsBool()
        {
            return (bool)this.value;
        }

        public sbyte GetValueAsInt8()
        {
            return (sbyte)this.value;
        }
        public byte GetValueAsUInt8()
        {
            return (byte)this.value;
        }

        public short GetValueAsInt16()
        {
            return (short)this.value;
        }
        public ushort GetValueAsUInt16()
        {
            return (ushort)this.value;
        }

        public int GetValueAsInt32()
        {
            return (int)this.value;
        }
        public uint GetValueAsUInt32()
        {
            return (uint)this.value;
        }

        public long GetValueAsInt64()
        {
            return (long)this.value;
        }
        public ulong GetValueAsUInt64()
        {
            return (ulong)this.value;
        }

        public float GetValueAsFloat()
        {
            return (float)this.value;
        }

        public double GetValueAsDouble()
        {
            return (double)this.value;
        }

        public EntityPtr<T> GetValueAsEntityPtr<T>() where T : Entity
        {
            return (EntityPtr<T>)this.value;
        }

        public EntityLink GetValueAsEntityLink()
        {
            return (EntityLink)this.value;
        }

        public EntityHandle GetValueAsEntityHandle()
        {
            return (EntityHandle)this.value;
        }

        public FilePtr GetValueAsFilePtr()
        {
            return (FilePtr)this.value;
        }

        public Color GetValueAsColor()
        {
            return (Color)this.value;
        }

        public Vector3 GetValueAsVector3()
        {
            return (Vector3)this.value;
        }

        public object GetValueAsWideVector3()
        {
            throw new NotImplementedException();
        }

        public Vector4 GetValueAsVector4()
        {
            return (Vector4)this.value;
        }

        public Quaternion GetValueAsQuat()
        {
            return (Quaternion)this.value;
        }

        public object GetValueAsMatrix3()
        {
            throw new NotImplementedException();
        }

        public Matrix4x4 GetValueAsMatrix4()
        {
            return (Matrix4x4)this.value;
        }

        public String GetValueAsString()
        {
            return (String)this.value;
        }

        public Path GetValueAsPath()
        {
            return (Path)this.value;
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