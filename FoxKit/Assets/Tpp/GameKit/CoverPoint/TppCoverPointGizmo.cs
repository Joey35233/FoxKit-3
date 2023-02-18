using UnityEngine;

namespace Tpp.GameKit
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class TppCoverPointGizmo : MonoBehaviour
    {
        private static readonly Color MainColor = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);
        private static readonly Color ArrowColor = new(176.0f / 255.0f, 12.0f / 255.0f, 0f);

        private void OnDrawGizmos()
        {
            Vector3 origin = transform.position;

            Gizmos.color = ArrowColor;
            Vector3 arrowHeadPos = origin + (1.5f * transform.forward);
            Gizmos.DrawLine(origin, arrowHeadPos);
            _ = transform.forward;
            Vector3 arrowPointer = Quaternion.AngleAxis(-45f, transform.up) * (0.4f * transform.forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);
            arrowPointer = Quaternion.AngleAxis(45f, transform.up) * (0.4f * transform.forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);

            Gizmos.color = MainColor;
            Gizmos.DrawLine(origin - transform.forward, origin);
            Gizmos.DrawLine(origin - transform.up, origin + transform.up);
            Gizmos.DrawLine(origin - transform.right, origin + transform.right);
        }

        private void OnDrawGizmosSelected() => OnDrawGizmos();
    }
}