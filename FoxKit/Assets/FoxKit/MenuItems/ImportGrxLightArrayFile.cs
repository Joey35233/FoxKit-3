using Fox.Fio;
using Fox.Grx;
using UnityEditor;
using CsSystem = System;

namespace FoxKit.MenuItems
{
    public class ImportGrxLightArrayFile
    {
        [MenuItem("FoxKit/Import/GrxLightArray")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GeoxPathFixedPack", "", "gpfp");
            if (string.IsNullOrEmpty(assetPath))
                return;
            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var grxlaReader = new GrxLightArrayFileReader();
            var scene = grxlaReader.Read(reader);
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);
        }
    }
}
