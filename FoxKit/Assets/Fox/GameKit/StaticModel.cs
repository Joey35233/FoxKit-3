using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class StaticModel : TransformData
    {
        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

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

            Instantiate(asset, gameObject.transform, false);
        }
    }
}