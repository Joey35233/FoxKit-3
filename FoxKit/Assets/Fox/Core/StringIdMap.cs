using System;
using System.Collections.Generic;
using Fox;
using System.IO;
using UnityEngine;

namespace Fox
{
    public class StringIdMap
    {
        private string UserDictionaryPath = null;

        private Dictionary<StrCode, string> Map;
        private Dictionary<StrCode, string> AddQueue = null;

        public StringIdMap()
        {
            Map = new Dictionary<StrCode, string>();
        }

        public void RegisterDictionary(string dictionaryPath)
        {
            if (dictionaryPath == null)
                return;
            
            string baseDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".stringdb");
            string userDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".ustringdb");
            
            UserDictionaryPath = userDictionaryPath;

            if (Fox.Fs.FileSystem.Exists(baseDictionaryPath))
            {
                using StreamReader baseDictionaryReadStream = new StreamReader(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(baseDictionaryPath), System.Text.Encoding.ASCII);
                while (baseDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode hash = new StrCode(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning(
                                $"StringIdMap: load entry {entry} already exists in {baseDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning(
                            $"StringIdMap: can't load malformed entry {entry} at {baseDictionaryPath}.");
                    }
                }
            }

            using (StreamReader userDictionaryReadStream = new StreamReader(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), System.Text.Encoding.ASCII))
            {
                AddQueue = new Dictionary<StrCode, string>();
                
                while (userDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode hash = new StrCode(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringIdMap: load entry {entry} already exists in {baseDictionaryPath} or {UserDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringIdMap: can't load malformed entry {entry} at {UserDictionaryPath}.");
                    }
                }
            }
        }

        public void RegisterBaseEntries(List<(StrCode, string)> baseEntries)
        {
            foreach ((StrCode hash, string value) in baseEntries)
                if (!TryAddToMap(Map, hash, value))
                    Debug.LogWarning($"StringIdMap: load entry {(hash, value)} already provided.");
        }

        public bool Resolve(StrCode hash, out string value)
        {
            bool status = Map.TryGetValue(hash, out value);
            if (!status)
                value = hash.ToString();
            
            return status;
        }

        public bool Add(string value)
        {
            if (AddQueue == null)
                return false;
            
            if (string.IsNullOrWhiteSpace(value))
                return false;

            StrCode hash = new StrCode(value);

            if (TryAddToMap(AddQueue, hash, value))
                TryAddToMap(Map, hash, value);

            return true;
        }

        public void Save()
        {
            if (AddQueue == null)
                return;
            
            using StreamWriter userDictionaryWriteStream = new StreamWriter(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), append: true, System.Text.Encoding.ASCII);
            foreach ((StrCode hash, string value) in AddQueue)
            {
                userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }
        }

        private static bool TryAddToMap(Dictionary<StrCode, string> map, StrCode hash, string value)
        {
            if (!map.TryAdd(hash, value))
            {
                return true;
            }
            else
            {
#if DEBUG
                if (!map.TryGetValue(hash, out string testValue) || testValue != value)
                {
                    Debug.LogWarning($"StringIdMap: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
                }
#endif
                return false;
            }
        }
    }

    public class StringId32Map
    {
        private string UserDictionaryPath = null;

        private Dictionary<StrCode32, string> Map;
        private Dictionary<StrCode32, string> AddQueue = null;

        public StringId32Map()
        {
            Map = new Dictionary<StrCode32, string>();
        }

        public void RegisterDictionary(string dictionaryPath)
        {
            if (dictionaryPath == null)
                return;
            
            string baseDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".stringdb");
            string userDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".ustringdb");
            
            UserDictionaryPath = userDictionaryPath;

            if (Fox.Fs.FileSystem.Exists(baseDictionaryPath))
            {
                using StreamReader baseDictionaryReadStream = new StreamReader(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(baseDictionaryPath), System.Text.Encoding.ASCII);
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

            using (StreamReader userDictionaryReadStream = new StreamReader(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), System.Text.Encoding.ASCII))
            {
                AddQueue = new Dictionary<StrCode32, string>();
                
                while (userDictionaryReadStream.ReadLine() is { } entry)
                {
                    string[] pair = entry.Split("\t");
                    if (pair.Length == 2)
                    {
                        StrCode32 hash = new StrCode32(pair[0]);
                        string value = pair[1];
                        if (!TryAddToMap(Map, hash, value))
                            Debug.LogWarning($"StringId32Map: load entry {entry} already exists in {baseDictionaryPath} or {UserDictionaryPath}.");
                    }
                    else
                    {
                        Debug.LogWarning($"StringId32Map: can't load malformed entry {entry} at {UserDictionaryPath}.");
                    }
                }
            }
        }

        public void RegisterBaseEntries(List<(StrCode32, string)> baseEntries)
        {
            foreach ((StrCode32 hash, string value) in baseEntries)
                if (!TryAddToMap(Map, hash, value))
                    Debug.LogWarning($"StringId32Map: load entry {(hash, value)} already provided.");
        }

        public bool Resolve(StrCode32 hash, out string value)
        {
            bool status = Map.TryGetValue(hash, out value);
            if (!status)
                value = hash.ToString();
            
            return status;
        }

        public bool Add(string value)
        {
            if (AddQueue == null)
                return false;
            
            if (string.IsNullOrWhiteSpace(value))
                return false;

            StrCode32 hash = new StrCode32(value);

            if (TryAddToMap(AddQueue, hash, value))
                TryAddToMap(Map, hash, value);

            return true;
        }

        public void Save()
        {
            if (AddQueue == null)
                return;
            
            using StreamWriter userDictionaryWriteStream = new StreamWriter(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), append: true, System.Text.Encoding.ASCII);
            foreach ((StrCode32 hash, string value) in AddQueue)
            {
                userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }
        }

        private static bool TryAddToMap(Dictionary<StrCode32, string> map, StrCode32 hash, string value)
        {
            if (map.TryAdd(hash, value))
            {
                return true;
            }
            else
            {
#if DEBUG
                if (!map.TryGetValue(hash, out string testValue) || testValue != value)
                {
                    Debug.LogWarning($"StringIdMap: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
                }
#endif
                return false;
            }
        }
    }
}
