using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using UnityEngine;

namespace Fox.Core
{
    public class DataSetFile2Reader
    {
        private static readonly EntityFactory entityFactory = new EntityFactory();
        private IDictionary<ulong, string> stringTable;
        private IDictionary<ulong, IEntityPtr> entityPtrRequests = new Dictionary<ulong, IEntityPtr>();
        private IDictionary<ulong, HashSet<EntityHandle>> entityHandleRequests = new Dictionary<ulong, HashSet<EntityHandle>>();

        public class ReadResult
        {
            public List<Entity> Entities;
            public List<GameObject> GameObjects;
            public GameObject DataSetGameObject;
        }

        public ReadResult Read(BinaryReader reader)
        {
            var headerBytes = reader.ReadBytes(32);
            var entityCount = BitConverter.ToInt32(headerBytes, 8);
            var stringTableOffset = BitConverter.ToInt32(headerBytes, 12);
            var entityTableOffset = reader.BaseStream.Position;

            reader.BaseStream.Seek(stringTableOffset, SeekOrigin.Begin);
            this.stringTable = ReadStringTable(reader);
            reader.BaseStream.Seek(entityTableOffset, SeekOrigin.Begin);

            var result = new ReadResult();
            var entities = new Dictionary<ulong, Entity>();
            var gameObjects = new Dictionary<ulong, GameObject>();
            for (int i = 0; i < entityCount; i++)
            {
                var entity = new DataSetFile2EntityReader(RequestEntityPtr, RequestEntityHandle).Read(reader, this.CreateEntity, (hash) => this.stringTable[hash]);
                entities.Add(entity.Address, entity);

                // Create GameObject
                if (entity is DataElement)
                {
                    continue;
                }

                var gameObject = new GameObject();
                if (entity is DataSet)
                {
                    gameObject.name = "DataSet";
                    result.DataSetGameObject = gameObject;
                    continue;
                }

                gameObjects.Add(entity.Address, gameObject);
                var entityComponent = gameObject.AddComponent<FoxEntity>();
                entityComponent.Entity = entity;
            }

            this.ResolveRequests(entities, gameObjects);

            result.Entities = entities.Values.ToList();
            result.GameObjects = gameObjects.Values.ToList();
            return result;
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

        private Entity CreateEntity(ulong classNameHash, ulong address, ushort version, ulong id)
        {
            return entityFactory.Create(this.stringTable[classNameHash], address, version, id);
        }

        private void ResolveRequests(IDictionary<ulong, Entity> entities, IDictionary<ulong, GameObject> gameObjects)
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
                if (entities.ContainsKey(entityHandle.Key) && !(entities[entityHandle.Key] is DataSet))
                {
                    if (!gameObjects.ContainsKey(entityHandle.Key))
                    {
                        // Design issue here: DataElements with EntityHandles to other DataElements
                        // This occurs in NavxAttributePathVolume due to the connections between GraphxSpatialGraphDataNode and GraphxSpatialGraphDataEdge
                        // Not sure how to solve this just yet.
                        UnityEngine.Debug.LogWarning("Requesting an EntityHandle to an Entity with no GameObject. This isn't currently supported.");
                        continue;
                    }

                    foreach (var request in entityHandle.Value)
                    {
                        request.Reset(gameObjects[entityHandle.Key].GetComponent<FoxEntity>());
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
    }
}
