

using Fox.Core;

namespace Tpp.GameKit
{
	public partial class TppGuardTargetData : Fox.Core.TransformData
	{
        private readonly SphereGizmo Gizmo = new SphereGizmo
        {
            SelectedColor = EditorColors.HostileColor,
            GizmoPath = "Tpp/GameKit/TppGuardTargetData.png",
        };

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.radius;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.radius;
            Gizmo.OnDrawGizmosSelected();
        }
    }
}