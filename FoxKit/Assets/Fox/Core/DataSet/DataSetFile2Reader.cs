using Fox.Core.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox.Core
{
    internal struct DataSetFile2Reader
    {
        // State
        private Dictionary<StrCode, string> StringTable;
        private Dictionary<ulong, Entity> EntityAddressMap;
        
        // Logger
        private TaskLogger Logger;

        public ReadOnlySpan<Entity> Read(ReadOnlySpan<byte> data, TaskLogger logger)
        {
            Logger = logger;
            StringTable = new Dictionary<StrCode, string>
            {
                { HashingBitConverter.ToStrCode(0), null },
                { new StrCode(string.Empty), string.Empty },
            };

            unsafe
            {
                fixed (byte* dataPtr = data)
                {
                    // Header
                    DataSetFile2.FileHeader* header = (DataSetFile2.FileHeader*)dataPtr;

                    // Read string table
                    if (header->StringTableOffset > 0)
                    {
                        DataSetFile2.StringData* stringData = (DataSetFile2.StringData*)((byte*)header + header->StringTableOffset);
                        while (stringData->Hash.IsValid() && stringData->Length > 0)
                        {
                            byte* literalData = (byte*)(stringData + 1);
                            
                            if (!StringTable.ContainsKey(stringData->Hash))
                            {
                                string literal = Marshal.PtrToStringAnsi((IntPtr)literalData, stringData->Length);

                                StringTable.Add(stringData->Hash, literal);
                            }
                            
                            stringData = (DataSetFile2.StringData*)(literalData + stringData->Length);
                        }
                    }

			        // v rlc with sai's direction, from Atvaark's FoxTool code
                    // TODO: Make different version or just figure out GZs weird path encryption
                    // string path = "Assets/Fox/Core/DataSet/fox_dictionary.txt";
                    // foreach (string line in System.IO.File.ReadAllLines(path))
                    // {
                    //     _ = stringTable.TryAdd(new StrCode(line), line);
                    // }
			        // ^

                    EntityAddressMap = new Dictionary<ulong, Entity>();
                    Entity[] entities = new Entity[header->EntityCount];
                    if (header->EntityCount > 0 && header->EntitiesOffset > 0)
                    {
                        // Initial read of each addressed Entity
                        DataSetFile2.EntityDef* entityDef = (DataSetFile2.EntityDef*)((byte*)header + header->EntitiesOffset);
                        for (uint i = 0; i < header->EntityCount; i++)
                        {
                            GameObject gameObject = new GameObject();
                            gameObject.SetActive(false);

                            Debug.Assert(entityDef->HeaderSize == 0x40);
                            Debug.Assert(entityDef->Signature == 0x00746E65); // "ent\0"

                            // TODO: Can turn into Dictionary that uses StrCode directly
                            EntityInfo entityInfo = EntityInfo.GetEntityInfo(entityDef->ClassName.ToString());
                            
                            Entity entity = gameObject.AddComponent(entityInfo.Type) as Entity;
                            EntityAddressMap.Add(entityDef->Address, entity);
                            entities[i] = entity;
                            
                            entityDef = (DataSetFile2.EntityDef*)((byte*)entityDef + entityDef->NextEntityOffset);
                        }

                        // Reset iterator and read properties
                        entityDef = (DataSetFile2.EntityDef*)((byte*)header + header->EntitiesOffset);
                        Dictionary<Type, int> typeCounts = new Dictionary<Type, int>();
                        for (uint i = 0; i < header->EntityCount; i++)
                        {
                            Entity entity = entities[i];
                                
                            // Static properties
                            DataSetFile2.PropertyDef* propertyDef = (DataSetFile2.PropertyDef*)((byte*)entityDef + entityDef->StaticPropertiesOffset);
                            for (int j = 0; j < entityDef->StaticPropertyCount; j++)
                            {
                                PropertyInfo.PropertyType dataType = propertyDef->DataType;
                                PropertyInfo.ContainerType containerType = propertyDef->ContainerType;
                                ushort arraySize = propertyDef->ArraySize;

                                // TODO: REMOVE
                                string propertyName = StringTable[propertyDef->Name];

                                if (containerType == PropertyInfo.ContainerType.StaticArray && arraySize == 1)
                                {
                                    object value = ReadPropertyValue(propertyDef, 0);
                                    entity.SetProperty(propertyName, new Value(value));
                                }
                                else if (containerType == PropertyInfo.ContainerType.StringMap)
                                {
                                    for (ushort k = 0; k < propertyDef->ArraySize; k++)
                                    {
                                        byte* payload = (byte*)propertyDef + propertyDef->PayloadOffset;
                                        
                                        string key = StringTable[*(StrCode*)payload];
                                        object value = ReadPropertyValue(propertyDef, k);
                                        entity.SetPropertyElement(propertyName, key, new Value(value));
                                    }
                                }
                                else
                                {
                                    for (ushort k = 0; k < propertyDef->ArraySize; k++)
                                    {
                                        object value = ReadPropertyValue(propertyDef, k);
                                        entity.SetPropertyElement(propertyName, k, new Value(value));
                                    }
                                }
                                
                                propertyDef = (DataSetFile2.PropertyDef*)((byte*)propertyDef + propertyDef->NextPropertyOffset);
                            }

                            // Dynamic properties
                            propertyDef = (DataSetFile2.PropertyDef*)((byte*)entityDef + entityDef->DynamicPropertiesOffset);
                            for (int j = 0; j < entityDef->DynamicPropertyCount; j++)
                            {
                                PropertyInfo.PropertyType dataType = propertyDef->DataType;
                                PropertyInfo.ContainerType containerType = propertyDef->ContainerType;
                                ushort arraySize = propertyDef->ArraySize;

                                string propertyName = StringTable[propertyDef->Name];
                                entity.AddDynamicProperty(dataType, propertyName, arraySize, containerType);

                                if (containerType == PropertyInfo.ContainerType.StringMap)
                                {
                                    for (ushort k = 0; k < propertyDef->ArraySize; k++)
                                    {
                                        byte* payload = (byte*)propertyDef + propertyDef->PayloadOffset;
                                        
                                        string key = StringTable[*(StrCode*)payload];
                                        object value = ReadPropertyValue(propertyDef, k);
                                        entity.SetPropertyElement(propertyName, key, new Value(value));
                                    }
                                }
                                else
                                {
                                    for (ushort k = 0; k < propertyDef->ArraySize; k++)
                                    {
                                        object value = ReadPropertyValue(propertyDef, k);
                                        entity.SetPropertyElement(propertyName, k, new Value(value));
                                    }
                                }
                                
                                propertyDef = (DataSetFile2.PropertyDef*)((byte*)propertyDef + propertyDef->NextPropertyOffset);
                            }
                            
                            // Naming
                            if (entity is DataSet)
                            {
                                entity.name = "DataSet";
                            }
                            else if (entity is not Data)
                            {
                                Type type = entity.GetType();
                            
                                // Grab current type count and increment registry
                                int typeCount = 0;
                                if (typeCounts.TryGetValue(type, out typeCount))
                                {
                                    typeCounts[type] = typeCount + 1;
                                }
                                else
                                {
                                    typeCounts.Add(type, typeCount);
                                }
                                // Actually name Entity
                                entity.name = $"{type.Name}{typeCount:D4}";
                            }
                            
                            entityDef = (DataSetFile2.EntityDef*)((byte*)entityDef + entityDef->NextEntityOffset);
                        }
                        
                        // Post
                        foreach (Entity entity in entities)
                        {
                            entity.OnDeserializeEntity(logger);
                            
                            entity.gameObject.SetActive(true);
                        }
                    }

                    return entities;
                }
            }
        }

        private unsafe object ReadPropertyValue(DataSetFile2.PropertyDef* propertyDef, ushort index)
        {
            byte* payload = (byte*)propertyDef + propertyDef->PayloadOffset;

            uint stride = PropertyInfo.SerializedPropertyStrideTable[(uint)propertyDef->DataType];
            if (propertyDef->ContainerType == PropertyInfo.ContainerType.StringMap)
            {
                stride += 8; // Key
                
                stride = (uint)Fox.AlignmentUtils.Align(stride, 0x10u);

                payload += index * stride + 8; // Current key
            }
            else
            {
                payload += index * stride;
            }

            switch (propertyDef->DataType)
            {
                case PropertyInfo.PropertyType.Int8:
                    return *(sbyte*)payload;
                case PropertyInfo.PropertyType.UInt8:
                    return *(byte*)payload;
                case PropertyInfo.PropertyType.Int16:
                    return *(short*)payload;
                case PropertyInfo.PropertyType.UInt16:
                    return *(ushort*)payload;
                case PropertyInfo.PropertyType.Int32:
                    return *(int*)payload;
                case PropertyInfo.PropertyType.UInt32:
                    return *(uint*)payload;
                case PropertyInfo.PropertyType.Int64:
                    return *(long*)payload;
                case PropertyInfo.PropertyType.UInt64:
                    return *(ulong*)payload;
                case PropertyInfo.PropertyType.Float:
                    return *(float*)payload;
                case PropertyInfo.PropertyType.Double:
                    return *(double*)payload;
                case PropertyInfo.PropertyType.Bool:
                    return *(bool*)payload;
                case PropertyInfo.PropertyType.String:
                    return StringTable[*(StrCode*)payload];
                case PropertyInfo.PropertyType.Path:
                    return new Path(StringTable[*(StrCode*)payload]);
                case PropertyInfo.PropertyType.EntityPtr:
                {
                    ulong address = *(ulong*)payload;
                    if (!EntityAddressMap.TryGetValue(address, out Entity entity) && address != 0x0)
                        Logger.AddError($"Unable to resolve address 0x{address:X8}.");

                    return entity;
                }
                case PropertyInfo.PropertyType.Vector3:
                    return *(Vector3*)payload;
                case PropertyInfo.PropertyType.Vector4:
                    return *(Vector4*)payload;
                case PropertyInfo.PropertyType.Quat:
                    return *(Quaternion*)payload;
                case PropertyInfo.PropertyType.Matrix3:
                    throw new NotImplementedException();
                case PropertyInfo.PropertyType.Matrix4:
                    return *(Matrix4x4*)payload;
                case PropertyInfo.PropertyType.Color:
                    return *(Color*)payload;
                case PropertyInfo.PropertyType.FilePtr:
                    return new FilePtr(new Path(StringTable[*(StrCode*)payload]));
                case PropertyInfo.PropertyType.EntityHandle:
                {
                    ulong address = *(ulong*)payload;
                    if (!EntityAddressMap.TryGetValue(address, out Entity entity) && address != 0x0)
                        Logger.AddError($"Unable to resolve address 0x{address:X8}.");

                    return entity;
                }
                case PropertyInfo.PropertyType.EntityLink:
                {
                    DataSetFile2.EntityLinkDef entityLinkDef = *(DataSetFile2.EntityLinkDef*)payload;

                    ulong address = entityLinkDef.Address;
                    if (!EntityAddressMap.TryGetValue(address, out Entity entity) && address != 0x0)
                        Logger.AddError($"Unable to resolve address 0x{address:X8}.");
                    
                    EntityLink entityLink = new EntityLink
                    {
                        packagePath = new Path(StringTable[entityLinkDef.PackagePathHash]),
                        archivePath = new Path(StringTable[entityLinkDef.ArchivePathHash]),
                        nameInArchive = StringTable[entityLinkDef.NameInArchiveHash],
                        handle = entity,
                    };

                    return entityLink;
                }
                case PropertyInfo.PropertyType.PropertyInfo:
                    throw new NotImplementedException();
                case PropertyInfo.PropertyType.WideVector3:
                    throw new NotImplementedException();
                default:
                    Logger.AddError($"Unexpected property type: {propertyDef->DataType}.");
                    throw new InvalidOperationException();
            }
        }
    }
}