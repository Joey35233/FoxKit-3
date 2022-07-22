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

namespace Fox.Demox
{
    [UnityEditor.InitializeOnLoad]
    public partial class ProceduralDemoData : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.FilePtr> evfFiles { get; set; } = new Fox.Core.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.FilePtr> eventFiles { get; set; } = new Fox.Core.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public int priority { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.String demoId { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> stringParams { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.EntityLink> entityParams { get; set; } = new Fox.Core.StringMap<Fox.Core.EntityLink>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<Fox.Core.FilePtr> fileParams { get; set; } = new Fox.Core.StringMap<Fox.Core.FilePtr>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.StringMap<int> objectNum { get; set; } = new Fox.Core.StringMap<int>();
        
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
        static ProceduralDemoData()
        {
            classInfo = new Fox.EntityInfo("ProceduralDemoData", typeof(ProceduralDemoData), new Fox.Core.TransformData().GetClassEntityInfo(), 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("evfFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("eventFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 352, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("priority", Fox.Core.PropertyInfo.PropertyType.Int32, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("demoId", Fox.Core.PropertyInfo.PropertyType.String, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("stringParams", Fox.Core.PropertyInfo.PropertyType.String, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("entityParams", Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fileParams", Fox.Core.PropertyInfo.PropertyType.FilePtr, 480, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("objectNum", Fox.Core.PropertyInfo.PropertyType.Int32, 528, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public ProceduralDemoData(ulong id) : base(id) { }
		public ProceduralDemoData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "priority":
                    this.priority = value.GetValueAsInt32();
                    return;
                case "demoId":
                    this.demoId = value.GetValueAsString();
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
                case "stringParams":
                    while(this.stringParams.Count <= index) { this.stringParams.Add(default(Fox.Core.String)); }
                    this.stringParams[index] = value.GetValueAsString();
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
                case "evfFiles":
                    this.evfFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "eventFiles":
                    this.eventFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "entityParams":
                    this.entityParams.Insert(key, value.GetValueAsEntityLink());
                    return;
                case "fileParams":
                    this.fileParams.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "objectNum":
                    this.objectNum.Insert(key, value.GetValueAsInt32());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}