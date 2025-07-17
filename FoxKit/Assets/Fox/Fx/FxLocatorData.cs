using Fox.Core;

namespace Fox.Fx
{
    [System.Serializable]
    public partial class FxLocatorData
    {
        private readonly BoxGizmo Gizmo = new();

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
