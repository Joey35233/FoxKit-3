using Fox.Fio;
using Fox.Kernel;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    public class DataSetFile2Reader
    {
        private IDictionary<StrCode, String> stringTable;
        private readonly IDictionary<ulong, Action<Entity>> entityPtrSetRequests = new Dictionary<ulong, Action<Entity>>();
        private readonly IDictionary<ulong, HashSet<Action<Entity>>> entityHandleSetRequests = new Dictionary<ulong, HashSet<Action<Entity>>>();

        public class ReadResult
        {
            public List<Entity> Entities;
            public List<GameObject> GameObjects;
            public GameObject DataSetGameObject;
        }

        public ReadResult Read(FileStreamReader reader)
        {
            byte[] headerBytes = reader.ReadBytes(32);
            int entityCount = BitConverter.ToInt32(headerBytes, 8);
            int stringTableOffset = BitConverter.ToInt32(headerBytes, 12);
            long entityTableOffset = reader.BaseStream.Position;

            reader.Seek(stringTableOffset);
            stringTable = ReadStringTable(reader);

			// v rlc with sai's direction, from Atvaark's FoxTool code
            string path = "Assets/Fox/Core/DataSet/fox_dictionary.txt";
            foreach (string line in System.IO.File.ReadAllLines(path))
            {
                var lineFoxString = new String(line);
                _ = stringTable.TryAdd(lineFoxString.Hash, lineFoxString);
            }
			// ^

            reader.Seek(entityTableOffset);

            var result = new ReadResult();
            var entities = new Dictionary<ulong, Entity>();
            var gameObjects = new Dictionary<ulong, GameObject>();
            for (int i = 0; i < entityCount; i++)
            {
                var gameObject = new GameObject();

                AddressedEntity addressedEntity = new DataSetFile2AddressedEntityReader(RequestSetEntityPtr, RequestSetEntityHandle)
                    .Read(reader, gameObject, (hash) => stringTable[hash]);
                entities.Add(addressedEntity.Address, addressedEntity.Entity);

                // Create GameObject
                if (addressedEntity.Entity is DataElement)
                {
                    gameObject.name = $"{addressedEntity.Entity.GetClassEntityInfo().Name}<0x{addressedEntity.Address:X8}>";
                }

                if (addressedEntity.Entity is DataSet)
                {
                    gameObject.name = "DataSet";
                    result.DataSetGameObject = gameObject;
                    continue;
                }

                gameObjects.Add(addressedEntity.Address, gameObject);
            }

            ResolveRequests(entities, gameObjects);

            result.Entities = entities.Values.ToList();
            result.GameObjects = gameObjects.Values.ToList();
            return result;
        }

        private static IDictionary<StrCode, String> ReadStringTable(FileStreamReader reader)
        {
            var dictionary = new Dictionary<StrCode, String>
            {
                { String.Empty.Hash, String.Empty }
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
                dictionary.Add(hash, new String(new string(literal)));
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

                UnityEngine.Debug.LogError($"Unable to resolve EntityPtr 0x{setEntityPtr.Key:X8}");
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
