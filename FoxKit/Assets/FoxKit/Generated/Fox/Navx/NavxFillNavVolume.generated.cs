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
    public partial class NavxFillNavVolume : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.String sceneName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String worldName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> attributes { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
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
        static NavxFillNavVolume()
        {
            classInfo = new Fox.EntityInfo("NavxFillNavVolume", typeof(NavxFillNavVolume), new Fox.Core.TransformData().GetClassEntityInfo(), 288, "Navx", 0);
			classInfo.StaticProperties.Insert("sceneName", new Fox.Core.PropertyInfo("sceneName", Fox.Core.PropertyInfo.PropertyType.String, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldName", new Fox.Core.PropertyInfo("worldName", Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("attributes", new Fox.Core.PropertyInfo("attributes", Fox.Core.PropertyInfo.PropertyType.String, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public NavxFillNavVolume(ulong id) : base(id) { }
		public NavxFillNavVolume() : base() { }
        
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
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "attributes":
                    while(this.attributes.Count <= index) { this.attributes.Add(default(Fox.Core.String)); }
                    this.attributes[index] = value.GetValueAsString();
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