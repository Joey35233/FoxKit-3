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
    public partial class TppFocusBokehFilterData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool debugDraw { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint debugDrawIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float focusInSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float bokehPower { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int quality { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> targetLocators { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
        
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
        static TppFocusBokehFilterData()
        {
            classInfo = new Fox.Core.EntityInfo("TppFocusBokehFilterData", typeof(TppFocusBokehFilterData), new Fox.Core.Data().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("debugDraw", Fox.Core.PropertyInfo.PropertyType.Bool, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("debugDrawIndex", Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("focusInSize", Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("bokehPower", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("quality", Fox.Core.PropertyInfo.PropertyType.Int32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetLocators", Fox.Core.PropertyInfo.PropertyType.EntityLink, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppFocusBokehFilterData(ulong id) : base(id) { }
		public TppFocusBokehFilterData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "debugDraw":
                    this.debugDraw = value.GetValueAsBool();
                    return;
                case "debugDrawIndex":
                    this.debugDrawIndex = value.GetValueAsUInt32();
                    return;
                case "focusInSize":
                    this.focusInSize = value.GetValueAsFloat();
                    return;
                case "bokehPower":
                    this.bokehPower = value.GetValueAsFloat();
                    return;
                case "quality":
                    this.quality = value.GetValueAsInt32();
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
                case "targetLocators":
                    while(this.targetLocators.Count <= index) { this.targetLocators.Add(default(Fox.Core.EntityLink)); }
                    this.targetLocators[index] = value.GetValueAsEntityLink();
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