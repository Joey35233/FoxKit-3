using Fox.Core;
using System;
using UnityEngine;

namespace Fox
{
    public class Value
    {
        private sbyte v;
        private FilePtr<File> filePtr;
        private Color color;
        private Matrix4x4 matrix4x4;
        private Quaternion quaternion;
        private Vector3 vector3;
        private bool v1;
        private double v2;
        private String @string;
        private EntityLink entityLink;
        private EntityHandle entityHandle;
        private IEntityPtr entity;
        private object entityLink1;

        public Value(sbyte v)
        {
            this.v = v;
        }

        public Value(IEntityPtr entity)
        {
            this.entity = entity;
        }

        public Value(FilePtr<File> filePtr)
        {
            this.filePtr = filePtr;
        }

        public Value(Color color)
        {
            this.color = color;
        }

        public Value(Matrix4x4 matrix4x4)
        {
            this.matrix4x4 = matrix4x4;
        }

        public Value(Quaternion quaternion)
        {
            this.quaternion = quaternion;
        }

        public Value(Vector3 vector3)
        {
            this.vector3 = vector3;
        }
        public Value(Vector4 vector3)
        {
            this.vector3 = vector3;
        }

        public Value(bool v1)
        {
            this.v1 = v1;
        }

        public Value(double v2)
        {
            this.v2 = v2;
        }

        public Value(String @string)
        {
            this.@string = @string;
        }

        public Value(EntityLink entityLink)
        {
            this.entityLink = entityLink;
        }

        public Value(EntityHandle entityHandle)
        {
            this.entityHandle = entityHandle;
        }

        public Value(object entityLink1)
        {
            this.entityLink1 = entityLink1;
        }

        internal bool GetValueAsBool()
        {
            throw new NotImplementedException();
        }

        internal float GetValueAsFloat()
        {
            throw new NotImplementedException();
        }

        internal Path GetValueAsPath()
        {
            throw new NotImplementedException();
        }

        internal FilePtr<File> GetValueAsFilePtr()
        {
            throw new NotImplementedException();
        }

        internal int GetValueAsInt32()
        {
            throw new NotImplementedException();
        }

        internal Color GetValueAsColor()
        {
            throw new NotImplementedException();
        }

        internal EntityPtr<T> GetValueAsEntityPtr<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        internal uint GetValueAsUInt32()
        {
            throw new NotImplementedException();
        }

        internal byte GetValueAsUInt8()
        {
            throw new NotImplementedException();
        }

        internal EntityLink GetValueAsEntityLink()
        {
            throw new NotImplementedException();
        }

        internal ushort GetValueAsUInt16()
        {
            throw new NotImplementedException();
        }

        internal Vector3 GetValueAsVector3()
        {
            throw new NotImplementedException();
        }

        internal string GetValueAsString()
        {
            throw new NotImplementedException();
        }

        internal EntityHandle GetValueAsEntityHandle()
        {
            throw new NotImplementedException();
        }

        internal short GetValueAsInt16()
        {
            throw new NotImplementedException();
        }

        internal object GetValueAsWideVector3()
        {
            throw new NotImplementedException();
        }

        internal ulong GetValueAsUInt64()
        {
            throw new NotImplementedException();
        }

        internal Vector4 GetValueAsVector4()
        {
            throw new NotImplementedException();
        }

        internal Quaternion GetValueAsQuat()
        {
            throw new NotImplementedException();
        }

        internal double GetValueAsDouble()
        {
            throw new NotImplementedException();
        }

        internal object GetValueAsMatrix3()
        {
            throw new NotImplementedException();
        }

        internal sbyte GetValueAsInt8()
        {
            throw new NotImplementedException();
        }

        internal Matrix4x4 GetValueAsMatrix4()
        {
            throw new NotImplementedException();
        }

        internal long GetValueAsInt64()
        {
            throw new NotImplementedException();
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