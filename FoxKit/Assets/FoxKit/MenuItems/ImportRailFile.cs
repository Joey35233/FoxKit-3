using Fox.Core.Utils;
using Fox.Geo;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportRailFile
    {
        [MenuItem("FoxKit/Import/RailFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import RailFile", "frl");
            if (string.IsNullOrEmpty(assetPath))
                return;

            TaskLogger logger = new TaskLogger("ImportRailFile");

            var frlReader = new RailFileReader();
            UnityEngine.SceneManagement.Scene? scene = frlReader.Read(System.IO.File.ReadAllBytes(assetPath), logger);
            logger.LogToUnityConsole();

            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("FRL import failed.");
        }
    }
}
