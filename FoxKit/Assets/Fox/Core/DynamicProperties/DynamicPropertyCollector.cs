using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    internal static class DynamicPropertyCollector
    {
        internal static DynamicProperty GetSpecificTypeForDescription(GameObject gameObject, PropertyInfo.PropertyType type, string name, PropertyInfo.ContainerType container, ushort arraySize)
        {
            DynamicProperty property = null;
            switch (container)
            {
                case PropertyInfo.ContainerType.StaticArray:
                {
                    property = type switch
                    {
                        PropertyInfo.PropertyType.UInt8 => gameObject.AddComponent<DynamicProperty_StaticArray_uint8>(),
                        PropertyInfo.PropertyType.UInt32 => gameObject.AddComponent<DynamicProperty_StaticArray_uint32>(),
                        PropertyInfo.PropertyType.UInt64 => gameObject.AddComponent<DynamicProperty_StaticArray_uint64>(),
                        PropertyInfo.PropertyType.Float => gameObject.AddComponent<DynamicProperty_StaticArray_float>(),
                        PropertyInfo.PropertyType.Bool => gameObject.AddComponent<DynamicProperty_StaticArray_bool>(),
                        PropertyInfo.PropertyType.String => gameObject.AddComponent<DynamicProperty_StaticArray_String>(),
                        PropertyInfo.PropertyType.Path => gameObject.AddComponent<DynamicProperty_StaticArray_Path>(),
                        _ => throw new NotSupportedException($"Unsupported DynamicProperty type detected: StaticArray {type}."),
                    };
                    if (property)
                        property.ChangeStaticArraySize(arraySize);
                    
                    break;
                }
                case PropertyInfo.ContainerType.DynamicArray:
                {
                    property = type switch
                    {
                        PropertyInfo.PropertyType.UInt8 => gameObject.AddComponent<DynamicProperty_DynamicArray_uint8>(),
                        PropertyInfo.PropertyType.UInt32 => gameObject.AddComponent<DynamicProperty_DynamicArray_uint32>(),
                        PropertyInfo.PropertyType.UInt64 => gameObject.AddComponent<DynamicProperty_DynamicArray_uint64>(),
                        PropertyInfo.PropertyType.Float => gameObject.AddComponent<DynamicProperty_DynamicArray_float>(),
                        PropertyInfo.PropertyType.Bool => gameObject.AddComponent<DynamicProperty_DynamicArray_bool>(),
                        PropertyInfo.PropertyType.String => gameObject.AddComponent<DynamicProperty_DynamicArray_String>(),
                        PropertyInfo.PropertyType.Path => gameObject.AddComponent<DynamicProperty_DynamicArray_Path>(),
                        _ => throw new NotSupportedException($"Unsupported DynamicProperty type detected: DynamicArray {type}"),
                    };
                    if (property)
                        property.ChangeStaticArraySize(arraySize);
                    
                    break;
                }
                case PropertyInfo.ContainerType.StringMap:
                {
                    property = type switch
                    {
                        PropertyInfo.PropertyType.Path => gameObject.AddComponent<DynamicProperty_StringMap_String>(),
                        PropertyInfo.PropertyType.EntityLink => gameObject.AddComponent<DynamicProperty_StringMap_EntityLink>(),
                        _ => throw new NotSupportedException($"Unsupported DynamicProperty type detected: StringMap {type}"),
                    };
                    
                    break;
                }
            }

            if (property != null)
                property.Name = name;
            
            return property;
        }
    }
}