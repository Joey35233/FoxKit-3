using System;

namespace Fox.Core
{
    /// <summary>
    /// Metadata defining a property.
    /// </summary>
    public class PropertyInfo
    {
        /// <summary>
        /// Types of values that can be stored in a Fox property.
        /// </summary>
        public enum PropertyType
        {
            Int8 = 0,
            UInt8 = 1,
            Int16 = 2,
            UInt16 = 3,
            Int32 = 4,
            UInt32 = 5,
            Int64 = 6,
            UInt64 = 7,
            Float = 8,
            Double = 9,
            Bool = 10,
            String = 11,
            Path = 12,
            EntityPtr = 13,
            Vector3 = 14,
            Vector4 = 15,
            Quat = 16,
            Matrix3 = 17,
            Matrix4 = 18,
            Color = 19,
            FilePtr = 20,
            EntityHandle = 21,
            EntityLink = 22,
            PropertyInfo = 23,
            WideVector3 = 24
        }

        /// <summary>
        /// Types of property containers.
        /// </summary>
        public enum ContainerType
        {
            /// <summary>
            /// An array with a fixed size. A StaticArray of arraySize 1 is not stored as an array.
            /// </summary>
            StaticArray = 0,
            /// <summary>
            /// An array that can contain any number of elements.
            /// </summary>
            DynamicArray = 1,
            /// <summary>
            /// An array that can contain any number of elements.
            /// </summary>
            StringMap = 2,
            /// <summary>
            /// An array that can contain any number of elements.
            /// </summary>
            List = 3
        }

        /// <summary>
        /// Unknown.
        /// </summary>
        public enum PropertyStorage
        {
            Instance,
            Class
        }

        /// <summary>
        /// Whether or not the property is exported to the editor and/or to the game.
        /// </summary>
        [Flags]
        public enum PropertyExport
        {
            Never,
            EditorOnly,
            EditorAndGame
        }

        /// <summary>
        /// Name of the property.
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// Type of data stored in the property.
        /// </summary>
        public PropertyType Type { get; }

        /// <summary>
        /// Offset at which the property's value is stored in C++.
        /// </summary>
        public uint Offset { get; }

        /// <summary>
        /// Only used for StaticArrays to indicate the number of elements in the array.
        /// </summary>
        public uint ArraySize { get; }

        /// <summary>
        /// Type of container storing the property's values.
        /// </summary>
        public ContainerType Container { get; }

        /// <summary>
        /// Unknown.
        /// </summary>
        public PropertyStorage Storage { get; }

        /// <summary>
        /// Type of Entity pointed to for EntityPtr properties.
        /// </summary>
        public Type PtrType { get; }

        /// <summary>
        /// Type of enum pointed to for uint32 or int32 properties.
        /// </summary>
        public Type Enum { get; }

        /// <summary>
        /// Whether or not the property is visible.
        /// </summary>
        public PropertyExport Readable { get; }

        /// <summary>
        /// Whether or not the property can be written to.
        /// </summary>
        public PropertyExport Writable { get; }

        public PropertyInfo
        (
            String name,
            PropertyType type,
            uint offset,
            uint arraySize = 1,
            ContainerType container = ContainerType.StaticArray,
            PropertyExport readable = PropertyExport.EditorAndGame,
            PropertyExport writable = PropertyExport.EditorAndGame,
            Type ptrType = null,
            Type enumType = null,
            PropertyStorage storage = PropertyStorage.Instance
        )
        {
            this.Name = name;
            this.Type = type;
            this.Offset = offset;
            this.ArraySize = arraySize;
            this.Container = container;
            this.Storage = storage;
            this.PtrType = ptrType;
            this.Enum = enumType;
            this.Readable = readable;
            this.Writable = writable;
        }

        public static Type GetTypeFromPropertyInfo(PropertyInfo propertyInfo)
        {
            PropertyType propertyType = propertyInfo.Type;

            if (propertyInfo.Enum != null)
                return propertyInfo.Enum;

            switch (propertyType)
            {
                case PropertyType.Int8:
                    return typeof(System.SByte);

                case PropertyType.UInt8:
                    return typeof(System.Byte);

                case PropertyType.Int16:
                    return typeof(System.Int16);

                case PropertyType.UInt16:
                    return typeof(System.UInt16);

                case PropertyType.Int32:
                    return typeof(System.Int32);

                case PropertyType.UInt32:
                    return typeof(System.UInt32);

                case PropertyType.Int64:
                    return typeof(System.Int64);

                case PropertyType.UInt64:
                    return typeof(System.UInt64);

                case PropertyType.Float:
                    return typeof(System.Single);

                case PropertyType.Double:
                    return typeof(System.Double);

                case PropertyType.Bool:
                    return typeof(bool);

                case PropertyType.String:
                    return typeof(String);

                case PropertyType.Path:
                    return typeof(Path);

                case PropertyType.EntityPtr:
                    return typeof(EntityPtr<>).MakeGenericType(new Type[] { propertyInfo.PtrType });

                case PropertyType.Vector3:
                    return typeof(UnityEngine.Vector3);

                case PropertyType.Vector4:
                    return typeof(UnityEngine.Vector4);

                case PropertyType.Quat:
                    return typeof(UnityEngine.Quaternion);

                //case PropertyType.Matrix3:
                //    return typeof(UnityEngine.Matrix3x3);

                case PropertyType.Matrix4:
                    return typeof(UnityEngine.Matrix4x4);

                case PropertyType.Color:
                    return typeof(UnityEngine.Color);

                case PropertyType.FilePtr:
                    return typeof(FilePtr);

                case PropertyType.EntityHandle:
                    return typeof(EntityHandle);

                case PropertyType.EntityLink:
                    return typeof(EntityLink);

                default:
                    throw new ArgumentException($"Invalid Fox type: {propertyType}.");
            }
        }
    }
}