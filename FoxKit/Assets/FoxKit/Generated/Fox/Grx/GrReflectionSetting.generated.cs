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
        [field: UnityEngine.SerializeField]
        public Fox.Core.Path reflectionTexturePath { get; set; }
        
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
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reflectionTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GrReflectionSetting(ulong id) : base(id) { }
		public GrReflectionSetting() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
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