using Fox.Fio;
using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public static class ImportNavTacticalActionFile
    {
        [MenuItem("FoxKit/Import/NavTacticalActionFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import NavTacticalAction", "", "nta");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new FileStreamReader(File.OpenRead(assetPath));
            var coverPointReader = new Fox.Tactical.TacticalActionFileReader();

            UnityEngine.SceneManagement.Scene scene;
            try
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            }
            catch (InvalidOperationException)
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            }
            scene.name = $"{Path.GetFileNameWithoutExtension(assetPath)}_fox2_nta";

            coverPointReader.Read(reader);

            _ = EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + scene.name + ".unity");
        }
    }
}
