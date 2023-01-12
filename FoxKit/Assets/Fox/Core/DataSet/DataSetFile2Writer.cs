using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    public class DataSetFile2Writer
    {
        private const int HeaderSize = 32;
        private const uint MagicNumber1 = 0x786f62f2;
        private const uint MagicNumber2 = 0x35;

        private readonly List<Kernel.String> strings = new();
        private readonly Dictionary<Entity, ulong> addresses = new();
        private readonly Dictionary<Entity, ulong> ids = new();

        private ulong lastAddress = 0x10000000u;
        private ulong lastId = 0;

        public void Write(BinaryWriter writer, UnityEngine.SceneManagement.Scene sceneToExport)
        {
            var entities = GetEntitiesToExport(sceneToExport);

            // Perform any last minute property updates
            foreach (var entity in entities)
            {
                AssignAddress(entity);
                AssignId(entity);
                entity.PrepareForExport();
            }

            // Skip header for now
            var headerPosition = writer.BaseStream.Position;
            writer.BaseStream.Position += HeaderSize;

            WriteEntities(writer, entities);
            int stringTableOffset = WriteStringTable(writer);

            var endPosition = WriteHeader(writer, entities, headerPosition, stringTableOffset);
            writer.BaseStream.Position = endPosition;
        }

        private void AssignAddress(Entity entity)
        {
            var address = lastAddress + 0x70;
            addresses.Add(entity, address);
            lastAddress = address;
        }

        private void AssignId(Entity entity)
        {
            var id = lastId + 1;
            ids.Add(entity, id);
            lastId = id;
        }

        private int WriteStringTable(BinaryWriter writer)
        {
            var stringTableOffset = (int)writer.BaseStream.Position;
            foreach (var foxString in strings)
            {
                if (!string.IsNullOrEmpty(foxString.CString))
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

        private void WriteEntities(BinaryWriter writer, List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                WriteEntity(writer, (uint)addresses[entity], ids[entity], entity);
            }
        }

        private static long WriteHeader(BinaryWriter writer, List<Entity> entities, long headerPosition, int stringTableOffset)
        {
            long endPosition = writer.BaseStream.Position;
            writer.BaseStream.Position = headerPosition;

            var entityCount = entities.Count;
            writer.Write(MagicNumber1);
            writer.Write(MagicNumber2);
            writer.Write(entityCount);
            writer.Write(stringTableOffset);
            writer.Write(HeaderSize);
            writer.WriteZeros(12);
            return endPosition;
        }

        private static List<Entity> GetEntitiesToExport(UnityEngine.SceneManagement.Scene sceneToExport)
        {
            var entities = (from FoxEntity entityComponent in GameObject.FindObjectsOfType<FoxEntity>()
                            where entityComponent.Entity != null && entityComponent.Entity.ShouldWriteToFox2() && entityComponent.gameObject.scene == sceneToExport
                            select entityComponent.Entity).ToList();

            CreateDataSet(entities);
            return entities;
        }

        private static void CreateDataSet(List<Entity> entities)
        {
            var dataSet = new DataSet();
            foreach (var entity in entities)
            {
                if (entity is Data)
                {
                    // TODO add to dataList
                }
            }

            entities.Insert(0, dataSet);
        }

        private void WriteStringTableEntry(BinaryWriter writer, Kernel.String foxString)
        {
            // TODO
        }

        private void WriteEntity(BinaryWriter writer, uint address, ulong id, Entity entity)
        {
            var entityWriter = new DataSetFile2EntityWriter();
            entityWriter.Write(entity, address, id, writer.BaseStream);
        }
    }
}
