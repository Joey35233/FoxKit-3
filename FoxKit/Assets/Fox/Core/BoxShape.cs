using Fox.Core.Utils;
using System;
using UnityEditor;
using UnityEngine;

namespace Fox.Core
{
    public partial class BoxShape : Fox.Core.ShapeData
    {
        protected partial UnityEngine.Vector3 Get_size()
        {
            UnityEngine.Transform transform = (this as MonoBehaviour).transform;
            return transform.localScale / 2;
        }
        protected partial void Set_size(UnityEngine.Vector3 value)
        {
            UnityEngine.Transform transform = (this as MonoBehaviour).transform;
            transform.localScale = 2 * value;
        }

        private readonly BoxGizmo Gizmo = new BoxGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Label = (this as MonoBehaviour).name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmos();
        }
    }
}