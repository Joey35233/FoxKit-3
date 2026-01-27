using System.Collections.Generic;
using Fox;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.GameKit;
using UnityEngine;

namespace Tpp.GameKit
{
    [ExecuteInEditMode]
    public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin
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
            }
            
            // TODO: HACK
            ReloadFile(logger);
        }

        private List<GameObject> ModelHandles = new();

        private List<GameObject> Instances;

        private void CreateModel(GameObject model, ObrObject obj)
        {
            Vector3 position = obj.Position;
            Quaternion rotation = obj.Rotation;
            Vector3 scale = Vector3.one * Mathf.Lerp(minSize, maxSize, obj.Scale);

            GameObject instance = GameObject.Instantiate(model, position, rotation, this.transform);
            instance.transform.localScale = scale;
            instance.name = "INSTANCE_WILL_RESET_ON_RELOAD";
            instance.hideFlags = HideFlags.DontSaveInEditor;
        }
        
        public void ReloadFile(TaskLogger logger = null)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                if (child.GetComponent<Entity>())
                    continue;
                DestroyImmediate(child.gameObject);
            }

            for (int i = 0; i < modelFile.Count; i++)
            {
                FilePtr _modelFile = modelFile[i];
                
                if (_modelFile != FilePtr.Empty)
                {
                    GameObject modelHandle = Fox.Fs.FileSystem.LoadAsset<GameObject>(_modelFile.path.String);
                    ModelHandles[i] = modelHandle;
                    
                    if (modelHandle)
                        foreach (var obj in Objects)
                            CreateModel(modelHandle, obj);
                    else
                        Debug.Log($"Could not find: {modelFile}");
                }
            }
        }
    }
}
