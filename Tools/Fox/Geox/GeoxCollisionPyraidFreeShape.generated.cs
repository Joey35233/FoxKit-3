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
    public partial class GeoxCollisionPyraidFreeShape : Fox.Core.TransformData 
    {
        // Properties
        public CollisionPyraidFreeShape_Category collisionCategory;
        
        public Fox.String collisionMaterial;
        
        public Fox.Core.DynamicArray<Fox.String> collisionAttributeNames = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.StaticArray<UnityEngine.Vector3> points = new Fox.Core.StaticArray<UnityEngine.Vector3>(5);
        
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
        static GeoxCollisionPyraidFreeShape()
        {
            classInfo = new Fox.EntityInfo("GeoxCollisionPyraidFreeShape", typeof(GeoxCollisionPyraidFreeShape), new Fox.Core.TransformData().GetClassEntityInfo(), 368, "Geox", 0);
			classInfo.StaticProperties.Insert("collisionCategory", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPyraidFreeShape_Category), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionMaterial", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("points", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 304, 5, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxCollisionPyraidFreeShape(ulong address, ulong id) : base(address, id) { }
		public GeoxCollisionPyraidFreeShape() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "collisionCategory":
                    this.collisionCategory = (CollisionPyraidFreeShape_Category)value.GetValueAsInt32();
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