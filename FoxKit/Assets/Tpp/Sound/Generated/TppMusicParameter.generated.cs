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

namespace Tpp.Sound
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppMusicParameter : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String tag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String playEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String daySwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String nightSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerEasySwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerOuterSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerHardSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerEasyLostSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerOuterLostSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerHardLostSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerEvasionSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String dangerStrongSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyReflexSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyNeutralToSneakSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetySneakSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyCautionSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyNoticeSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyCautionNoticeSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String safetyAlertToCautionSwitchEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String neutralSwitchEvent { get; set; }
        
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
        static TppMusicParameter()
        {
            classInfo = new Fox.Core.EntityInfo("TppMusicParameter", typeof(TppMusicParameter), new Fox.Core.Data().GetClassEntityInfo(), 144, "Sound", 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("tag", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("playEvent", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("daySwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nightSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerEasySwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerOuterSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerHardSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerEasyLostSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerOuterLostSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerHardLostSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerEvasionSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dangerStrongSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyReflexSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyNeutralToSneakSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetySneakSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyCautionSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyNoticeSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyCautionNoticeSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("safetyAlertToCautionSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("neutralSwitchEvent", Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppMusicParameter(ulong id) : base(id) { }
		public TppMusicParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "tag":
                    this.tag = value.GetValueAsString();
                    return;
                case "playEvent":
                    this.playEvent = value.GetValueAsString();
                    return;
                case "daySwitchEvent":
                    this.daySwitchEvent = value.GetValueAsString();
                    return;
                case "nightSwitchEvent":
                    this.nightSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerEasySwitchEvent":
                    this.dangerEasySwitchEvent = value.GetValueAsString();
                    return;
                case "dangerOuterSwitchEvent":
                    this.dangerOuterSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerHardSwitchEvent":
                    this.dangerHardSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerEasyLostSwitchEvent":
                    this.dangerEasyLostSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerOuterLostSwitchEvent":
                    this.dangerOuterLostSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerHardLostSwitchEvent":
                    this.dangerHardLostSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerEvasionSwitchEvent":
                    this.dangerEvasionSwitchEvent = value.GetValueAsString();
                    return;
                case "dangerStrongSwitchEvent":
                    this.dangerStrongSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyReflexSwitchEvent":
                    this.safetyReflexSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyNeutralToSneakSwitchEvent":
                    this.safetyNeutralToSneakSwitchEvent = value.GetValueAsString();
                    return;
                case "safetySneakSwitchEvent":
                    this.safetySneakSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyCautionSwitchEvent":
                    this.safetyCautionSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyNoticeSwitchEvent":
                    this.safetyNoticeSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyCautionNoticeSwitchEvent":
                    this.safetyCautionNoticeSwitchEvent = value.GetValueAsString();
                    return;
                case "safetyAlertToCautionSwitchEvent":
                    this.safetyAlertToCautionSwitchEvent = value.GetValueAsString();
                    return;
                case "neutralSwitchEvent":
                    this.neutralSwitchEvent = value.GetValueAsString();
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