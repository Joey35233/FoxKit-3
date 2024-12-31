using Fox.Core.Utils;
using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fox.Core
{
    public class DataSetFile2Reader
    {
        private IDictionary<StrCode, string> stringTable;
        private readonly IDictionary<ulong, Action<Entity>> entityPtrSetRequests = new Dictionary<ulong, Action<Entity>>();
        private readonly IDictionary<ulong, HashSet<Action<Entity>>> entityHandleSetRequests = new Dictionary<ulong, HashSet<Action<Entity>>>();
        private TaskLogger logger;

        public class ReadResult
        {
            public List<GameObject> GameObjects;
            public GameObject DataSetGameObject;
            public IDictionary<TransformData, TransformData> TransformDataChildToParentMap = new Dictionary<TransformData, TransformData>();
        }

        public ReadResult Read(FileStreamReader reader, TaskLogger logger)
        {
            this.logger = logger;

            byte[] headerBytes = reader.ReadBytes(32);
            int entityCount = BitConverter.ToInt32(headerBytes, 8);
            int stringTableOffset = BitConverter.ToInt32(headerBytes, 12);
            long entityTableOffset = reader.BaseStream.Position;

            reader.Seek(stringTableOffset);
            stringTable = ReadStringTable(reader);

			// v rlc with sai's direction, from Atvaark's FoxTool code
            // TODO: Make different version or just figure out GZs weird path encryption
            // string path = "Assets/Fox/Core/DataSet/fox_dictionary.txt";
            // foreach (string line in System.IO.File.ReadAllLines(path))
            // {
            //     _ = stringTable.TryAdd(new StrCode(line), line);
            // }
			// ^

            reader.Seek(entityTableOffset);

            var result = new ReadResult();
            var entities = new Dictionary<ulong, Entity>();
            var gameObjects = new Dictionary<ulong, GameObject>();
            for (int i = 0; i < entityCount; i++)
            {
                var gameObject = new GameObject();

                AddressedEntity addressedEntity = new DataSetFile2AddressedEntityReader(RequestSetEntityPtr, RequestSetEntityHandle, result.TransformDataChildToParentMap, logger)
                    .Read(reader, gameObject, (hash) => stringTable[hash]);
                entities.Add(addressedEntity.Address, addressedEntity.Entity);

                // Name GameObject
                if (addressedEntity.Entity is DataElement)
                {
                    gameObject.name = $"{addressedEntity.Entity.GetClassEntityInfo().Name}<0x{addressedEntity.Address:X8}>";
                }
                else if (addressedEntity.Entity is DataSet)
                {
                    gameObject.name = "DataSet";
                    result.DataSetGameObject = gameObject;
                    continue;
                }

                gameObjects.Add(addressedEntity.Address, gameObject);
            }

            ResolveRequests(entities, gameObjects);

            result.GameObjects = gameObjects.Values.ToList();
            return result;
        }

        private static IDictionary<StrCode, string> ReadStringTable(FileStreamReader reader)
        {
            var dictionary = new Dictionary<StrCode, string>
            {
                { new StrCode(string.Empty), string.Empty }
            };

            while (true)
            {
                StrCode hash = reader.ReadStrCode();
                if (hash == 0)
                {
                    return dictionary;
                }

                int length = reader.ReadInt32();
                char[] literal = reader.ReadChars(length);
                if (dictionary.ContainsKey(hash))
                {
                    continue;
                }

                dictionary.Add(hash, new string(literal));
            }
        }

        private void ResolveRequests(IDictionary<ulong, Entity> entities, IDictionary<ulong, GameObject> gameObjects)
        {
            foreach (KeyValuePair<ulong, Action<Entity>> setEntityPtr in entityPtrSetRequests)
            {
                if (entities.ContainsKey(setEntityPtr.Key))
                {
                    setEntityPtr.Value(entities[setEntityPtr.Key]);
                    continue;
                }

                logger.AddError($"Unable to resolve EntityPtr 0x{setEntityPtr.Key:X8}.");
            }

            foreach (KeyValuePair<ulong, HashSet<Action<Entity>>> setEntityHandle in entityHandleSetRequests)
            {
                if (entities.ContainsKey(setEntityHandle.Key))
                {
                    if (!gameObjects.ContainsKey(setEntityHandle.Key))
                    {
                        foreach (Action<Entity> request in setEntityHandle.Value)
                        {
                            request(entities[setEntityHandle.Key]);
                        }
                        continue;
                    }

                    foreach (Action<Entity> request in setEntityHandle.Value)
                    {
                        request(gameObjects[setEntityHandle.Key].GetComponent<Entity>());
                    }
                }
                else
                {
                    logger.AddError($"Unable to resolve EntityHandle 0x{setEntityHandle.Key:X8}");
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

            entityPtrSetRequests.Add(address, setPtr);
        }

        public void RequestSetEntityHandle(ulong address, Action<Entity> setHandle)
        {
            if (address == 0)
            {
                return;
            }

            if (!entityHandleSetRequests.ContainsKey(address))
            {
                entityHandleSetRequests.Add(address, new HashSet<Action<Entity>>());
            }

            _ = entityHandleSetRequests[address].Add(setHandle);
        }
    }
}
