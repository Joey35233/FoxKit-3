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

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var trapReader = new GeoTrapFileReader();
            var scene = trapReader.Read(reader);
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);
        }
    }
}