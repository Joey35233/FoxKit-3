using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEditor;
using UnityEditor.AssetImporters;
using System.IO;

namespace Fox.Nav
{
    [ScriptedImporter(1, "nav2")]
    public class NavFileScriptedImporter : ScriptedImporter
    {
        public override void OnImportAsset(AssetImportContext ctx)
        {
            // Read the entire file as byte array
            byte[] fileData = File.ReadAllBytes(ctx.assetPath);
            
            string fileName = System.IO.Path.GetFileNameWithoutExtension(ctx.assetPath);
            
            // Create the Nav2Asset
            GameObject gameObject = new GameObject(fileName);
            NavFile navFile = gameObject.AddComponent<NavFile>();
            navFile.Data = fileData;
            
            // Add to context
            ctx.AddObjectToAsset(fileName, gameObject);
            ctx.SetMainObject(gameObject);
        }
    }
}