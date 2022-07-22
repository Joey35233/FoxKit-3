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
    [UnityEditor.InitializeOnLoad]
    public partial class TppLightProbeArray : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<TppLightProbeArray_DrawRejectionLevel> drawRejectionLevels { get; set; } = new Fox.Core.DynamicArray<TppLightProbeArray_DrawRejectionLevel>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> relatedLights { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.EntityLink> shDatas { get; set; } = new Fox.Core.DynamicArray<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr lightArrayFile { get; set; }
        
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
        static TppLightProbeArray()
        {
            classInfo = new Fox.EntityInfo("TppLightProbeArray", typeof(TppLightProbeArray), new Fox.Core.TransformData().GetClassEntityInfo(), 336, "Light", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionLevels", Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLightProbeArray_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("relatedLights", Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shDatas", Fox.Core.PropertyInfo.PropertyType.EntityLink, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightArrayFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppLightProbeArray(ulong id) : base(id) { }
		public TppLightProbeArray() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "lightArrayFile":
                    this.lightArrayFile = value.GetValueAsFilePtr();
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
                case "drawRejectionLevels":
                    while(this.drawRejectionLevels.Count <= index) { this.drawRejectionLevels.Add(default(TppLightProbeArray_DrawRejectionLevel)); }
                    this.drawRejectionLevels[index] = (TppLightProbeArray_DrawRejectionLevel)value.GetValueAsInt32();
                    return;
                case "relatedLights":
                    while(this.relatedLights.Count <= index) { this.relatedLights.Add(default(Fox.Core.EntityLink)); }
                    this.relatedLights[index] = value.GetValueAsEntityLink();
                    return;
                case "shDatas":
                    while(this.shDatas.Count <= index) { this.shDatas.Add(default(Fox.Core.EntityLink)); }
                    this.shDatas[index] = value.GetValueAsEntityLink();
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