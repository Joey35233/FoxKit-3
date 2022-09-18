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

namespace Fox.Anim
{
    [UnityEditor.InitializeOnLoad]
    public partial class FacialSettingData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>> aspectMaskList { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement> mouthMask { get; set; } = new Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement> lipMask { get; set; } = new Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String rootName { get; set; }
        
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
        static FacialSettingData()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("FacialSettingData"), typeof(FacialSettingData), new Fox.Core.Data().GetClassEntityInfo(), 104, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("aspectMaskList"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mouthMask"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lipMask"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rootName"), Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public FacialSettingData(ulong id) : base(id) { }
		public FacialSettingData() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "mouthMask":
                    this.mouthMask = value.GetValueAsEntityPtr<Fox.Anim.FacialMaskElement>();
                    return;
                case "lipMask":
                    this.lipMask = value.GetValueAsEntityPtr<Fox.Anim.FacialMaskElement>();
                    return;
                case "rootName":
                    this.rootName = value.GetValueAsString();
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
                case "aspectMaskList":
                    while(this.aspectMaskList.Count <= index) { this.aspectMaskList.Add(default(Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>)); }
                    this.aspectMaskList[index] = value.GetValueAsEntityPtr<Fox.Anim.FacialMaskElement>();
                    return;
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