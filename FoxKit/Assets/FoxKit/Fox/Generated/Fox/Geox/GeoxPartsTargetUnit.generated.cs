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

namespace Fox.Geox
{
    public partial class GeoxPartsTargetUnit : Fox.Core.Data 
    {
        // Properties
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>> objectArray = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>>();
        
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
        static GeoxPartsTargetUnit()
        {
            classInfo = new Fox.EntityInfo("GeoxPartsTargetUnit", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, "Target", 0);
			
			classInfo.StaticProperties.Insert("objectArray", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Geox.GeoxPartsTargetObject), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoxPartsTargetUnit(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "objectArray":
                    while(this.objectArray.Count <= index) { this.objectArray.Add(default(Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>)); }
                    this.objectArray[index] = value.GetValueAsEntityPtr<Fox.Geox.GeoxPartsTargetObject>();
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