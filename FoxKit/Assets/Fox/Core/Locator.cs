using UnityEngine;

namespace Fox.Core
{
    public partial class Locator : TransformData
    {
        public override void Reset()
        {
            base.Reset();
            size = 1;
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