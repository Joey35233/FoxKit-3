using System.Collections.Generic;
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

            string basePath = Fox.Fs.FileSystem.GetUnityPathFromFoxPath(System.IO.Path.ChangeExtension(dictionaryPath, ".stringdb"));
            UserDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".ustringdb");
            string userPath = Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath);
            StringIdDatabase baseDatabase = StringIdDatabase.Read(basePath, StringDatabaseType.Base);
            StringIdDatabase userDatabase = StringIdDatabase.Read(userPath, StringDatabaseType.User);
            foreach (KeyValuePair<string, string> entry in baseDatabase.Strings)
                TryAddToMap(Map, new StrCode(entry.Key), entry.Value);
            foreach (KeyValuePair<string, string> entry in userDatabase.Strings)
                TryAddToMap(Map, new StrCode(entry.Key), entry.Value);
            AddQueue = new Dictionary<StrCode, string>();
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

            // A raw hash string carries no text to remember
            if (StrCode.IsHash(value))
                return false;

            StrCode hash = new StrCode(value);

            if (TryAddToMap(Map, hash, value))
                AddQueue.TryAdd(hash, value);

            return true;
        }

        public void Save()
        {
            if (AddQueue == null || AddQueue.Count == 0)
                return;

            using (StreamWriter userDictionaryWriteStream = new StreamWriter(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), append: true, System.Text.Encoding.ASCII))
            {
                foreach ((StrCode hash, string value) in AddQueue)
                    userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }

            AddQueue.Clear();
        }

        private static bool TryAddToMap(Dictionary<StrCode, string> map, StrCode hash, string value)
        {
            if (map.TryAdd(hash, value))
                return true;

#if DEBUG
            if (map.TryGetValue(hash, out string testValue) && testValue != value)
                Debug.LogWarning($"StringIdMap: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
#endif
            return false;
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

            string basePath = Fox.Fs.FileSystem.GetUnityPathFromFoxPath(System.IO.Path.ChangeExtension(dictionaryPath, ".stringdb"));
            UserDictionaryPath = System.IO.Path.ChangeExtension(dictionaryPath, ".ustringdb");
            string userPath = Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath);
            StringId32Database baseDatabase = StringId32Database.Read(basePath, StringDatabaseType.Base);
            StringId32Database userDatabase = StringId32Database.Read(userPath, StringDatabaseType.User);
            foreach (KeyValuePair<string, string> entry in baseDatabase.Strings)
                TryAddToMap(Map, new StrCode32(entry.Key), entry.Value);
            foreach (KeyValuePair<string, string> entry in userDatabase.Strings)
                TryAddToMap(Map, new StrCode32(entry.Key), entry.Value);
            AddQueue = new Dictionary<StrCode32, string>();
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

            // A raw hash string carries no text to remember
            if (StrCode32.IsHash(value))
                return false;

            StrCode32 hash = new StrCode32(value);

            if (TryAddToMap(Map, hash, value))
                AddQueue.TryAdd(hash, value);

            return true;
        }

        public void Save()
        {
            if (AddQueue == null || AddQueue.Count == 0)
                return;

            using (StreamWriter userDictionaryWriteStream = new StreamWriter(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(UserDictionaryPath), append: true, System.Text.Encoding.ASCII))
            {
                foreach ((StrCode32 hash, string value) in AddQueue)
                    userDictionaryWriteStream.WriteLine($"{hash}\t{value}");
            }

            AddQueue.Clear();
        }

        private static bool TryAddToMap(Dictionary<StrCode32, string> map, StrCode32 hash, string value)
        {
            if (map.TryAdd(hash, value))
                return true;

#if DEBUG
            if (map.TryGetValue(hash, out string testValue) && testValue != value)
                Debug.LogWarning($"StringId32Map: Collision detected for hash {hash}. Submitted: {value}, Existing: {testValue}");
#endif
            return false;
        }
    }
}
