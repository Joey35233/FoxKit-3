using System.Collections.Generic;
using Fox;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.GameKit;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace Tpp.GameKit
{
    public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin
    {
        public static TppObjectBrushPluginSkeletonModel Deserialize(FileStreamReader reader)
        {
            var plugin = new TppObjectBrushPluginSkeletonModel();

            return plugin;
        }
        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            foreach (var modelFil in modelFile)
            {
                if (modelFil == FilePtr.Empty)
                {
                    logger.AddWarningEmptyPath(nameof(modelFile));
                    return;
                }
            }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private List<AsyncOperationHandle<GameObject>> ModelHandle = new();

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
                    ModelHandle.Insert(i,Addressables.LoadAssetAsync<GameObject>(firstLocation));;
                    _ = ModelHandle[i].WaitForCompletion();
                    OnLoadAsset(ModelHandle);
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
            ModelHandle = handle;

            foreach (var ModelHandl in ModelHandle)
            {
                if (ModelHandl.Status == AsyncOperationStatus.Succeeded)
                {
                    foreach (var obj in Objects)
                    {
                        CreateModel(ModelHandl.Result, obj);
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
            foreach (var ModelHandl in ModelHandle)
                if (ModelHandl.IsValid())
                    Addressables.Release(ModelHandl);
        }
    }
}
