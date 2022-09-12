using UnityEngine;

namespace Tpp.GameKit
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class TppCoverPointGizmo : MonoBehaviour
    {
        private readonly static Color MainColor = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);
        private readonly static Color ArrowColor = new(176.0f / 255.0f, 12.0f / 255.0f, 0f);

        void OnDrawGizmos()
        {
            Vector3 origin = this.transform.position;

            Gizmos.color = ArrowColor;
            Vector3 arrowHeadPos = origin + 1.5f * this.transform.forward;
            Gizmos.DrawLine(origin, arrowHeadPos);

            Vector3 arrowPointer = this.transform.forward;
            arrowPointer = Quaternion.AngleAxis(-45f, this.transform.up) * (0.4f * this.transform.forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);
            arrowPointer = Quaternion.AngleAxis(45f, this.transform.up) * (0.4f * this.transform.forward);
            Gizmos.DrawLine(arrowHeadPos, arrowHeadPos - arrowPointer);

            Gizmos.color = MainColor;
            Gizmos.DrawLine(origin - this.transform.forward, origin);
            Gizmos.DrawLine(origin - this.transform.up, origin + this.transform.up);
            Gizmos.DrawLine(origin - this.transform.right, origin + this.transform.right);
        }

        void OnDrawGizmosSelected()
        {
            OnDrawGizmos();
        }
    }
}