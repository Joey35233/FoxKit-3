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
    public partial class TppPermanentGimmickEventAnimationParameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected uint flag1 { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path defaultAnimPath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.Path eventAnimPath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float fadeTime { get; set; }
        
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
        static TppPermanentGimmickEventAnimationParameter()
        {
            classInfo = new Fox.Core.EntityInfo("TppPermanentGimmickEventAnimationParameter", typeof(TppPermanentGimmickEventAnimationParameter), new Fox.Core.DataElement().GetClassEntityInfo(), 56, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flag1", Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultAnimPath", Fox.Core.PropertyInfo.PropertyType.Path, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("eventAnimPath", Fox.Core.PropertyInfo.PropertyType.Path, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fadeTime", Fox.Core.PropertyInfo.PropertyType.Float, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppPermanentGimmickEventAnimationParameter(ulong id) : base(id) { }
		public TppPermanentGimmickEventAnimationParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "flag1":
                    this.flag1 = value.GetValueAsUInt32();
                    return;
                case "defaultAnimPath":
                    this.defaultAnimPath = value.GetValueAsPath();
                    return;
                case "eventAnimPath":
                    this.eventAnimPath = value.GetValueAsPath();
                    return;
                case "fadeTime":
                    this.fadeTime = value.GetValueAsFloat();
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