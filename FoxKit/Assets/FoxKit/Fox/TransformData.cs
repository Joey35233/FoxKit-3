using Fox;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class TransformData : Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            var transformEntity = this.transform;
            if (transformEntity.Get() == null)
            {
                Debug.LogWarning($"{this.name}: transform is null");
                return;
            }

            gameObject.transform.position = transformEntity.Get().transform_translation;
            gameObject.transform.rotation = transformEntity.Get().transform_rotation_quat;
            gameObject.transform.localScale = transformEntity.Get().transform_scale;

            // TODO spawn mesh
            /*var visualizer = GameObject.CreatePrimitive(PrimitiveType.Cube);
            visualizer.transform.SetParent(gameObject.transform);
            visualizer.transform.localPosition = Vector3.zero;
            visualizer.transform.localRotation = Quaternion.identity;
            visualizer.transform.localScale = Vector3.one;*/
        }
    }
}