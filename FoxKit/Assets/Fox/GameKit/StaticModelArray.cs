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

        private GameObject Model;

        private List<GameObject> Instances;

        private void CreateModel(Matrix4x4 matrix)
        {
            matrix = Fox.Math.FoxToUnityMatrix(matrix);
            
            Vector3 position = matrix.GetColumn(3);
            Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
            Vector3 scale = new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);

            GameObject instance = GameObject.Instantiate(Model, position, rotation);
            instance.name = "StaticModelArrayInstance";
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
                        logger?.AddWarningMissingAsset(targetPath.String);
                    }
                        
                    Addressables.Release(handle);
                };
        }

        private void OnLoadAsset(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Model = handle.Result;
                foreach (var matrix in transforms)
                {
                    CreateModel(matrix);
                }
            }
        }

        private void OnEnable()
        {
            while (transform.childCount > 0)
                DestroyImmediate(transform.GetChild(0).gameObject);
            
            ReloadFile();
        }

        public void AddInstance(Vector3 position, Quaternion rotation, Vector3 scale)
        {
            Matrix4x4 matrix = Matrix4x4.TRS(position, rotation, scale);
            transforms.Add(matrix);
        }

        public void UpdateInstance(int index, Matrix4x4 matrix)
        {
            if (index >= 0 && index < transforms.Count)
            {
                transforms[index] = matrix;
            }
        }
    }
}
