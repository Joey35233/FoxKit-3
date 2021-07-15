namespace Fox
{
    using System;
    using UnityEngine;

    [Serializable]
    public class InspectorTestData : Data
    {
        #region Non-array properties
        public sbyte property10;
        public byte property11;
        public short property12;
        public ushort property13;
        public int property14;
        public uint property15;
        public long property16;
        public ulong property17;
        public float property18;
        public double property19;
        public bool property20;
        public Fox.String property21;
        public Fox.Path property22;
        public EntityPtr<Data> property23;
        public Vector3 property24;
        public Vector4 property25;
        public Quaternion property26;
        public Matrix4x4 property27;
        public Color property28;
        public Fox.FilePtr<File> property29;
        public Fox.EntityHandle property30;
        public Fox.EntityLink property31;
        #endregion

        #region StaticArray properties
        #endregion

        #region DynamicArray properties
        #endregion

        #region StringMap properties
        #endregion
    }
}