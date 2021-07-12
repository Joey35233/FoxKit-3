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
    public partial class TppRainFilterInterrupt : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<UnityEngine.Matrix4x4> planeMatrices = new Fox.Core.DynamicArray<UnityEngine.Matrix4x4>();
        
        public Fox.Core.DynamicArray<Fox.Core.Path> maskTextures = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
        public Fox.Core.DynamicArray<uint> interruptFlags = new Fox.Core.DynamicArray<uint>();
        
        public Fox.Core.DynamicArray<uint> levels = new Fox.Core.DynamicArray<uint>();
        
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
        static TppRainFilterInterrupt()
        {
            classInfo = new Fox.EntityInfo("TppRainFilterInterrupt", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 208, null, 2);
			
			classInfo.StaticProperties.Insert("planeMatrices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Matrix4, 208, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTextures", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 192, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interruptFlags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 224, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("levels", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 240, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TppRainFilterInterrupt(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "planeMatrices":
                    while(this.planeMatrices.Count <= index) { this.planeMatrices.Add(default(UnityEngine.Matrix4x4)); }
                    this.planeMatrices[index] = value.GetValueAsMatrix4();
                    return;
                case "maskTextures":
                    while(this.maskTextures.Count <= index) { this.maskTextures.Add(default(Fox.Core.Path)); }
                    this.maskTextures[index] = value.GetValueAsPath();
                    return;
                case "interruptFlags":
                    while(this.interruptFlags.Count <= index) { this.interruptFlags.Add(default(uint)); }
                    this.interruptFlags[index] = value.GetValueAsUInt32();
                    return;
                case "levels":
                    while(this.levels.Count <= index) { this.levels.Add(default(uint)); }
                    this.levels[index] = value.GetValueAsUInt32();
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