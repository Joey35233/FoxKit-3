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
    public partial class TerrainMaterialConfigration : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<uint> slot0 = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> slot1 = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> slot2 = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> slot3 = new Fox.Core.DynamicArray<uint>();
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TerrainMaterialConfigration()
        {
            classInfo = new Fox.EntityInfo("TerrainMaterialConfigration", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 128, null, 0);
			
			classInfo.StaticProperties.Insert("slot0", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("slot1", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("slot2", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("slot3", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TerrainMaterialConfigration(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
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