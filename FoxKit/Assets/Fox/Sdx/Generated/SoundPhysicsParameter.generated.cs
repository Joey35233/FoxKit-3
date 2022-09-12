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
    public partial class SoundPhysicsParameter : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String hitEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String rollStartEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String rollEndEvent { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String hitRtpcName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String rollRtpcName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String switchName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String generalEvent1 { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String generalEvent2 { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hitLowerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hitUpperPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hitIntervalSeconds { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hitLowerRtpc { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float hitUpperRtpc { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollLowerPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollUpperPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollStartSeconds { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollEndSeconds { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollLowerRtpc { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float rollUpperRtpc { get; set; }
        
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
        static SoundPhysicsParameter()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SoundPhysicsParameter"), typeof(SoundPhysicsParameter), new Fox.Core.Data().GetClassEntityInfo(), 140, "Sound", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitEvent"), Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollStartEvent"), Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollEndEvent"), Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitRtpcName"), Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollRtpcName"), Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("switchName"), Fox.Core.PropertyInfo.PropertyType.String, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("generalEvent1"), Fox.Core.PropertyInfo.PropertyType.String, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("generalEvent2"), Fox.Core.PropertyInfo.PropertyType.String, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitLowerPower"), Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitUpperPower"), Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitIntervalSeconds"), Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitLowerRtpc"), Fox.Core.PropertyInfo.PropertyType.Float, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hitUpperRtpc"), Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollLowerPower"), Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollUpperPower"), Fox.Core.PropertyInfo.PropertyType.Float, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollStartSeconds"), Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollEndSeconds"), Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollLowerRtpc"), Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rollUpperRtpc"), Fox.Core.PropertyInfo.PropertyType.Float, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public SoundPhysicsParameter(ulong id) : base(id) { }
		public SoundPhysicsParameter() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "hitEvent":
                    this.hitEvent = value.GetValueAsString();
                    return;
                case "rollStartEvent":
                    this.rollStartEvent = value.GetValueAsString();
                    return;
                case "rollEndEvent":
                    this.rollEndEvent = value.GetValueAsString();
                    return;
                case "hitRtpcName":
                    this.hitRtpcName = value.GetValueAsString();
                    return;
                case "rollRtpcName":
                    this.rollRtpcName = value.GetValueAsString();
                    return;
                case "switchName":
                    this.switchName = value.GetValueAsString();
                    return;
                case "generalEvent1":
                    this.generalEvent1 = value.GetValueAsString();
                    return;
                case "generalEvent2":
                    this.generalEvent2 = value.GetValueAsString();
                    return;
                case "hitLowerPower":
                    this.hitLowerPower = value.GetValueAsFloat();
                    return;
                case "hitUpperPower":
                    this.hitUpperPower = value.GetValueAsFloat();
                    return;
                case "hitIntervalSeconds":
                    this.hitIntervalSeconds = value.GetValueAsFloat();
                    return;
                case "hitLowerRtpc":
                    this.hitLowerRtpc = value.GetValueAsFloat();
                    return;
                case "hitUpperRtpc":
                    this.hitUpperRtpc = value.GetValueAsFloat();
                    return;
                case "rollLowerPower":
                    this.rollLowerPower = value.GetValueAsFloat();
                    return;
                case "rollUpperPower":
                    this.rollUpperPower = value.GetValueAsFloat();
                    return;
                case "rollStartSeconds":
                    this.rollStartSeconds = value.GetValueAsFloat();
                    return;
                case "rollEndSeconds":
                    this.rollEndSeconds = value.GetValueAsFloat();
                    return;
                case "rollLowerRtpc":
                    this.rollLowerRtpc = value.GetValueAsFloat();
                    return;
                case "rollUpperRtpc":
                    this.rollUpperRtpc = value.GetValueAsFloat();
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