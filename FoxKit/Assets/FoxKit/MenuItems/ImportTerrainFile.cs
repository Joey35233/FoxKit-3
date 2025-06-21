using Fox.Core;
using Fox.Fio;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ImportTerrainFile
    {
        [MenuItem("FoxKit/Import/Terrain")]
        private static void OnImportAsset()
        {
            // string assetPath = EditorUtility.OpenFilePanel("Import Terrain", "", "tre2");
            // if (System.String.IsNullOrEmpty(assetPath))
            // {
            //     Debug.Log("File doesn't exist or is empty");
            //     return;
            // }
            // Debug.Log($"File {assetPath} loaded");
            //
            // Fox.Gr.Terrain.MappedData asset = ScriptableObject.CreateInstance<Fox.Gr.Terrain.MappedData>();
            // if (Fox.Gr.TerrainFile.TryDeserialize(asset, System.IO.File.ReadAllBytes(assetPath)))
            // {
            //     AssetDatabase.CreateAsset(asset, $"Assets/Game/{assetPath.Substring(assetPath.LastIndexOf("Assets"))}.asset");
            //
            //     Debug.Log($"Asset {asset.name} created");
            //     // Need to save the embedded textures to the asset
            //     //AssetDatabase.AddObjectToAsset(asset.LodParam, asset);
            //     //AssetDatabase.AddObjectToAsset(asset.MaxHeight, asset);
            //     //AssetDatabase.AddObjectToAsset(asset.MinHeight, asset);
            //     // AssetDatabase.AddObjectToAsset(asset.DataControl.HeightMap, asset);
            //     // AssetDatabase.AddObjectToAsset(asset.DataControl.ComboTexture, asset);
            //     //AssetDatabase.AddObjectToAsset(asset.MaterialIds, asset);
            //     //AssetDatabase.AddObjectToAsset(asset.ConfigrationIds, asset);
            //
            //     AssetDatabase.SaveAssets();
            // }
            // else
            // {
            //     Debug.Log($"Asset {asset.name} not created");
            // }
        }
    }
}