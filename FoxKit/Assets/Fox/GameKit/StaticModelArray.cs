using System;
using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using Transform = UnityEngine.Transform;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class StaticModelArray : Data
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                return;
            }
            
            // foreach (Matrix4x4 foxTransform in transforms)
            // {
            //     Matrix4x4 transform = Fox.Math.FoxToUnityMatrix(foxTransform);
            //     
            //     GameObject instance = GameObject.Instantiate(asset, gameObject.transform, false);
            //     Matrix4x4 unityTransform = Fox.Math.FoxToUnityMatrix(transform);
            //     instance.transform.position = unityTransform.GetPosition();
            //     //instance.transform.rotation = unityTransform.rotation;
            //     //instance.transform.position = Fox.Math.FoxToUnityVector3(transform.GetPosition());
            //     instance.transform.rotation = Fox.Math.FoxToUnityQuaternion(transform.rotation);
            //     instance.transform.localScale = transform.lossyScale;
            // }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private AsyncOperationHandle<GameObject> ModelHandle;

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, Matrix4x4 matrix)
        {
            matrix = Fox.Math.FoxToUnityMatrix(matrix);
            
            Vector3 position = matrix.GetColumn(3);
            Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
            Vector3 scale = new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);

            GameObject instance = GameObject.Instantiate(model, position, rotation);
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.transform.localScale = scale;
            instance.transform.SetParent(this.transform);
            instance.hideFlags = HideFlags.DontSaveInEditor;
        }

        public void CreateInstance()
        {
            
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
                foreach (var matrix in transforms)
                {
                    CreateModel(ModelHandle.Result, matrix);
                }
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
