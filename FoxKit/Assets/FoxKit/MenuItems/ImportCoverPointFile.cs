using System.IO;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.Fio;

namespace FoxKit.MenuItems
{
    public static class ImportCoverPointFile
    {
        [MenuItem("FoxKit/Import/CoverPointFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import CoverPointFile", "", "tcvp");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new FileStreamReader(File.OpenRead(assetPath));
            var coverPointReader = new Tpp.GameKit.CoverPointFileReader();

            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            scene.name = $"{Path.GetFileNameWithoutExtension(assetPath)}_fox2_tcvp";

            coverPointReader.Read(reader);

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + scene.name + ".unity");
        }
    }
}