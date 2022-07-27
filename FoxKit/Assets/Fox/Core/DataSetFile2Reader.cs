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
        private IDictionary<ulong, string> stringTable;
        private IDictionary<ulong, Action<Entity>> entityPtrSetRequests = new Dictionary<ulong, Action<Entity>>();
        private IDictionary<ulong, HashSet<Action<Entity>>> entityHandleSetRequests = new Dictionary<ulong, HashSet<Action<Entity>>>();

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
                var addressedEntity = new DataSetFile2AddressedEntityReader(RequestSetEntityPtr, RequestSetEntityHandle).Read(reader, this.CreateEntity, (hash) => this.stringTable[hash]);
                entities.Add(addressedEntity.Address, addressedEntity.Entity);

                // Create GameObject
                if (addressedEntity.Entity is DataElement)
                {
                    continue;
                }

                var gameObject = new GameObject();
                if (addressedEntity.Entity is DataSet)
                {
                    gameObject.name = "DataSet";
                    result.DataSetGameObject = gameObject;
                    continue;
                }

                gameObjects.Add(addressedEntity.Address, gameObject);
                var entityComponent = gameObject.AddComponent<FoxEntity>();
                entityComponent.Entity = addressedEntity.Entity;
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

        private Entity CreateEntity(ulong classNameHash)
        {
            return EntityInfo.ConstructEntity(classNameHash);
        }

        private void ResolveRequests(IDictionary<ulong, Entity> entities, IDictionary<ulong, GameObject> gameObjects)
        {
            foreach(var setEntityPtr in this.entityPtrSetRequests)
            {
                if (entities.ContainsKey(setEntityPtr.Key))
                {
                    setEntityPtr.Value(entities[setEntityPtr.Key]);
                    continue;
                }

                UnityEngine.Debug.LogError("Unable to resolve EntityPtr " + setEntityPtr.Key.ToString("X8"));
            }

            foreach (var setEntityHandle in this.entityHandleSetRequests)
            {
                if (entities.ContainsKey(setEntityHandle.Key))
                {
                    if (!gameObjects.ContainsKey(setEntityHandle.Key))
                    {
                        foreach (var request in setEntityHandle.Value)
                        {
                            request(entities[setEntityHandle.Key]);
                        }
                        continue;
                    }

                    foreach (var request in setEntityHandle.Value)
                    {
                        request(gameObjects[setEntityHandle.Key].GetComponent<FoxEntity>().Entity);
                    }
                }
                else
                {
                    UnityEngine.Debug.LogError("Unable to resolve EntityHandle 0x" + setEntityHandle.Key.ToString("X8"));
                }
            }

            // TODO EntityLink
        }

        public void RequestSetEntityPtr(ulong address, Action<Entity> setPtr)
        {
            if (address == 0)
            {
                return;
            }

            this.entityPtrSetRequests.Add(address, setPtr);
        }

        public void RequestSetEntityHandle(ulong address, Action<Entity> setHandle)
        {
            if (address == 0)
            {
                return;
            }

            if (!this.entityHandleSetRequests.ContainsKey(address))
            {
                this.entityHandleSetRequests.Add(address, new HashSet<Action<Entity>>());
            }

            this.entityHandleSetRequests[address].Add(setHandle);
        }
    }
}
