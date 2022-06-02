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
    public partial class FacialSettingData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>> aspectMaskList = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>>();
        
        public Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement> mouthMask = new Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>();
        
        public Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement> lipMask = new Fox.Core.EntityPtr<Fox.Anim.FacialMaskElement>();
        
        public Fox.String rootName;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static FacialSettingData()
        {
            classInfo = new Fox.EntityInfo("FacialSettingData", new Fox.Core.Data().GetClassEntityInfo(), 104, null, 2);
			
			classInfo.StaticProperties.Insert("aspectMaskList", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mouthMask", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lipMask", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.FacialMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rootName", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public FacialSettingData(ulong address, ulong id) : base(address, id) { }
		public FacialSettingData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
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