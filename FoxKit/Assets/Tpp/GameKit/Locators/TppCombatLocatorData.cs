using Fox.Core;
namespace Tpp.GameKit
{
	public partial class TppCombatLocatorData : Fox.Core.TransformData
	{
        private readonly DoubleSphereGizmo Gizmo = new DoubleSphereGizmo
        {
            SelectedColor = EditorColors.HostileColor,
            OuterRadiusColor = EditorColors.HostileColorDeselected,
            GizmoPath = "Tpp/GameKit/TppCombatLocatorData.png",
        };

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.radius;
            Gizmo.OuterRadius = this.lostSearchRadius;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.radius;
            Gizmo.OuterRadius = this.lostSearchRadius;
            Gizmo.OnDrawGizmosSelected();
        }
        public override void Reset()
        {
            base.Reset();
            radius = 10;
            lostSearchRadius = 45;
            memberCount = 2;
            memberCountFront = 4;
        }
    }
}