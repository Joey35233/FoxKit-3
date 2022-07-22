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
    public partial class TppLensFlareShapeArray : Tpp.Effect.TppLensFlareShape 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint spriteCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float offsetScaleMin { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float offsetScaleMax { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float sizeScaleMin { get; set; }
        
        [field: UnityEngine.SerializeField]
        public float sizeScaleMax { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color randomColorMin { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Color randomColorMax { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint randomSeed { get; set; }
        
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
        static TppLensFlareShapeArray()
        {
            classInfo = new Fox.EntityInfo("TppLensFlareShapeArray", typeof(TppLensFlareShapeArray), new Tpp.Effect.TppLensFlareShape().GetClassEntityInfo(), 768, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("spriteCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 816, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetScaleMin", Fox.Core.PropertyInfo.PropertyType.Float, 820, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetScaleMax", Fox.Core.PropertyInfo.PropertyType.Float, 824, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sizeScaleMin", Fox.Core.PropertyInfo.PropertyType.Float, 828, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sizeScaleMax", Fox.Core.PropertyInfo.PropertyType.Float, 832, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("randomColorMin", Fox.Core.PropertyInfo.PropertyType.Color, 848, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("randomColorMax", Fox.Core.PropertyInfo.PropertyType.Color, 864, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("randomSeed", Fox.Core.PropertyInfo.PropertyType.UInt32, 880, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppLensFlareShapeArray(ulong id) : base(id) { }
		public TppLensFlareShapeArray() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "spriteCount":
                    this.spriteCount = value.GetValueAsUInt32();
                    return;
                case "offsetScaleMin":
                    this.offsetScaleMin = value.GetValueAsFloat();
                    return;
                case "offsetScaleMax":
                    this.offsetScaleMax = value.GetValueAsFloat();
                    return;
                case "sizeScaleMin":
                    this.sizeScaleMin = value.GetValueAsFloat();
                    return;
                case "sizeScaleMax":
                    this.sizeScaleMax = value.GetValueAsFloat();
                    return;
                case "randomColorMin":
                    this.randomColorMin = value.GetValueAsColor();
                    return;
                case "randomColorMax":
                    this.randomColorMax = value.GetValueAsColor();
                    return;
                case "randomSeed":
                    this.randomSeed = value.GetValueAsUInt32();
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