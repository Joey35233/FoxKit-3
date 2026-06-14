using System.Collections.Generic;
using Fox.GameService;
using System.IO;
using Fox;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Path = System.IO.Path;

namespace FoxKit.MenuItems
{
    public static class ConvertDictionary
    {
        [MenuItem("FoxKit/Debug/ConvertDictionary (StringId)")]
        private static void OnConvert()
        {
            string[] selectedAssets = Selection.assetGUIDs;
            foreach (string asset in selectedAssets)
            {
                string path = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(path) == ".txt")
                {
                    string[] lines = File.ReadAllLines(path);
                    
                    using StreamWriter streamWriter = new StreamWriter(Path.ChangeExtension(path, "pathdb"), false, System.Text.Encoding.ASCII);
                    foreach (string line in lines)
                    {
                        streamWriter.WriteLine($"{new StrCode(line)}\t{line}");
                    }
                }
            }
        }
        [MenuItem("FoxKit/Debug/ConvertDictionary (StringId32)")]
        private static void OnConvert32()
        {
            string[] selectedAssets = Selection.assetGUIDs;
            foreach (string asset in selectedAssets)
            {
                string path = AssetDatabase.GUIDToAssetPath(asset);
                if (Path.GetExtension(path) == ".txt")
                {
                    string[] lines = File.ReadAllLines(path);
                    
                    using StreamWriter streamWriter = new StreamWriter(Path.ChangeExtension(path, "pathdb"), false, System.Text.Encoding.ASCII);
                    foreach (string line in lines)
                    {
                        streamWriter.WriteLine($"{new StrCode32(line)}\t{line}");
                    }
                }
            }
        }
    }
}
