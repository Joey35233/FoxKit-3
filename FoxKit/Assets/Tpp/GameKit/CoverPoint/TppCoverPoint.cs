using Fox.Core.Utils;
using UnityEngine;

namespace Tpp.GameKit
{
    public partial class TppCoverPoint : Fox.Tactical.GkTacticalPoint
    {
        private static readonly Color MainColor = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);
        private static readonly Color ArrowColor = new(176.0f / 255.0f, 12.0f / 255.0f, 0f);

        private void OnDrawGizmos()
        {
            UnityEngine.Transform trans = this.transform;

            Vector3 origin = trans.position;
            Vector3 up = trans.up;
            Vector3 forward = trans.forward;
            Vector3 right = trans.right;

            Gizmos.color = ArrowColor;
            Vector3 arrowHeadPos = origin + (1.5f * forward);
            Gizmos.DrawLine(origin, arrowHeadPos);
            Vector3 arrowPointer = Quaternion.AngleAxis(-45f, up) * (0.4f * forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);
            arrowPointer = Quaternion.AngleAxis(45f, up) * (0.4f * forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);

            Gizmos.color = MainColor;
            Gizmos.DrawLine(origin - forward, origin);
            Gizmos.DrawLine(origin - up, origin + up);
            Gizmos.DrawLine(origin - right, origin + right);
        }

        private void OnDrawGizmosSelected() => OnDrawGizmos();
    }
}
