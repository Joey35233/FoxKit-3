using Fox.Fio;
using Fox.Geo;
using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoxKit.MenuItems
{
    public class ImportGeoPathFixedPackFile
    {
        [MenuItem("FoxKit/Import/GeoPathFixedPackFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GeoPathFixedPackFile", "", "gpfp");
            if (System.String.IsNullOrEmpty(assetPath))
                return;

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var gpfpReader = new GeoPathFixedPackFileReader();
            UnityEngine.SceneManagement.Scene? scene;
            try
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            }
            catch (InvalidOperationException)
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            }
            scene = gpfpReader.Read(reader);
            if (scene is Scene realScene)
                realScene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("GPFP import failed.");
        }
    }
}
