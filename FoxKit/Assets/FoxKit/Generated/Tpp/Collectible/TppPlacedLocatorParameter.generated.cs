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

namespace Tpp.Collectible
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppPlacedLocatorParameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected uint equipIdStrCode32 { get; set; }
        
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
        static TppPlacedLocatorParameter()
        {
            classInfo = new Fox.EntityInfo("TppPlacedLocatorParameter", typeof(TppPlacedLocatorParameter), new Fox.Core.DataElement().GetClassEntityInfo(), 32, null, 0);
			classInfo.StaticProperties.Insert("equipIdStrCode32", new Fox.Core.PropertyInfo("equipIdStrCode32", Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPlacedLocatorParameter(ulong id) : base(id) { }
		public TppPlacedLocatorParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "equipIdStrCode32":
                    this.equipIdStrCode32 = value.GetValueAsUInt32();
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