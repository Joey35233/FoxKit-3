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

namespace Tpp.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppTrapCheckIsCharacterCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink checkLocator { get; set; }
        
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
        static TppTrapCheckIsCharacterCallbackDataElement()
        {
            classInfo = new Fox.EntityInfo("TppTrapCheckIsCharacterCallbackDataElement", typeof(TppTrapCheckIsCharacterCallbackDataElement), new Fox.Geo.GeoTrapModuleCallbackDataElement().GetClassEntityInfo(), 0, null, 0);
			classInfo.StaticProperties.Insert("checkLocator", new Fox.Core.PropertyInfo("checkLocator", Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppTrapCheckIsCharacterCallbackDataElement(ulong id) : base(id) { }
		public TppTrapCheckIsCharacterCallbackDataElement() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "checkLocator":
                    this.checkLocator = value.GetValueAsEntityLink();
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