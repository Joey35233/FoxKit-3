using Fox.Ui;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ImportLangFile
    {
        [MenuItem("FoxKit/Import/LangFile")]
        private static void OnImportAsset()
        {
            string assetPath = Fox.Fs.FileUtils.OpenFilePanel("Import LangFile", "", "lng,lng2");
            if (String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var stream = new FileStream(assetPath, FileMode.Open);
            var langReader = new LangFileReader();
            List<LangFileEntry> entries = langReader.Read(stream, new Dictionary<uint, string>());
            LangFileAsset asset = ScriptableObject.CreateInstance<LangFileAsset>();
            asset.Entries = entries;

            // TODO Read langId dictionary
            // TODO get real path
            AssetDatabase.CreateAsset(asset, $"Assets/{System.IO.Path.GetFileNameWithoutExtension(assetPath)}.asset");
            AssetDatabase.SaveAssets();
        }
    }
}