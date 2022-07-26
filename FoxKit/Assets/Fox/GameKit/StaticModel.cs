using Fox.Core;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    public partial class StaticModel : TransformData
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

            var instance = GameObject.Instantiate(asset) as GameObject;
            instance.transform.SetParent(gameObject.transform, false);
        }
    }
}