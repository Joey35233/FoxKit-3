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
    public partial class GeoxCollisionPrimitive : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public CollisionPrimitive_Category collisionCategory { get; set; }
        
        [field: UnityEngine.SerializeField]
        public CollisionPrimitive_PrimType primitiveType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String groupTag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String collisionMaterial { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> collisionAttributeNames { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GeoxCollisionPrimitive()
        {
            classInfo = new Fox.Core.EntityInfo("GeoxCollisionPrimitive", typeof(GeoxCollisionPrimitive), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Geox", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionCategory", Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPrimitive_Category), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("primitiveType", Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPrimitive_PrimType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("groupTag", Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionMaterial", Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionAttributeNames", Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoxCollisionPrimitive(ulong id) : base(id) { }
		public GeoxCollisionPrimitive() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "collisionAttributeNames":
                    while(this.collisionAttributeNames.Count <= index) { this.collisionAttributeNames.Add(default(Fox.Kernel.String)); }
                    this.collisionAttributeNames[index] = value.GetValueAsString();
                    return;
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