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

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class CheckpointContainer : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.GameKit.CheckpointUnit>> checkPointUnits { get; set; } = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.GameKit.CheckpointUnit>>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.DynamicArray<Fox.Core.String> passedCheckpoints { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.String latestCheckpointTag { get; set; }
        
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
        static CheckpointContainer()
        {
            classInfo = new Fox.EntityInfo("CheckpointContainer", typeof(CheckpointContainer), new Fox.Core.Entity().GetClassEntityInfo(), 0, "GameKit", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkPointUnits", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.GameKit.CheckpointUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("passedCheckpoints", Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("latestCheckpointTag", Fox.Core.PropertyInfo.PropertyType.String, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public CheckpointContainer(ulong id) : base(id) { }
		public CheckpointContainer() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "latestCheckpointTag":
                    this.latestCheckpointTag = value.GetValueAsString();
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
                case "passedCheckpoints":
                    while(this.passedCheckpoints.Count <= index) { this.passedCheckpoints.Add(default(Fox.Core.String)); }
                    this.passedCheckpoints[index] = value.GetValueAsString();
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
                case "checkPointUnits":
                    this.checkPointUnits.Insert(key, value.GetValueAsEntityPtr<Fox.GameKit.CheckpointUnit>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}