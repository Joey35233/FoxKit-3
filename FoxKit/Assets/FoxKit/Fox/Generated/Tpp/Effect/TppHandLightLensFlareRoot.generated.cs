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
    public partial class TppHandLightLensFlareRoot : Tpp.Effect.TppLensFlareRootBase 
    {
        // Properties
        public bool independentEditMode;
        
        public bool takeover;
        
        public bool debugFillCheck;
        
        public bool needCollisionCheck;
        
        public float exposureBlend;
        
        public Fox.String lensFlareName;
        
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
        static TppHandLightLensFlareRoot()
        {
            classInfo = new Fox.EntityInfo("TppHandLightLensFlareRoot", typeof(TppHandLightLensFlareRoot), new Tpp.Effect.TppLensFlareRootBase().GetClassEntityInfo(), 688, null, 4);
			classInfo.StaticProperties.Insert("independentEditMode", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("takeover", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("debugFillCheck", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 306, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("needCollisionCheck", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 307, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("exposureBlend", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lensFlareName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shapes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppHandLightLensFlareRoot(ulong id) : base(id) { }
		public TppHandLightLensFlareRoot() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "independentEditMode":
                    this.independentEditMode = value.GetValueAsBool();
                    return;
                case "takeover":
                    this.takeover = value.GetValueAsBool();
                    return;
                case "debugFillCheck":
                    this.debugFillCheck = value.GetValueAsBool();
                    return;
                case "needCollisionCheck":
                    this.needCollisionCheck = value.GetValueAsBool();
                    return;
                case "exposureBlend":
                    this.exposureBlend = value.GetValueAsFloat();
                    return;
                case "lensFlareName":
                    this.lensFlareName = value.GetValueAsString();
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