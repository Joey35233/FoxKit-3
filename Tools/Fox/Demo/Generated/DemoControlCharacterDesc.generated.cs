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

namespace Fox.Demo
{
    [UnityEditor.InitializeOnLoad]
    public partial class DemoControlCharacterDesc : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String characterId { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String releaseGroupName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String releaseTag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool controlledAtStart { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 translation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Quaternion rotation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String startGroupName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String startTag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 startTranslation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Quaternion startRotation { get; set; }
        
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
        static DemoControlCharacterDesc()
        {
            classInfo = new Fox.Core.EntityInfo("DemoControlCharacterDesc", typeof(DemoControlCharacterDesc), new Fox.Core.DataElement().GetClassEntityInfo(), 128, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("characterId", Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("releaseGroupName", Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("releaseTag", Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("controlledAtStart", Fox.Core.PropertyInfo.PropertyType.Bool, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("translation", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotation", Fox.Core.PropertyInfo.PropertyType.Quat, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startGroupName", Fox.Core.PropertyInfo.PropertyType.String, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startTag", Fox.Core.PropertyInfo.PropertyType.String, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startTranslation", Fox.Core.PropertyInfo.PropertyType.Vector3, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("startRotation", Fox.Core.PropertyInfo.PropertyType.Quat, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public DemoControlCharacterDesc(ulong id) : base(id) { }
		public DemoControlCharacterDesc() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "characterId":
                    this.characterId = value.GetValueAsString();
                    return;
                case "releaseGroupName":
                    this.releaseGroupName = value.GetValueAsString();
                    return;
                case "releaseTag":
                    this.releaseTag = value.GetValueAsString();
                    return;
                case "controlledAtStart":
                    this.controlledAtStart = value.GetValueAsBool();
                    return;
                case "translation":
                    this.translation = value.GetValueAsVector3();
                    return;
                case "rotation":
                    this.rotation = value.GetValueAsQuat();
                    return;
                case "startGroupName":
                    this.startGroupName = value.GetValueAsString();
                    return;
                case "startTag":
                    this.startTag = value.GetValueAsString();
                    return;
                case "startTranslation":
                    this.startTranslation = value.GetValueAsVector3();
                    return;
                case "startRotation":
                    this.startRotation = value.GetValueAsQuat();
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