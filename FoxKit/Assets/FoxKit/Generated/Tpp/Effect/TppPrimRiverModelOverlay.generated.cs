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
    public partial class TppPrimRiverModelOverlay : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.String primRiverGroupName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool visibility { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float depthBlendLength { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float raise { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink staticModel { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String maskTextureName { get; set; }
        
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
        static TppPrimRiverModelOverlay()
        {
            classInfo = new Fox.EntityInfo("TppPrimRiverModelOverlay", typeof(TppPrimRiverModelOverlay), new Fox.Core.Data().GetClassEntityInfo(), 120, null, 0);
			classInfo.StaticProperties.Insert("primRiverGroupName", new Fox.Core.PropertyInfo("primRiverGroupName", Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("visibility", new Fox.Core.PropertyInfo("visibility", Fox.Core.PropertyInfo.PropertyType.Bool, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("depthBlendLength", new Fox.Core.PropertyInfo("depthBlendLength", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("raise", new Fox.Core.PropertyInfo("raise", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("staticModel", new Fox.Core.PropertyInfo("staticModel", Fox.Core.PropertyInfo.PropertyType.EntityLink, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maskTextureName", new Fox.Core.PropertyInfo("maskTextureName", Fox.Core.PropertyInfo.PropertyType.String, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppPrimRiverModelOverlay(ulong id) : base(id) { }
		public TppPrimRiverModelOverlay() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "primRiverGroupName":
                    this.primRiverGroupName = value.GetValueAsString();
                    return;
                case "visibility":
                    this.visibility = value.GetValueAsBool();
                    return;
                case "depthBlendLength":
                    this.depthBlendLength = value.GetValueAsFloat();
                    return;
                case "raise":
                    this.raise = value.GetValueAsFloat();
                    return;
                case "staticModel":
                    this.staticModel = value.GetValueAsEntityLink();
                    return;
                case "maskTextureName":
                    this.maskTextureName = value.GetValueAsString();
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