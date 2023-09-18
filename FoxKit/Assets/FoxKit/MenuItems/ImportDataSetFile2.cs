using Fox.Core;
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

            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene,NewSceneMode.Single);
            scene.name = Path.GetFileNameWithoutExtension(assetPath);

            using var reader = new FileStreamReader(System.IO.File.OpenRead(assetPath));
            var fox2Reader = new DataSetFile2Reader();
            DataSetFile2Reader.ReadResult readResult = fox2Reader.Read(reader);

            var typeCount = new Dictionary<Type, int>();
            var transformGameObjects = new Dictionary<Entity, UnityEngine.GameObject>();

            foreach (UnityEngine.GameObject gameObject in readResult.GameObjects)
            {
                Entity entity = gameObject.GetComponent<Entity>();

                // Name the GameObject
                if (entity is Data)
                {
                    gameObject.name = (entity as Data).name.CString;
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
                else if (entity is DataElement)
                {
                    EntityHandle parent = (entity as DataElement).owner;

                    // I love orphaned DataElements
                    if (parent.Entity != null)
                    {
                        gameObject.transform.SetParent(parent.Entity.transform);
                        gameObject.transform.SetLocalPositionAndRotation(UnityEngine.Vector3.zero, UnityEngine.Quaternion.identity);
                    }
                }
                else
                {
                    gameObject.transform.SetParent(readResult.DataSetGameObject.transform);
                }

                entity.InitializeGameObject(gameObject);
            }

            foreach (Entity entity in transformGameObjects.Keys)
            {
                var transformData = entity as TransformData;

                EntityHandle parent = transformData.parent;
                if (parent.Entity == null)
                    continue;

                UnityEngine.GameObject parentGameObject = transformGameObjects[parent.Entity];
                UnityEngine.GameObject gameObject = transformGameObjects[entity];
                gameObject.transform.SetParent(parentGameObject.transform, false);
            }

            _ = EditorSceneManager.SaveScene(scene, "Assets/Scenes/" + CsSystem.IO.Path.GetFileName(assetPath) + ".unity");
        }
    }
}