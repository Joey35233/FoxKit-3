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
    public partial class TppVfxFileLoader : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> vfxFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> geoMaterialFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.StringMap<Fox.Core.FilePtr> otherFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
        
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
        static TppVfxFileLoader()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppVfxFileLoader"), typeof(TppVfxFileLoader), new Fox.Core.Data().GetClassEntityInfo(), 208, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("geoMaterialFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("otherFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 216, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public TppVfxFileLoader(ulong id) : base(id) { }
		public TppVfxFileLoader() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
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
                case "vfxFiles":
                    this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "geoMaterialFiles":
                    this.geoMaterialFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "otherFiles":
                    this.otherFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}