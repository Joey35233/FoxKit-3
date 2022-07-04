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
    public partial class MotherBaseConstructDivisionLocator : Fox.Core.TransformData 
    {
        // Properties
        public byte type;
        
        public bool isLowModel;
        
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> staticModels = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
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
        static MotherBaseConstructDivisionLocator()
        {
            classInfo = new Fox.EntityInfo("MotherBaseConstructDivisionLocator", typeof(MotherBaseConstructDivisionLocator), new Fox.Core.TransformData().GetClassEntityInfo(), 288, "TppMotherBase", 1);
			classInfo.StaticProperties.Insert("type", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isLowModel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("staticModels", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 312, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public MotherBaseConstructDivisionLocator(ulong address, ulong id) : base(address, id) { }
		public MotherBaseConstructDivisionLocator() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "type":
                    this.type = value.GetValueAsUInt8();
                    return;
                case "isLowModel":
                    this.isLowModel = value.GetValueAsBool();
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
                case "staticModels":
                    while(this.staticModels.Count <= index) { this.staticModels.Add(default(Fox.Core.EntityLink)); }
                    this.staticModels[index] = value.GetValueAsEntityLink();
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