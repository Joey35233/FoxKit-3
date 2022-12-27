using Fox.Fio;
using Fox.Grx;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using CsSystem = System;

namespace FoxKit.MenuItems
{
    public class ImportGrxLightArrayFile
    {
        [MenuItem("FoxKit/Import/GrxLightArray")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GrxLightArray", "", "grxla");
            if (string.IsNullOrEmpty(assetPath))
                return;
            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var grxlaReader = new GrxLightArrayFileReader();
            if (grxlaReader.Read(reader) is Scene scene)
                scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("GRXLA import failed.");
        }
    }
}
