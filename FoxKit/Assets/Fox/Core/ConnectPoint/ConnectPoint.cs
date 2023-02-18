using UnityEngine;

namespace Fox.Core
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PointGizmo))]
    public class ConnectPoint : MonoBehaviour
    {
        private void Reset()
        {
            PointGizmo pointGizmo = gameObject.GetComponent<PointGizmo>();
            if (pointGizmo is not null)
            {
                pointGizmo.ScaleMode = PointGizmo.GizmoScaleMode.InheritLocal;
                pointGizmo.Scale = new Vector3(0.05f, 0.05f, 0.05f);
                pointGizmo.DrawLabel = true;
            }
        }
    }
}