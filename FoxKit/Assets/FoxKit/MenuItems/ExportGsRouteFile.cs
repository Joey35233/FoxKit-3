using Fox.GameService;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ExportGsRouteFile
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

            using BinaryWriter writer = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            GsRouteSetWriter frtWriter = new GsRouteSetWriter();

            frtWriter.Write(writer, scene);
        }
    }
}
