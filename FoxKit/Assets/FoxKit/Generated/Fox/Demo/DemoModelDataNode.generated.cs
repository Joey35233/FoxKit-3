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

namespace Fox.Demo
{
    [UnityEditor.InitializeOnLoad]
    public partial class DemoModelDataNode : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.String> partNames { get; set; } = new Fox.Core.StringMap<Fox.Core.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink target { get; set; }
        
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
        static DemoModelDataNode()
        {
            classInfo = new Fox.EntityInfo("DemoModelDataNode", typeof(DemoModelDataNode), new Fox.Core.Data().GetClassEntityInfo(), 144, null, 2);
			classInfo.StaticProperties.Insert("partNames", new Fox.Core.PropertyInfo("partNames", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("target", new Fox.Core.PropertyInfo("target", Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public DemoModelDataNode(ulong id) : base(id) { }
		public DemoModelDataNode() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "target":
                    this.target = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "partNames":
                    this.partNames.Insert(key, value.GetValueAsString());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}