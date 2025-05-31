using Fox.Core;
using System;

namespace Fox.Navx
{
    public partial class NavxNavFilter
    {
        private BoxGizmo Gizmo = new BoxGizmo();

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.OnDrawGizmos();
        }
    }
}