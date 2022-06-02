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
    public partial class GeoxCollisionPrimitive : Fox.Core.TransformData 
    {
        // Properties
        public CollisionPrimitive_Category collisionCategory;
        
        public CollisionPrimitive_PrimType primitiveType;
        
        public Fox.String groupTag;
        
        public Fox.String collisionMaterial;
        
        public Fox.Core.DynamicArray<Fox.String> collisionAttributeNames = new Fox.Core.DynamicArray<Fox.String>();
        
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
        static GeoxCollisionPrimitive()
        {
            classInfo = new Fox.EntityInfo("GeoxCollisionPrimitive", new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Geox", 0);
			
			classInfo.StaticProperties.Insert("collisionCategory", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPrimitive_Category), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("primitiveType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPrimitive_PrimType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("groupTag", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionMaterial", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionAttributeNames", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxCollisionPrimitive(ulong address, ulong id) : base(address, id) { }
		public GeoxCollisionPrimitive() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "collisionCategory":
                    this.collisionCategory = (CollisionPrimitive_Category)value.GetValueAsInt32();
                    return;
                case "primitiveType":
                    this.primitiveType = (CollisionPrimitive_PrimType)value.GetValueAsInt32();
                    return;
                case "groupTag":
                    this.groupTag = value.GetValueAsString();
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