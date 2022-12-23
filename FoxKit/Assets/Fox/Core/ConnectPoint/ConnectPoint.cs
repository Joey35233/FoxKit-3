using Fox;
using System;
using UnityEngine;

namespace Fox.Core
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(PointGizmo))]
    public class ConnectPoint : MonoBehaviour
    {
        private void Reset()
        {
            var pointGizmo = this.gameObject.GetComponent<PointGizmo>();
            if (pointGizmo is not null)
            {
                pointGizmo.ScaleMode = PointGizmo.GizmoScaleMode.InheritLocal;
                pointGizmo.Scale = new Vector3(0.05f, 0.05f, 0.05f);
                pointGizmo.DrawLabel = true;
            }
        }
    }
}