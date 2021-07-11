using Fox.Core;
using System.IO;
using UnityEditor;
using CsSystem = System;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.GameCore;
using System.Collections.Generic;
using System;

namespace FoxKit.MenuItems
{
    public static class ImportDataSet
    {
        [MenuItem("FoxKit/Import/DataSet")]
        private static void OnImportAsset()
        {
            var assetPath = EditorUtility.OpenFilePanel("Import DataSet", "", "fox2,bnd,clo,des,evf,fsd,lad,parts,ph,phsd,sdf,sim,tgt,vdp,veh,vfxlf");
            if (string.IsNullOrEmpty(assetPath))
            {
                return;
            }

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var fox2Reader = new DataSetFile2Reader();
            var entities = fox2Reader.Read(reader);

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene); //CreateScene(CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath));
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);

            var typeCount = new Dictionary<Type, int>();
            UnityEngine.GameObject dataSetGameObject = null;
            foreach(var entity in entities)
            {
                var gameObject = new UnityEngine.GameObject();
                if (entity is Data)
                {
                    gameObject.name = (entity as Data).name;
                }
                else
                {
                    gameObject.transform.SetParent(dataSetGameObject.transform);
                    if (typeCount.ContainsKey(entity.GetType()))
                    {
                        gameObject.name = entity.GetType().Name + (typeCount[entity.GetType()] + 1).ToString("D4");
                        typeCount[entity.GetType()]++;
                    }
                    else
                    {
                        gameObject.name = entity.GetType().Name + "0000";
                        typeCount.Add(entity.GetType(), 0);
                    }
                }
                if (entity is DataSet)
                {
                    dataSetGameObject = gameObject;
                    gameObject.name = "DataSet";
                }
            }

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + CsSystem.IO.Path.GetFileName(assetPath) + ".unity");
        }
    }
}