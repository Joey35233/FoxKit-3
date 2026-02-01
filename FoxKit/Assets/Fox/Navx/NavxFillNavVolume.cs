using Fox.Core;
using System;
using UnityEngine;

namespace Fox.Navx
{
    public partial class NavxFillNavVolume
    {
        public override void Reset()
        {
            base.Reset();
            sceneName = "MainScene";
        }

        public void OnDrawGizmos()
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;
            Gizmos.color = BoxGizmo.UnselectedColor;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }
    }
}