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

namespace Tpp.MarkerLocator
{
    public partial class TppMarker2LocatorParameter : Fox.Core.DataElement 
    {
        // Properties
        public Fox.String markerType;
        
        public Fox.String markerId;
        
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
        static TppMarker2LocatorParameter()
        {
            classInfo = new Fox.EntityInfo("TppMarker2LocatorParameter", new Fox.Core.DataElement().GetClassEntityInfo(), 36, null, 0);
			
			classInfo.StaticProperties.Insert("markerType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("markerId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppMarker2LocatorParameter(ulong address, ulong id) : base(address, id) { }
		public TppMarker2LocatorParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "markerType":
                    this.markerType = value.GetValueAsString();
                    return;
                case "markerId":
                    this.markerId = value.GetValueAsString();
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