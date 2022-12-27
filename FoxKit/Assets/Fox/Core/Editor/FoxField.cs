using UnityEngine.UIElements;
using UnityEditor;
using System;
using UnityEngine;
using Fox.Core;
using System.Reflection;
using static Fox.Core.PropertyInfo;
using PropertyInfo = Fox.Core.PropertyInfo;
using Fox.Kernel;
using String = Fox.Kernel.String;

namespace Fox.Editor
{
    public interface IFoxField : IBindable
    {
        private static StyleSheet FoxFieldLightStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/Core/Editor/FoxFieldLight.uss");
        private static StyleSheet FoxFieldDarkStyleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Fox/Core/Editor/FoxFieldDark.uss");

        public static StyleSheet FoxFieldStyleSheet { get { return EditorGUIUtility.isProSkin ? FoxFieldDarkStyleSheet : FoxFieldLightStyleSheet; } }
    }

    public interface ICustomBindable : IBindable
    {
        void BindProperty(SerializedProperty property);

        void BindProperty(SerializedProperty property, string label);
    }

    public static class FoxFieldUtils
    {
        // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
        private static readonly Type SerializedPropertyBindEventType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.UIElements.SerializedPropertyBindEvent");
        private static MethodInfo SerializedPropertyBindEventTypeIDMethod = SerializedPropertyBindEventType.GetMethod("TypeId", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        public static readonly long SerializedPropertyBindEventTypeId = (long)SerializedPropertyBindEventTypeIDMethod.Invoke(null, null);
        public static readonly System.Reflection.PropertyInfo SerializedPropertyBindEventBindProperty = SerializedPropertyBindEventType.GetProperty("bindProperty");

        public static Func<IFoxField> GetTypeFieldConstructor(Type propertyType)
        {
            switch (propertyType)
            {
                case Type type when type.IsEnum:
                    return type.IsDefined(typeof(FlagsAttribute), inherit: false) ? () => new EnumFlagsField() : () => new EnumField();

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

                case Type type when type == typeof(String):
                    return () => new StringField();

                case Type type when type == typeof(Path):
                    return () => new PathField();

                case Type type when type == typeof(Vector3):
                    return () => new Vector3Field();

                case Type type when type == typeof(Vector4):
                    return () => new Vector4Field();

                case Type type when type == typeof(Color):
                    return () => new ColorField();

                case Type type when type == typeof(Quaternion):
                    return () => new QuaternionField();

                case Type type when type == typeof(FilePtr):
                    return () => new FilePtrField();

                case Type type when type == typeof(EntityHandle):
                    return () => new EntityHandleField();

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityPtr<>):
                    return () => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] })) as IFoxField;

                case Type type when type == typeof(Matrix4x4):
                    return () => new Matrix4Field();

                case Type type when type == typeof(EntityLink):
                    return () => new EntityLinkField();

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

                case Type type when type == typeof(String):
                    return () => new StringField("p");

                case Type type when type == typeof(Path):
                    return () => new PathField("p");

                case Type type when type == typeof(Vector3):
                    return () => new Vector3Field("p");

                case Type type when type == typeof(Vector4):
                    return () => new Vector4Field("p");

                case Type type when type == typeof(Color):
                    return () => new ColorField("p");

                case Type type when type == typeof(Quaternion):
                    return () => new QuaternionField("p");

                case Type type when type == typeof(FilePtr):
                    return () => new FilePtrField("p");

                case Type type when type == typeof(EntityHandle):
                    return () => new EntityHandleField("p");

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(EntityPtr<>):
                    return () => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] }), new object[] { "p" }) as IFoxField;

                case Type type when type == typeof(Matrix4x4):
                    return () => new Matrix4Field("p");

                case Type type when type == typeof(EntityLink):
                    return () => new EntityLinkField("p");

                case Type type when type.IsEnum:
                    return type.IsDefined(typeof(FlagsAttribute), inherit: false) ? () => new EnumFlagsField("p") : () => new EnumField("p");

                case Type type when type.IsGenericType && type.GetGenericTypeDefinition() == typeof(StaticArray<>):
                    return () => Activator.CreateInstance(typeof(StaticArrayField<>).MakeGenericType(new Type[] { type.GenericTypeArguments[0] }), new object[] { "p" }) as IFoxField;

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }

        // For BaseField, field, when you send a ChangeEvent:
        // It stores field.value as lastFieldValue (SerializedObjectBindingToBaseField.FieldValueChanged)
        // If lastFieldValue is different than the SerializedProperty's value, it sets the property and applies it to the SerializedObject. (SerializedObjectBindingPropertyToBaseField.SyncFieldValueToProperty)

        // For BaseField, field, when you modify its SerializedProperty
        // However, since the SerializedProperty was changed, it has to process it. It gets the property's value. (SerializedObjectBindingPropertyToBaseField.SyncPropertyToField)
        // Then it calls BaseField.SetValueWithoutValidation which modifies field.value (SerializedObjectBinding.AssignValueToField)

        // SerializedProperty | set BaseField<T>.value -> SVWN() + ChangeEvent<T> -> Event received but the property is longer different
        // value              | SVWN() + ChangeEvent<T> -> ApplyModifiedProperties() -> set BaseField<T>.value but stopped because the value is no longer different
        public static ICustomBindable GetCustomBindableField(PropertyInfo propertyInfo)
        {
            if (propertyInfo.Container == ContainerType.StaticArray && propertyInfo.ArraySize > 1)
                return Activator.CreateInstance(typeof(StaticArrayField<>).MakeGenericType(new Type[] { PropertyInfo.GetTypeFromPropertyInfo(propertyInfo) }), null) as ICustomBindable;

            if (propertyInfo.Container == ContainerType.DynamicArray || propertyInfo.Container == ContainerType.List)
                return Activator.CreateInstance(typeof(DynamicArrayField<>).MakeGenericType(new Type[] { PropertyInfo.GetTypeFromPropertyInfo(propertyInfo) }), null) as ICustomBindable;

            if (propertyInfo.Container == ContainerType.StringMap)
                return Activator.CreateInstance(typeof(StringMapField<>).MakeGenericType(new Type[] { PropertyInfo.GetTypeFromPropertyInfo(propertyInfo) }), null) as ICustomBindable;

            if (propertyInfo.Enum != null)
                if (propertyInfo.Enum.IsDefined(typeof(System.FlagsAttribute), false))
                    return new EnumFlagsField();
                else
                    return new EnumField();

            PropertyType propertyType = propertyInfo.Type;

            switch (propertyType)
            {
                case PropertyType.Int8:
                    return new Int8Field();

                case PropertyType.UInt8:
                    return new UInt8Field();

                case PropertyType.Int16:
                    return new Int16Field();

                case PropertyType.UInt16:
                    return new UInt16Field();

                case PropertyType.Int32:
                    return new Int32Field();

                case PropertyType.UInt32:
                    return new UInt32Field();

                case PropertyType.Int64:
                    return new Int64Field();

                case PropertyType.UInt64:
                    return new UInt64Field();

                case PropertyType.Float:
                    return new FloatField();

                case PropertyType.Double:
                    return new DoubleField();

                case PropertyType.Bool:
                    return new BoolField();

                case PropertyType.String:
                    return new StringField();

                case PropertyType.Path:
                    return new PathField();

                case PropertyType.EntityPtr:
                    return Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { propertyInfo.PtrType }), null) as ICustomBindable;

                case PropertyType.Vector3:
                    return new Vector3Field();

                case PropertyType.Vector4:
                    return new Vector4Field();

                case PropertyType.Quat:
                    return new QuaternionField();

                //case PropertyType.Matrix3:
                //    return new QuaternionField();

                case PropertyType.Matrix4:
                    return new Matrix4Field();

                case PropertyType.Color:
                    return new ColorField();

                case PropertyType.FilePtr:
                    return new FilePtrField();

                case PropertyType.EntityHandle:
                    return new EntityHandleField();

                case PropertyType.EntityLink:
                    return new EntityLinkField();

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }
    }
}