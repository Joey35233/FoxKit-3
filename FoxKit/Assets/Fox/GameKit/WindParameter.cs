namespace Fox.GameKit
{
    public partial class WindParameter : Fox.GameKit.EnvironmentParameter
    {
        private partial float Get_speed() => throw new System.NotImplementedException();
        private partial void Set_speed(float value) => throw new System.NotImplementedException();

        private partial UnityEngine.Quaternion Get_rotation() => throw new System.NotImplementedException();
        private partial void Set_rotation(UnityEngine.Quaternion value) => throw new System.NotImplementedException();

        internal float GetInfluenceOfGlobal() => influenceOfGlobal;
        internal void SetInfluenceOfGlobal(float value) => influenceOfGlobal = value;
    }
}