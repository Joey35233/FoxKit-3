namespace Fox.Ph
{
    public partial class PhShapeParam : Fox.Core.Entity
    {
        internal UnityEngine.Vector3 GetOffset() => offset;
        internal void SetOffset(UnityEngine.Vector3 value) => offset = value;

        internal UnityEngine.Quaternion GetRotation() => rotation;
        internal void SetRotation(UnityEngine.Quaternion value) => rotation = value;

        internal UnityEngine.Vector3 GetSize() => size;
        internal void SetSize(UnityEngine.Vector3 value) => size = value;

        internal virtual void DrawGizmos()
        {
        }
    }
}