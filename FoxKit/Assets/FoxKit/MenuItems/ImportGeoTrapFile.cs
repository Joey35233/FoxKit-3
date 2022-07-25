using Fox.Core;
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
    public static class ImportGeoTrapFile
    {
        [MenuItem("FoxKit/Import/GeoTrapFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GeoTrapFile", "", "trap");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var trapReader = new GeoTrapFileReader();
            trapReader.Read(reader);

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + CsSystem.IO.Path.GetFileName(assetPath) + ".unity");
        }
    }
}