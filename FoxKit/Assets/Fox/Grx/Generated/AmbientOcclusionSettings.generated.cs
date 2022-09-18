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

namespace Fox.Grx
{
    [UnityEditor.InitializeOnLoad]
    public partial class AmbientOcclusionSettings : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public AmbientOcclusionSettings_Method method { get; set; }
        
        [field: UnityEngine.SerializeField]
        public AmbientOcclusionSettings_LightAttachment attachment { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityPtr<Fox.Grx.GrxLineSSAOParameters> lineSSAOParameters { get; protected set; } = new Fox.Core.EntityPtr<Fox.Grx.GrxLineSSAOParameters>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityPtr<Fox.Grx.GrxAreaSSAOParameters> areaSSAOParameters { get; protected set; } = new Fox.Core.EntityPtr<Fox.Grx.GrxAreaSSAOParameters>();
        
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
        static AmbientOcclusionSettings()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("AmbientOcclusionSettings"), typeof(AmbientOcclusionSettings), new Fox.Core.Data().GetClassEntityInfo(), 88, "Config", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("method"), Fox.Core.PropertyInfo.PropertyType.Int32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(AmbientOcclusionSettings_Method), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attachment"), Fox.Core.PropertyInfo.PropertyType.Int32, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(AmbientOcclusionSettings_LightAttachment), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lineSSAOParameters"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Grx.GrxLineSSAOParameters), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("areaSSAOParameters"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Grx.GrxAreaSSAOParameters), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public AmbientOcclusionSettings(ulong id) : base(id) { }
		public AmbientOcclusionSettings() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "method":
                    this.method = (AmbientOcclusionSettings_Method)value.GetValueAsInt32();
                    return;
                case "attachment":
                    this.attachment = (AmbientOcclusionSettings_LightAttachment)value.GetValueAsInt32();
                    return;
                case "lineSSAOParameters":
                    this.lineSSAOParameters = value.GetValueAsEntityPtr<Fox.Grx.GrxLineSSAOParameters>();
                    return;
                case "areaSSAOParameters":
                    this.areaSSAOParameters = value.GetValueAsEntityPtr<Fox.Grx.GrxAreaSSAOParameters>();
                    return;
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}