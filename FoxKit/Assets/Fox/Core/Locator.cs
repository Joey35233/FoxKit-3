using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class Locator : TransformData
    {
        private readonly BoxGizmo Gizmo = new BoxGizmo { Color = new Color(0.819607843f, 0.768627451f, 0.623529412f) };

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