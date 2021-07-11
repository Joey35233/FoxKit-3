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
    public partial class FacialMaskElement : Fox.Core.DataElement 
    {
        // Properties
        public CsSystem.Collections.Generic.List<string> skelList = new CsSystem.Collections.Generic.List<string>();
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Anim.ParameterMaskElement>> shaderList = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Anim.ParameterMaskElement>>();
        
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
        static FacialMaskElement()
        {
            classInfo = new Fox.EntityInfo("FacialMaskElement", new Fox.Core.DataElement(0, 0, 0).GetClassEntityInfo(), 64, null, 1);
			
			classInfo.StaticProperties.Insert("skelList", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shaderList", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Anim.ParameterMaskElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public FacialMaskElement(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "skelList":
                    while(this.skelList.Count <= index) { this.skelList.Add(default(string)); }
                    this.skelList[index] = value.GetValueAsString();
                    return;
                case "shaderList":
                    while(this.shaderList.Count <= index) { this.shaderList.Add(default(Fox.Core.EntityPtr<Fox.Anim.ParameterMaskElement>)); }
                    this.shaderList[index] = value.GetValueAsEntityPtr<Fox.Anim.ParameterMaskElement>();
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