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

namespace Fox.EdDemo
{
    public partial class ChildrenIdConvertParameter : Fox.Demo.DemoParameter 
    {
        // Properties
        public Fox.String injuryId;
        
        public Fox.String yellowHoodId;
        
        public Fox.String afloId;
        
        public Fox.String shortAfloId;
        
        public Fox.String blackCoatId;
        
        public byte injuryPriority;
        
        public byte yellowHoodPriority;
        
        public byte afloPriority;
        
        public byte shortAfloPriority;
        
        public byte blackCoatPriority;
        
        public bool enableInjuredChildSpecialization;
        
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
        static ChildrenIdConvertParameter()
        {
            classInfo = new Fox.EntityInfo("ChildrenIdConvertParameter", new Fox.Demo.DemoParameter(0, 0, 0).GetClassEntityInfo(), 60, null, 0);
			
			classInfo.StaticProperties.Insert("injuryId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("yellowHoodId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("afloId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shortAfloId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blackCoatId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("injuryPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("yellowHoodPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 105, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("afloPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 106, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shortAfloPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 107, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blackCoatPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enableInjuredChildSpecialization", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 109, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public ChildrenIdConvertParameter(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "injuryId":
                    this.injuryId = value.GetValueAsString();
                    return;
                case "yellowHoodId":
                    this.yellowHoodId = value.GetValueAsString();
                    return;
                case "afloId":
                    this.afloId = value.GetValueAsString();
                    return;
                case "shortAfloId":
                    this.shortAfloId = value.GetValueAsString();
                    return;
                case "blackCoatId":
                    this.blackCoatId = value.GetValueAsString();
                    return;
                case "injuryPriority":
                    this.injuryPriority = value.GetValueAsUInt8();
                    return;
                case "yellowHoodPriority":
                    this.yellowHoodPriority = value.GetValueAsUInt8();
                    return;
                case "afloPriority":
                    this.afloPriority = value.GetValueAsUInt8();
                    return;
                case "shortAfloPriority":
                    this.shortAfloPriority = value.GetValueAsUInt8();
                    return;
                case "blackCoatPriority":
                    this.blackCoatPriority = value.GetValueAsUInt8();
                    return;
                case "enableInjuredChildSpecialization":
                    this.enableInjuredChildSpecialization = value.GetValueAsBool();
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