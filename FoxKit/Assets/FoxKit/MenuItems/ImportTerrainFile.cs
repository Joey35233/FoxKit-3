using System.IO;
using UnityEditor;
using FoxKit.Gr.Terrain;

namespace FoxKit.MenuItems
{
    public static class ImportTerrainFile
    {
        [MenuItem("FoxKit/Import/Terrain")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import Terrain", "", "tre2");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var tre2Reader = new TerrainFileReader(reader);
            var asset = tre2Reader.Read();

            AssetDatabase.CreateAsset(asset, $"Assets/{Path.GetFileNameWithoutExtension(assetPath)}.asset");

            // Need to save the embedded textures to the asset
            AssetDatabase.AddObjectToAsset(asset.LodParam, asset);

            AssetDatabase.SaveAssets();
        }
    }
}