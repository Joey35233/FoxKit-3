using System.Collections.Generic;
using Fox;
using System.IO;
using UnityEngine;

namespace Fox
{
    public class StringIdMap
    {
        private readonly string UserDictionaryPath;

        private Dictionary<StrCode, string> Map = new Dictionary<StrCode, string>();
        private Dictionary<StrCode, string> AddQueue = new Dictionary<StrCode, string>();

        public StringIdMap(string dictionaryPath)
        {
            string baseDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".pathdb");
            string userDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".user.pathdb");
            
            UserDictionaryPath = userDictionaryPath;

            using (StreamReader baseDictionaryReadStream = new StreamReader(baseDictionaryPath, System.Text.Encoding.ASCII))
            {
                while (baseDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode hash = new StrCode(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringIdMap: load entry {entry} already exists in {baseDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringIdMap: can't load malformed entry {entry} at {baseDictionaryPath}.");
                    }
                }
            }

            using (StreamReader userDictionaryReadStream = new StreamReader(userDictionaryPath, System.Text.Encoding.ASCII))
            {
                while (userDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode hash = new StrCode(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringIdMap: load entry {entry} already exists in {baseDictionaryPath} or {userDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringIdMap: can't load malformed entry {entry} at {userDictionaryPath}.");
                    }
                }
            }
        }

        public bool Resolve(StrCode hash, out string value) => Map.TryGetValue(hash, out value);

        public void Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            StrCode hash = new StrCode(value);

            if (!TryAddToMap(AddQueue, hash, value))
                TryAddToMap(Map, hash, value);
        }

        public void Save()
        {
            using StreamWriter userDictionaryWriteStream = new StreamWriter(UserDictionaryPath, append: true, System.Text.Encoding.ASCII);
            foreach ((StrCode hash, string value) in AddQueue)
            {
                userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }
        }

        private static bool TryAddToMap(Dictionary<StrCode, string> map, StrCode hash, string value)
        {
            if (!map.TryAdd(hash, value))
            {
#if DEBUG
                if (!map.TryGetValue(hash, out string testValue) || testValue != value)
                {
                    Debug.LogWarning($"StringIdMap: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
                }
#endif
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    public class StringId32Map
    {
        private readonly string UserDictionaryPath;

        private Dictionary<StrCode32, string> Map = new Dictionary<StrCode32, string>();
        private Dictionary<StrCode32, string> AddQueue = new Dictionary<StrCode32, string>();

        public StringId32Map(string dictionaryPath)
        {
            string baseDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".pathdb");
            string userDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".user.pathdb");
            
            UserDictionaryPath = userDictionaryPath;

            using (StreamReader baseDictionaryReadStream = new StreamReader(baseDictionaryPath, System.Text.Encoding.ASCII))
            {
                while (baseDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode32 hash = new StrCode32(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringId32Map: load entry {entry} already exists in {baseDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringId32Map: can't load malformed entry {entry} at {baseDictionaryPath}.");
                    }
                }
            }

            using (StreamReader userDictionaryReadStream = new StreamReader(userDictionaryPath, System.Text.Encoding.ASCII))
            {
                while (userDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode32 hash = new StrCode32(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringId32Map: load entry {entry} already exists in {baseDictionaryPath} or {userDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringId32Map: can't load malformed entry {entry} at {userDictionaryPath}.");
                    }
                }
            }
        }

        public bool Resolve(StrCode32 hash, out string value) => Map.TryGetValue(hash, out value);

        public void Add(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            StrCode32 hash = new StrCode32(value);

            if (!TryAddToMap(AddQueue, hash, value))
                TryAddToMap(Map, hash, value);
        }

        public void Save()
        {
            using StreamWriter userDictionaryWriteStream = new StreamWriter(UserDictionaryPath, append: true, System.Text.Encoding.ASCII);
            foreach ((StrCode32 hash, string value) in AddQueue)
            {
                userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }
        }

        private static bool TryAddToMap(Dictionary<StrCode32, string> map, StrCode32 hash, string value)
        {
            if (!map.TryAdd(hash, value))
            {
#if DEBUG
                if (!map.TryGetValue(hash, out string testValue) || testValue != value)
                {
                    Debug.LogWarning($"StringIdMap: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
                }
#endif
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
