using Fox.Core;
using UnityEngine;

namespace Fox.Sdx
{
    public partial class SoundSource : Fox.Core.TransformData
    {
        private readonly SphereGizmo Gizmo = new SphereGizmo
        {
            SelectedColor = EditorColors.PlayerUtilityColor,
            GizmoPath = "Fox/Sdx/SoundSource.png"
        };

        public void OnDrawGizmos()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.playRange;
            Gizmo.Label = this.name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = this.transform;
            Gizmo.Radius = this.playRange;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmosSelected();
        }
    }
}