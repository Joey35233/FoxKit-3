using System.Collections.Generic;
using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.PartsBuilder
{
    [ExecuteInEditMode]
    public partial class ModelDescription
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

            if (modelFile != FilePtr.Empty)
            {
                ModelPrefab = Fox.Fs.FileSystem.LoadAsset<GameObject>(modelFile.path.String);
                if (ModelPrefab)
                    CreateModel(ModelPrefab);
                else
                    Debug.Log($"Could not find: {modelFile}");
            }
        }

        private void OnEnable()
        {
            ReloadFile();
        }
        
        public override void Reset()
        {
            base.Reset();
            lodFarPixelSize = -1;
            lodNearPixelSize = -1;
            lodPolygonSize = -1;
            drawRejectionLevel = ModelDescription_DrawRejectionLevel.DEFAULT;
            rejectFarRangeShadowCast = ModelDescription_RejectFarRangeShadowCast.DEFAULT;
        }
    }
}
