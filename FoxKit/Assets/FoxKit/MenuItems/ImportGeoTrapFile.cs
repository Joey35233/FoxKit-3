using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Fox.Fio;
using Fox.Geo;

namespace FoxKit.MenuItems
{
    public class ImportGeoTrapFile
    {
        [MenuItem("FoxKit/Import/GeoTrapFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GeoTrapFile", "", "trap");
            if (string.IsNullOrEmpty(assetPath))
                return;

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var trapReader = new GeoTrapFileReader();
            Scene? scene = trapReader.Read(reader);
            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("TRAP import failed.");
        }
    }
}
