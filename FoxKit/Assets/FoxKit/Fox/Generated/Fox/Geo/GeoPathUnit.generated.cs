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
    public partial class GeoPathUnit : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.StringMap<byte> tags = new Fox.Core.StringMap<byte>();
        
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
        static GeoPathUnit()
        {
            classInfo = new Fox.EntityInfo("GeoPathUnit", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 0, "Path", 0);
			
			classInfo.StaticProperties.Insert("tags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 304, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoPathUnit(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                case "tags":
                    this.tags.Add(key, value.GetValueAsUInt8());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}