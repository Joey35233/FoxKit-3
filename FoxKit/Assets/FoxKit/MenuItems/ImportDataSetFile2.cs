using Fox.Core;
using Fox.Core.Utils;
using System;
using Fox.Fs;
using UnityEditor;

namespace FoxKit.MenuItems
{
    public static class ImportDataSetFile2
    {
        private const string ExtensionWhitelist = "fox2,bnd,clo,des,evf,fsd,lad,parts,ph,phsd,sdf,sim,tgt,vdp,veh,vfxlf";
        
        [MenuItem("FoxKit/Import/DataSetFile2")]
        private static void OnImportAsset()
        {
            string externalPath = EditorUtility.OpenFilePanel("Import DataSetFile2", "", ExtensionWhitelist);
            if (string.IsNullOrEmpty(externalPath))
            {
                return;
            }

            var logger = new TaskLogger("Import DataSetFile2");

            string path = Fox.Fs.FileSystem.GetVirtualPathFromExternalPath(externalPath);
            if (path == null)
            {
                logger.AddError("Selected file is not within external directory.");
                logger.LogToUnityConsole();
                return;
            }
            
            ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadExternalFile(path);
            UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, DataSetFile2.SceneLoadMode.Auto, logger);
            logger.LogToUnityConsole();
            
            Fox.Fs.FileSystem.TryImportAsset(scene, path);
        }
        
        [MenuItem("FoxKit/Import/DataSetFile2 (Loose)")]
        private static void OnImportLooseAsset()
        {
            string externalPath = EditorUtility.OpenFilePanel("Import DataSetFile2 (Loose)", "", ExtensionWhitelist);
            if (String.IsNullOrEmpty(externalPath))
            {
                return;
            }

            var logger = new TaskLogger("Import DataSetFile2 (Loose)");

            ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadLooseFile(externalPath);
            UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, DataSetFile2.SceneLoadMode.Auto, logger);
            logger.LogToUnityConsole();
            
            Fox.Fs.FileSystem.TryImportAsset(scene, externalPath, ImportFileMode.Loose);
        }
        
        [MenuItem("FoxKit/Open/DataSetFile2")]
        private static void OnOpenAsset()
        {
            string externalPath = EditorUtility.OpenFilePanel("Open DataSetFile2", "", ExtensionWhitelist);
            if (String.IsNullOrEmpty(externalPath))
            {
                return;
            }

            var logger = new TaskLogger("Open DataSetFile2");

            ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadLooseFile(externalPath);
            UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, DataSetFile2.SceneLoadMode.Auto, logger);
            logger.LogToUnityConsole();
            
            Fox.Fs.FileSystem.TryImportAsset(scene, externalPath, ImportFileMode.OpenDontSave);
        }
    }
}