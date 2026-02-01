using System;
using Fox.Core;
using Fox.Core.Utils;
using Fox.GameKit;
using Fox.Gr;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

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
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            foreach (var modelFileInstance in modelFile)
            {
                if (modelFileInstance == FilePtr.Empty)
                {
                    logger.AddWarningEmptyPath(nameof(modelFile));
                    return;
                }
            }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private List<AsyncOperationHandle<GameObject>> ModelHandles = new();

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, ObrObject obj)
        {
            Vector3 position = obj.Position;
            Quaternion rotation = obj.Rotation;
            Vector3 scale = Vector3.one * Mathf.Lerp(minSize, maxSize, obj.Scale);

            GameObject instance = GameObject.Instantiate(model, position, rotation);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.transform.localScale = scale;
            instance.transform.SetParent(this.transform);
            instance.hideFlags = HideFlags.DontSaveInEditor;
        }
        
        public void ReloadFile(TaskLogger logger = null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.GetComponent<Entity>() != null)
                    continue;
                DestroyImmediate(child.gameObject);
            }

            for (int i = 0; i < modelFile.Count; i++)
            {
                Path targetPath = modelFile[i]?.path;
                if (targetPath is null || string.IsNullOrEmpty(targetPath.String))
                    return;
                
                var getLocationsHandle = Addressables.LoadResourceLocationsAsync(targetPath.String);
                getLocationsHandle.WaitForCompletion();
                    
                IList<IResourceLocation> results = getLocationsHandle.Result;
                if (results.Count > 0)
                {
                    IResourceLocation firstLocation = results[0];
                    ModelHandles.Insert(i,Addressables.LoadAssetAsync<GameObject>(firstLocation));;
                    _ = ModelHandles[i].WaitForCompletion();
                    OnLoadAsset(ModelHandles);
                }
                else
                {
                    Debug.Log($"Could not find: {targetPath.String}");
                }
                Addressables.Release(getLocationsHandle);
            }
        }
        private void OnLoadAsset(List<AsyncOperationHandle<GameObject>> handle)
        {
            ModelHandles = handle;

            foreach (var modelHandle in ModelHandles)
            {
                if (modelHandle.Status == AsyncOperationStatus.Succeeded)
                {
                    foreach (var obj in Objects)
                    {
                        CreateModel(modelHandle.Result, obj);
                    }
                }
            }
        }

        private void OnEnable()
        {
            ReloadFile();
        }
        
        private void OnDisable()
        {
            foreach (var modelHandle in ModelHandles)
                if (modelHandle.IsValid())
                    Addressables.Release(modelHandle);
        }
    }
}
