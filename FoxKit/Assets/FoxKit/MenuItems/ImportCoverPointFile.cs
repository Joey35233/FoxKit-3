using Fox.Geo;
using System.IO;
using UnityEditor;
using CsSystem = System;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.GameCore;
using System.Collections.Generic;
using System;
using System.Linq;

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

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var coverPointReader = new Tpp.GameKit.CoverPointFileReader();

            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            scene.name = $"{Path.GetFileNameWithoutExtension(assetPath)}_fox2_tcvp";

            coverPointReader.Read(reader);

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + scene.name + ".unity");
        }
    }
}