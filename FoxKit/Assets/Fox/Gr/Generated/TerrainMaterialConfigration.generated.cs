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

namespace Fox.Gr
{
    [UnityEditor.InitializeOnLoad]
    public partial class TerrainMaterialConfigration : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> slot0 { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> slot1 { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> slot2 { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<uint> slot3 { get; set; } = new Fox.Kernel.DynamicArray<uint>();
        
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
        static TerrainMaterialConfigration()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TerrainMaterialConfigration"), typeof(TerrainMaterialConfigration), new Fox.Core.Data().GetClassEntityInfo(), 128, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("slot0"), Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("slot1"), Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("slot2"), Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("slot3"), Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TerrainMaterialConfigration(ulong id) : base(id) { }
		public TerrainMaterialConfigration() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "slot0":
                    while(this.slot0.Count <= index) { this.slot0.Add(default(uint)); }
                    this.slot0[index] = value.GetValueAsUInt32();
                    return;
                case "slot1":
                    while(this.slot1.Count <= index) { this.slot1.Add(default(uint)); }
                    this.slot1[index] = value.GetValueAsUInt32();
                    return;
                case "slot2":
                    while(this.slot2.Count <= index) { this.slot2.Add(default(uint)); }
                    this.slot2[index] = value.GetValueAsUInt32();
                    return;
                case "slot3":
                    while(this.slot3.Count <= index) { this.slot3.Add(default(uint)); }
                    this.slot3[index] = value.GetValueAsUInt32();
                    return;
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