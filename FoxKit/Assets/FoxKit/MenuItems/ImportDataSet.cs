using Fox.Core;
using System.IO;
using UnityEditor;
using CsSystem = System;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Fox.GameCore;
using System.Collections.Generic;
using System;
using System.Linq;

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

            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
            scene.name = CsSystem.IO.Path.GetFileNameWithoutExtension(assetPath);

            using var reader = new BinaryReader(System.IO.File.OpenRead(assetPath));
            var fox2Reader = new DataSetFile2Reader();
            var readResult = fox2Reader.Read(reader);

            var typeCount = new Dictionary<Type, int>();
            var transformGameObjects = new Dictionary<Entity, UnityEngine.GameObject>();

            foreach(var gameObject in readResult.GameObjects)
            {
                var entity = gameObject.GetComponent<FoxEntity>().Entity;

                // Name the GameObject
                if (entity is Data)
                {
                    gameObject.name = (entity as Data).name;
                }
                else
                {
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

                // Parenting
                if (entity is TransformData)
                {
                    transformGameObjects.Add(entity, gameObject);
                }
                else
                {
                    gameObject.transform.SetParent(readResult.DataSetGameObject.transform);
                }

                entity.InitializeGameObject(gameObject);
            }

            foreach(var entity in transformGameObjects.Keys)
            {
                var transformData = entity as TransformData;

                var parent = transformData.parent;
                if (parent.Entity == null)
                    continue;

                var parentGameObject = transformGameObjects[parent.Entity];
                var gameObject = transformGameObjects[entity];
                gameObject.transform.SetParent(parentGameObject.transform);
            }

            EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + CsSystem.IO.Path.GetFileName(assetPath) + ".unity");
        }
    }
}