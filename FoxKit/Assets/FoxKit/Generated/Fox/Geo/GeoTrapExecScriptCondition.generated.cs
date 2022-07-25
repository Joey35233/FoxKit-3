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
    public partial class GeoTrapExecScriptCondition : Fox.Geo.GeoCheckModuleCondition 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool execEnter { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool execStay { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool execExit { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path execScriptPath { get; set; }
        
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
        static GeoTrapExecScriptCondition()
        {
            classInfo = new Fox.EntityInfo("GeoTrapExecScriptCondition", typeof(GeoTrapExecScriptCondition), new Fox.Geo.GeoCheckModuleCondition().GetClassEntityInfo(), 0, "Trap", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execEnter", Fox.Core.PropertyInfo.PropertyType.Bool, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execStay", Fox.Core.PropertyInfo.PropertyType.Bool, 369, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execExit", Fox.Core.PropertyInfo.PropertyType.Bool, 370, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execScriptPath", Fox.Core.PropertyInfo.PropertyType.Path, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoTrapExecScriptCondition(ulong id) : base(id) { }
		public GeoTrapExecScriptCondition() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "execEnter":
                    this.execEnter = value.GetValueAsBool();
                    return;
                case "execStay":
                    this.execStay = value.GetValueAsBool();
                    return;
                case "execExit":
                    this.execExit = value.GetValueAsBool();
                    return;
                case "execScriptPath":
                    this.execScriptPath = value.GetValueAsPath();
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