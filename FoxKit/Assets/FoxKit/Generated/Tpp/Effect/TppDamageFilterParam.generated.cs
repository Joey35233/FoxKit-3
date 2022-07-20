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
    public partial class TppDamageFilterParam : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color burnOutsideColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color burnMiddleColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color burnInsideColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color burnHoleColor { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float burnSpriteSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float burnSpritePosition { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String damageColorCorrectionTextureName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String injuryColorCorrectionTextureName { get; set; }
        
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
        static TppDamageFilterParam()
        {
            classInfo = new Fox.EntityInfo("TppDamageFilterParam", typeof(TppDamageFilterParam), new Fox.Core.TransformData().GetClassEntityInfo(), 336, null, 0);
			classInfo.StaticProperties.Insert("burnOutsideColor", new Fox.Core.PropertyInfo("burnOutsideColor", Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("burnMiddleColor", new Fox.Core.PropertyInfo("burnMiddleColor", Fox.Core.PropertyInfo.PropertyType.Color, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("burnInsideColor", new Fox.Core.PropertyInfo("burnInsideColor", Fox.Core.PropertyInfo.PropertyType.Color, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("burnHoleColor", new Fox.Core.PropertyInfo("burnHoleColor", Fox.Core.PropertyInfo.PropertyType.Color, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("burnSpriteSize", new Fox.Core.PropertyInfo("burnSpriteSize", Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("burnSpritePosition", new Fox.Core.PropertyInfo("burnSpritePosition", Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("damageColorCorrectionTextureName", new Fox.Core.PropertyInfo("damageColorCorrectionTextureName", Fox.Core.PropertyInfo.PropertyType.String, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("injuryColorCorrectionTextureName", new Fox.Core.PropertyInfo("injuryColorCorrectionTextureName", Fox.Core.PropertyInfo.PropertyType.String, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppDamageFilterParam(ulong id) : base(id) { }
		public TppDamageFilterParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "burnOutsideColor":
                    this.burnOutsideColor = value.GetValueAsColor();
                    return;
                case "burnMiddleColor":
                    this.burnMiddleColor = value.GetValueAsColor();
                    return;
                case "burnInsideColor":
                    this.burnInsideColor = value.GetValueAsColor();
                    return;
                case "burnHoleColor":
                    this.burnHoleColor = value.GetValueAsColor();
                    return;
                case "burnSpriteSize":
                    this.burnSpriteSize = value.GetValueAsFloat();
                    return;
                case "burnSpritePosition":
                    this.burnSpritePosition = value.GetValueAsFloat();
                    return;
                case "damageColorCorrectionTextureName":
                    this.damageColorCorrectionTextureName = value.GetValueAsString();
                    return;
                case "injuryColorCorrectionTextureName":
                    this.injuryColorCorrectionTextureName = value.GetValueAsString();
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