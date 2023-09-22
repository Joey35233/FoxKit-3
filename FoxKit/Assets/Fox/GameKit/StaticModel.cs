using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class StaticModel : TransformData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            string path = "/Assets/Game" + modelFile.path.CString;
            if (System.String.IsNullOrEmpty(path))
            {
                logger.AddWarningNullProperty(nameof(modelFile));
                return;
            }

            // Remove leading /
            string trimmedPath = path.Remove(0, 1);
            GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedPath);
            if (asset == null)
            {
                logger.AddWarningMissingAsset(trimmedPath);
                return;
            }

            var instance = GameObject.Instantiate(asset);
            instance.transform.SetParent(gameObject.transform, false);
        }
    }
}