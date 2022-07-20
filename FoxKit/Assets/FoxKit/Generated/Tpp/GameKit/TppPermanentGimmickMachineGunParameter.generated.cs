//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CsSystem = System;
using Fox;

namespace Tpp.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppPermanentGimmickMachineGunParameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public float maxYAxisAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float minYAxisAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxXAxisAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float minXAxisAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr weaponPartsFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint flags1 { get; set; }
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppPermanentGimmickMachineGunParameter()
        {
            classInfo = new Fox.EntityInfo("TppPermanentGimmickMachineGunParameter", typeof(TppPermanentGimmickMachineGunParameter), new Fox.Core.DataElement().GetClassEntityInfo(), 80, null, 1);
			classInfo.StaticProperties.Insert("maxYAxisAngle", new Fox.Core.PropertyInfo("maxYAxisAngle", Fox.Core.PropertyInfo.PropertyType.Float, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("minYAxisAngle", new Fox.Core.PropertyInfo("minYAxisAngle", Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxXAxisAngle", new Fox.Core.PropertyInfo("maxXAxisAngle", Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("minXAxisAngle", new Fox.Core.PropertyInfo("minXAxisAngle", Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("weaponPartsFile", new Fox.Core.PropertyInfo("weaponPartsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flags1", new Fox.Core.PropertyInfo("flags1", Fox.Core.PropertyInfo.PropertyType.UInt32, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPermanentGimmickMachineGunParameter(ulong id) : base(id) { }
		public TppPermanentGimmickMachineGunParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "maxYAxisAngle":
                    this.maxYAxisAngle = value.GetValueAsFloat();
                    return;
                case "minYAxisAngle":
                    this.minYAxisAngle = value.GetValueAsFloat();
                    return;
                case "maxXAxisAngle":
                    this.maxXAxisAngle = value.GetValueAsFloat();
                    return;
                case "minXAxisAngle":
                    this.minXAxisAngle = value.GetValueAsFloat();
                    return;
                case "weaponPartsFile":
                    this.weaponPartsFile = value.GetValueAsFilePtr();
                    return;
                case "flags1":
                    this.flags1 = value.GetValueAsUInt32();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}