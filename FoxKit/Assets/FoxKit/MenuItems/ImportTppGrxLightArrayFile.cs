using Fox.Fio;
using Tpp.Effect;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using CsSystem = System;

namespace FoxKit.MenuItems
{
    public class ImportTppGrxLightArrayFile
    {
        [MenuItem("FoxKit/Import/TppGrxLightArrayFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import TppGrxLightArrayFile", "", "grxla");
            if (CsSystem.String.IsNullOrEmpty(assetPath))
                return;
            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var grxlaReader = new TppGrxLightArrayFileReader();
            if (grxlaReader.Read(reader) is Scene scene)
                scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);
            else
                Debug.LogError("TGRXLA import failed.");
        }
    }
}
