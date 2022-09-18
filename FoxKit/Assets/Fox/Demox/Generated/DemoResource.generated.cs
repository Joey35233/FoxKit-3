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

namespace Fox.Demox
{
    [UnityEditor.InitializeOnLoad]
    public partial class DemoResource : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public bool enable { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String demoIdentifierName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> demoIdentifierKey { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public uint streamBufferSizeInKbytes { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint systemPacketSizeInKbytes { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint systemPacketNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint soundPacketSizeInKbytes { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint soundPacketNum { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint demoPacketSizeInKbytes { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint demoPacketNum { get; set; }
        
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
        static DemoResource()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("DemoResource"), typeof(DemoResource), new Fox.Core.Data().GetClassEntityInfo(), 120, null, 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoIdentifierName"), Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoIdentifierKey"), Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("streamBufferSizeInKbytes"), Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("systemPacketSizeInKbytes"), Fox.Core.PropertyInfo.PropertyType.UInt32, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("systemPacketNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("soundPacketSizeInKbytes"), Fox.Core.PropertyInfo.PropertyType.UInt32, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("soundPacketNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoPacketSizeInKbytes"), Fox.Core.PropertyInfo.PropertyType.UInt32, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoPacketNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public DemoResource(ulong id) : base(id) { }
		public DemoResource() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "enable":
                    this.enable = value.GetValueAsBool();
                    return;
                case "demoIdentifierName":
                    this.demoIdentifierName = value.GetValueAsString();
                    return;
                case "streamBufferSizeInKbytes":
                    this.streamBufferSizeInKbytes = value.GetValueAsUInt32();
                    return;
                case "systemPacketSizeInKbytes":
                    this.systemPacketSizeInKbytes = value.GetValueAsUInt32();
                    return;
                case "systemPacketNum":
                    this.systemPacketNum = value.GetValueAsUInt32();
                    return;
                case "soundPacketSizeInKbytes":
                    this.soundPacketSizeInKbytes = value.GetValueAsUInt32();
                    return;
                case "soundPacketNum":
                    this.soundPacketNum = value.GetValueAsUInt32();
                    return;
                case "demoPacketSizeInKbytes":
                    this.demoPacketSizeInKbytes = value.GetValueAsUInt32();
                    return;
                case "demoPacketNum":
                    this.demoPacketNum = value.GetValueAsUInt32();
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
                case "demoIdentifierKey":
                    while(this.demoIdentifierKey.Count <= index) { this.demoIdentifierKey.Add(default(Fox.Kernel.String)); }
                    this.demoIdentifierKey[index] = value.GetValueAsString();
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