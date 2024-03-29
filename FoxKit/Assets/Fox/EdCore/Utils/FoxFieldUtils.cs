using Fox.Core;
using Fox.Kernel;
using System;
using System.Reflection;
using UnityEngine;
using static Fox.Core.PropertyInfo;
using PropertyInfo = Fox.Core.PropertyInfo;
using String = Fox.Kernel.String;

namespace Fox.EdCore
{
    public static class FoxFieldUtils
    {
        // UNITYENHANCEMENT: https://github.com/Joey35233/FoxKit-3/issues/12
        private static readonly Type SerializedPropertyBindEventType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.UIElements.SerializedPropertyBindEvent");
        private static readonly MethodInfo SerializedPropertyBindEventTypeIDMethod = SerializedPropertyBindEventType.GetMethod("TypeId", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);
        public static readonly long SerializedPropertyBindEventTypeId = (long)SerializedPropertyBindEventTypeIDMethod.Invoke(null, null);
        public static readonly System.Reflection.PropertyInfo SerializedPropertyBindEventBindProperty = SerializedPropertyBindEventType.GetProperty("bindProperty");

        public static Func<IFoxField> GetBindableElementConstructorForType(Type propertyType) =>
            propertyType switch
            {
                Type type when type.IsEnum => type.IsDefined(typeof(FlagsAttribute), inherit: false) ? () => new EnumFlagsField() : () => new EnumField(),
                Type type when type == typeof(bool) => () => new BoolField(),
                Type type when type == typeof(sbyte) => () => new Int8Field(false),
                Type type when type == typeof(byte) => () => new UInt8Field(false),
                Type type when type == typeof(short) => () => new Int16Field(false),
                Type type when type == typeof(ushort) => () => new UInt16Field(false),
                Type type when type == typeof(int) => () => new Int32Field(false),
                Type type when type == typeof(uint) => () => new UInt32Field(false),
                Type type when type == typeof(long) => () => new Int64Field(false),
                Type type when type == typeof(ulong) => () => new UInt64Field(false),
                Type type when type == typeof(float) => () => new FloatField(false),
                Type type when type == typeof(double) => () => new DoubleField(false),
                Type type when type == typeof(String) => () => new StringField(),
                Type type when type == typeof(Path) => () => new PathField(),
                Type type when type == typeof(Vector3) => () => new Vector3Field(),
                Type type when type == typeof(Vector4) => () => new Vector4Field(),
                Type type when type == typeof(Color) => () => new ColorField(),
                Type type when type == typeof(Quaternion) => () => new QuaternionField(),
                Type type when type == typeof(FilePtr) => () => new FilePtrField(),
                Type type when type == typeof(Entity) || type.IsSubclassOf(typeof(Entity)) => () => new EntityHandleField(),
                Type type when type == typeof(Matrix4x4) => () => new Matrix4Field(),
                Type type when type == typeof(EntityLink) => () => new EntityLinkField(),
                _ => throw new ArgumentException($"Invalid Fox type: {propertyType}."),
            };

        public static Func<IFoxField> GetBindableElementConstructorForPropertyInfo(PropertyInfo propertyInfo) =>
            propertyInfo switch
            {
                { Enum: not null } => propertyInfo.Enum.IsDefined(typeof(FlagsAttribute), inherit: false) ? () => new EnumFlagsField() : () => new EnumField(),
                { Type: PropertyType.Bool } => () => new BoolField(),
                { Type: PropertyType.Int8 } => () => new Int8Field(false),
                { Type: PropertyType.UInt8 } => () => new UInt8Field(false),
                { Type: PropertyType.Int16 } => () => new Int16Field(false),
                { Type: PropertyType.UInt16 } => () => new UInt16Field(false),
                { Type: PropertyType.Int32 } => () => new Int32Field(false),
                { Type: PropertyType.UInt32 } => () => new UInt32Field(false),
                { Type: PropertyType.Int64 } => () => new Int64Field(false),
                { Type: PropertyType.UInt64 } => () => new UInt64Field(false),
                { Type: PropertyType.Float } => () => new FloatField(false),
                { Type: PropertyType.Double } => () => new DoubleField(false),
                { Type: PropertyType.String } => () => new StringField(),
                { Type: PropertyType.Path } => () => new PathField(),
                { Type: PropertyType.Vector3 } => () => new Vector3Field(),
                { Type: PropertyType.Vector4 } => () => new Vector4Field(),
                { Type: PropertyType.Color } => () => new ColorField(),
                { Type: PropertyType.Quat } => () => new QuaternionField(),
                { Type: PropertyType.FilePtr } => () => new FilePtrField(),
                { Type: PropertyType.EntityPtr } => () => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(propertyInfo.PtrType)) as IFoxField,
                { Type: PropertyType.EntityHandle } => () => new EntityHandleField(),
                { Type: PropertyType.Matrix4 } => () => new Matrix4Field(),
                { Type: PropertyType.EntityLink } => () => new EntityLinkField(),
                _ => throw new ArgumentException($"Invalid Fox type: {propertyInfo.Type}."),
            };

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

            if (propertyInfo.Container is ContainerType.DynamicArray or ContainerType.List)
                return Activator.CreateInstance(typeof(DynamicArrayField<>).MakeGenericType(new Type[] { PropertyInfo.GetTypeFromPropertyInfo(propertyInfo) }), null) as ICustomBindable;

            if (propertyInfo.Container == ContainerType.StringMap)
                return Activator.CreateInstance(typeof(StringMapField<>).MakeGenericType(new Type[] { PropertyInfo.GetTypeFromPropertyInfo(propertyInfo) }), null) as ICustomBindable;

            if (propertyInfo.Enum != null)
                return propertyInfo.Enum.IsDefined(typeof(System.FlagsAttribute), false) ? new EnumFlagsField() : new EnumField();

            PropertyType propertyType = propertyInfo.Type;

            return propertyType switch
            {
                PropertyType.Int8 => new Int8Field(),
                PropertyType.UInt8 => new UInt8Field(),
                PropertyType.Int16 => new Int16Field(),
                PropertyType.UInt16 => new UInt16Field(),
                PropertyType.Int32 => new Int32Field(),
                PropertyType.UInt32 => new UInt32Field(),
                PropertyType.Int64 => new Int64Field(),
                PropertyType.UInt64 => new UInt64Field(),
                PropertyType.Float => new FloatField(),
                PropertyType.Double => new DoubleField(),
                PropertyType.Bool => new BoolField(),
                PropertyType.String => new StringField(),
                PropertyType.Path => new PathField(),
                PropertyType.EntityPtr => Activator.CreateInstance(typeof(EntityPtrField<>).MakeGenericType(new Type[] { propertyInfo.PtrType }), null) as ICustomBindable,
                PropertyType.Vector3 => new Vector3Field(),
                PropertyType.Vector4 => new Vector4Field(),
                PropertyType.Quat => new QuaternionField(),
                PropertyType.Matrix4 => new Matrix4Field(),
                PropertyType.Color => new ColorField(),
                PropertyType.FilePtr => new FilePtrField(),
                PropertyType.EntityHandle => new EntityHandleField(),
                PropertyType.EntityLink => new EntityLinkField(),
                _ => throw new ArgumentException($"Invalid Fox type: {propertyType}."),
            };
        }
    }
}