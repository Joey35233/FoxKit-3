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
    public partial class Bucket : Fox.Core.Entity
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.Entity collector { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String name { get; protected set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String sceneName { get; protected set; }

        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Actor>> actors { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Core.Actor>>();

        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Core.FilePtr> dataSetFiles { get; set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();

        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.DataBodySet>> dataBodySets { get; set; } = new Fox.Kernel.StringMap<Fox.Core.EntityPtr<Fox.Core.DataBodySet>>();

        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Core.DataSet> editableDataSet { get; set; } = new Fox.Core.EntityPtr<Fox.Core.DataSet>();

        [field: UnityEngine.SerializeField]
        protected Fox.Kernel.Path editableDataSetPath { get; set; }

        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Core.DataBodySet> editableDataBodySet { get; set; } = new Fox.Core.EntityPtr<Fox.Core.DataBodySet>();

        [field: UnityEngine.SerializeField]
        protected bool editableDataSetChanged { get; set; }

        public bool isEditableLocked { get => Get_isEditableLocked(); set { Set_isEditableLocked(value); } }
        protected partial bool Get_isEditableLocked();
        protected partial void Set_isEditableLocked(bool value);

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
        static Bucket()
        {
            if (Fox.Core.Entity.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("Bucket"), typeof(Bucket), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("collector"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("name"), Fox.Core.PropertyInfo.PropertyType.String, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sceneName"), Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("actors"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 88, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.Actor), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dataSetFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dataBodySets"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("editableDataSet"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataSet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("editableDataSetPath"), Fox.Core.PropertyInfo.PropertyType.Path, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("editableDataBodySet"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.DataBodySet), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("editableDataSetChanged"), Fox.Core.PropertyInfo.PropertyType.Bool, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isEditableLocked"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

            ClassInfoInitialized = true;
        }

        // Constructors
		public Bucket(ulong id) : base(id) { }
		public Bucket() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "collector":
                    this.collector = value.GetValueAsEntityHandle();
                    return;
                case "name":
                    this.name = value.GetValueAsString();
                    return;
                case "sceneName":
                    this.sceneName = value.GetValueAsString();
                    return;
                case "editableDataSet":
                    this.editableDataSet = value.GetValueAsEntityPtr<Fox.Core.DataSet>();
                    return;
                case "editableDataSetPath":
                    this.editableDataSetPath = value.GetValueAsPath();
                    return;
                case "editableDataBodySet":
                    this.editableDataBodySet = value.GetValueAsEntityPtr<Fox.Core.DataBodySet>();
                    return;
                case "editableDataSetChanged":
                    this.editableDataSetChanged = value.GetValueAsBool();
                    return;
                case "isEditableLocked":
                    this.isEditableLocked = value.GetValueAsBool();
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
                case "actors":
                    while(this.actors.Count <= index) { this.actors.Add(default(Fox.Core.EntityPtr<Fox.Core.Actor>)); }
                    this.actors[index] = value.GetValueAsEntityPtr<Fox.Core.Actor>();
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
                case "dataSetFiles":
                    this.dataSetFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "dataBodySets":
                    this.dataBodySets.Insert(key, value.GetValueAsEntityPtr<Fox.Core.DataBodySet>());
                    return;
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}