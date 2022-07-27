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

namespace Fox.Sdx
{
    [UnityEditor.InitializeOnLoad]
    public partial class SoundSourceTrapParameter : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink source { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String enterEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String outEvent { get; set; }
        
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
        static SoundSourceTrapParameter()
        {
            classInfo = new Fox.Core.EntityInfo("SoundSourceTrapParameter", typeof(SoundSourceTrapParameter), new Fox.Geo.GeoTrapModuleCallbackDataElement().GetClassEntityInfo(), 0, "Sound", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("source", Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enterEvent", Fox.Core.PropertyInfo.PropertyType.String, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("outEvent", Fox.Core.PropertyInfo.PropertyType.String, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public SoundSourceTrapParameter(ulong id) : base(id) { }
		public SoundSourceTrapParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "source":
                    this.source = value.GetValueAsEntityLink();
                    return;
                case "enterEvent":
                    this.enterEvent = value.GetValueAsString();
                    return;
                case "outEvent":
                    this.outEvent = value.GetValueAsString();
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