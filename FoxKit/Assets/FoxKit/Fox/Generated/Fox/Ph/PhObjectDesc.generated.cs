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
    public partial class PhObjectDesc : Fox.Core.Data 
    {
        // Properties
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Core.Entity>> bodies = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>> constraints = new CsSystem.Collections.Generic.List<Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>>();
        
        public CsSystem.Collections.Generic.List<int> bodyIndices = new CsSystem.Collections.Generic.List<int>();
        
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
        static PhObjectDesc()
        {
            classInfo = new Fox.EntityInfo("PhObjectDesc", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 112, "Ph", 0);
			
			classInfo.StaticProperties.Insert("bodies", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("constraints", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Ph.PhConstraintParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("bodyIndices", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public PhObjectDesc(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
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
                case "bodies":
                    while(this.bodies.Count <= index) { this.bodies.Add(default(Fox.Core.EntityPtr<Fox.Core.Entity>)); }
                    this.bodies[index] = value.GetValueAsEntityPtr<Fox.Core.Entity>();
                    return;
                case "constraints":
                    while(this.constraints.Count <= index) { this.constraints.Add(default(Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>)); }
                    this.constraints[index] = value.GetValueAsEntityPtr<Fox.Ph.PhConstraintParam>();
                    return;
                case "bodyIndices":
                    while(this.bodyIndices.Count <= index) { this.bodyIndices.Add(default(int)); }
                    this.bodyIndices[index] = value.GetValueAsInt32();
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