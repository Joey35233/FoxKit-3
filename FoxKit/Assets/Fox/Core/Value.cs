using Fox;
using System;
using System.Collections;
using UnityEngine;

namespace Fox.Core
{
    public class Value
    {
        private readonly object value;

        public Value(bool v1)
        {
            value = v1;
        }

        public Value(sbyte v)
        {
            value = v;
        }
        public Value(byte v2)
        {
            value = v2;
        }

        public Value(short v)
        {
            value = v;
        }
        public Value(ushort v2)
        {
            value = v2;
        }

        public Value(int v2)
        {
            value = v2;
        }
        public Value(uint v2)
        {
            value = v2;
        }

        public Value(long v2)
        {
            value = v2;
        }
        public Value(ulong v2)
        {
            value = v2;
        }

        public Value(float v2)
        {
            value = v2;
        }

        public Value(double v2)
        {
            value = v2;
        }

        // TODO: Old EntityPtr<T> constructor; delete
        // public Value(Entity entity)
        // {
        //     value = entity;
        // }

        public Value(EntityLink entityLink)
        {
            value = entityLink;
        }

        public Value(Entity entityHandle)
        {
            value = entityHandle;
        }

        public Value(FilePtr filePtr)
        {
            value = filePtr;
        }

        public Value(Color color)
        {
            value = color;
        }

        public Value(Vector3 vector3)
        {
            value = vector3;
        }

        public Value(WideVector3 wideVector3)
        {
            value = wideVector3;
        }

        public Value(Vector4 vector3)
        {
            value = vector3;
        }

        public Value(Quaternion quaternion)
        {
            value = quaternion;
        }

        public Value(Matrix3x3 matrix3x3)
        {
            value = matrix3x3;
        }

        public Value(Matrix4x4 matrix4x4)
        {
            value = matrix4x4;
        }

        public Value(string @string)
        {
            value = @string;
        }

        public Value(Path path)
        {
            value = path;
        }

        public Value(Enum @enum)
        {
            value = @enum;
        }

        public Value(IStringMap stringMap)
        {
            value = stringMap;
        }

        public Value(IList list)
        {
            value = list;
        }

        public bool GetValueAsBool() => (bool)value;

        public sbyte GetValueAsInt8() => (sbyte)value;
        public byte GetValueAsUInt8() => (byte)value;

        public short GetValueAsInt16() => (short)value;
        public ushort GetValueAsUInt16() => (ushort)value;

        public int GetValueAsInt32() => (int)value;
        public uint GetValueAsUInt32() => (uint)value;

        public long GetValueAsInt64() => (long)value;
        public ulong GetValueAsUInt64() => (ulong)value;

        public float GetValueAsFloat() => (float)value;

        public double GetValueAsDouble() => (double)value;

        public T GetValueAsEntityPtr<T>() where T : Entity => (T)value;

        public EntityLink GetValueAsEntityLink() => (EntityLink)value;

        public Entity GetValueAsEntityHandle() => (Entity)value;

        public FilePtr GetValueAsFilePtr() => (FilePtr)value;

        public Color GetValueAsColor() => (Color)value;

        public Vector3 GetValueAsVector3() => (Vector3)value;

        public WideVector3 GetValueAsWideVector3() => (WideVector3)value;

        public Vector4 GetValueAsVector4() => (Vector4)value;

        public Quaternion GetValueAsQuat() => (Quaternion)value;

        public Matrix3x3 GetValueAsMatrix3() => (Matrix3x3)value;

        public Matrix4x4 GetValueAsMatrix4() => (Matrix4x4)value;

        public string GetValueAsString() => (string)value;

        public Path GetValueAsPath() => (Path)value;

        public IStringMap GetValueAsStringMap<T>() => (StringMap<T>)value;

        public IStringMap GetValueAsIStringMap() => (IStringMap)value;

        public IList GetValueAsIList() => (IList)value;

        public object GetValueAsBoxedObject() => value;
    }
}