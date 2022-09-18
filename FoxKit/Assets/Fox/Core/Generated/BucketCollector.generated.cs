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
    public partial class BucketCollector : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.Bucket>> buckets { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.Bucket>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Core.Bucket> mainBucket { get; set; } = new Fox.Core.EntityPtr<Fox.Core.Bucket>();
        
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
        static BucketCollector()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("BucketCollector"), typeof(BucketCollector), new Fox.Core.Entity().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("buckets"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Bucket), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mainBucket"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Bucket), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public BucketCollector(ulong id) : base(id) { }
		public BucketCollector() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "mainBucket":
                    this.mainBucket = value.GetValueAsEntityPtr<Fox.Core.Bucket>();
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
                case "buckets":
                    this.buckets.Insert(key, value.GetValueAsEntityPtr<Fox.Core.Bucket>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}