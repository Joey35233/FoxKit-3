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

namespace Tpp.GameCore
{
    public partial class TppPlayer2BlockControllerData : Fox.Core.Data 
    {
        // Properties
        public uint configuration_commonMotionBlockSize;
        
        public uint configuration_commonMotionBlockSizePs3;
        
        public uint configuration_additiveMotionBlockCount;
        
        public uint configuration_additiveMotionBlockSize;
        
        public uint configuration_partsBlockCount;
        
        public uint configuration_partsBlockSize;
        
        public string instanceSettings_instancePackagePath;
        
        public uint instanceSettings_instanceBlockSize;
        
        public string instanceSettings_commonMotionTypeName;
        
        public CsSystem.Collections.Generic.List<string> instanceSettings_partsTypeNames = new CsSystem.Collections.Generic.List<string>();
        
        public CsSystem.Collections.Generic.List<string> instanceSettings_partsTypeInitial = new CsSystem.Collections.Generic.List<string>();
        
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
        static TppPlayer2BlockControllerData()
        {
            classInfo = new Fox.EntityInfo("TppPlayer2BlockControllerData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 136, null, 3);
			
			classInfo.StaticProperties.Insert("configuration_commonMotionBlockSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("configuration_commonMotionBlockSizePs3", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("configuration_additiveMotionBlockCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("configuration_additiveMotionBlockSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("configuration_partsBlockCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("configuration_partsBlockSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceSettings_instancePackagePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceSettings_instanceBlockSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceSettings_commonMotionTypeName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceSettings_partsTypeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceSettings_partsTypeInitial", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppPlayer2BlockControllerData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "configuration_commonMotionBlockSize":
                    this.configuration_commonMotionBlockSize = value.GetValueAsUInt32();
                    return;
                case "configuration_commonMotionBlockSizePs3":
                    this.configuration_commonMotionBlockSizePs3 = value.GetValueAsUInt32();
                    return;
                case "configuration_additiveMotionBlockCount":
                    this.configuration_additiveMotionBlockCount = value.GetValueAsUInt32();
                    return;
                case "configuration_additiveMotionBlockSize":
                    this.configuration_additiveMotionBlockSize = value.GetValueAsUInt32();
                    return;
                case "configuration_partsBlockCount":
                    this.configuration_partsBlockCount = value.GetValueAsUInt32();
                    return;
                case "configuration_partsBlockSize":
                    this.configuration_partsBlockSize = value.GetValueAsUInt32();
                    return;
                case "instanceSettings_instancePackagePath":
                    this.instanceSettings_instancePackagePath = value.GetValueAsString();
                    return;
                case "instanceSettings_instanceBlockSize":
                    this.instanceSettings_instanceBlockSize = value.GetValueAsUInt32();
                    return;
                case "instanceSettings_commonMotionTypeName":
                    this.instanceSettings_commonMotionTypeName = value.GetValueAsString();
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
                case "instanceSettings_partsTypeNames":
                    while(this.instanceSettings_partsTypeNames.Count <= index) { this.instanceSettings_partsTypeNames.Add(default(string)); }
                    this.instanceSettings_partsTypeNames[index] = value.GetValueAsString();
                    return;
                case "instanceSettings_partsTypeInitial":
                    while(this.instanceSettings_partsTypeInitial.Count <= index) { this.instanceSettings_partsTypeInitial.Add(default(string)); }
                    this.instanceSettings_partsTypeInitial[index] = value.GetValueAsString();
                    return;
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