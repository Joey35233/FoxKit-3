using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;

namespace Fox.Core
{
    public class DataSetFile2Reader
    {
        private static readonly EntityFactory entityFactory = new EntityFactory();
        private IDictionary<ulong, string> stringTable;
        private IDictionary<ulong, IEntityPtr> entityPtrRequests = new Dictionary<ulong, IEntityPtr>();
        private IDictionary<ulong, HashSet<EntityHandle>> entityHandleRequests = new Dictionary<ulong, HashSet<EntityHandle>>();

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
                Entity entity = new DataSetFile2EntityReader(RequestEntityPtr, RequestEntityHandle, RequestEntityLink).Read(reader, this.CreateEntity, (hash) => this.stringTable[hash]);
                entities.Add(entity.Address, entity);
            }

            this.ResolveRequests(entities);
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

        private void ResolveRequests(IDictionary<ulong, Entity> entities)
        {
            foreach(var entityPtr in this.entityPtrRequests)
            {
                if (entities.ContainsKey(entityPtr.Key))
                {
                    entityPtr.Value.Reset(entities[entityPtr.Key]);
                    continue;
                }

                UnityEngine.Debug.LogError("Unable to resolve EntityPtr " + entityPtr.Key.ToString("X8"));
            }

            foreach (var entityHandle in this.entityHandleRequests)
            {
                if (entities.ContainsKey(entityHandle.Key))
                {
                    foreach (var request in entityHandle.Value)
                    {
                        request.Reset(entities[entityHandle.Key]);
                    }
                }
                else
                {
                    UnityEngine.Debug.LogError("Unable to resolve EntityHandle 0x" + entityHandle.Key.ToString("X8"));
                }
            }

            // TODO EntityLink
        }

        public void RequestEntityPtr(ulong address, IEntityPtr ptr)
        {
            if (address == 0)
            {
                return;
            }

            this.entityPtrRequests.Add(address, ptr);
        }

        public void RequestEntityHandle(ulong address, EntityHandle ptr)
        {
            if (address == 0)
            {
                return;
            }

            if (!this.entityHandleRequests.ContainsKey(address))
            {
                this.entityHandleRequests.Add(address, new HashSet<EntityHandle>());
            }

            this.entityHandleRequests[address].Add(ptr);
        }

        public void RequestEntityLink(ulong address, ulong packagePath, ulong archivePath, ulong nameInArchive, EntityLink entityLink)
        {

        }
    }
}
