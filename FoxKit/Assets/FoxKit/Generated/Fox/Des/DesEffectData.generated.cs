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

namespace Fox.Des
{
    [UnityEditor.InitializeOnLoad]
    public partial class DesEffectData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path effectFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String effectName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String setModelName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path connectPointFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String connectPointName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public DesEffectDataDesEffectFlag effectFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint randomSeed { get; set; }
        
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
        static DesEffectData()
        {
            classInfo = new Fox.EntityInfo("DesEffectData", typeof(DesEffectData), new Fox.Core.Data().GetClassEntityInfo(), 0, "Des", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectName", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("setModelName", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectPointFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectPointName", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectFlag", Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(DesEffectDataDesEffectFlag), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("randomSeed", Fox.Core.PropertyInfo.PropertyType.UInt32, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public DesEffectData(ulong id) : base(id) { }
		public DesEffectData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "effectFilePath":
                    this.effectFilePath = value.GetValueAsPath();
                    return;
                case "effectName":
                    this.effectName = value.GetValueAsString();
                    return;
                case "setModelName":
                    this.setModelName = value.GetValueAsString();
                    return;
                case "connectPointFilePath":
                    this.connectPointFilePath = value.GetValueAsPath();
                    return;
                case "connectPointName":
                    this.connectPointName = value.GetValueAsString();
                    return;
                case "effectFlag":
                    this.effectFlag = (DesEffectDataDesEffectFlag)value.GetValueAsUInt32();
                    return;
                case "randomSeed":
                    this.randomSeed = value.GetValueAsUInt32();
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