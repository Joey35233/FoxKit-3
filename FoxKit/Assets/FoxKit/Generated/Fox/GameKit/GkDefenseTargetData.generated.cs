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

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class GkDefenseTargetData : Fox.GameKit.GkTargetData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String name { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.String skeletonName { get; set; }
        
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
        static GkDefenseTargetData()
        {
            classInfo = new Fox.EntityInfo("GkDefenseTargetData", typeof(GkDefenseTargetData), new Fox.GameKit.GkTargetData().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("name", Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("skeletonName", Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GkDefenseTargetData(ulong id) : base(id) { }
		public GkDefenseTargetData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "name":
                    this.name = value.GetValueAsString();
                    return;
                case "skeletonName":
                    this.skeletonName = value.GetValueAsString();
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