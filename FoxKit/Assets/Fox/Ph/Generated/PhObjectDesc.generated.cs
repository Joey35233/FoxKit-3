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
    public partial class PhObjectDesc : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Entity>> bodies { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Entity>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>> constraints { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Ph.PhConstraintParam>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<int> bodyIndices { get; set; } = new Fox.Kernel.DynamicArray<int>();
        
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
        static PhObjectDesc()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhObjectDesc"), typeof(PhObjectDesc), new Fox.Core.Data().GetClassEntityInfo(), 112, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bodies"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.Entity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("constraints"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Ph.PhConstraintParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bodyIndices"), Fox.Core.PropertyInfo.PropertyType.Int32, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public PhObjectDesc(ulong id) : base(id) { }
		public PhObjectDesc() : base() { }
        
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