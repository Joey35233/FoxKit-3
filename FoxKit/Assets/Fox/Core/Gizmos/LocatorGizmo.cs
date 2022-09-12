using UnityEngine;

namespace Fox.Core
{
    /// <summary>
    /// Draws a locator gizmo in the scene.
    /// </summary>
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class LocatorGizmo : MonoBehaviour
    {
        private readonly static Color LocatorColor = new(67.0f / 255.0f, 1.0f, 163.0f / 255.0f);

        void OnDrawGizmos()
        {
            Gizmos.color = LocatorColor;
            Gizmos.DrawLine(this.transform.position - this.transform.forward, this.transform.position + this.transform.forward);
            Gizmos.DrawLine(this.transform.position - this.transform.up, this.transform.position + this.transform.up);
            Gizmos.DrawLine(this.transform.position - this.transform.right, this.transform.position + this.transform.right);
        }

        void OnDrawGizmosSelected()
        {
            OnDrawGizmos();
        }
    }
}