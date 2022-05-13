using Fox;
using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class TransformData : Data
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            var transformEntity = this.transform.Get();
            if (transformEntity == null)
            {
                return;
            }

            gameObject.transform.position = transformEntity.transform_translation;
            gameObject.transform.rotation = transformEntity.transform_rotation_quat;
            gameObject.transform.localScale = transformEntity.transform_scale;
        }
    }
}