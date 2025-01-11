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
                        PropertyInfo.PropertyType.Float => gameObject.AddComponent<DynamicProperty_StaticArray_float>(),
                        PropertyInfo.PropertyType.Bool => gameObject.AddComponent<DynamicProperty_StaticArray_bool>(),
                        PropertyInfo.PropertyType.String => gameObject.AddComponent<DynamicProperty_StaticArray_String>(),
                        PropertyInfo.PropertyType.Path => gameObject.AddComponent<DynamicProperty_StaticArray_Path>(),
                        _ => throw new NotSupportedException("Unsupported DynamicProperty type detected."),
                    };
                    if (property)
                        property.ChangeStaticArraySize(arraySize);
                    
                    break;
                }
                case PropertyInfo.ContainerType.DynamicArray:
                {
                    property = type switch
                    {
                        _ => throw new NotSupportedException("Unsupported DynamicProperty type detected."),
                    };
                    
                    break;
                }
                case PropertyInfo.ContainerType.StringMap:
                {
                    property = type switch
                    {
                        PropertyInfo.PropertyType.Path => gameObject.AddComponent<DynamicProperty_StringMap_String>(),
                        _ => throw new NotSupportedException("Unsupported DynamicProperty type detected."),
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