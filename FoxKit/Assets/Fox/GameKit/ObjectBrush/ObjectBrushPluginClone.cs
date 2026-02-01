using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteAlways]
    [SelectionBase]
    public partial class ObjectBrushPluginClone
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

        private void OnEnable()
        {
            if (!PrefabUtility.IsPartOfPrefabInstance(this))
                return;
            
            base.OnEnableBase();
            
            if (modelFile == FilePtr.Empty)
                return;
            
            GameObject modelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
            if (modelPrefab == null)
            {
                Debug.Log($"Could not find: {modelFile}");
                return;
            }
            
            ModelInstance = (GameObject)PrefabUtility.InstantiatePrefab(modelPrefab);
            ModelInstance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            ModelInstance.hideFlags = HideFlags.DontSaveInEditor;
            ModelInstance.transform.SetParent(this.transform, false);
            ModelInstance.transform.localScale = Vector3.one;
        }

        private void OnValidate()
        {
            if (maxSize < minSize)
                maxSize = minSize + 0.001f;
            else if (minSize > maxSize)
                minSize = maxSize - 0.001f;
        }

        private void Update()
        {
            if (transform.hasChanged && ModelInstance != null)
            {
                float scale = transform.localScale.x;
                scale = Mathf.Clamp(scale, 1.0f, 2.0f);
                transform.localScale = new Vector3(scale, scale, scale);

                float normalizedScale = scale - 1.0f;

                float instanceScale = Mathf.Lerp(minSize, maxSize, normalizedScale);
                float correctiveScale = instanceScale / scale;
                ModelInstance.transform.localScale = correctiveScale * Vector3.one;
            }
        }

        private void OnDisable()
        {
            base.OnDisableBase();
        }
    }
}