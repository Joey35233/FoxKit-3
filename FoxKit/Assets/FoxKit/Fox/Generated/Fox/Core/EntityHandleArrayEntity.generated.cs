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

namespace Fox.Core
{
    [UnityEditor.InitializeOnLoad]
    public partial class EntityHandleArrayEntity : Fox.Core.Entity 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityHandle> array = new Fox.Core.DynamicArray<Fox.Core.EntityHandle>();
        
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
        static EntityHandleArrayEntity()
        {
            classInfo = new Fox.EntityInfo("EntityHandleArrayEntity", typeof(EntityHandleArrayEntity), new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("array", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public EntityHandleArrayEntity(ulong id) : base(id) { }
		public EntityHandleArrayEntity() : base() { }
        
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
                case "array":
                    while(this.array.Count <= index) { this.array.Add(default(Fox.Core.EntityHandle)); }
                    this.array[index] = value.GetValueAsEntityHandle();
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