using Fox.GameService;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ExportRouteFile
    {
        [MenuItem("FoxKit/Export/RouteFile")]
        private static void OnExport()
        {
            GameObject selectedGameObject = Selection.activeGameObject;

            Scene scene;
            if (selectedGameObject != null)
                scene = selectedGameObject.scene;
            else
                scene = SceneManager.GetActiveScene();

            Export(scene);
        }

        [MenuItem("GameObject/Export/RouteFile", false, -10)]
        private static void OnExport(MenuCommand command)
        {
            if (command == null || command.context == null)
            {
                return;
            }

            Export(((GameObject)command.context).scene);
        }

        private static void Export(Scene scene)
        {
            string outputPath = Fox.Fs.FileUtils.SaveFilePanel("Export RouteFile", scene.name, "frt");
            if (string.IsNullOrEmpty(outputPath))
            {
                return;
            }

            Fox.Core.Utils.TaskLogger logger = new Fox.Core.Utils.TaskLogger("ExportRouteFile");

            RouteFileWriter frtWriter = new RouteFileWriter();
            byte[] data = frtWriter.Write(scene, logger);
            logger.LogToUnityConsole();

            if (data == null)
            {
                Debug.LogError("FRT export failed.");
                return;
            }

            System.IO.File.WriteAllBytes(outputPath, data);
        }
    }
}
