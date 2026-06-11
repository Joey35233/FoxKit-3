using System;
using Fox.Core;
using Fox.Core.Utils;
using Fox.Gr;
using PlasticPipe.Tube;
using UnityEditor;
using UnityEngine;

namespace Tpp.GameKit
{
    [ExecuteAlways]
    [SelectionBase]
    public partial class TppObjectBrushPluginBush
    {
        private void OnDrawGizmosSelected()
        {
            if (gimmickParameter == null)
            {
                Debug.Assert(ModelInstance == null);
                return;
            }
            
            if (ModelInstance == null)
                return;

            Bounds bounds = new Bounds();
            if (ModelUtils.CalculateBounds(ModelInstance.transform, ref bounds))
            {
                float sphereRadius = gimmickParameter.modelRadius;
                
                Gizmos.matrix = Matrix4x4.Translate(transform.position);
                Gizmos.DrawWireSphere(bounds.center, sphereRadius);
            }
        }
    }
}
