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
    public partial class EntityPtrArrayEntity : Fox.Core.Entity 
    {
        // Properties
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Core.Entity>> array = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
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
        static EntityPtrArrayEntity()
        {
            classInfo = new Fox.EntityInfo("EntityPtrArrayEntity", new Fox.Core.Entity(0, 0, 0).GetClassEntityInfo(), 40, null, 0);
			
			classInfo.StaticProperties.Insert("array", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public EntityPtrArrayEntity(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                    while(this.array.Count <= index) { this.array.Add(default(Fox.Core.EntityPtr<Fox.Core.Entity>)); }
                    this.array[index] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
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