using System;
using System.Runtime.CompilerServices;
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
        private readonly static float LocatorScale = 1.0f;

        void OnDrawGizmos()
        {
            Gizmos.color = LocatorColor;

            var position = this.transform.position;
            var scale = this.transform.localScale;

            var right = (this.transform.right * LocatorScale) * scale.x;
            var lineRi = new Tuple<Vector3, Vector3>(position - right, position + right);
            Gizmos.DrawLine(lineRi.Item1, lineRi.Item2);

            var up = (this.transform.up * LocatorScale) * scale.y;
            var lineUp = new Tuple<Vector3, Vector3>(position - up, position + up);
            Gizmos.DrawLine(lineUp.Item1, lineUp.Item2);

            var forward = (this.transform.forward * LocatorScale) * scale.z;
            var lineFw = new Tuple<Vector3, Vector3>(position - forward, position + forward);
            Gizmos.DrawLine(lineFw.Item1, lineFw.Item2);
        }

        void OnDrawGizmosSelected()
        {
            OnDrawGizmos();
        }
    }
}