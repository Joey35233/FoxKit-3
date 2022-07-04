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
    public partial class TppPermanentGimmickData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> partsFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> locaterFile;
        
        public Fox.Core.EntityPtr<Fox.Core.DataElement> parameters = new Fox.Core.EntityPtr<Fox.Core.DataElement>();
        
        public uint flags1;
        
        public uint flags2;
        
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
        static TppPermanentGimmickData()
        {
            classInfo = new Fox.EntityInfo("TppPermanentGimmickData", typeof(TppPermanentGimmickData), new Fox.Core.Data().GetClassEntityInfo(), 144, "Gimmick", 0);
			classInfo.StaticProperties.Insert("partsFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("locaterFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("parameters", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.DataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flags1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flags2", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPermanentGimmickData(ulong address, ulong id) : base(address, id) { }
		public TppPermanentGimmickData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "locaterFile":
                    this.locaterFile = value.GetValueAsFilePtr();
                    return;
                case "parameters":
                    this.parameters = value.GetValueAsEntityPtr<Fox.Core.DataElement>();
                    return;
                case "flags1":
                    this.flags1 = value.GetValueAsUInt32();
                    return;
                case "flags2":
                    this.flags2 = value.GetValueAsUInt32();
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