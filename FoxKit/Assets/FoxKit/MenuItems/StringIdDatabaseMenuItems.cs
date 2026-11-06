using System.Collections.Generic;
using System.IO;
using Fox;
using UnityEditor;
using UnityEngine;
using Path = System.IO.Path;

namespace FoxKit.MenuItems
{
    public static class StringIdDatabaseMenuItems
    {
        [MenuItem("FoxKit/Debug/Create StringId Database")]
        private static void Create()
        {
            foreach (string asset in Selection.assetGUIDs)
            {
                string source = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(source) != ".txt")
                    continue;
                
                string directory = Path.GetDirectoryName(source);
                if (Path.GetFileName(directory) == "Strings")
                    directory = Path.GetDirectoryName(directory);
                
                string path = Path.Combine(directory, Path.GetFileNameWithoutExtension(source) + ".stringdb");
                string userPath = Path.ChangeExtension(path, ".ustringdb");
                if (File.Exists(path) || File.Exists(userPath))
                {
                    Debug.Log($"A database already exists for {source}.");
                    continue;
                }

                StringIdDatabase database = new StringIdDatabase();
                foreach (string value in File.ReadLines(source))
                {
                    if (value.Contains('\t') || StrCode.IsHash(value))
                        throw new InvalidDataException($"Expected a string, got: {value}");
                    
                    string hash = new StrCode(value).ToString();
                    if (database.Strings.TryGetValue(hash, out string existing) && existing != value)
                        throw new InvalidDataException($"Hash collision: {existing} and {value} ({hash}).");
                    
                    database.Strings[hash] = value;
                }
                database.Write(path, StringDatabaseType.Base);
                
                new StringIdDatabase().Write(userPath, StringDatabaseType.User);
                
                Debug.Log($"Created {path} with {database.Strings.Count} strings.");
            }
            AssetDatabase.Refresh();
        }

        [MenuItem("FoxKit/Debug/Create StringId32 Database")]
        private static void Create32()
        {
            foreach (string asset in Selection.assetGUIDs)
            {
                string source = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(source) != ".txt")
                    continue;
                
                string directory = Path.GetDirectoryName(source);
                if (Path.GetFileName(directory) == "Strings")
                    directory = Path.GetDirectoryName(directory);
                
                string path = Path.Combine(directory, Path.GetFileNameWithoutExtension(source) + ".stringdb");
                string userPath = Path.ChangeExtension(path, ".ustringdb");
                if (File.Exists(path) || File.Exists(userPath))
                {
                    Debug.Log($"A database already exists for {source}.");
                    continue;
                }

                StringId32Database database = new StringId32Database();
                foreach (string value in File.ReadLines(source))
                {
                    if (value.Contains('\t') || StrCode32.IsHash(value))
                        throw new InvalidDataException($"Expected a string, got: {value}");
                    
                    string hash = new StrCode32(value).ToString();
                    if (database.Strings.TryGetValue(hash, out string existing) && existing != value)
                        throw new InvalidDataException($"Hash collision: {existing} and {value} ({hash}).");
                    
                    database.Strings[hash] = value;
                }
                database.Write(path, StringDatabaseType.Base);
                
                new StringId32Database().Write(userPath, StringDatabaseType.User);
                
                Debug.Log($"Created {path} with {database.Strings.Count} strings.");
            }
            AssetDatabase.Refresh();
        }

        [MenuItem("FoxKit/Debug/Update StringId Database")]
        private static void Update()
        {
            foreach (string asset in Selection.assetGUIDs)
            {
                string selected = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(selected) != ".stringdb" && Path.GetExtension(selected) != ".ustringdb")
                    continue;
                
                string path = Path.ChangeExtension(selected, ".stringdb");
                string userPath = Path.ChangeExtension(selected, ".ustringdb");
                StringIdDatabase database = StringIdDatabase.Read(path, StringDatabaseType.Base);
                StringIdDatabase userDatabase = StringIdDatabase.Read(userPath, StringDatabaseType.User);
                
                List<string> promoted = new List<string>();
                foreach (KeyValuePair<string, string> entry in userDatabase.Strings)
                {
                    string hash = new StrCode(entry.Value).ToString();
                    if (StrCode.IsHash(entry.Value) || hash != entry.Key)
                        throw new InvalidDataException($"User string {entry.Value} does not match its hash {entry.Key}.");
                    
                    if (database.Hashes.Contains(hash))
                        promoted.Add(hash);
                }
                
                foreach (string hash in promoted)
                {
                    database.Strings.Add(hash, userDatabase.Strings[hash]);
                    database.Hashes.Remove(hash);
                }
                
                int count = promoted.Count;
                if (count > 0)
                    database.Write(path, StringDatabaseType.Base);
                
                Debug.Log($"Updated {path}: promoted {count} strings; {database.Hashes.Count} hashes remain.");
            }
            AssetDatabase.Refresh();
        }

        [MenuItem("FoxKit/Debug/Update StringId32 Database")]
        private static void Update32()
        {
            foreach (string asset in Selection.assetGUIDs)
            {
                string selected = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(selected) != ".stringdb" && Path.GetExtension(selected) != ".ustringdb")
                    continue;
                
                string path = Path.ChangeExtension(selected, ".stringdb");
                string userPath = Path.ChangeExtension(selected, ".ustringdb");
                StringId32Database database = StringId32Database.Read(path, StringDatabaseType.Base);
                StringId32Database userDatabase = StringId32Database.Read(userPath, StringDatabaseType.User);
                
                List<string> promoted = new List<string>();
                foreach (KeyValuePair<string, string> entry in userDatabase.Strings)
                {
                    string hash = new StrCode32(entry.Value).ToString();
                    if (StrCode32.IsHash(entry.Value) || hash != entry.Key)
                        throw new InvalidDataException($"User string {entry.Value} does not match its hash {entry.Key}.");
                    
                    if (database.Hashes.Contains(hash))
                        promoted.Add(hash);
                }
                
                foreach (string hash in promoted)
                {
                    database.Strings.Add(hash, userDatabase.Strings[hash]);
                    database.Hashes.Remove(hash);
                }
                
                int count = promoted.Count;
                if (count > 0)
                    database.Write(path, StringDatabaseType.Base);
                
                Debug.Log($"Updated {path}: promoted {count} strings; {database.Hashes.Count} hashes remain.");
            }
            AssetDatabase.Refresh();
        }
    }
}
