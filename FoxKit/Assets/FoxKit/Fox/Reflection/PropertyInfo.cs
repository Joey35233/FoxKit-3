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
    }
}