using UnityEngine;

namespace Fox.Core
{
    public partial class BoxShape : Fox.Core.ShapeData
    {
        private partial UnityEngine.Vector3 Get_size()
        {
            UnityEngine.Transform transform = this.transform;
            return transform.localScale / 2;
        }
        private partial void Set_size(UnityEngine.Vector3 value)
        {
            UnityEngine.Transform transform = this.transform;
            transform.localScale = 2 * value;
        }

        private readonly BoxGizmo Gizmo = new BoxGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = this.name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmosSelected();
        }
    }
}