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

namespace Fox.Geox
{
    [UnityEditor.InitializeOnLoad]
    public partial class GeoxPartsTargetObject : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public PrimType primType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public AxisSort axisSortFlag { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected ulong systemAttribute { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint through { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isValid { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String categoryTag { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> groupTags { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink applicationDataLink { get; set; }
        
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
        static GeoxPartsTargetObject()
        {
            classInfo = new Fox.EntityInfo("GeoxPartsTargetObject", typeof(GeoxPartsTargetObject), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Target", 2);
			classInfo.StaticProperties.Insert("primType", new Fox.Core.PropertyInfo("primType", Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PrimType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("axisSortFlag", new Fox.Core.PropertyInfo("axisSortFlag", Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(AxisSort), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("systemAttribute", new Fox.Core.PropertyInfo("systemAttribute", Fox.Core.PropertyInfo.PropertyType.UInt64, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("through", new Fox.Core.PropertyInfo("through", Fox.Core.PropertyInfo.PropertyType.UInt32, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isValid", new Fox.Core.PropertyInfo("isValid", Fox.Core.PropertyInfo.PropertyType.Bool, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("categoryTag", new Fox.Core.PropertyInfo("categoryTag", Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("groupTags", new Fox.Core.PropertyInfo("groupTags", Fox.Core.PropertyInfo.PropertyType.String, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("applicationDataLink", new Fox.Core.PropertyInfo("applicationDataLink", Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public GeoxPartsTargetObject(ulong id) : base(id) { }
		public GeoxPartsTargetObject() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "primType":
                    this.primType = (PrimType)value.GetValueAsInt32();
                    return;
                case "axisSortFlag":
                    this.axisSortFlag = (AxisSort)value.GetValueAsInt32();
                    return;
                case "systemAttribute":
                    this.systemAttribute = value.GetValueAsUInt64();
                    return;
                case "through":
                    this.through = value.GetValueAsUInt32();
                    return;
                case "isValid":
                    this.isValid = value.GetValueAsBool();
                    return;
                case "categoryTag":
                    this.categoryTag = value.GetValueAsString();
                    return;
                case "applicationDataLink":
                    this.applicationDataLink = value.GetValueAsEntityLink();
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
                case "groupTags":
                    while(this.groupTags.Count <= index) { this.groupTags.Add(default(Fox.Core.String)); }
                    this.groupTags[index] = value.GetValueAsString();
                    return;
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