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
        [MenuItem("FoxKit/Import/GrxLightArrayFile")]
        private static void OnImportAsset()
        {
            string assetPath = EditorUtility.OpenFilePanel("Import GrxLightArrayFile", "", "grxla");
            if (CsSystem.String.IsNullOrEmpty(assetPath))
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
