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
    public partial class TppGimmickBrokenElectricCableBank : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.Path referencePartsPath;
        
        public Fox.Core.FilePtr<Fox.Core.File> modelFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> connectPointFile;
        
        public byte instanceCount;
        
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
        static TppGimmickBrokenElectricCableBank()
        {
            classInfo = new Fox.EntityInfo("TppGimmickBrokenElectricCableBank", typeof(TppGimmickBrokenElectricCableBank), new Fox.Core.Data().GetClassEntityInfo(), 128, "Gimmick", 0);
			classInfo.StaticProperties.Insert("referencePartsPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("modelFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("connectPointFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("instanceCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppGimmickBrokenElectricCableBank(ulong id) : base(id) { }
		public TppGimmickBrokenElectricCableBank() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "referencePartsPath":
                    this.referencePartsPath = value.GetValueAsPath();
                    return;
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "connectPointFile":
                    this.connectPointFile = value.GetValueAsFilePtr();
                    return;
                case "instanceCount":
                    this.instanceCount = value.GetValueAsUInt8();
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