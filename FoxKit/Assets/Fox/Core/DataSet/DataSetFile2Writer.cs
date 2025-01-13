using Fox.Fio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    public class DataSetFile2Writer
    {
        private const int HeaderSize = 32;
        private const uint MagicNumber1 = 0x786f62f2;
        private const uint MagicNumber2 = 0x35;

        private readonly HashSet<string> strings = new();
        private readonly Dictionary<Entity, ulong> addresses = new();
        private readonly Dictionary<Entity, ulong> ids = new();

        private ulong lastAddress = 0x10000000u;
        private ulong lastId = 0;

        public void Write(BinaryWriter writer, UnityEngine.SceneManagement.Scene sceneToExport)
        {
            List<Entity> entities = GetEntitiesToExport(sceneToExport, out CreateDataSetResult result);
            if (result == CreateDataSetResult.Failure)
            {
                return;
            }

            IDictionary<Entity, EntityExportContext> exportContexts = new Dictionary<Entity, EntityExportContext>();

            foreach (Entity entity in entities)
            {
                AssignAddress(entity);
                AssignId(entity);

                var context = new EntityExportContext();
                exportContexts.Add(entity, context);
                entity.OverridePropertiesForExport(context);
            }

            long headerPosition = writer.BaseStream.Position;
            writer.BaseStream.Position += HeaderSize;

            WriteEntities(writer, entities, exportContexts);

            int stringTableOffset = WriteStringTable(writer);
            long endPosition = WriteHeader(writer, entities, headerPosition, stringTableOffset);

            writer.BaseStream.Position = endPosition;
        }

        private void AssignAddress(Entity entity)
        {
            ulong address = lastAddress + 0x70;
            addresses.Add(entity, address);
            lastAddress = address;
        }

        private void AssignId(Entity entity)
        {
            ulong id = lastId + 1;
            ids.Add(entity, id);
            lastId = id;
        }

        private int WriteStringTable(BinaryWriter writer)
        {
            int stringTableOffset = (int)writer.BaseStream.Position;

            // Remove dupes and write string table
            foreach (string foxString in strings)
            {
                if (!string.IsNullOrEmpty(foxString))
                {
                    WriteStringTableEntry(writer, foxString);
                }
            }

            writer.Write((long)0);
            writer.AlignWrite(16, 0x00);
            writer.Write(new byte[] { 0x00, 0x00, 0x65, 0x6E, 0x64 });
            writer.AlignWrite(16, 0x00);
            return stringTableOffset;
        }

        private void WriteEntities(BinaryWriter writer, List<Entity> entities, IDictionary<Entity, EntityExportContext> exportContexts)
        {
            foreach (Entity entity in entities)
            {
                WriteEntity(writer, (uint)addresses[entity], ids[entity], entity, exportContexts[entity]);
            }
        }

        private static long WriteHeader(BinaryWriter writer, List<Entity> entities, long headerPosition, int stringTableOffset)
        {
            long endPosition = writer.BaseStream.Position;
            writer.BaseStream.Position = headerPosition;

            int entityCount = entities.Count;
            writer.Write(MagicNumber1);
            writer.Write(MagicNumber2);
            writer.Write(entityCount);
            writer.Write(stringTableOffset);
            writer.Write(HeaderSize);
            writer.WriteZeros(12);
            return endPosition;
        }

        private List<Entity> GetEntitiesToExport(UnityEngine.SceneManagement.Scene sceneToExport, out CreateDataSetResult result)
        {
            var entities = (from Entity entityComponent in GameObject.FindObjectsOfType<Entity>()
                            where entityComponent.ShouldWriteToFox2() && entityComponent.gameObject.scene == sceneToExport
                            select entityComponent).ToList();

            result = CreateDataSet(entities);
            return entities;
        }

        enum CreateDataSetResult
        {
            Success,
            Failure
        }

        private static CreateDataSetResult CreateDataSet(List<Entity> entities)
        {
            DataSet dataSet = entities.FirstOrDefault(ent => ent is DataSet) as DataSet;
            if (dataSet == null)
            {
                dataSet = new GameObject("DataSet").AddComponent<DataSet>();
                entities.Insert(0, dataSet);
            }

            // Validate Entities
            int dataSetIndex = -1;
            var usedNames = new HashSet<string>();
            for (int i = 0; i < entities.Count; i++)
            {
                Entity entity = entities[i];
                if (entity is DataSet)
                {
                    dataSetIndex = i;
                    continue;
                }
                if (entity is Data)
                {
                    if (usedNames.Contains(entity.name))
                    {
                        Debug.LogError($"Two or more Datas share a name ('{entity.name}'). Exported Datas require unique names.");
                        return CreateDataSetResult.Failure;
                    }
                }

                _ = usedNames.Add(entity.name);
            }

            // Once Entities have been validated, update Data properties
            dataSet.ClearDataList();
            for (int i = 0; i < entities.Count; i++)
            {
                if (entities[i] is Data data and not DataSet)
                {
                    dataSet.AddData(data);
                    UpdateDataOwners(data);
                }
            }

            MoveItemAtIndexToFront(entities, dataSetIndex);
            return CreateDataSetResult.Success;
        }

        private static void UpdateDataOwners(Data data)
        { 
            EntityInfo entityInfo = data.GetClassEntityInfo();
            do
            {
                // TODO: Might need to consider EntityLink
                foreach (PropertyInfo propertyInfo in entityInfo.OrderedStaticProperties)
                {
                    if (propertyInfo.Type == PropertyInfo.PropertyType.EntityPtr)
                    {
                        switch (propertyInfo.Container)
                        {
                            case PropertyInfo.ContainerType.StaticArray:
                                if (propertyInfo.ArraySize == 1)
                                {
                                    DataElement element = data.GetProperty(propertyInfo.Name).GetValueAsEntityPtr<DataElement>();
                                    if (element != null)
                                        element.SetOwner(data);
                                }
                                else
                                {
                                    DataElement[] staticArray = data.GetProperty(propertyInfo.Name).GetValueAsIList() as DataElement[];
                                    if (staticArray is null)
                                        continue;
                                    foreach (var element in staticArray)
                                    {
                                        if (element != null)
                                            element.SetOwner(data);
                                    }
                                }

                                break;
                            case PropertyInfo.ContainerType.DynamicArray:
                                DynamicArray<DataElement> dynamicArray = data.GetProperty(propertyInfo.Name).GetValueAsIList() as DynamicArray<DataElement>;
                                if (dynamicArray is null)
                                    continue;
                                foreach (var element in dynamicArray)
                                {
                                    if (element != null)
                                        element.SetOwner(data);
                                }

                                break;
                            case PropertyInfo.ContainerType.StringMap:
                                StringMap<DataElement> stringMap = data.GetProperty(propertyInfo.Name).GetValueAsStringMap<DataElement>() as StringMap<DataElement>;
                                if (stringMap is null)
                                    continue;
                                foreach (var element in stringMap)
                                {
                                    if (element.Value != null)
                                        element.Value.SetOwner(data);
                                }

                                break;
                        }
                    }
                }

                entityInfo = entityInfo.Super;
            } while (entityInfo != null);
        }

        /// <summary>
        /// TODO Move into extension method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        private static void MoveItemAtIndexToFront<T>(List<T> list, int index)
        {
            T item = list[index];
            for (int i = index; i > 0; i--)
                list[i] = list[i - 1];
            list[0] = item;
        }

        private void WriteStringTableEntry(BinaryWriter writer, string foxString)
        {
            byte[] nameBytes = foxString == null ? new byte[0] : Encoding.UTF8.GetBytes(foxString);
            writer.Write(Fox.HashingBitConverter.StrCodeToUInt64(new StrCode(foxString)));
            writer.Write((uint)nameBytes.Length);
            writer.Write(nameBytes);
        }

        private void WriteEntity(BinaryWriter writer, uint address, ulong id, Entity entity, EntityExportContext entityExportContext)
        {
            var entityWriter = new DataSetFile2EntityWriter();
            entityWriter.Write(entity, entityExportContext, addresses, strings, address, id, writer.BaseStream);
        }
    }
}
