using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    [Serializable]
    public class InspectorTestData
    {
        public InspectorTestData()
        {
            StaticArray_property = new StaticArray<sbyte>(5);
            DynamicArray_property = new DynamicArray<string>(5);
            StringMap_property = new StringMap<sbyte>();
        }

        #region Non-array properties
        public sbyte int8_property;
        public byte uint8_property;
        public short int16_property;
        public ushort uint16_property;
        public int int32_property;
        public uint uint32_property;
        public long int64_property;
        public ulong uint64_property;
        public float float32_property;
        public double float64_property;
        public bool bool_property;
        public Fox.String String_property;
        public Fox.Path Path_property;
        public EntityPtr<Entity> EntityPtr_property;
        public Vector3 Vector3_property;
        public Vector4 Vector4_property;
        public Quaternion Quaternion_property;
        public Matrix4x4 Matrix4x4_property;
        public Color color_property;
        public Fox.FilePtr<File> FilePtr_property;
        public Fox.EntityHandle EntityHandle_property;
        public Fox.EntityLink EntityLink_property;
        #endregion

        #region StaticArray properties
        public StaticArray<sbyte> StaticArray_property;
        #endregion

        #region DynamicArray properties
        public DynamicArray<string> DynamicArray_property;
        #endregion

        #region StringMap properties
        public StringMap<sbyte> StringMap_property;
        #endregion
    }
}