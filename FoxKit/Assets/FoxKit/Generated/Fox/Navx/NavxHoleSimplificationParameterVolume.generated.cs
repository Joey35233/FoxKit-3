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

namespace Fox.Navx
{
    [UnityEditor.InitializeOnLoad]
    public partial class NavxHoleSimplificationParameterVolume : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.String sceneName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String worldName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float convexThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float obbExpandThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float obbToAabbThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float smoothingThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isNotClosePassage { get; set; }
        
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
        static NavxHoleSimplificationParameterVolume()
        {
            classInfo = new Fox.EntityInfo("NavxHoleSimplificationParameterVolume", typeof(NavxHoleSimplificationParameterVolume), new Fox.Core.TransformData().GetClassEntityInfo(), 288, "Navx", 1);
			classInfo.StaticProperties.Insert("sceneName", new Fox.Core.PropertyInfo("sceneName", Fox.Core.PropertyInfo.PropertyType.String, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldName", new Fox.Core.PropertyInfo("worldName", Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("convexThreshold", new Fox.Core.PropertyInfo("convexThreshold", Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("obbExpandThreshold", new Fox.Core.PropertyInfo("obbExpandThreshold", Fox.Core.PropertyInfo.PropertyType.Float, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("obbToAabbThreshold", new Fox.Core.PropertyInfo("obbToAabbThreshold", Fox.Core.PropertyInfo.PropertyType.Float, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smoothingThreshold", new Fox.Core.PropertyInfo("smoothingThreshold", Fox.Core.PropertyInfo.PropertyType.Float, 332, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isNotClosePassage", new Fox.Core.PropertyInfo("isNotClosePassage", Fox.Core.PropertyInfo.PropertyType.Bool, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public NavxHoleSimplificationParameterVolume(ulong id) : base(id) { }
		public NavxHoleSimplificationParameterVolume() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "sceneName":
                    this.sceneName = value.GetValueAsString();
                    return;
                case "worldName":
                    this.worldName = value.GetValueAsString();
                    return;
                case "convexThreshold":
                    this.convexThreshold = value.GetValueAsFloat();
                    return;
                case "obbExpandThreshold":
                    this.obbExpandThreshold = value.GetValueAsFloat();
                    return;
                case "obbToAabbThreshold":
                    this.obbToAabbThreshold = value.GetValueAsFloat();
                    return;
                case "smoothingThreshold":
                    this.smoothingThreshold = value.GetValueAsFloat();
                    return;
                case "isNotClosePassage":
                    this.isNotClosePassage = value.GetValueAsBool();
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