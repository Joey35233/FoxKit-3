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

namespace Fox.Ui
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiFontGroupData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Ui.UiFontDataElement>> fonts { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Ui.UiFontDataElement>>();
        
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
        static UiFontGroupData()
        {
            classInfo = new Fox.EntityInfo("UiFontGroupData", typeof(UiFontGroupData), new Fox.Core.Data().GetClassEntityInfo(), 80, "Ui", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fonts", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Ui.UiFontDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public UiFontGroupData(ulong id) : base(id) { }
		public UiFontGroupData() : base() { }
        
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
                case "fonts":
                    while(this.fonts.Count <= index) { this.fonts.Add(default(Fox.Core.EntityPtr<Fox.Ui.UiFontDataElement>)); }
                    this.fonts[index] = value.GetValueAsEntityPtr<Fox.Ui.UiFontDataElement>();
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