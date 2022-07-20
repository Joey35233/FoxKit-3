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
    public partial class TppLensFlareField : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public TppLensFlareFieldShapeType shapeType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public TppLensFlareFieldInterpType interpType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool debugDrawFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color debugDrawColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float innerScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float centerScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float outerScale { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float innerValue { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float centerValue { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float outerValue { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool reverse { get; set; }
        
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
        static TppLensFlareField()
        {
            classInfo = new Fox.EntityInfo("TppLensFlareField", typeof(TppLensFlareField), new Fox.Core.Data().GetClassEntityInfo(), 144, null, 2);
			classInfo.StaticProperties.Insert("shapeType", new Fox.Core.PropertyInfo("shapeType", Fox.Core.PropertyInfo.PropertyType.Int32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareFieldShapeType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("interpType", new Fox.Core.PropertyInfo("interpType", Fox.Core.PropertyInfo.PropertyType.Int32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppLensFlareFieldInterpType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("debugDrawFlag", new Fox.Core.PropertyInfo("debugDrawFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("debugDrawColor", new Fox.Core.PropertyInfo("debugDrawColor", Fox.Core.PropertyInfo.PropertyType.Color, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerScale", new Fox.Core.PropertyInfo("innerScale", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("centerScale", new Fox.Core.PropertyInfo("centerScale", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outerScale", new Fox.Core.PropertyInfo("outerScale", Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerValue", new Fox.Core.PropertyInfo("innerValue", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("centerValue", new Fox.Core.PropertyInfo("centerValue", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outerValue", new Fox.Core.PropertyInfo("outerValue", Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("reverse", new Fox.Core.PropertyInfo("reverse", Fox.Core.PropertyInfo.PropertyType.Bool, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppLensFlareField(ulong id) : base(id) { }
		public TppLensFlareField() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "shapeType":
                    this.shapeType = (TppLensFlareFieldShapeType)value.GetValueAsInt32();
                    return;
                case "interpType":
                    this.interpType = (TppLensFlareFieldInterpType)value.GetValueAsInt32();
                    return;
                case "debugDrawFlag":
                    this.debugDrawFlag = value.GetValueAsBool();
                    return;
                case "debugDrawColor":
                    this.debugDrawColor = value.GetValueAsColor();
                    return;
                case "innerScale":
                    this.innerScale = value.GetValueAsFloat();
                    return;
                case "centerScale":
                    this.centerScale = value.GetValueAsFloat();
                    return;
                case "outerScale":
                    this.outerScale = value.GetValueAsFloat();
                    return;
                case "innerValue":
                    this.innerValue = value.GetValueAsFloat();
                    return;
                case "centerValue":
                    this.centerValue = value.GetValueAsFloat();
                    return;
                case "outerValue":
                    this.outerValue = value.GetValueAsFloat();
                    return;
                case "reverse":
                    this.reverse = value.GetValueAsBool();
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