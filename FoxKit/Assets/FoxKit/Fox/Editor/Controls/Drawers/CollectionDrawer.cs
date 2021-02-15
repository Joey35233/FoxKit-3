using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

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
                case Type _ when propertyType == typeof(Fox.Path):
                case Type _ when propertyType == typeof(Vector3):
                case Type _ when propertyType == typeof(Vector4):
                case Type _ when propertyType == typeof(Color):
                case Type _ when propertyType == typeof(Quaternion):
                case Type _ when propertyType == typeof(Fox.FilePtr<>):
                case Type _ when propertyType == typeof(Fox.EntityHandle):
                    return 20;

                case Type _ when propertyType == typeof(Matrix4x4):
                    return 80;

                default:
                    return 20;
            }
        }
    }
}