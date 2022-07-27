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

namespace Tpp.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class TppSharedGimmickData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr modelFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr geomFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr breakedModelFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr breakedGeomFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr partsFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint numDynamicGimmick { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr locaterFile { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint flags1 { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint flags2 { get; set; }
        
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
        static TppSharedGimmickData()
        {
            classInfo = new Fox.Core.EntityInfo("TppSharedGimmickData", typeof(TppSharedGimmickData), new Fox.Core.Data().GetClassEntityInfo(), 240, "Gimmick", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("geomFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("breakedModelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("breakedGeomFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("partsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("numDynamicGimmick", Fox.Core.PropertyInfo.PropertyType.UInt32, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("locaterFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags1", Fox.Core.PropertyInfo.PropertyType.UInt32, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags2", Fox.Core.PropertyInfo.PropertyType.UInt32, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppSharedGimmickData(ulong id) : base(id) { }
		public TppSharedGimmickData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "geomFile":
                    this.geomFile = value.GetValueAsFilePtr();
                    return;
                case "breakedModelFile":
                    this.breakedModelFile = value.GetValueAsFilePtr();
                    return;
                case "breakedGeomFile":
                    this.breakedGeomFile = value.GetValueAsFilePtr();
                    return;
                case "partsFile":
                    this.partsFile = value.GetValueAsFilePtr();
                    return;
                case "numDynamicGimmick":
                    this.numDynamicGimmick = value.GetValueAsUInt32();
                    return;
                case "locaterFile":
                    this.locaterFile = value.GetValueAsFilePtr();
                    return;
                case "flags1":
                    this.flags1 = value.GetValueAsUInt32();
                    return;
                case "flags2":
                    this.flags2 = value.GetValueAsUInt32();
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