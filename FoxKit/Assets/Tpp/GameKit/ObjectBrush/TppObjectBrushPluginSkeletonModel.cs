using System.Collections.Generic;
using Fox;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.GameKit;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    [ExecuteInEditMode]
    public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            foreach (var _modelFile in modelFile)
            {
                if (_modelFile == FilePtr.Empty)
                {
                    logger.AddWarningEmptyPath(nameof(modelFile));
                    return;
                }
                else
                {
                    Fox.Fs.FileSystem.ImportAssetCopy(_modelFile.path.String);
                }
            }
        }

        private GameObject[] ModelPrefabs;

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, ObjectBrushObject obj)
        {
            Vector3 position = obj.Position;
            Quaternion rotation = obj.Rotation;
            Vector3 scale = Vector3.one * Mathf.Lerp(minSize, maxSize, obj.NormalizedScale);

            GameObject instance =(GameObject)PrefabUtility.InstantiatePrefab(model, gameObject.transform);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.hideFlags = HideFlags.DontSaveInEditor;
            instance.AddComponent<StaticModelArrayInstance>();
        }
        
        public void ReloadFile(TaskLogger logger = null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.GetComponent<Entity>())
                    continue;
                DestroyImmediate(child.gameObject);
            }

            ModelPrefabs = new GameObject[modelFile.Count];
            for (int i = 0; i < modelFile.Count; i++)
            {
                FilePtr _modelFile = modelFile[i];
                
                if (_modelFile != FilePtr.Empty)
                {
                    GameObject prefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(_modelFile.path.String);
                    ModelPrefabs[i] = prefab;
                    
                    if (prefab)
                        foreach (var obj in Objects)
                            CreateModel(prefab, obj);
                    else
                        Debug.Log($"Could not find: {modelFile}");
                }
            }
        }

        private void OnEnable()
        {
            ReloadFile();
        }
    }
}
