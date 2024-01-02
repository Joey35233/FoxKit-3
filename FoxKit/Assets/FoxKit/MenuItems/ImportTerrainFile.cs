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
            string assetPath = EditorUtility.OpenFilePanel("Import Terrain", "", "tre2");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            Fox.Gr.Terrain.TerrainTileAsset asset = ScriptableObject.CreateInstance<Fox.Gr.Terrain.TerrainTileAsset>();
            if (Fox.Gr.TerrainFile.TryDeserialize(asset, System.IO.File.ReadAllBytes(assetPath)))
            {
                AssetDatabase.CreateAsset(asset, $"Assets/Game/{assetPath.Substring(assetPath.LastIndexOf("Assets"))}.asset");

                // Need to save the embedded textures to the asset
                //AssetDatabase.AddObjectToAsset(asset.LodParam, asset);
                //AssetDatabase.AddObjectToAsset(asset.MaxHeight, asset);
                //AssetDatabase.AddObjectToAsset(asset.MinHeight, asset);
                // AssetDatabase.AddObjectToAsset(asset.DataControl.HeightMap, asset);
                // AssetDatabase.AddObjectToAsset(asset.DataControl.ComboTexture, asset);
                //AssetDatabase.AddObjectToAsset(asset.MaterialIds, asset);
                //AssetDatabase.AddObjectToAsset(asset.ConfigrationIds, asset);

                AssetDatabase.SaveAssets();
            }
        }
    }
}