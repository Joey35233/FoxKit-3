using Fox.Core;
using UnityEngine;

namespace Fox.Sdx
{
    public partial class SoundSource : Fox.Core.TransformData
    {
        private readonly SphereGizmo Gizmo = new SphereGizmo { SelectedColor = EditorColors.AudioSelectedColor, UnselectedColor = EditorColors.AudioUnselectedColor };

        public void OnDrawGizmos()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Radius = this.playRange;
            Gizmo.Label = (this as MonoBehaviour).name;
            Gizmo.OnDrawGizmos();
        }

        public void OnDrawGizmosSelected()
        {
            Gizmo.Transform = (this as MonoBehaviour).transform;
            Gizmo.Radius = this.playRange;
            Gizmo.Label = null;
            Gizmo.OnDrawGizmosSelected();
        }
    }
}