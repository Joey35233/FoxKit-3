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
    public partial class TppLensFlareShapeCircle : Tpp.Effect.TppLensFlareShape 
    {
        // Properties
        public float outerScale;
        
        public float innerScale;
        
        public uint divideNum;
        
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
        static TppLensFlareShapeCircle()
        {
            classInfo = new Fox.EntityInfo("TppLensFlareShapeCircle", typeof(TppLensFlareShapeCircle), new Tpp.Effect.TppLensFlareShape().GetClassEntityInfo(), 688, null, 1);
			classInfo.StaticProperties.Insert("outerScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 816, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("innerScale", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 820, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("divideNum", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 824, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppLensFlareShapeCircle(ulong id) : base(id) { }
		public TppLensFlareShapeCircle() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "outerScale":
                    this.outerScale = value.GetValueAsFloat();
                    return;
                case "innerScale":
                    this.innerScale = value.GetValueAsFloat();
                    return;
                case "divideNum":
                    this.divideNum = value.GetValueAsUInt32();
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