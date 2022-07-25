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

namespace Fox.Geo
{
    [UnityEditor.InitializeOnLoad]
    public partial class CollisionPoly : Fox.Geo.CollisionObject 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected ulong attribute { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.FoxKernel.DynamicArray<UnityEngine.Vector3> vertices { get; set; } = new Fox.FoxKernel.DynamicArray<UnityEngine.Vector3>();
        
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
        static CollisionPoly()
        {
            classInfo = new Fox.EntityInfo("CollisionPoly", typeof(CollisionPoly), new Fox.Geo.CollisionObject().GetClassEntityInfo(), 0, "Collision", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("attribute", Fox.Core.PropertyInfo.PropertyType.UInt64, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vertices", Fox.Core.PropertyInfo.PropertyType.Vector3, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public CollisionPoly(ulong id) : base(id) { }
		public CollisionPoly() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "attribute":
                    this.attribute = value.GetValueAsUInt64();
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
                case "vertices":
                    while(this.vertices.Count <= index) { this.vertices.Add(default(UnityEngine.Vector3)); }
                    this.vertices[index] = value.GetValueAsVector3();
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