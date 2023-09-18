using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            List<Entity> entities = GetEntitiesToExport(sceneToExport);

            // Perform any last minute property updates
            foreach (Entity entity in entities)
            {
                AssignAddress(entity);
                AssignId(entity);
                entity.PrepareForExport();
            }

            long headerPosition = writer.BaseStream.Position;
            writer.BaseStream.Position += HeaderSize;

            WriteEntities(writer, entities);
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
            foreach (Kernel.String foxString in strings.Distinct())
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

        private void WriteEntities(BinaryWriter writer, List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                WriteEntity(writer, (uint)addresses[entity], ids[entity], entity);
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

        private List<Entity> GetEntitiesToExport(UnityEngine.SceneManagement.Scene sceneToExport)
        {
            var entities = (from Entity entityComponent in GameObject.FindObjectsOfType<Entity>()
                            where entityComponent.ShouldWriteToFox2() && entityComponent.gameObject.scene == sceneToExport
                            select entityComponent).ToList();

            //_ = entities.RemoveAll(ent => ent.GetClassEntityInfo().Name.CString == "TppTextureLoader");
            //_ = entities.RemoveAll(ent => ent.GetClassEntityInfo().Name.CString == "DataIdentifier");

            CreateDataSet(entities);

            var allEntities = new HashSet<Entity>();
            foreach (Entity entity in entities)
            {
                if (!allEntities.Contains(entity))
                {
                    _ = allEntities.Add(entity);
                }

                entity.CollectReferencedEntities(allEntities);
            }
                        
            return allEntities.ToList();
        }

        private static void CreateDataSet(List<Entity> entities)
        {
            var dataSet = entities.First(ent => ent is DataSet) as DataSet;
            dataSet.name = Kernel.String.Empty;
            dataSet.ClearData();
            foreach (Entity entity in entities)
            {
                if (entity is DataSet)
                {
                    continue;
                }
                if (entity is Data)
                {
                    var data = entity as Data;
                    dataSet.AddData(data.name, new EntityPtr<Data>(data));
                    data.SetDataSet(EntityHandle.Get(dataSet));
                }
            }

            entities.Insert(0, dataSet);
        }

        private void WriteStringTableEntry(BinaryWriter writer, Kernel.String foxString)
        {
            byte[] nameBytes = foxString.CString == null ? new byte[0] : Encoding.UTF8.GetBytes(foxString.CString);
            writer.Write(Kernel.HashingBitConverter.StrCodeToUInt64(foxString.Hash));
            writer.Write((uint)nameBytes.Length);
            writer.Write(nameBytes);
        }

        private void WriteEntity(BinaryWriter writer, uint address, ulong id, Entity entity)
        {
            var entityWriter = new DataSetFile2EntityWriter();
            entityWriter.Write(entity, addresses, strings, address, id, writer.BaseStream);
        }
    }
}
