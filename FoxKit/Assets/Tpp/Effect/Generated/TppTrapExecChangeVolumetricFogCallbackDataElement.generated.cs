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

namespace Tpp.Effect
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppTrapExecChangeVolumetricFogCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool ignoreYAxis { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool ignoreZAxis { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float interpRange { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool restoreFogParameters { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color color { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float luminance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color albedo { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float density { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float nearDistance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float falloff { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeAlbedo { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeLuminance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeDensity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeNearDistance { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeFalloff { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink areaVolumetricFog { get; set; }
        
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
        static TppTrapExecChangeVolumetricFogCallbackDataElement()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppTrapExecChangeVolumetricFogCallbackDataElement"), typeof(TppTrapExecChangeVolumetricFogCallbackDataElement), new Fox.Geo.GeoTrapModuleCallbackDataElement().GetClassEntityInfo(), 0, null, 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("ignoreYAxis"), Fox.Core.PropertyInfo.PropertyType.Bool, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("ignoreZAxis"), Fox.Core.PropertyInfo.PropertyType.Bool, 165, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("interpRange"), Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("restoreFogParameters"), Fox.Core.PropertyInfo.PropertyType.Bool, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("luminance"), Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("albedo"), Fox.Core.PropertyInfo.PropertyType.Color, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("density"), Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("nearDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("falloff"), Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeColor"), Fox.Core.PropertyInfo.PropertyType.Bool, 166, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeAlbedo"), Fox.Core.PropertyInfo.PropertyType.Bool, 167, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeLuminance"), Fox.Core.PropertyInfo.PropertyType.Bool, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeDensity"), Fox.Core.PropertyInfo.PropertyType.Bool, 169, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeNearDistance"), Fox.Core.PropertyInfo.PropertyType.Bool, 170, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("changeFalloff"), Fox.Core.PropertyInfo.PropertyType.Bool, 171, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("areaVolumetricFog"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppTrapExecChangeVolumetricFogCallbackDataElement(ulong id) : base(id) { }
		public TppTrapExecChangeVolumetricFogCallbackDataElement() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "ignoreYAxis":
                    this.ignoreYAxis = value.GetValueAsBool();
                    return;
                case "ignoreZAxis":
                    this.ignoreZAxis = value.GetValueAsBool();
                    return;
                case "interpRange":
                    this.interpRange = value.GetValueAsFloat();
                    return;
                case "restoreFogParameters":
                    this.restoreFogParameters = value.GetValueAsBool();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "luminance":
                    this.luminance = value.GetValueAsFloat();
                    return;
                case "albedo":
                    this.albedo = value.GetValueAsColor();
                    return;
                case "density":
                    this.density = value.GetValueAsFloat();
                    return;
                case "nearDistance":
                    this.nearDistance = value.GetValueAsFloat();
                    return;
                case "falloff":
                    this.falloff = value.GetValueAsFloat();
                    return;
                case "changeColor":
                    this.changeColor = value.GetValueAsBool();
                    return;
                case "changeAlbedo":
                    this.changeAlbedo = value.GetValueAsBool();
                    return;
                case "changeLuminance":
                    this.changeLuminance = value.GetValueAsBool();
                    return;
                case "changeDensity":
                    this.changeDensity = value.GetValueAsBool();
                    return;
                case "changeNearDistance":
                    this.changeNearDistance = value.GetValueAsBool();
                    return;
                case "changeFalloff":
                    this.changeFalloff = value.GetValueAsBool();
                    return;
                case "areaVolumetricFog":
                    this.areaVolumetricFog = value.GetValueAsEntityLink();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
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