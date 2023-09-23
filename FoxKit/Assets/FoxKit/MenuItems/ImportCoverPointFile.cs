using Fox.Fio;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ImportCoverPointFile
    {
        [MenuItem("FoxKit/Import/CoverPointFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import CoverPointFile", "", "tcvp");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new FileStreamReader(File.OpenRead(assetPath));
            var coverPointReader = new Tpp.GameKit.CoverPointFileReader();

            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
            scene.name = $"{Path.GetFileNameWithoutExtension(assetPath)}_fox2_tcvp";

            coverPointReader.Read(reader);

            _ = EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + scene.name + ".unity");
        }
    }
}