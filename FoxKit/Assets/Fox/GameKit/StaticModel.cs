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
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

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
        
        public void ReloadFile(TaskLogger logger = null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.GetComponent<Entity>() != null)
                    continue;
                DestroyImmediate(child.gameObject);
            }

            Path targetPath = modelFile?.path;
            if (targetPath is null || string.IsNullOrEmpty(targetPath.String))
                return;
            
            var getLocationsHandle = Addressables.LoadResourceLocationsAsync(targetPath.String);
            getLocationsHandle.WaitForCompletion();
                
            IList<IResourceLocation> results = getLocationsHandle.Result;
            if (results.Count > 0)
            {
                IResourceLocation firstLocation = results[0];
                ModelHandle = Addressables.LoadAssetAsync<GameObject>(firstLocation);
                _ = ModelHandle.WaitForCompletion();
                OnLoadAsset(ModelHandle);
            }
            else
            {
                Debug.Log($"Could not find: {targetPath.String}");
            }
                
            Addressables.Release(getLocationsHandle);
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
            ReloadFile();
        }

        private void OnDisable()
        {
            if (ModelHandle.IsValid())
                Addressables.Release(ModelHandle);
        }
        public override void Reset()
        {
            base.Reset();
            lodFarSize = -1;
            lodNearSize = -1;
            lodPolygonSize = -1;
            color = Color.white;
            drawRejectionLevel = StaticModel_DrawRejectionLevel.DEFAULT;
            rejectFarRangeShadowCast = StaticModel_RejectFarRangeShadowCast.DEFAULT;
        }
    }
}