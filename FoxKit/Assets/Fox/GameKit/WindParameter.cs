using Fox.Core;

namespace Fox.GameKit
{
    public partial class WindParameter : Fox.GameKit.EnvironmentParameter
    {
        protected partial float Get_speed() => throw new System.NotImplementedException();
        protected partial void Set_speed(float value) { throw new System.NotImplementedException(); }

        protected partial UnityEngine.Quaternion Get_rotation() => throw new System.NotImplementedException();
        protected partial void Set_rotation(UnityEngine.Quaternion value) { throw new System.NotImplementedException(); }

        internal float GetInfluenceOfGlobal() => influenceOfGlobal;
        internal void SetInfluenceOfGlobal(float value) => influenceOfGlobal = value;
    }
}