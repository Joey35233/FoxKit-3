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

namespace Tpp.MotherBaseCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class MotherBaseConstructData : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public MbConstructDataType type { get; set; }
        
        [field: UnityEngine.SerializeField]
        public ushort index { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.StaticArray<byte> divisionType { get; set; } = new Fox.FoxKernel.StaticArray<byte>(4);
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.StaticArray<ushort> divisionRotate { get; set; } = new Fox.FoxKernel.StaticArray<ushort>(4);
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.StaticArray<bool> anotherConnector { get; set; } = new Fox.FoxKernel.StaticArray<bool>(8);
        
        [field: UnityEngine.SerializeField]
        public byte cluster { get; set; }
        
        [field: UnityEngine.SerializeField]
        public byte plant { get; set; }
        
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
        static MotherBaseConstructData()
        {
            classInfo = new Fox.EntityInfo("MotherBaseConstructData", typeof(MotherBaseConstructData), new Fox.Core.TransformData().GetClassEntityInfo(), 288, "TppMotherBase", 6);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("type", Fox.Core.PropertyInfo.PropertyType.Int32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(MbConstructDataType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("index", Fox.Core.PropertyInfo.PropertyType.UInt16, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("divisionType", Fox.Core.PropertyInfo.PropertyType.UInt8, 374, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("divisionRotate", Fox.Core.PropertyInfo.PropertyType.UInt16, 378, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("anotherConnector", Fox.Core.PropertyInfo.PropertyType.Bool, 386, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cluster", Fox.Core.PropertyInfo.PropertyType.UInt8, 394, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("plant", Fox.Core.PropertyInfo.PropertyType.UInt8, 395, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public MotherBaseConstructData(ulong id) : base(id) { }
		public MotherBaseConstructData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "type":
                    this.type = (MbConstructDataType)value.GetValueAsInt32();
                    return;
                case "index":
                    this.index = value.GetValueAsUInt16();
                    return;
                case "cluster":
                    this.cluster = value.GetValueAsUInt8();
                    return;
                case "plant":
                    this.plant = value.GetValueAsUInt8();
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
                case "divisionType":
                    
                    this.divisionType[index] = value.GetValueAsUInt8();
                    return;
                case "divisionRotate":
                    
                    this.divisionRotate[index] = value.GetValueAsUInt16();
                    return;
                case "anotherConnector":
                    
                    this.anotherConnector[index] = value.GetValueAsBool();
                    return;
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