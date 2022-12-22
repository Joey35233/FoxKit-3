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
using Fox.Fio;
using Fox.Geox;

namespace FoxKit.MenuItems
{
    public class ImportGeoxPathFixedPack
    {
        [MenuItem("FoxKit/Import/GeoxPathFixedPack")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import GeoxPathFixedPack", "", "gpfp");
            if (string.IsNullOrEmpty(assetPath))
                return;

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var gpfpReader = new GeoxPathFixedPackReader();
            var scene = gpfpReader.Read(reader);
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);
        }
    }
}
