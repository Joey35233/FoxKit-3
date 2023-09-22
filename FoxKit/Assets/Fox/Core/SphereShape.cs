using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class SphereShape : Fox.Core.ShapeData
    {
        protected partial float Get_radius()
        {
            TransformEntity transformEntity = transform.Get();
            return Mathf.Min(transformEntity.scale.x, transformEntity.scale.y, transformEntity.scale.z);
        }
        protected partial void Set_radius(float value)
        {
            TransformEntity transformEntity = transform.Get();
            transformEntity.scale = new Vector3(value, value, value);
        }
        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            base.InitializeGameObject(gameObject, logger);
            _ = gameObject.AddComponent<SphereGizmo>();
        }
    }
}