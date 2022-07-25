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

namespace Fox.PartsBuilder
{
    [UnityEditor.InitializeOnLoad]
    public partial class EffectDescription : Fox.PartsBuilder.PartDescription 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String> connectDestinationSkelNames { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String> connectDestinationCnpNames { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<UnityEngine.Vector3> offsetSkelPositions { get; set; } = new Fox.FoxKernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<UnityEngine.Vector3> offsetCnpPositions { get; set; } = new Fox.FoxKernel.DynamicArray<UnityEngine.Vector3>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<UnityEngine.Vector4> generalSkelParameters { get; set; } = new Fox.FoxKernel.DynamicArray<UnityEngine.Vector4>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<UnityEngine.Vector4> generalCnpParameters { get; set; } = new Fox.FoxKernel.DynamicArray<UnityEngine.Vector4>();
        
        [field: UnityEngine.SerializeField]
        public bool effectConnect { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool changeEffectConnectSetting { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool visibleModelWithEffect { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool createStartEffect { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint effectRandomSeed { get; set; }
        
        [field: UnityEngine.SerializeField]
        public EffectKind effectKind { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String effectVariationName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String effectFileFromVfxFileLoader { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr effectFileFromFilePtr { get; set; }
        
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
        static EffectDescription()
        {
            classInfo = new Fox.EntityInfo("EffectDescription", typeof(EffectDescription), new Fox.PartsBuilder.PartDescription().GetClassEntityInfo(), 232, "PartsBuilder", 6);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectDestinationSkelNames", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectDestinationCnpNames", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetSkelPositions", Fox.Core.PropertyInfo.PropertyType.Vector3, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetCnpPositions", Fox.Core.PropertyInfo.PropertyType.Vector3, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("generalSkelParameters", Fox.Core.PropertyInfo.PropertyType.Vector4, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("generalCnpParameters", Fox.Core.PropertyInfo.PropertyType.Vector4, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectConnect", Fox.Core.PropertyInfo.PropertyType.Bool, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("changeEffectConnectSetting", Fox.Core.PropertyInfo.PropertyType.Bool, 249, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("visibleModelWithEffect", Fox.Core.PropertyInfo.PropertyType.Bool, 250, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("createStartEffect", Fox.Core.PropertyInfo.PropertyType.Bool, 251, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectRandomSeed", Fox.Core.PropertyInfo.PropertyType.UInt32, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectKind", Fox.Core.PropertyInfo.PropertyType.Int32, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(EffectKind), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectVariationName", Fox.Core.PropertyInfo.PropertyType.String, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectFileFromVfxFileLoader", Fox.Core.PropertyInfo.PropertyType.String, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("effectFileFromFilePtr", Fox.Core.PropertyInfo.PropertyType.FilePtr, 280, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public EffectDescription(ulong id) : base(id) { }
		public EffectDescription() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "effectConnect":
                    this.effectConnect = value.GetValueAsBool();
                    return;
                case "changeEffectConnectSetting":
                    this.changeEffectConnectSetting = value.GetValueAsBool();
                    return;
                case "visibleModelWithEffect":
                    this.visibleModelWithEffect = value.GetValueAsBool();
                    return;
                case "createStartEffect":
                    this.createStartEffect = value.GetValueAsBool();
                    return;
                case "effectRandomSeed":
                    this.effectRandomSeed = value.GetValueAsUInt32();
                    return;
                case "effectKind":
                    this.effectKind = (EffectKind)value.GetValueAsInt32();
                    return;
                case "effectVariationName":
                    this.effectVariationName = value.GetValueAsString();
                    return;
                case "effectFileFromVfxFileLoader":
                    this.effectFileFromVfxFileLoader = value.GetValueAsString();
                    return;
                case "effectFileFromFilePtr":
                    this.effectFileFromFilePtr = value.GetValueAsFilePtr();
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
                case "connectDestinationSkelNames":
                    while(this.connectDestinationSkelNames.Count <= index) { this.connectDestinationSkelNames.Add(default(Fox.FoxKernel.String)); }
                    this.connectDestinationSkelNames[index] = value.GetValueAsString();
                    return;
                case "connectDestinationCnpNames":
                    while(this.connectDestinationCnpNames.Count <= index) { this.connectDestinationCnpNames.Add(default(Fox.FoxKernel.String)); }
                    this.connectDestinationCnpNames[index] = value.GetValueAsString();
                    return;
                case "offsetSkelPositions":
                    while(this.offsetSkelPositions.Count <= index) { this.offsetSkelPositions.Add(default(UnityEngine.Vector3)); }
                    this.offsetSkelPositions[index] = value.GetValueAsVector3();
                    return;
                case "offsetCnpPositions":
                    while(this.offsetCnpPositions.Count <= index) { this.offsetCnpPositions.Add(default(UnityEngine.Vector3)); }
                    this.offsetCnpPositions[index] = value.GetValueAsVector3();
                    return;
                case "generalSkelParameters":
                    while(this.generalSkelParameters.Count <= index) { this.generalSkelParameters.Add(default(UnityEngine.Vector4)); }
                    this.generalSkelParameters[index] = value.GetValueAsVector4();
                    return;
                case "generalCnpParameters":
                    while(this.generalCnpParameters.Count <= index) { this.generalCnpParameters.Add(default(UnityEngine.Vector4)); }
                    this.generalCnpParameters[index] = value.GetValueAsVector4();
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