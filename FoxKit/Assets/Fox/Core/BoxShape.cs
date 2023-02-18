using UnityEngine;

namespace Fox.Core
{
    public partial class BoxShape : Fox.Core.ShapeData
    {
        protected partial UnityEngine.Vector3 Get_size()
        {
            TransformEntity transformEntity = transform.Get();
            return transformEntity.scale / 2;
        }
        protected partial void Set_size(UnityEngine.Vector3 value)
        {
            TransformEntity transformEntity = transform.Get();
            transformEntity.scale = 2 * value;
        }
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            _ = gameObject.AddComponent<BoxGizmo>();
        }
    }
}