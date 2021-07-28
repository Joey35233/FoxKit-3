using Fox.Core;
using System.IO;
using UnityEditor;
using CsSystem = System;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.GameCore;
using System.Collections.Generic;
using System;
using Fox.Ui;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ImportLangFile
    {
        [MenuItem("FoxKit/Import/LangFile")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import LangFile", "", "lng,lng2");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var stream = new FileStream(assetPath, FileMode.Open);
            var langReader = new LangFileReader();
            var entries = langReader.Read(stream, new Dictionary<uint, string>());
            var asset = ScriptableObject.CreateInstance<LangFileAsset>();
            asset.Entries = entries;

            // TODO Read langId dictionary
            // TODO get real path
            AssetDatabase.CreateAsset(asset, $"Assets/{System.IO.Path.GetFileNameWithoutExtension(assetPath)}.asset");
            AssetDatabase.SaveAssets();
        }
    }
}