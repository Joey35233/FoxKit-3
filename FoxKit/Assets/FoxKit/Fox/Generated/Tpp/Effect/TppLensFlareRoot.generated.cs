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

namespace Tpp.Effect
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppLensFlareRoot : Tpp.Effect.TppLensFlareRootBase 
    {
        // Properties
        public bool useDebugLightPosition;
        
        public float lightPositionX;
        
        public float lightPositionY;
        
        public float shieldCheckLength;
        
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> shapes = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
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
        static TppLensFlareRoot()
        {
            classInfo = new Fox.EntityInfo("TppLensFlareRoot", typeof(TppLensFlareRoot), new Tpp.Effect.TppLensFlareRootBase().GetClassEntityInfo(), 0, null, 3);
			classInfo.StaticProperties.Insert("useDebugLightPosition", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightPositionX", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lightPositionY", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shieldCheckLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shapes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppLensFlareRoot(ulong id) : base(id) { }
		public TppLensFlareRoot() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "useDebugLightPosition":
                    this.useDebugLightPosition = value.GetValueAsBool();
                    return;
                case "lightPositionX":
                    this.lightPositionX = value.GetValueAsFloat();
                    return;
                case "lightPositionY":
                    this.lightPositionY = value.GetValueAsFloat();
                    return;
                case "shieldCheckLength":
                    this.shieldCheckLength = value.GetValueAsFloat();
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
                case "shapes":
                    while(this.shapes.Count <= index) { this.shapes.Add(default(Fox.Core.EntityLink)); }
                    this.shapes[index] = value.GetValueAsEntityLink();
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