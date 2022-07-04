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

namespace Fox.Ph
{
    [UnityEditor.InitializeOnLoad]
    public partial class PhDaemon : Fox.Core.Entity 
    {
        // Properties
        public Fox.Core.EntityPtr<Fox.Ph.PhMaterialManager> materialManager = new Fox.Core.EntityPtr<Fox.Ph.PhMaterialManager>();
        
        public float defaultFriction;
        
        public float defaultRestitution;
        
        public bool isParallel;
        
        public bool isUseSmallJob;
        
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
        static PhDaemon()
        {
            classInfo = new Fox.EntityInfo("PhDaemon", typeof(PhDaemon), new Fox.Core.Entity().GetClassEntityInfo(), 0, "Ph", 0);
			classInfo.StaticProperties.Insert("materialManager", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Ph.PhMaterialManager), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultFriction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultRestitution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isParallel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isUseSmallJob", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 209, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public PhDaemon(ulong address, ulong id) : base(address, id) { }
		public PhDaemon() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "materialManager":
                    this.materialManager = value.GetValueAsEntityPtr<Fox.Ph.PhMaterialManager>();
                    return;
                case "defaultFriction":
                    this.defaultFriction = value.GetValueAsFloat();
                    return;
                case "defaultRestitution":
                    this.defaultRestitution = value.GetValueAsFloat();
                    return;
                case "isParallel":
                    this.isParallel = value.GetValueAsBool();
                    return;
                case "isUseSmallJob":
                    this.isUseSmallJob = value.GetValueAsBool();
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