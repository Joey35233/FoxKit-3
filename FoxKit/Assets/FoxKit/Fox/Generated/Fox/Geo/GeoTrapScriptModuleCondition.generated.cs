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

namespace Fox.Geo
{
    public partial class GeoTrapScriptModuleCondition : Fox.Geo.GeoTrapCondition 
    {
        // Properties
        public bool isAndCheck;
        
        public Fox.Core.DynamicArray<Fox.Core.Path> checkScriptPathArray = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
        public Fox.Core.DynamicArray<Fox.Core.Path> execScriptPathArray = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
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
        static GeoTrapScriptModuleCondition()
        {
            classInfo = new Fox.EntityInfo("GeoTrapScriptModuleCondition", new Fox.Geo.GeoTrapCondition(0, 0, 0).GetClassEntityInfo(), 0, "Trap", 1);
			
			classInfo.StaticProperties.Insert("isAndCheck", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("checkScriptPathArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 328, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("execScriptPathArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoTrapScriptModuleCondition(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "isAndCheck":
                    this.isAndCheck = value.GetValueAsBool();
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
                case "checkScriptPathArray":
                    while(this.checkScriptPathArray.Count <= index) { this.checkScriptPathArray.Add(default(Fox.Core.Path)); }
                    this.checkScriptPathArray[index] = value.GetValueAsPath();
                    return;
                case "execScriptPathArray":
                    while(this.execScriptPathArray.Count <= index) { this.execScriptPathArray.Add(default(Fox.Core.Path)); }
                    this.execScriptPathArray[index] = value.GetValueAsPath();
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