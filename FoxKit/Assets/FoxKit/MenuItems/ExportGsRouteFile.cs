using Fox.GameService;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ExportGsRouteFile
    {
        [MenuItem("GameObject/Export/GsRouteFile", false, -10)]
        private static void OnExport(MenuCommand command)
        {
            if (command == null || command.context == null)
            {
                return;
            }

            UnityEngine.SceneManagement.Scene scene = ((GameObject)command.context).scene;
            string routeSetName = scene.name;
            string outputPath = EditorUtility.SaveFilePanel("Export GsRouteFile", "", $"{routeSetName}", "frt");
            if (System.String.IsNullOrEmpty(outputPath))
            {
                return;
            }

            using var writer = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            var frtWriter = new GsRouteSetWriter();

            frtWriter.Write(writer, scene);
        }
    }
}
