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
    public partial class GeoSearchSphere : Fox.Geo.GeoSearchObject 
    {
        // Properties
        public UnityEngine.Vector4 p;
        
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
        static GeoSearchSphere()
        {
            classInfo = new Fox.EntityInfo("GeoSearchSphere", typeof(GeoSearchSphere), new Fox.Geo.GeoSearchObject().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("p", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector4, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoSearchSphere(ulong id) : base(id) { }
		public GeoSearchSphere() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "p":
                    this.p = value.GetValueAsVector4();
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