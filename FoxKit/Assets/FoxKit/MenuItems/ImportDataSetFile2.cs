using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using CsSystem = System;

namespace FoxKit.MenuItems
{
    public static class ImportDataSetFile2
    {
        [MenuItem("FoxKit/Import/DataSetFile2")]
        private static void OnImportAsset()
        {
            string externalPath = EditorUtility.OpenFilePanel("Import DataSetFile2", "", "fox2,bnd,clo,des,evf,fsd,lad,parts,ph,phsd,sdf,sim,tgt,vdp,veh,vfxlf");
            if (String.IsNullOrEmpty(externalPath))
            {
                return;
            }

            var logger = new TaskLogger("Import DataSetFile2");

            string path = Fox.Fs.FileSystem.GetFoxPathFromExternalPath(externalPath);
            ReadOnlySpan<byte> fileData = Fox.Fs.FileSystem.ReadExternalFile(path);
            UnityEngine.SceneManagement.Scene scene = DataSetFile2.Read(fileData, DataSetFile2.SceneLoadMode.Auto, logger);
            logger.LogToUnityConsole();
            
            Fox.Fs.FileSystem.TryImportAsset(scene, path);
        }
    }
}