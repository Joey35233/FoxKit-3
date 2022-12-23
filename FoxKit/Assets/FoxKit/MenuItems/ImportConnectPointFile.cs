using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Fox.Fio;
using Fox.Core;

namespace FoxKit.MenuItems
{
    public static class ImportConnectPointFile
    {
        [MenuItem("FoxKit/Import/ConnectPointFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import ConnectPointFile", "", "fcnp");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }
            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var fcnpReader = new ConnectPointFileReader();
            fcnpReader.Read(reader);
        }
    }
}
