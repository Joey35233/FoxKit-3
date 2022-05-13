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

            var path = this.modelFile.path.CString;
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogWarning($"{this.name}: modelFile is null");
                return;
            }

            // Remove leading /
            var trimmedPath = path.Remove(0, 1);
            var asset = AssetDatabase.LoadAssetAtPath<GameObject>(trimmedPath);
            if (asset == null)
            {
                Debug.LogWarning($"{this.name}: Unable to find asset at path {trimmedPath}");
                return;
            }

            foreach (Matrix4x4 transform in this.transforms)
            {
                var instance = GameObject.Instantiate(asset) as GameObject;
                instance.transform.position = transform.GetPosition();
                instance.transform.rotation = transform.rotation;
                instance.transform.localScale = transform.lossyScale;
                instance.transform.SetParent(gameObject.transform, false);
            }
        }
    }
}
