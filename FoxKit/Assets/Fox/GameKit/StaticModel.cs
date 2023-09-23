using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class StaticModel : TransformData
    {
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);

            if (modelFile == FilePtr.Empty)
            {
                logger.AddWarningEmptyPath(nameof(modelFile));
                return;
            }

            GameObject asset = AssetManager.LoadAsset<GameObject>(modelFile, out string unityPath);
            if (asset == null)
            {
                logger.AddWarningMissingAsset(unityPath);
                return;
            }

            var instance = GameObject.Instantiate(asset);
            instance.transform.SetParent(gameObject.transform, false);
        }
    }
}