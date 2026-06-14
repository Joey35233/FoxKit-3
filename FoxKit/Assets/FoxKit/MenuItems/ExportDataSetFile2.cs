using Fox.Core;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

namespace FoxKit.MenuItems
{
    public static class ExportDataSetFile2
    {
        [MenuItem("FoxKit/Export/DataSetFile2")]
        private static void OnExport()
        {
            UnityEngine.SceneManagement.Scene scene;
            
            GameObject selectedGameObject = Selection.activeGameObject;
            if (selectedGameObject != null)
                scene = selectedGameObject.scene;
            else
                scene = SceneManager.GetActiveScene();

            Export(scene);
        }
        
        
        [MenuItem("GameObject/Export/DataSetFile2", false, -10)]
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
            string dataSetName = scene.name;
            string outputPath = Fox.Fs.FileUtils.SaveFilePanel("Export DataSetFile2", $"{dataSetName}", "fox2");
            if (string.IsNullOrEmpty(outputPath))
            {
                return;
            }

            using var writer = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            var fox2Writer = new DataSetFile2Writer();

            fox2Writer.Write(writer, scene);
        }
    }
}