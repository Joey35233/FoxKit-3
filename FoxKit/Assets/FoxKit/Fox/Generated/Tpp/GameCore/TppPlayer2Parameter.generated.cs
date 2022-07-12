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
    public partial class TppPlayer2Parameter : Fox.Core.DataElement 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> motionGraphFile;
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> vfxFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public uint lifeMax;
        
        public float lifeRecoveryPerSecond;
        
        public float respawnTime;
        
        public uint clipCount;
        
        public float fireInterval;
        
        public float lifeRecoveryCooldownTimer;
        
        public Fox.String partsType;
        
        public Fox.Core.StringMap<byte> TODO_trapTags = new Fox.Core.StringMap<byte>();
        
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
        static TppPlayer2Parameter()
        {
            classInfo = new Fox.EntityInfo("TppPlayer2Parameter", typeof(TppPlayer2Parameter), new Fox.Core.DataElement().GetClassEntityInfo(), 184, null, 5);
			classInfo.StaticProperties.Insert("motionGraphFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("vfxFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 80, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lifeMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lifeRecoveryPerSecond", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("respawnTime", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clipCount", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fireInterval", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lifeRecoveryCooldownTimer", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("TODO_trapTags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt8, 160, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPlayer2Parameter(ulong id) : base(id) { }
		public TppPlayer2Parameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "motionGraphFile":
                    this.motionGraphFile = value.GetValueAsFilePtr();
                    return;
                case "lifeMax":
                    this.lifeMax = value.GetValueAsUInt32();
                    return;
                case "lifeRecoveryPerSecond":
                    this.lifeRecoveryPerSecond = value.GetValueAsFloat();
                    return;
                case "respawnTime":
                    this.respawnTime = value.GetValueAsFloat();
                    return;
                case "clipCount":
                    this.clipCount = value.GetValueAsUInt32();
                    return;
                case "fireInterval":
                    this.fireInterval = value.GetValueAsFloat();
                    return;
                case "lifeRecoveryCooldownTimer":
                    this.lifeRecoveryCooldownTimer = value.GetValueAsFloat();
                    return;
                case "partsType":
                    this.partsType = value.GetValueAsString();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                case "vfxFiles":
                    this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "TODO_trapTags":
                    this.TODO_trapTags.Insert(key, value.GetValueAsUInt8());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}