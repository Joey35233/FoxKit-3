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
    public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement 
    {
        // Properties
        public Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnitParam> param = new Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnitParam>();
        
        public Fox.String boneName;
        
        public bool initialized;
        
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
        static SimAssociationUnit()
        {
            classInfo = new Fox.EntityInfo("SimAssociationUnit", typeof(SimAssociationUnit), new Fox.Phx.PhxAssociationUnitElement().GetClassEntityInfo(), 160, "Sim", 1);
			classInfo.StaticProperties.Insert("param", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimAssociationUnitParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("boneName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("initialized", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public SimAssociationUnit(ulong id) : base(id) { }
		public SimAssociationUnit() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "param":
                    this.param = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnitParam>();
                    return;
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