using Fox.Core.Utils;
using Fox.GameService;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportRouteFile
    {
        [MenuItem("FoxKit/Import/RouteFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import RouteFile", "frt");
            if (string.IsNullOrEmpty(assetPath))
                return;

            TaskLogger logger = new TaskLogger("ImportRouteFile");

            var frtReader = new RouteFileReader();
            UnityEngine.SceneManagement.Scene? scene = frtReader.Read(System.IO.File.ReadAllBytes(assetPath), logger);
            logger.LogToUnityConsole();
            
            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("FRT import failed.");
        }
    }
}
