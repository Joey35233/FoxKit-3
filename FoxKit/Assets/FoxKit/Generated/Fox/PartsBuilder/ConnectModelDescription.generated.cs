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

namespace Fox.PartsBuilder
{
    [UnityEditor.InitializeOnLoad]
    public partial class ConnectModelDescription : Fox.PartsBuilder.ModelDescription 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.String> connectPointNames { get; set; } = new Fox.Core.StringMap<Fox.Core.String>();
        
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
        static ConnectModelDescription()
        {
            classInfo = new Fox.EntityInfo("ConnectModelDescription", typeof(ConnectModelDescription), new Fox.PartsBuilder.ModelDescription().GetClassEntityInfo(), 336, "PartsBuilder", 3);
			classInfo.StaticProperties.Insert("connectPointNames", new Fox.Core.PropertyInfo("connectPointNames", Fox.Core.PropertyInfo.PropertyType.String, 368, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public ConnectModelDescription(ulong id) : base(id) { }
		public ConnectModelDescription() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "connectPointNames":
                    this.connectPointNames.Insert(key, value.GetValueAsString());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}