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
    public partial class TppModelMarkerFilterSettings : Fox.Core.Data 
    {
        // Properties
        public float texRepeatsNear;
        
        public float texRepeatsFar;
        
        public float texRepeatsMin;
        
        public float texRepeatsMax;
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> alphas = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> offsets = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> incidences = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
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
        static TppModelMarkerFilterSettings()
        {
            classInfo = new Fox.EntityInfo("TppModelMarkerFilterSettings", typeof(TppModelMarkerFilterSettings), new Fox.Core.Data().GetClassEntityInfo(), 128, "TppEffect", 0);
			classInfo.StaticProperties.Insert("texRepeatsNear", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("texRepeatsFar", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("texRepeatsMin", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("texRepeatsMax", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("alphas", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("offsets", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("incidences", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppModelMarkerFilterSettings(ulong id) : base(id) { }
		public TppModelMarkerFilterSettings() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "texRepeatsNear":
                    this.texRepeatsNear = value.GetValueAsFloat();
                    return;
                case "texRepeatsFar":
                    this.texRepeatsFar = value.GetValueAsFloat();
                    return;
                case "texRepeatsMin":
                    this.texRepeatsMin = value.GetValueAsFloat();
                    return;
                case "texRepeatsMax":
                    this.texRepeatsMax = value.GetValueAsFloat();
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
                case "alphas":
                    while(this.alphas.Count <= index) { this.alphas.Add(default(UnityEngine.Vector3)); }
                    this.alphas[index] = value.GetValueAsVector3();
                    return;
                case "offsets":
                    while(this.offsets.Count <= index) { this.offsets.Add(default(UnityEngine.Vector3)); }
                    this.offsets[index] = value.GetValueAsVector3();
                    return;
                case "incidences":
                    while(this.incidences.Count <= index) { this.incidences.Add(default(UnityEngine.Vector3)); }
                    this.incidences[index] = value.GetValueAsVector3();
                    return;
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
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