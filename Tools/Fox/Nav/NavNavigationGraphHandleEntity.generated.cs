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

namespace Fox.Nav
{
    [UnityEditor.InitializeOnLoad]
    public partial class NavNavigationGraphHandleEntity : Fox.Nav.NavUnitHandleEntity 
    {
        // Properties
        public uint subId;
        
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
        static NavNavigationGraphHandleEntity()
        {
            classInfo = new Fox.EntityInfo("NavNavigationGraphHandleEntity", typeof(NavNavigationGraphHandleEntity), new Fox.Nav.NavUnitHandleEntity().GetClassEntityInfo(), 0, "Nav", 0);
			classInfo.StaticProperties.Insert("subId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public NavNavigationGraphHandleEntity(ulong id) : base(id) { }
		public NavNavigationGraphHandleEntity() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "subId":
                    this.subId = value.GetValueAsUInt32();
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