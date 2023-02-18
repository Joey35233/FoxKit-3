using System.IO;
using UnityEditor;

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

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var tre2Reader = new Fox.Gr.TerrainFileReader(reader);
            Fox.Gr.TerrainFileAsset asset = tre2Reader.Read();

            AssetDatabase.CreateAsset(asset, $"Assets/{Path.GetFileNameWithoutExtension(assetPath)}.asset");

            // Need to save the embedded textures to the asset
            AssetDatabase.AddObjectToAsset(asset.LodParam, asset);
            AssetDatabase.AddObjectToAsset(asset.MaxHeight, asset);
            AssetDatabase.AddObjectToAsset(asset.MinHeight, asset);
            AssetDatabase.AddObjectToAsset(asset.Heightmap, asset);
            AssetDatabase.AddObjectToAsset(asset.ComboTexture, asset);
            AssetDatabase.AddObjectToAsset(asset.MaterialIds, asset);
            AssetDatabase.AddObjectToAsset(asset.ConfigrationIds, asset);

            AssetDatabase.SaveAssets();
        }
    }
}