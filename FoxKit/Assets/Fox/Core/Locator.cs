using UnityEngine;

namespace Fox.Core
{
    [System.Serializable]
    public partial class Locator : TransformData
    {
        private readonly BoxGizmo Gizmo = new BoxGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = this.name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmos();
        }
    }
}