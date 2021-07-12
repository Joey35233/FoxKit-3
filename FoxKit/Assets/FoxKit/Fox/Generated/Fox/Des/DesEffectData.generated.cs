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
    public partial class DesEffectData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.Path effectFilePath;
        
        public Fox.String effectName;
        
        public Fox.String setModelName;
        
        public Fox.Core.Path connectPointFilePath;
        
        public Fox.String connectPointName;
        
        public DesEffectDataDesEffectFlag effectFlag;
        
        public uint randomSeed;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static DesEffectData()
        {
            classInfo = new Fox.EntityInfo("DesEffectData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, "Des", 1);
			
			classInfo.StaticProperties.Insert("effectFilePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("effectName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("setModelName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connectPointFilePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connectPointName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("effectFlag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(DesEffectDataDesEffectFlag), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("randomSeed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public DesEffectData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
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