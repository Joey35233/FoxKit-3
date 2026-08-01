using Fox.GameService;
using System.IO;
using Fox.Geo;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ExportRailFile
    {
        [MenuItem("FoxKit/Export/RailFile")]
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

        [MenuItem("GameObject/Export/RailFile", false, -10)]
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
            string outputPath = Fox.Fs.FileUtils.SaveFilePanel("Export RailFile", scene.name, "frl");
            if (string.IsNullOrEmpty(outputPath))
            {
                return;
            }

            RailFileWriter frlWriter = new RailFileWriter();
            byte[] data = frlWriter.Write(scene);
            System.IO.File.WriteAllBytes(outputPath, data);
        }
    }
}
