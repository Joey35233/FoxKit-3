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
    public partial class GeoSearchLine : Fox.Geo.GeoSearchObject 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 p { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 v { get; set; }
        
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
        static GeoSearchLine()
        {
            classInfo = new Fox.EntityInfo("GeoSearchLine", typeof(GeoSearchLine), new Fox.Geo.GeoSearchObject().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("p", Fox.Core.PropertyInfo.PropertyType.Vector3, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("v", Fox.Core.PropertyInfo.PropertyType.Vector3, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoSearchLine(ulong id) : base(id) { }
		public GeoSearchLine() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "p":
                    this.p = value.GetValueAsVector3();
                    return;
                case "v":
                    this.v = value.GetValueAsVector3();
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
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}