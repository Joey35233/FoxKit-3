using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Core
{
    [Serializable]
    public class InspectorTestData
    {
        public InspectorTestData()
        {
            #region StaticArray constructors
            int8_StaticArray_property = new StaticArray<sbyte>(5);
            uint8_StaticArray_property = new StaticArray<byte>(5);
            int16_StaticArray_property = new StaticArray<short>(5);
            uint16_StaticArray_property = new StaticArray<ushort>(5);
            int32_StaticArray_property = new StaticArray<int>(5);
            uint32_StaticArray_property = new StaticArray<uint>(5);
            int64_StaticArray_property = new StaticArray<long>(5);
            uint64_StaticArray_property = new StaticArray<ulong>(5);
            float32_StaticArray_property = new StaticArray<float>(5);
            float64_StaticArray_property = new StaticArray<double>(5);
            bool_StaticArray_property = new StaticArray<bool>(5);
            String_StaticArray_property = new StaticArray<Fox.String>(5);
            Path_StaticArray_property = new StaticArray<Path>(5);
            //EntityPtr_StaticArray_property = new StaticArray<EntityPtr<Entity>>(5);
            Vector3_StaticArray_property = new StaticArray<Vector3>(5);
            Vector4_StaticArray_property = new StaticArray<Vector4>(5);
            Quaternion_StaticArray_property = new StaticArray<Quaternion>(5);
            Matrix4x4_StaticArray_property = new StaticArray<Matrix4x4>(5);
            color_StaticArray_property = new StaticArray<Color>(5);
            FilePtr_StaticArray_property = new StaticArray<FilePtr<File>>(5);
            EntityHandle_StaticArray_property = new StaticArray<EntityHandle>(5);
            EntityLink_StaticArray_property = new StaticArray<EntityLink>(5);
            #endregion

            #region DynamicArray constructors
            int8_DynamicArray_property = new DynamicArray<sbyte>(5);
            uint8_DynamicArray_property = new DynamicArray<byte>(5);
            int16_DynamicArray_property = new DynamicArray<short>(5);
            uint16_DynamicArray_property = new DynamicArray<ushort>(5);
            int32_DynamicArray_property = new DynamicArray<int>(5);
            uint32_DynamicArray_property = new DynamicArray<uint>(5);
            int64_DynamicArray_property = new DynamicArray<long>(5);
            uint64_DynamicArray_property = new DynamicArray<ulong>(5);
            float32_DynamicArray_property = new DynamicArray<float>(5);
            float64_DynamicArray_property = new DynamicArray<double>(5);
            bool_DynamicArray_property = new DynamicArray<bool>(5);
            String_DynamicArray_property = new DynamicArray<Fox.String>(5);
            Path_DynamicArray_property = new DynamicArray<Path>(5);
            //EntityPtr_DynamicArray_property = new DynamicArray<EntityPtr<Entity>>(5);
            Vector3_DynamicArray_property = new DynamicArray<Vector3>(5);
            Vector4_DynamicArray_property = new DynamicArray<Vector4>(5);
            Quaternion_DynamicArray_property = new DynamicArray<Quaternion>(5);
            Matrix4x4_DynamicArray_property = new DynamicArray<Matrix4x4>(5);
            color_DynamicArray_property = new DynamicArray<Color>(5);
            FilePtr_DynamicArray_property = new DynamicArray<FilePtr<File>>(5);
            EntityHandle_DynamicArray_property = new DynamicArray<EntityHandle>(5);
            EntityLink_DynamicArray_property = new DynamicArray<EntityLink>(5);
            #endregion

            #region StringMap constructors
            int8_StringMap_property = new StringMap<sbyte>();
            uint8_StringMap_property = new StringMap<byte>();
            int16_StringMap_property = new StringMap<short>();
            uint16_StringMap_property = new StringMap<ushort>();
            int32_StringMap_property = new StringMap<int>();
            uint32_StringMap_property = new StringMap<uint>();
            int64_StringMap_property = new StringMap<long>();
            uint64_StringMap_property = new StringMap<ulong>();
            float32_StringMap_property = new StringMap<float>();
            float64_StringMap_property = new StringMap<double>();
            bool_StringMap_property = new StringMap<bool>();
            String_StringMap_property = new StringMap<Fox.String>();
            Path_StringMap_property = new StringMap<Path>();
            //EntityPtr_StringMap_property = new StringMap<EntityPtr<Entity>>();
            Vector3_StringMap_property = new StringMap<Vector3>();
            Vector4_StringMap_property = new StringMap<Vector4>();
            Quaternion_StringMap_property = new StringMap<Quaternion>();
            Matrix4x4_StringMap_property = new StringMap<Matrix4x4>();
            color_StringMap_property = new StringMap<Color>();
            FilePtr_StringMap_property = new StringMap<FilePtr<File>>();
            EntityHandle_StringMap_property = new StringMap<EntityHandle>();
            EntityLink_StringMap_property = new StringMap<EntityLink>();
            #endregion
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
        public Path Path_property;
        public EntityPtr<Entity> EntityPtr_property;
        public Vector3 Vector3_property;
        public Vector4 Vector4_property;
        public Quaternion Quaternion_property;
        public Matrix4x4 Matrix4x4_property;
        public Color color_property;
        public FilePtr<File> FilePtr_property;
        public EntityHandle EntityHandle_property;
        public EntityLink EntityLink_property;
        #endregion

        #region StaticArray properties
        public StaticArray<sbyte> int8_StaticArray_property;
        public StaticArray<byte> uint8_StaticArray_property;
        public StaticArray<short> int16_StaticArray_property;
        public StaticArray<ushort> uint16_StaticArray_property;
        public StaticArray<int> int32_StaticArray_property;
        public StaticArray<uint> uint32_StaticArray_property;
        public StaticArray<long> int64_StaticArray_property;
        public StaticArray<ulong> uint64_StaticArray_property;
        public StaticArray<float> float32_StaticArray_property;
        public StaticArray<double> float64_StaticArray_property;
        public StaticArray<bool> bool_StaticArray_property;
        public StaticArray<Fox.String> String_StaticArray_property;
        public StaticArray<Path> Path_StaticArray_property;
        //public StaticArray<EntityPtr<Entity>> EntityPtr_StaticArray_property;
        public StaticArray<Vector3> Vector3_StaticArray_property;
        public StaticArray<Vector4> Vector4_StaticArray_property;
        public StaticArray<Quaternion> Quaternion_StaticArray_property;
        public StaticArray<Matrix4x4> Matrix4x4_StaticArray_property;
        public StaticArray<Color> color_StaticArray_property;
        public StaticArray<Fox.Core.FilePtr<Fox.Core.File>> FilePtr_StaticArray_property;
        public StaticArray<Fox.Core.EntityHandle> EntityHandle_StaticArray_property;
        public StaticArray<Fox.Core.EntityLink> EntityLink_StaticArray_property;
        #endregion

        #region DynamicArray properties
        public DynamicArray<sbyte> int8_DynamicArray_property;
        public DynamicArray<byte> uint8_DynamicArray_property;
        public DynamicArray<short> int16_DynamicArray_property;
        public DynamicArray<ushort> uint16_DynamicArray_property;
        public DynamicArray<int> int32_DynamicArray_property;
        public DynamicArray<uint> uint32_DynamicArray_property;
        public DynamicArray<long> int64_DynamicArray_property;
        public DynamicArray<ulong> uint64_DynamicArray_property;
        public DynamicArray<float> float32_DynamicArray_property;
        public DynamicArray<double> float64_DynamicArray_property;
        public DynamicArray<bool> bool_DynamicArray_property;
        public DynamicArray<Fox.String> String_DynamicArray_property;
        public DynamicArray<Path> Path_DynamicArray_property;
        //public DynamicArray<EntityPtr<Entity>> EntityPtr_DynamicArray_property;
        public DynamicArray<Vector3> Vector3_DynamicArray_property;
        public DynamicArray<Vector4> Vector4_DynamicArray_property;
        public DynamicArray<Quaternion> Quaternion_DynamicArray_property;
        public DynamicArray<Matrix4x4> Matrix4x4_DynamicArray_property;
        public DynamicArray<Color> color_DynamicArray_property;
        public DynamicArray<FilePtr<File>> FilePtr_DynamicArray_property;
        public DynamicArray<EntityHandle> EntityHandle_DynamicArray_property;
        public DynamicArray<EntityLink> EntityLink_DynamicArray_property;
        #endregion

        #region StringMap properties
        public StringMap<sbyte> int8_StringMap_property;
        public StringMap<byte> uint8_StringMap_property;
        public StringMap<short> int16_StringMap_property;
        public StringMap<ushort> uint16_StringMap_property;
        public StringMap<int> int32_StringMap_property;
        public StringMap<uint> uint32_StringMap_property;
        public StringMap<long> int64_StringMap_property;
        public StringMap<ulong> uint64_StringMap_property;
        public StringMap<float> float32_StringMap_property;
        public StringMap<double> float64_StringMap_property;
        public StringMap<bool> bool_StringMap_property;
        public StringMap<Fox.String> String_StringMap_property;
        public StringMap<Path> Path_StringMap_property;
        //public StringMap<EntityPtr<Entity>> EntityPtr_StringMap_property;
        public StringMap<Vector3> Vector3_StringMap_property;
        public StringMap<Vector4> Vector4_StringMap_property;
        public StringMap<Quaternion> Quaternion_StringMap_property;
        public StringMap<Matrix4x4> Matrix4x4_StringMap_property;
        public StringMap<Color> color_StringMap_property;
        public StringMap<FilePtr<File>> FilePtr_StringMap_property;
        public StringMap<EntityHandle> EntityHandle_StringMap_property;
        public StringMap<EntityLink> EntityLink_StringMap_property;
        #endregion
    }

    [Serializable]
    public class InspectorTestData2
    {
        public InspectorTestData2()
        {
            strings = new StaticArray<Path>(5);
        }

        public Path str;

        public StaticArray<Path> strings;
    }
}