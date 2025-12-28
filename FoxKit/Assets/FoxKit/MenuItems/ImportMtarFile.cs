using System;
using Fox.Anim;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace FoxKit.MenuItems
{
    public static class ImportMtarFile
    {
        [MenuItem("FoxKit/Import/MtarFile")]
        private static void OnImportAsset()
        {
            string externalPath = EditorUtility.OpenFilePanel("Import MtarFile", Fox.Fs.FsModule.ExternalBasePath, "mtar");
            if (string.IsNullOrEmpty(externalPath))
                return;

            var logger = new TaskLogger("Import MtarFile");

            string virtualPath = Fox.Fs.FileSystem.GetVirtualPathFromExternalPath(externalPath);
            if (virtualPath == null)
            {
                logger.AddError("Selected file is not within external directory.");
                logger.LogToUnityConsole();
                return;
            }
            
            ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadExternalFile(virtualPath);
            AnimationClip[] clips = MtarFile.Convert(fileData);
            logger.LogToUnityConsole();
            
            Fox.Fs.FileSystem.TryImportAsset(clips, virtualPath);
        }
    }
}