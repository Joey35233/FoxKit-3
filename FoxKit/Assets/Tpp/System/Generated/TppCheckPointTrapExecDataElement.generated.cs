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

namespace Tpp.System
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppCheckPointTrapExecDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> locators { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static new Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppCheckPointTrapExecDataElement()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppCheckPointTrapExecDataElement"), typeof(TppCheckPointTrapExecDataElement), new Fox.Geo.GeoTrapModuleCallbackDataElement().GetClassEntityInfo(), 48, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("locators"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppCheckPointTrapExecDataElement(ulong id) : base(id) { }
		public TppCheckPointTrapExecDataElement() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "locators":
                    while(this.locators.Count <= index) { this.locators.Add(default(Fox.Core.EntityLink)); }
                    this.locators[index] = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}