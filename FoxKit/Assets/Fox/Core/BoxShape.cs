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

        public void OnDrawGizmos()
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = BoxGizmo.UnselectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = BoxGizmo.SelectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}