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

namespace Fox.Grx
{
    [UnityEditor.InitializeOnLoad]
    public partial class GrReflectionSetting : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.Path reflectionTexturePath;
        
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
        static GrReflectionSetting()
        {
            classInfo = new Fox.EntityInfo("GrReflectionSetting", typeof(GrReflectionSetting), new Fox.Core.Data().GetClassEntityInfo(), 72, "Config", 0);
			classInfo.StaticProperties.Insert("reflectionTexturePath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GrReflectionSetting(ulong id) : base(id) { }
		public GrReflectionSetting() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "reflectionTexturePath":
                    this.reflectionTexturePath = value.GetValueAsPath();
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