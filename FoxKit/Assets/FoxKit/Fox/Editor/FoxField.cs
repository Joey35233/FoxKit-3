using UnityEngine.UIElements;
using UnityEditor;
using System;
using UnityEngine;
using Fox.Core;

namespace Fox.Editor
{
    public interface IFoxField : IBindable
    {
        private static StyleSheet FoxFieldLightStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/FoxFieldLight.uss");
        private static StyleSheet FoxFieldDarkStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/FoxKit/Fox/Editor/FoxFieldDark.uss");

        public static StyleSheet FoxFieldStyleSheet { get { return EditorGUIUtility.isProSkin ? FoxFieldDarkStyleSheet : FoxFieldLightStyleSheet; } }
    }

    public static class FoxFieldUtils
    {
        public static Func<IFoxField> GetTypeFieldConstructor(Type propertyType)
        {
            switch (propertyType)
            {
                case Type type when type == typeof(bool):
                    return () => new BoolField();

                case Type type when type == typeof(sbyte):
                    return () => new Int8Field(false);

                case Type type when type == typeof(byte):
                    return () => new UInt8Field(false);

                case Type type when type == typeof(short):
                    return () => new Int16Field(false);

                case Type type when type == typeof(ushort):
                    return () => new UInt16Field(false);

                case Type type when type == typeof(int):
                    return () => new Int32Field(false);

                case Type type when type == typeof(uint):
                    return () => new UInt32Field(false);

                case Type type when type == typeof(long):
                    return () => new Int64Field(false);

                case Type type when type == typeof(ulong):
                    return () => new UInt64Field(false);

                case Type type when type == typeof(float):
                    return () => new FloatField(false);

                case Type type when type == typeof(double):
                    return () => new DoubleField(false);

                case Type type when type == typeof(Fox.String):
                    return () => new StringField();

                case Type type when type == typeof(Fox.Core.Path):
                    return () => new PathField();

                case Type type when type == typeof(Vector3):
                    return () => new Vector3Field();

                case Type type when type == typeof(Vector4):
                    return () => new Vector4Field();

                case Type type when type == typeof(Color):
                    return () => new ColorField();

                case Type type when type == typeof(Quaternion):
                    return () => new QuaternionField();

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(FilePtr<>):
                    return () => new FilePtrField();

                case Type type when type == typeof(EntityHandle):
                    return () => new EntityHandleField();

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityPtr<>):
                    return () => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] })) as IFoxField;

                case Type type when type == typeof(Matrix4x4):
                    return () => new Matrix4Field();

                case Type type when type == typeof(EntityLink):
                    return () => new EntityLinkField();

                case Type type when type.GetGenericTypeDefinition() == typeof(StaticArray<>):
                    return () => Activator.CreateInstance(typeof(StaticArrayField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] })) as IFoxField;

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }

        public static Func<IFoxField> GetTypeFieldConstructorWithLabelPlaceholder(Type propertyType)
        {
            switch (propertyType)
            {
                case Type type when type == typeof(bool):
                    return () => new BoolField("p");

                case Type type when type == typeof(sbyte):
                    return () => new Int8Field("p", false);

                case Type type when type == typeof(byte):
                    return () => new UInt8Field("p", false);

                case Type type when type == typeof(short):
                    return () => new Int16Field("p", false);

                case Type type when type == typeof(ushort):
                    return () => new UInt16Field("p", false);

                case Type type when type == typeof(int):
                    return () => new Int32Field("p", false);

                case Type type when type == typeof(uint):
                    return () => new UInt32Field("p", false);

                case Type type when type == typeof(long):
                    return () => new Int64Field("p", false);

                case Type type when type == typeof(ulong):
                    return () => new UInt64Field("p", false);

                case Type type when type == typeof(float):
                    return () => new FloatField("p", false);

                case Type type when type == typeof(double):
                    return () => new DoubleField("p", false);

                case Type type when type == typeof(Fox.String):
                    return () => new StringField("p");

                case Type type when type == typeof(Fox.Core.Path):
                    return () => new PathField("p");

                case Type type when type == typeof(Vector3):
                    return () => new Vector3Field("p");

                case Type type when type == typeof(Vector4):
                    return () => new Vector4Field("p");

                case Type type when type == typeof(Color):
                    return () => new ColorField("p");

                case Type type when type == typeof(Quaternion):
                    return () => new QuaternionField("p");

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(FilePtr<>):
                    return () => new FilePtrField("p");

                case Type type when type == typeof(EntityHandle):
                    return () => new EntityHandleField("p");

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityPtr<>):
                    return () => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] }), new object[] { "p" }) as IFoxField;

                case Type type when type == typeof(Matrix4x4):
                    return () => new Matrix4Field("p");

                case Type type when type == typeof(EntityLink):
                    return () => new EntityLinkField("p");

                case Type type when type.GetGenericTypeDefinition() == typeof(StaticArray<>):
                    return () => Activator.CreateInstance(typeof(StaticArrayField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] }), new object[] { "p" }) as IFoxField;

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }
    }
}