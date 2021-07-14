using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using Fox.Core;

namespace Fox.Editor
{
    internal static class CollectionDrawer
    {
        public static StyleSheet PropertyDrawerStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/Controls/Drawers/CollectionDrawer.uss");

        public static int GetListEntrySize(Type propertyType)
        {
            switch (propertyType)
            {
                case Type _ when propertyType == typeof(sbyte):
                case Type _ when propertyType == typeof(byte):
                case Type _ when propertyType == typeof(short):
                case Type _ when propertyType == typeof(ushort):
                case Type _ when propertyType == typeof(int):
                case Type _ when propertyType == typeof(uint):
                case Type _ when propertyType == typeof(long):
                case Type _ when propertyType == typeof(ulong):
                case Type _ when propertyType == typeof(float):
                case Type _ when propertyType == typeof(double):
                case Type _ when propertyType == typeof(bool):
                case Type _ when propertyType == typeof(Fox.String):
                case Type _ when propertyType == typeof(Path):
                case Type _ when propertyType == typeof(Vector3):
                case Type _ when propertyType == typeof(Vector4):
                case Type _ when propertyType == typeof(Color):
                case Type _ when propertyType == typeof(Quaternion):
                case Type _ when propertyType == typeof(FilePtr<>):
                case Type _ when propertyType == typeof(EntityHandle):
                    return 20;

                case Type _ when propertyType == typeof(Matrix4x4):
                    return 80;

                default:
                    return 20;
            }
        }

        public static Func<string, BindableElement> GetTypeFieldConstructor(Type propertyType)
        {
            switch (propertyType)
            {
                case Type _ when propertyType == typeof(sbyte):
                    return (label) => new Int8Field(label, false);
                case Type _ when propertyType == typeof(byte):
                    return (label) => new UInt8Field(label, false);
                case Type _ when propertyType == typeof(short):
                    return (label) => new Int16Field(label, false);
                case Type _ when propertyType == typeof(ushort):
                    return (label) => new UInt16Field(label, false);
                case Type _ when propertyType == typeof(int):
                    return (label) => new Int32Field(label, false);
                case Type _ when propertyType == typeof(uint):
                    return (label) => new UInt32Field(label, false);
                case Type _ when propertyType == typeof(long):
                    return (label) => new Int64Field(label, false);
                case Type _ when propertyType == typeof(ulong):
                    return (label) => new UInt64Field(label, false);
                case Type _ when propertyType == typeof(float):
                case Type _ when propertyType == typeof(double):
                case Type _ when propertyType == typeof(bool):
                case Type _ when propertyType == typeof(Fox.String):
                case Type _ when propertyType == typeof(Path):
                case Type _ when propertyType == typeof(Vector3):
                case Type _ when propertyType == typeof(Vector4):
                case Type _ when propertyType == typeof(Color):
                case Type _ when propertyType == typeof(Quaternion):
                case Type _ when propertyType == typeof(FilePtr<>):
                case Type _ when propertyType == typeof(EntityHandle):
                    return 20;

                case Type _ when propertyType == typeof(Matrix4x4):
                    return 80;

                default:
                    return 20;
            }
        }
    }
}