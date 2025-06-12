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
            string assetPath = EditorUtility.OpenFilePanel("Import DataSetFile2", "", "fox2,bnd,clo,des,evf,fsd,lad,parts,ph,phsd,sdf,sim,tgt,vdp,veh,vfxlf");
            if (String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            UnityEngine.SceneManagement.Scene scene;
            try
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Additive);
            }
            catch (InvalidOperationException)
            {
                scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            }
            scene.name = System.IO.Path.GetFileNameWithoutExtension(assetPath);

            var logger = new TaskLogger("Import FOX2");
            byte[] fileData = System.IO.File.ReadAllBytes(assetPath);
            var fox2Reader = new DataSetFile2Reader();
            _ = fox2Reader.Read(fileData, logger);

            logger.LogToUnityConsole();
            
            _ = EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + CsSystem.IO.Path.GetFileName(assetPath) + ".unity");
        }
    }
}