using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class StaticModelArray : Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);

            string path = "/Assets/Game" + modelFile.path.CString;
            if (System.String.IsNullOrEmpty(path))
            {
                Debug.LogWarning($"{name}: modelFile is null");
                return;
            }

            // Remove leading /
            string trimmedPath = path.Remove(0, 1);
            GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedPath);
            if (asset == null)
            {
                Debug.LogWarning($"{name}: Unable to find asset at path {trimmedPath}");
                return;
            }

            foreach (Matrix4x4 transform in transforms)
            {
                var instance = GameObject.Instantiate(asset);
                Matrix4x4 unityTransform = Kernel.Math.FoxToUnityMatrix(transform);
                instance.transform.position = unityTransform.GetPosition();
                //instance.transform.rotation = unityTransform.rotation;
                //instance.transform.position = Kernel.Math.FoxToUnityVector3(transform.GetPosition());
                instance.transform.rotation = Kernel.Math.FoxToUnityQuaternion(transform.rotation);
                instance.transform.localScale = transform.lossyScale;
                instance.transform.SetParent(gameObject.transform, false);
            }
        }
    }
}
