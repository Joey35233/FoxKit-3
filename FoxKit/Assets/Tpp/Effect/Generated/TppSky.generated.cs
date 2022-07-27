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
    public partial class TppSky : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool enable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint priority { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr model { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path cloudTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint textureRepeats { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float lightExtinction { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float diffusion { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dirLightGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float ambLightGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float inCloudScatterGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float density { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cloudWindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float densityLayerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float densityLayerWindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint dom2TextureRepeats { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom2CloudDensity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom2WindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom2DensityLayerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom2DensityLayerWindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint dom3TextureRepeats { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom3CloudDensity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom3WindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom3DensityLayerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float dom3DensityLayerWindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path cylCloudTexture { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint cylTextureRepeats { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylCloudDensity { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylDiffusion { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylScatterGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylDirLightGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylAmbLightGain { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylWindInfluence { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylDensityLayerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float cylDensityLayerWindInfluence { get; set; }
        
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
        static TppSky()
        {
            classInfo = new Fox.Core.EntityInfo("TppSky", typeof(TppSky), new Fox.Core.TransformData().GetClassEntityInfo(), 432, "TppEffect", 11);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("enable", Fox.Core.PropertyInfo.PropertyType.Bool, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("priority", Fox.Core.PropertyInfo.PropertyType.UInt32, 420, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("model", Fox.Core.PropertyInfo.PropertyType.FilePtr, 424, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cloudTexture", Fox.Core.PropertyInfo.PropertyType.Path, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("textureRepeats", Fox.Core.PropertyInfo.PropertyType.UInt32, 404, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightExtinction", Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("diffusion", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dirLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("ambLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inCloudScatterGain", Fox.Core.PropertyInfo.PropertyType.Float, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("density", Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cloudWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("densityLayerPower", Fox.Core.PropertyInfo.PropertyType.Float, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("densityLayerWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 332, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom2TextureRepeats", Fox.Core.PropertyInfo.PropertyType.UInt32, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom2CloudDensity", Fox.Core.PropertyInfo.PropertyType.Float, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom2WindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom2DensityLayerPower", Fox.Core.PropertyInfo.PropertyType.Float, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom2DensityLayerWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom3TextureRepeats", Fox.Core.PropertyInfo.PropertyType.UInt32, 412, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom3CloudDensity", Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom3WindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom3DensityLayerPower", Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dom3DensityLayerWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylCloudTexture", Fox.Core.PropertyInfo.PropertyType.Path, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylTextureRepeats", Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylCloudDensity", Fox.Core.PropertyInfo.PropertyType.Float, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylDiffusion", Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylScatterGain", Fox.Core.PropertyInfo.PropertyType.Float, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylDirLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 388, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylAmbLightGain", Fox.Core.PropertyInfo.PropertyType.Float, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylDensityLayerPower", Fox.Core.PropertyInfo.PropertyType.Float, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cylDensityLayerWindInfluence", Fox.Core.PropertyInfo.PropertyType.Float, 396, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppSky(ulong id) : base(id) { }
		public TppSky() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "priority":
                    this.priority = value.GetValueAsUInt32();
                    return;
                case "model":
                    this.model = value.GetValueAsFilePtr();
                    return;
                case "cloudTexture":
                    this.cloudTexture = value.GetValueAsPath();
                    return;
                case "textureRepeats":
                    this.textureRepeats = value.GetValueAsUInt32();
                    return;
                case "lightExtinction":
                    this.lightExtinction = value.GetValueAsFloat();
                    return;
                case "diffusion":
                    this.diffusion = value.GetValueAsFloat();
                    return;
                case "dirLightGain":
                    this.dirLightGain = value.GetValueAsFloat();
                    return;
                case "ambLightGain":
                    this.ambLightGain = value.GetValueAsFloat();
                    return;
                case "inCloudScatterGain":
                    this.inCloudScatterGain = value.GetValueAsFloat();
                    return;
                case "density":
                    this.density = value.GetValueAsFloat();
                    return;
                case "cloudWindInfluence":
                    this.cloudWindInfluence = value.GetValueAsFloat();
                    return;
                case "densityLayerPower":
                    this.densityLayerPower = value.GetValueAsFloat();
                    return;
                case "densityLayerWindInfluence":
                    this.densityLayerWindInfluence = value.GetValueAsFloat();
                    return;
                case "dom2TextureRepeats":
                    this.dom2TextureRepeats = value.GetValueAsUInt32();
                    return;
                case "dom2CloudDensity":
                    this.dom2CloudDensity = value.GetValueAsFloat();
                    return;
                case "dom2WindInfluence":
                    this.dom2WindInfluence = value.GetValueAsFloat();
                    return;
                case "dom2DensityLayerPower":
                    this.dom2DensityLayerPower = value.GetValueAsFloat();
                    return;
                case "dom2DensityLayerWindInfluence":
                    this.dom2DensityLayerWindInfluence = value.GetValueAsFloat();
                    return;
                case "dom3TextureRepeats":
                    this.dom3TextureRepeats = value.GetValueAsUInt32();
                    return;
                case "dom3CloudDensity":
                    this.dom3CloudDensity = value.GetValueAsFloat();
                    return;
                case "dom3WindInfluence":
                    this.dom3WindInfluence = value.GetValueAsFloat();
                    return;
                case "dom3DensityLayerPower":
                    this.dom3DensityLayerPower = value.GetValueAsFloat();
                    return;
                case "dom3DensityLayerWindInfluence":
                    this.dom3DensityLayerWindInfluence = value.GetValueAsFloat();
                    return;
                case "cylCloudTexture":
                    this.cylCloudTexture = value.GetValueAsPath();
                    return;
                case "cylTextureRepeats":
                    this.cylTextureRepeats = value.GetValueAsUInt32();
                    return;
                case "cylCloudDensity":
                    this.cylCloudDensity = value.GetValueAsFloat();
                    return;
                case "cylDiffusion":
                    this.cylDiffusion = value.GetValueAsFloat();
                    return;
                case "cylScatterGain":
                    this.cylScatterGain = value.GetValueAsFloat();
                    return;
                case "cylDirLightGain":
                    this.cylDirLightGain = value.GetValueAsFloat();
                    return;
                case "cylAmbLightGain":
                    this.cylAmbLightGain = value.GetValueAsFloat();
                    return;
                case "cylWindInfluence":
                    this.cylWindInfluence = value.GetValueAsFloat();
                    return;
                case "cylDensityLayerPower":
                    this.cylDensityLayerPower = value.GetValueAsFloat();
                    return;
                case "cylDensityLayerWindInfluence":
                    this.cylDensityLayerWindInfluence = value.GetValueAsFloat();
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