using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class ObjectBrushPluginStaticModel
    {
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                return;
            }
            else
            {
                Fox.Fs.FileSystem.ImportAssetCopy(modelFile.path.String);
            }
        }

        private GameObject ModelPrefab;

        private void OnEnable()
        {
            if (modelFile == FilePtr.Empty)
                return;
            
            ModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
            if (!ModelPrefab)
                Debug.Log($"Could not find: {modelFile}");
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