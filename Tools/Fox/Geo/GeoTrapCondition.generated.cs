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
    [UnityEditor.InitializeOnLoad]
    public partial class GeoTrapCondition : Fox.Core.TransformData 
    {
        // Properties
        public Fox.String trapCategory;
        
        public uint trapPriority;
        
        public bool enable;
        
        public bool isOnce;
        
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
        static GeoTrapCondition()
        {
            classInfo = new Fox.EntityInfo("GeoTrapCondition", typeof(GeoTrapCondition), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Trap", 3);
			classInfo.StaticProperties.Insert("trapCategory", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("trapPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("enable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isOnce", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 317, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoTrapCondition(ulong address, ulong id) : base(address, id) { }
		public GeoTrapCondition() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "trapCategory":
                    this.trapCategory = value.GetValueAsString();
                    return;
                case "trapPriority":
                    this.trapPriority = value.GetValueAsUInt32();
                    return;
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "isOnce":
                    this.isOnce = value.GetValueAsBool();
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