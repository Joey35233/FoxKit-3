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
    public partial class GeoxCollisionFreeShape : Fox.Core.TransformData 
    {
        // Properties
        public CollisionFreeShape_Category collisionCategory;
        
        public Fox.String collisionMaterial;
        
        public Fox.Core.DynamicArray<Fox.String> collisionAttributeNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.StaticArray<UnityEngine.Vector3> points = new Fox.Core.StaticArray<UnityEngine.Vector3>(8);
        
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
        static GeoxCollisionFreeShape()
        {
            classInfo = new Fox.EntityInfo("GeoxCollisionFreeShape", new Fox.Core.TransformData().GetClassEntityInfo(), 416, "Geox", 0);
			
			classInfo.StaticProperties.Insert("collisionCategory", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionFreeShape_Category), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionMaterial", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 448, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("points", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 304, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxCollisionFreeShape(ulong address, ulong id) : base(address, id) { }
		public GeoxCollisionFreeShape() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "collisionCategory":
                    this.collisionCategory = (CollisionFreeShape_Category)value.GetValueAsInt32();
                    return;
                case "collisionMaterial":
                    this.collisionMaterial = value.GetValueAsString();
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
                case "collisionAttributeNames":
                    while(this.collisionAttributeNames.Count <= index) { this.collisionAttributeNames.Add(default(Fox.String)); }
                    this.collisionAttributeNames[index] = value.GetValueAsString();
                    return;
                case "points":
                    
                    this.points[index] = value.GetValueAsVector3();
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