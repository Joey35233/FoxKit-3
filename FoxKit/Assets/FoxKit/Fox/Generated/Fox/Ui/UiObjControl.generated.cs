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
    public partial class UiObjControl : Fox.Core.Entity 
    {
        // Properties
        public Fox.Core.Path uigName;
        
        public Fox.String uigFileName;
        
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
        static UiObjControl()
        {
            classInfo = new Fox.EntityInfo("UiObjControl", typeof(UiObjControl), new Fox.Core.Entity().GetClassEntityInfo(), 0, "Ui", 0);
			classInfo.StaticProperties.Insert("uigName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("uigFileName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public UiObjControl(ulong address, ulong id) : base(address, id) { }
		public UiObjControl() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "uigName":
                    this.uigName = value.GetValueAsPath();
                    return;
                case "uigFileName":
                    this.uigFileName = value.GetValueAsString();
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