using System;
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

        private GameObject ModelPrefab;

        private void OnEnable()
        {
            if (modelFile.Count < 1 || modelFile[0] == FilePtr.Empty)
                return;
            
            ModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile[0].path.String);
            if (!ModelPrefab)
                Debug.Log($"Could not find: {modelFile[0]}");
        }

        public override GameObject GetModelInstance(ObjectBrushObject obj)
        {
            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(ModelPrefab);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.hideFlags = HideFlags.DontSaveInEditor;
            instance.AddComponent<StaticModelArrayInstance>();
            
            instance.transform.position = obj.Position;
            instance.transform.rotation = obj.Rotation;
            instance.transform.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, obj.NormalizedScale);

            return instance;
        }
    }
}
