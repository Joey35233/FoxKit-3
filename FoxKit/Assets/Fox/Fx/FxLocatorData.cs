using Fox.Core;
using UnityEngine;

namespace Fox.Fx
{
    public partial class FxLocatorData
    {
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
