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

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));

            Fox.GameKit.TerrainMapAsset asset = ScriptableObject.CreateInstance<Fox.GameKit.TerrainMapAsset>();
            if (Fox.GameKit.TerrainMapAsset.TryReadTerrainFile(asset, reader, Fox.GameKit.TerrainFileType.TRE2))
            {

                AssetDatabase.CreateAsset(asset, $"Assets/Game/Assets/{Path.GetFileNameWithoutExtension(assetPath)}.asset");

                // Need to save the embedded textures to the asset
                //AssetDatabase.AddObjectToAsset(asset.LodParam, asset);
                //AssetDatabase.AddObjectToAsset(asset.MaxHeight, asset);
                //AssetDatabase.AddObjectToAsset(asset.MinHeight, asset);
                AssetDatabase.AddObjectToAsset(asset.DataControl.HeightMap, asset);
                AssetDatabase.AddObjectToAsset(asset.DataControl.ComboTexture, asset);
                //AssetDatabase.AddObjectToAsset(asset.MaterialIds, asset);
                //AssetDatabase.AddObjectToAsset(asset.ConfigrationIds, asset);

                AssetDatabase.SaveAssets();
            }
        }
    }
}