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
    [UnityEditor.InitializeOnLoad]
    public partial class GeoxDynamicPolygon : Fox.Core.TransformData 
    {
        // Properties
        public bool isVisibleGeom;
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> vertices = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<Fox.String> collisionAttributeTags = new Fox.Core.DynamicArray<Fox.String>();
        
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
        static GeoxDynamicPolygon()
        {
            classInfo = new Fox.EntityInfo("GeoxDynamicPolygon", typeof(GeoxDynamicPolygon), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Geox", 0);
			classInfo.StaticProperties.Insert("isVisibleGeom", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributeTags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxDynamicPolygon(ulong id) : base(id) { }
		public GeoxDynamicPolygon() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "isVisibleGeom":
                    this.isVisibleGeom = value.GetValueAsBool();
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
                case "vertices":
                    while(this.vertices.Count <= index) { this.vertices.Add(default(UnityEngine.Vector3)); }
                    this.vertices[index] = value.GetValueAsVector3();
                    return;
                case "collisionAttributeTags":
                    while(this.collisionAttributeTags.Count <= index) { this.collisionAttributeTags.Add(default(Fox.String)); }
                    this.collisionAttributeTags[index] = value.GetValueAsString();
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