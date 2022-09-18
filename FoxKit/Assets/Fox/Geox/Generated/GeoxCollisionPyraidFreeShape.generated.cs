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
        [field: UnityEngine.SerializeField]
        public CollisionPyraidFreeShape_Category collisionCategory { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String collisionMaterial { get; protected set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> collisionAttributeNames { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StaticArray<UnityEngine.Vector3> points { get; set; } = new Fox.Kernel.StaticArray<UnityEngine.Vector3>(5);
        
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
        static GeoxCollisionPyraidFreeShape()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoxCollisionPyraidFreeShape"), typeof(GeoxCollisionPyraidFreeShape), new Fox.Core.TransformData().GetClassEntityInfo(), 368, "Geox", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("collisionCategory"), Fox.Core.PropertyInfo.PropertyType.Int32, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(CollisionPyraidFreeShape_Category), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("collisionMaterial"), Fox.Core.PropertyInfo.PropertyType.String, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("collisionAttributeNames"), Fox.Core.PropertyInfo.PropertyType.String, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("points"), Fox.Core.PropertyInfo.PropertyType.Vector3, 304, 5, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoxCollisionPyraidFreeShape(ulong id) : base(id) { }
		public GeoxCollisionPyraidFreeShape() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "collisionAttributeNames":
                    while(this.collisionAttributeNames.Count <= index) { this.collisionAttributeNames.Add(default(Fox.Kernel.String)); }
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
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}