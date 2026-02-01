using System;
using Fox.Core;
using Fox.Core.Utils;
using Fox.GameKit;
using Fox.Gr;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    [ExecuteAlways]
    [SelectionBase]
    public partial class TppObjectBrushPluginSkeletonModel
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

        private void OnEnable()
        {
            if (!PrefabUtility.IsPartOfPrefabInstance(this))
                return;

            base.OnEnableBase();
            
            if (modelFile.Count < 1 || modelFile[0] == FilePtr.Empty)
                return;
            
            GameObject modelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile[0].path.String);
            if (modelPrefab == null)
            {
                Debug.Log($"Could not find: {modelFile[0]}");
                return;
            }
            
            ModelInstance = (GameObject)PrefabUtility.InstantiatePrefab(modelPrefab);
            ModelInstance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            ModelInstance.hideFlags = HideFlags.DontSaveInEditor;
            ModelInstance.transform.SetParent(this.transform, false);
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

        private void OnDrawGizmosSelected()
        {
            if (ModelInstance == null)
                return;

            Bounds bounds = new Bounds();
            if (ModelUtils.CalculateBounds(ModelInstance.transform, ref bounds))
            {
                float sphereRadius = bounds.extents.y + extensionRadius;
                
                Gizmos.matrix = Matrix4x4.Translate(transform.position);
                Gizmos.DrawWireSphere(bounds.center, sphereRadius);
            }
        }
    }
}
