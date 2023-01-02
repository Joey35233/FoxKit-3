using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using Fox.Fio;
using Fox.Geo;
using Fox.GameService;

namespace FoxKit.MenuItems
{
    public class ImportGsRouteFile
    {
        [MenuItem("FoxKit/Import/GsRouteFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GsRouteFile", "", "frt");
            if (string.IsNullOrEmpty(assetPath))
                return;

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var frtReader = new GsRouteSetReader();
            Scene? scene = frtReader.Read(reader);
            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("FRT import failed.");
        }
    }
}
