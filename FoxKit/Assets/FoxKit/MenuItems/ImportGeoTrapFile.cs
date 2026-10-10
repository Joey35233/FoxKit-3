using Fox.Geox;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportGeoTrapFile
    {
        [MenuItem("FoxKit/Import/GeoTrapFile")]
        private static void OnImport()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GeoTrapFile", "", "trap");
            if (string.IsNullOrEmpty(assetPath))
                return;

            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            GameObject root = new GameObject(Path.GetFileNameWithoutExtension(assetPath));

            if (GeoTrapFileReader.Read(File.ReadAllBytes(assetPath), root))
                scene.name = Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("TRAP import failed.");
        }
    }
}
