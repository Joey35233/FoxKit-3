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
    public partial class GeoxPathWall : Fox.Core.TransformData 
    {
        // Properties
        public float height;
        
        public bool isVisibleGeom;
        
        public Face_Mode faceFlag;
        
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
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GeoxPathWall()
        {
            classInfo = new Fox.EntityInfo("GeoxPathWall", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 288, "Geox", 0);
			
			classInfo.StaticProperties.Insert("height", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isVisibleGeom", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("faceFlag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Face_Mode), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributeTags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GeoxPathWall(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "isVisibleGeom":
                    this.isVisibleGeom = value.GetValueAsBool();
                    return;
                case "faceFlag":
                    this.faceFlag = (Face_Mode)value.GetValueAsInt32();
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