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

namespace Fox.PartsBuilder
{
    [UnityEditor.InitializeOnLoad]
    public partial class FoxOffsetModelDescription : Fox.PartsBuilder.ModelDescription 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 offsetTranslation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UnityEngine.Quaternion offsetRotQuat { get; set; }
        
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
        static FoxOffsetModelDescription()
        {
            classInfo = new Fox.EntityInfo("FoxOffsetModelDescription", typeof(FoxOffsetModelDescription), new Fox.PartsBuilder.ModelDescription().GetClassEntityInfo(), 0, "PartsBuilder", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetTranslation", Fox.Core.PropertyInfo.PropertyType.Vector3, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("offsetRotQuat", Fox.Core.PropertyInfo.PropertyType.Quat, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public FoxOffsetModelDescription(ulong id) : base(id) { }
		public FoxOffsetModelDescription() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "offsetTranslation":
                    this.offsetTranslation = value.GetValueAsVector3();
                    return;
                case "offsetRotQuat":
                    this.offsetRotQuat = value.GetValueAsQuat();
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