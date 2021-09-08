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

        public static Func<BindableElement> GetTypeFieldConstructor(Type propertyType)
        {
            switch (propertyType)
            {
                case Type _ when propertyType == typeof(bool):
                    return () => new BoolField();

                case Type _ when propertyType == typeof(sbyte):
                    return () => new Int8Field(false);

                case Type _ when propertyType == typeof(byte):
                    return () => new UInt8Field(false);

                case Type _ when propertyType == typeof(short):
                    return () => new Int16Field(false);

                case Type _ when propertyType == typeof(ushort):
                    return () => new UInt16Field(false);

                case Type _ when propertyType == typeof(int):
                    return () => new Int32Field(false);

                case Type _ when propertyType == typeof(uint):
                    return () => new UInt32Field(false);

                case Type _ when propertyType == typeof(long):
                    return () => new Int64Field(false);

                case Type _ when propertyType == typeof(ulong):
                    return () => new UInt64Field(false);

                case Type _ when propertyType == typeof(float):
                    return () => new FloatField();
                case Type _ when propertyType == typeof(double):
                    return () => new DoubleField();

                case Type _ when propertyType == typeof(Fox.String):
                    return () => new StringField();

                case Type _ when propertyType == typeof(Fox.Core.Path):
                    return () => new PathField();

                case Type _ when propertyType == typeof(Vector3):
                    return () => new Vector3Field();

                case Type _ when propertyType == typeof(Vector4):
                    return () => new Fox.Editor.Vector4Field();

                case Type _ when propertyType == typeof(Color):
                    return () => new Fox.Editor.ColorField();

                case Type _ when propertyType == typeof(Quaternion):
                    return () => new QuaternionField();

                case Type _ when propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(FilePtr<>):
                    return () => new FilePtrField();

                case Type _ when propertyType == typeof(EntityHandle):
                    return () => new EntityHandleField();

                case Type _ when propertyType == typeof(Matrix4x4):
                    return () => new Matrix4Field();

                case Type _ when propertyType == typeof(EntityLink):
                    return () => new EntityLinkField();

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }
    }
}