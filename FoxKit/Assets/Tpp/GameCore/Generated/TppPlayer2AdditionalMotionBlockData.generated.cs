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

namespace Tpp.GameCore
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppPlayer2AdditionalMotionBlockData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint blockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint vramBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint residentVramSyncBufferSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint baseVramSyncBufferSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint equipVramSyncBufferSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint weaponVramSyncBufferSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path fpkPath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path vramFpkPath { get; set; }
        
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
        static TppPlayer2AdditionalMotionBlockData()
        {
            classInfo = new Fox.Core.EntityInfo("TppPlayer2AdditionalMotionBlockData", typeof(TppPlayer2AdditionalMotionBlockData), new Fox.Core.Data().GetClassEntityInfo(), 104, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("blockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vramBlockSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("residentVramSyncBufferSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("baseVramSyncBufferSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("equipVramSyncBufferSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("weaponVramSyncBufferSize", Fox.Core.PropertyInfo.PropertyType.UInt32, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fpkPath", Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vramFpkPath", Fox.Core.PropertyInfo.PropertyType.Path, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppPlayer2AdditionalMotionBlockData(ulong id) : base(id) { }
		public TppPlayer2AdditionalMotionBlockData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "blockSize":
                    this.blockSize = value.GetValueAsUInt32();
                    return;
                case "vramBlockSize":
                    this.vramBlockSize = value.GetValueAsUInt32();
                    return;
                case "residentVramSyncBufferSize":
                    this.residentVramSyncBufferSize = value.GetValueAsUInt32();
                    return;
                case "baseVramSyncBufferSize":
                    this.baseVramSyncBufferSize = value.GetValueAsUInt32();
                    return;
                case "equipVramSyncBufferSize":
                    this.equipVramSyncBufferSize = value.GetValueAsUInt32();
                    return;
                case "weaponVramSyncBufferSize":
                    this.weaponVramSyncBufferSize = value.GetValueAsUInt32();
                    return;
                case "fpkPath":
                    this.fpkPath = value.GetValueAsPath();
                    return;
                case "vramFpkPath":
                    this.vramFpkPath = value.GetValueAsPath();
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