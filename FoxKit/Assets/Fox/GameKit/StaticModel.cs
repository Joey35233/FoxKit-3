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

            string path = modelFile.path.CString;
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

            var instance = GameObject.Instantiate(asset);
            instance.transform.SetParent(gameObject.transform, false);
        }
    }
}