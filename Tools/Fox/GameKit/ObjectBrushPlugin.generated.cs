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

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class ObjectBrushPlugin : Fox.Core.Data 
    {
        // Properties
        public Fox.String parentDataName;
        
        public bool visibility;
        
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
        static ObjectBrushPlugin()
        {
            classInfo = new Fox.EntityInfo("ObjectBrushPlugin", typeof(ObjectBrushPlugin), new Fox.Core.Data().GetClassEntityInfo(), 76, null, 2);
			classInfo.StaticProperties.Insert("parentDataName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("visibility", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public ObjectBrushPlugin(ulong address, ulong id) : base(address, id) { }
		public ObjectBrushPlugin() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "parentDataName":
                    this.parentDataName = value.GetValueAsString();
                    return;
                case "visibility":
                    this.visibility = value.GetValueAsBool();
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