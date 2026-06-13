using Fox.GameService;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ExportGsRouteFile
    {
        [MenuItem("FoxKit/Export/GsRouteFile")]
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

        [MenuItem("GameObject/Export/GsRouteFile", false, -10)]
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
            string routeSetName = scene.name;
            string outputPath = EditorUtility.SaveFilePanel("Export GsRouteFile", "", $"{routeSetName}", "frt");
            if (System.String.IsNullOrEmpty(outputPath))
            {
                return;
            }

            // Record any custom route names so they un-hash on re-import.
            foreach (GsRouteData route in UnityEngine.Object.FindObjectsByType<GsRouteData>(FindObjectsSortMode.None))
            {
                if (route.gameObject.scene == scene)
                    RouteDictionaries.RegisterUserRoute(route.name);
            }

            using var writer = new BinaryWriter(System.IO.File.Open(outputPath, FileMode.Create), System.Text.Encoding.Default);
            var frtWriter = new GsRouteSetWriter();

            frtWriter.Write(writer, scene);
        }
    }
}
