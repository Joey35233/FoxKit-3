using Fox.Fio;
using Fox.GameService;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportGsRouteFile
    {
        [MenuItem("FoxKit/Import/GsRouteFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GsRouteFile", "", "frt");
            if (System.String.IsNullOrEmpty(assetPath))
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
