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
    public partial class RandomNumberGenerator 
    {
        // Properties
        public uint seed;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static  Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static RandomNumberGenerator()
        {
            classInfo = new Fox.EntityInfo("RandomNumberGenerator", typeof(RandomNumberGenerator), null, 0, null, 0);
			classInfo.StaticProperties.Insert("seed", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		
		public RandomNumberGenerator()
        {
            
        }
        
        public virtual void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "seed":
                    this.seed = value.GetValueAsUInt32();
                    return;
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
        
        public virtual void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName);
            }
        }
    }
}