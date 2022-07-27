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
    public partial class NavxNavigableParameter : Fox.Core.DataElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String name { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isDefault { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float radius { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float simplificationThreshold { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float height { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxClimbableAngle { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float maxStepSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float minArea { get; set; }
        
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
        static NavxNavigableParameter()
        {
            classInfo = new Fox.Core.EntityInfo("NavxNavigableParameter", typeof(NavxNavigableParameter), new Fox.Core.DataElement().GetClassEntityInfo(), 60, "Navx", 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("name", Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDefault", Fox.Core.PropertyInfo.PropertyType.Bool, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.Float, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("simplificationThreshold", Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("height", Fox.Core.PropertyInfo.PropertyType.Float, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxClimbableAngle", Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxStepSize", Fox.Core.PropertyInfo.PropertyType.Float, 84, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minArea", Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public NavxNavigableParameter(ulong id) : base(id) { }
		public NavxNavigableParameter() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "name":
                    this.name = value.GetValueAsString();
                    return;
                case "isDefault":
                    this.isDefault = value.GetValueAsBool();
                    return;
                case "radius":
                    this.radius = value.GetValueAsFloat();
                    return;
                case "simplificationThreshold":
                    this.simplificationThreshold = value.GetValueAsFloat();
                    return;
                case "height":
                    this.height = value.GetValueAsFloat();
                    return;
                case "maxClimbableAngle":
                    this.maxClimbableAngle = value.GetValueAsFloat();
                    return;
                case "maxStepSize":
                    this.maxStepSize = value.GetValueAsFloat();
                    return;
                case "minArea":
                    this.minArea = value.GetValueAsFloat();
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