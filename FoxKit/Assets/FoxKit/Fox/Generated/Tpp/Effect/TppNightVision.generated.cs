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
    public partial class TppNightVision : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.EntityPtr<Tpp.Effect.TppNightVisionParam> param = new Fox.Core.EntityPtr<Tpp.Effect.TppNightVisionParam>();
        
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
        static TppNightVision()
        {
            classInfo = new Fox.EntityInfo("TppNightVision", typeof(TppNightVision), new Fox.Core.Data().GetClassEntityInfo(), 72, "TppEffect", 0);
			classInfo.StaticProperties.Insert("param", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Tpp.Effect.TppNightVisionParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TppNightVision(ulong address, ulong id) : base(address, id) { }
		public TppNightVision() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "param":
                    this.param = value.GetValueAsEntityPtr<Tpp.Effect.TppNightVisionParam>();
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