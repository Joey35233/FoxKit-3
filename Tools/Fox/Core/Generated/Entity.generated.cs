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
    public partial class Entity 
    {
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static  Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static Entity()
        {
            classInfo = new Fox.Core.EntityInfo("Entity", typeof(Entity), null, -1, null, 2);
        }

        // Constructors
		public Entity(ulong id)
        {
            this.Id = id;
        }
		public Entity()
        {
            
            this.Id = 0;
        }
        
        public virtual void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetValue(value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetElement(index, value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetElement(key, value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
    }
}