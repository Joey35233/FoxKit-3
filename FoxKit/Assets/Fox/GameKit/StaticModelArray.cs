using Fox.Core;
using Fox.Core.Utils;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
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

            GameObject asset = AssetManager.LoadAsset<GameObject>(modelFile, out string unityPath);
            if (asset == null)
            {
                logger.AddWarningMissingAsset(unityPath);
                return;
            }

            foreach (Matrix4x4 transform in transforms)
            {
                GameObject instance = GameObject.Instantiate(asset, gameObject.transform, false);
                Matrix4x4 unityTransform = Kernel.Math.FoxToUnityMatrix(transform);
                instance.transform.position = unityTransform.GetPosition();
                //instance.transform.rotation = unityTransform.rotation;
                //instance.transform.position = Kernel.Math.FoxToUnityVector3(transform.GetPosition());
                instance.transform.rotation = Kernel.Math.FoxToUnityQuaternion(transform.rotation);
                instance.transform.localScale = transform.lossyScale;
            }
        }
    }
}
