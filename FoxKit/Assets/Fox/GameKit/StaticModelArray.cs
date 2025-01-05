using System;
using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;
using Transform = UnityEngine.Transform;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
    public partial class StaticModelArray : Data
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            // if (modelFile == FilePtr.Empty)
            // {
            //     logger.AddWarningEmptyPath(nameof(modelFile));
            //     return;
            // }
            //
            // GameObject asset = AssetManager.LoadAsset<GameObject>(modelFile, out string unityPath);
            // if (asset == null)
            // {
            //     logger.AddWarningMissingAsset(unityPath);
            //     return;
            // }
            //
            // foreach (Matrix4x4 transform in transforms)
            // {
            //     GameObject instance = GameObject.Instantiate(asset, gameObject.transform, false);
            //     Matrix4x4 unityTransform = Fox.Math.FoxToUnityMatrix(transform);
            //     instance.transform.position = unityTransform.GetPosition();
            //     //instance.transform.rotation = unityTransform.rotation;
            //     //instance.transform.position = Fox.Math.FoxToUnityVector3(transform.GetPosition());
            //     instance.transform.rotation = Fox.Math.FoxToUnityQuaternion(transform.rotation);
            //     instance.transform.localScale = transform.lossyScale;
            // }
        }

        private GameObject Model;

        private List<GameObject> Instances;

        private void CreateModel(Matrix4x4 matrix)
        {
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
        
        private void ReloadFile()
        {
            Path targetPath = modelFile.path;
            if (string.IsNullOrEmpty(targetPath.String))
                return;
            
            var handle = Addressables.LoadAssetAsync<GameObject>(targetPath.String);
            handle.Completed += HandleOnCompleted;
        }
        private void HandleOnCompleted(AsyncOperationHandle<GameObject> handle)
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
        
        private void OnDisable()
        {
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
