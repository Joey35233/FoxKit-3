using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameKit
{
    [ExecuteInEditMode]
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
        
        private GameObject ModelPrefab;

        private GameObject Instance;

        private void CreateModel(GameObject model, ObjectBrushObject obj)
        {
            Vector3 position = obj.Position;
            Quaternion rotation = obj.Rotation;
            Vector3 scale = Vector3.one * Mathf.Lerp(minSize, maxSize, obj.NormalizedScale);

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

            if (modelFile != FilePtr.Empty)
            {
                ModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
                if (ModelPrefab)
                    foreach (var obj in Objects)
                        CreateModel(ModelPrefab, obj);
                else
                    Debug.Log($"Could not find: {modelFile}");
            }
        }

        private void OnEnable()
        {
            ReloadFile();
        }
    }
}