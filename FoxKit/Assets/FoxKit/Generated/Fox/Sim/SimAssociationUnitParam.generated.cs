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

namespace Fox.Sim
{
    [UnityEditor.InitializeOnLoad]
    public partial class SimAssociationUnitParam : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.String boneName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool initialized { get; protected set; }
        
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
        static SimAssociationUnitParam()
        {
            classInfo = new Fox.EntityInfo("SimAssociationUnitParam", typeof(SimAssociationUnitParam), new Fox.Core.Entity().GetClassEntityInfo(), 32, "Sim", 2);
			classInfo.StaticProperties.Insert("boneName", new Fox.Core.PropertyInfo("boneName", Fox.Core.PropertyInfo.PropertyType.String, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("initialized", new Fox.Core.PropertyInfo("initialized", Fox.Core.PropertyInfo.PropertyType.Bool, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public SimAssociationUnitParam(ulong id) : base(id) { }
		public SimAssociationUnitParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "boneName":
                    this.boneName = value.GetValueAsString();
                    return;
                case "initialized":
                    this.initialized = value.GetValueAsBool();
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