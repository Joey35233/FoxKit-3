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

namespace Fox.Ui
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiNodeDataBody : Fox.Core.DataBody 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityHandle> inputEdges { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityHandle>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityHandle> outputEdges { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityHandle>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.Path uigName { get; set; }
        
        // ClassInfos
        public static new bool ClassInfoInitialized = false;
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
        static UiNodeDataBody()
        {
            if (Fox.Core.DataBody.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UiNodeDataBody"), typeof(UiNodeDataBody), Fox.Core.DataBody.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("inputEdges"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("outputEdges"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 104, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("uigName"), Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public UiNodeDataBody(ulong id) : base(id) { }
		public UiNodeDataBody() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "uigName":
                    this.uigName = value.GetValueAsPath();
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
                case "inputEdges":
                    while(this.inputEdges.Count <= index) { this.inputEdges.Add(default(Fox.Core.EntityHandle)); }
                    this.inputEdges[index] = value.GetValueAsEntityHandle();
                    return;
                case "outputEdges":
                    while(this.outputEdges.Count <= index) { this.outputEdges.Add(default(Fox.Core.EntityHandle)); }
                    this.outputEdges[index] = value.GetValueAsEntityHandle();
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