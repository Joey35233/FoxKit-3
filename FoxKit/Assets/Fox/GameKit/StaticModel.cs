using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class StaticModel : TransformData
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                return;
            }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private AsyncOperationHandle<GameObject> ModelHandle;

        private GameObject Instance;

        private void CreateModel(GameObject model)
        {
            GameObject instance = GameObject.Instantiate(model, this.transform, false);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.hideFlags = HideFlags.DontSaveInEditor;
        }
        
        private void ReloadFile(TaskLogger logger = null)
        {
            Path targetPath = modelFile?.path;
            if (targetPath is null || string.IsNullOrEmpty(targetPath.String))
                return;
            
            Addressables.LoadResourceLocationsAsync(targetPath.String).Completed +=
                (handle) =>
                {
                    IList<IResourceLocation> results = handle.Result;
                    if (results.Count > 0)
                    {
                        IResourceLocation firstLocation = results[0];
                        Addressables.LoadAssetAsync<GameObject>(firstLocation).Completed += OnLoadAsset;
                    }
                    else
                    {
                        Debug.Log($"Could not find: {targetPath.String}");
                    }
                        
                    Addressables.Release(handle);
                };
        }

        private void OnLoadAsset(AsyncOperationHandle<GameObject> handle)
        {
            ModelHandle = handle;
            
            if (ModelHandle.Status == AsyncOperationStatus.Succeeded)
            {
                CreateModel(ModelHandle.Result);
            }
        }

        private void OnEnable()
        {
            while (transform.childCount > 0)
                DestroyImmediate(transform.GetChild(0).gameObject);
            
            ReloadFile();
        }

        private void OnDisable()
        {
            if (ModelHandle.IsValid())
                Addressables.Release(ModelHandle);
        }
    }
}