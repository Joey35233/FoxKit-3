using Fox.Fio;
using Fox.Geo;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportGeoTrapFile
    {
        [MenuItem("FoxKit/Import/GeoTrapFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GeoTrapFile", "", "trap");
            if (System.String.IsNullOrEmpty(assetPath))
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
