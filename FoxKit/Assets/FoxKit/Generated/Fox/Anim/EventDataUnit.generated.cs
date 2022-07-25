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

namespace Fox.Anim
{
    [UnityEditor.InitializeOnLoad]
    public partial class EventDataUnit : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String eventName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.TimeSection>> sections { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.TimeSection>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String> paramString { get; set; } = new Fox.FoxKernel.DynamicArray<Fox.FoxKernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<int> paramInt { get; set; } = new Fox.FoxKernel.DynamicArray<int>();
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.DynamicArray<float> paramFloat { get; set; } = new Fox.FoxKernel.DynamicArray<float>();
        
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
        static EventDataUnit()
        {
            classInfo = new Fox.EntityInfo("EventDataUnit", typeof(EventDataUnit), new Fox.Core.Data().GetClassEntityInfo(), 136, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("eventName", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sections", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.TimeSection), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("paramString", Fox.Core.PropertyInfo.PropertyType.String, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("paramInt", Fox.Core.PropertyInfo.PropertyType.Int32, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("paramFloat", Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public EventDataUnit(ulong id) : base(id) { }
		public EventDataUnit() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "eventName":
                    this.eventName = value.GetValueAsString();
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
                case "sections":
                    while(this.sections.Count <= index) { this.sections.Add(default(Fox.Core.EntityPtr<Fox.Anim.TimeSection>)); }
                    this.sections[index] = value.GetValueAsEntityPtr<Fox.Anim.TimeSection>();
                    return;
                case "paramString":
                    while(this.paramString.Count <= index) { this.paramString.Add(default(Fox.FoxKernel.String)); }
                    this.paramString[index] = value.GetValueAsString();
                    return;
                case "paramInt":
                    while(this.paramInt.Count <= index) { this.paramInt.Add(default(int)); }
                    this.paramInt[index] = value.GetValueAsInt32();
                    return;
                case "paramFloat":
                    while(this.paramFloat.Count <= index) { this.paramFloat.Add(default(float)); }
                    this.paramFloat[index] = value.GetValueAsFloat();
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