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

namespace Fox.Des
{
    [UnityEditor.InitializeOnLoad]
    public partial class DesFixData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> elementNames { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
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
        static DesFixData()
        {
            classInfo = new Fox.EntityInfo("DesFixData", typeof(DesFixData), new Fox.Core.Data().GetClassEntityInfo(), 80, "Des", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("elementNames", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public DesFixData(ulong id) : base(id) { }
		public DesFixData() : base() { }
        
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
                case "elementNames":
                    while(this.elementNames.Count <= index) { this.elementNames.Add(default(Fox.Core.String)); }
                    this.elementNames[index] = value.GetValueAsString();
                    return;
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