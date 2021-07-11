using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;

namespace Fox.Core
{
    public class DataSetFile2Reader
    {
        private static readonly EntityFactory entityFactory = new EntityFactory();
        private IDictionary<ulong, string> stringTable;

        public List<Entity> Read(BinaryReader reader)
        {
            var headerBytes = reader.ReadBytes(32);
            var entityCount = BitConverter.ToInt32(headerBytes, 8);
            var stringTableOffset = BitConverter.ToInt32(headerBytes, 12);
            var entityTableOffset = reader.BaseStream.Position;

            reader.BaseStream.Seek(stringTableOffset, SeekOrigin.Begin);
            this.stringTable = ReadStringTable(reader);
            reader.BaseStream.Seek(entityTableOffset, SeekOrigin.Begin);

            var entities = new Dictionary<ulong, Entity>();
            for (int i = 0; i < entityCount; i++)
            {
                Entity entity = new DataSetFile2EntityReader(RequestEntityPtr, RequestEntityHandle, RequestFilePtr, RequestEntityLink).Read(reader, this.CreateEntity, (hash) => this.stringTable[hash]);
                entities.Add(entity.Address, entity);
            }

            foreach(var ent in entities.Values)
            {
                UnityEngine.Debug.Log(ent);
            }

            return entities.Values.ToList();
        }

        private static IDictionary<ulong, string> ReadStringTable(BinaryReader reader)
        {
            var dictionary = new Dictionary<ulong, string>
            {
                { 203000540209048, string.Empty }
            };

            while (true)
            {
                var hash = reader.ReadUInt64();
                if (hash == 0)
                {
                    return dictionary;
                }

                var length = reader.ReadInt32();
                var literal = reader.ReadChars(length);
                dictionary.Add(hash, new string(literal));
            }
        }

        private Entity CreateEntity(ulong classNameHash, ulong address, ushort version, ushort idA, ushort idB)
        {
            return entityFactory.Create(this.stringTable[classNameHash], address, version, idA, idB);
        }

        public void RequestFilePtr(ulong path, FilePtr<Core.File> ptr)
        {

        }

        public void RequestEntityPtr(ulong address, IEntityPtr ptr)
        {

        }

        public void RequestEntityHandle(ulong address, EntityHandle ptr)
        {

        }

        public void RequestEntityLink(ulong address, ulong packagePath, ulong archivePath, ulong nameInArchive, EntityLink entityLink)
        {

        }
    }
}
