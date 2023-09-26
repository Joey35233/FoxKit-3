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

        private readonly HashSet<Kernel.String> strings = new();
        private readonly Dictionary<Entity, ulong> addresses = new();
        private readonly Dictionary<Entity, ulong> ids = new();

        private ulong lastAddress = 0x10000000u;
        private ulong lastId = 0;

        public void Write(BinaryWriter writer, UnityEngine.SceneManagement.Scene sceneToExport)
        {
            EditorUtility.DisplayProgressBar("FoxKit", "Gathering Entities...", 0);

            List<Entity> entities = GetEntitiesToExport(sceneToExport, out CreateDataSetResult result);
            if (result == CreateDataSetResult.Failure)
            {
                EditorUtility.ClearProgressBar();
                return;
            }

            IDictionary<Entity, EntityExportContext> exportContexts = new Dictionary<Entity, EntityExportContext>();

            EditorUtility.DisplayProgressBar("FoxKit", "Converting Entities...", 0);
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

            EditorUtility.DisplayProgressBar("FoxKit", $"Writing string table...", 0.99f);
            int stringTableOffset = WriteStringTable(writer);
            long endPosition = WriteHeader(writer, entities, headerPosition, stringTableOffset);
            EditorUtility.ClearProgressBar();

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
            foreach (Kernel.String foxString in strings)
            {
                if (!System.String.IsNullOrEmpty(foxString.CString))
                {
                    WriteStringTableEntry(writer, foxString);
                }
            }

            writer.Write((long)0);
            writer.BaseStream.AlignWrite(16, 0x00);
            writer.Write(new byte[] { 0x00, 0x00, 0x65, 0x6E, 0x64 });
            writer.BaseStream.AlignWrite(16, 0x00);
            return stringTableOffset;
        }

        private void WriteEntities(BinaryWriter writer, List<Entity> entities, IDictionary<Entity, EntityExportContext> exportContexts)
        {
            int writtenEntities = 0;
            int entityCount = entities.Count;

            foreach (Entity entity in entities)
            {
                float progress = (float)writtenEntities / (float)entityCount;
                EditorUtility.DisplayProgressBar("FoxKit", $"Writing Entities ({writtenEntities + 1}/{entityCount})...", progress);

                WriteEntity(writer, (uint)addresses[entity], ids[entity], entity, exportContexts[entity]);
                writtenEntities++;
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
            var dataSet = entities.FirstOrDefault(ent => ent is DataSet) as DataSet;
            if (dataSet == null)
            {
                dataSet = new GameObject("DataSet").AddComponent<DataSet>();
                entities.Insert(0, dataSet);
            }

            dataSet.name = Kernel.String.Empty;
            dataSet.ClearData();

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

                    var data = entity as Data;

                    data.SetDataSet(dataSet);
                }

                _ = usedNames.Add(entity.name);
            }

            MoveItemAtIndexToFront(entities, dataSetIndex);
            return CreateDataSetResult.Success;
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

        private void WriteStringTableEntry(BinaryWriter writer, Kernel.String foxString)
        {
            byte[] nameBytes = foxString.CString == null ? new byte[0] : Encoding.UTF8.GetBytes(foxString.CString);
            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(foxString.Hash));
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
