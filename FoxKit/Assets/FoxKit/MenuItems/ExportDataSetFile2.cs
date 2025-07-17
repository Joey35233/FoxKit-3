using Fox.Core;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ExportDataSetFile2
    {
        [MenuItem("GameObject/Export/DataSetFile2", false, -10)]
        private static void OnExport(MenuCommand command)
        {
            if (command == null || command.context == null)
            {
                return;
            }

            UnityEngine.SceneManagement.Scene scene = ((GameObject)command.context).scene;
            string dataSetName = scene.name;
            string outputPath = EditorUtility.SaveFilePanel("Export DataSetFile2", "", $"{dataSetName}", "fox2");
            if (System.String.IsNullOrEmpty(outputPath))
            {
                return;
            }

            using var writer = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            var fox2Writer = new DataSetFile2Writer();

            fox2Writer.Write(writer, scene);
        }
    }
}