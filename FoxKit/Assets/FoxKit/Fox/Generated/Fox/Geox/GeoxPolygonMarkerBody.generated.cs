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
    public partial class GeoxPolygonMarkerBody : Fox.Core.TransformDataBody 
    {
        // Properties
        public Fox.Core.DynamicArray<UnityEngine.Vector3> vertices = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
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
        static GeoxPolygonMarkerBody()
        {
            classInfo = new Fox.EntityInfo("GeoxPolygonMarkerBody", new Fox.Core.TransformDataBody().GetClassEntityInfo(), 0, "Geox", 0);
			
			classInfo.StaticProperties.Insert("vertices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxPolygonMarkerBody(ulong address, ulong id) : base(address, id) { }
		public GeoxPolygonMarkerBody() : base() { }
        
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
                case "vertices":
                    while(this.vertices.Count <= index) { this.vertices.Add(default(UnityEngine.Vector3)); }
                    this.vertices[index] = value.GetValueAsVector3();
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