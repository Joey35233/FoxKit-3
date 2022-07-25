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

namespace Fox.Core
{
    [UnityEditor.InitializeOnLoad]
    public partial class DataSetReference : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.FoxKernel.Path referenceFilePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isReferenceLocked { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Core.DataSetDifference> dataSetDifference { get; set; } = new Fox.Core.EntityPtr<Fox.Core.DataSetDifference>();
        
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
        static DataSetReference()
        {
            classInfo = new Fox.EntityInfo("DataSetReference", typeof(DataSetReference), new Fox.Core.TransformData().GetClassEntityInfo(), 416, "Data", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("referenceFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isReferenceLocked", Fox.Core.PropertyInfo.PropertyType.Bool, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dataSetDifference", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataSetDifference), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public DataSetReference(ulong id) : base(id) { }
		public DataSetReference() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "referenceFilePath":
                    this.referenceFilePath = value.GetValueAsPath();
                    return;
                case "isReferenceLocked":
                    this.isReferenceLocked = value.GetValueAsBool();
                    return;
                case "dataSetDifference":
                    this.dataSetDifference = value.GetValueAsEntityPtr<Fox.Core.DataSetDifference>();
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