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
    public partial class Entity : UnityEngine.MonoBehaviour
    {
        
        // ClassInfos
        public static  bool ClassInfoInitialized = false;
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
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("Entity"), typeof(Entity), null, -1, null, 2);

            ClassInfoInitialized = true;
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
        
        public virtual void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetValue(value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetElement(index, value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
					if (this.DynamicProperties.TryGetValue(propertyName, out DynamicProperty property))
					{
						property.SetElement(key, value);
						return;
					}
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
    }
}