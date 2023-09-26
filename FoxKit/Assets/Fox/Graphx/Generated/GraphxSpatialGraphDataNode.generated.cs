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

namespace Fox.Graphx
{
    [UnityEditor.InitializeOnLoad]
    public partial class GraphxSpatialGraphDataNode : Fox.Core.DataElement
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public UnityEngine.Vector3 position { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.Entity> inlinks { get; protected set; } = new Fox.Kernel.DynamicArray<Fox.Core.Entity>();

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.Entity> outlinks { get; protected set; } = new Fox.Kernel.DynamicArray<Fox.Core.Entity>();

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
        static GraphxSpatialGraphDataNode()
        {
            if (Fox.Core.DataElement.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GraphxSpatialGraphDataNode"), typeof(GraphxSpatialGraphDataNode), Fox.Core.DataElement.ClassInfo, 80, "Graphx", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("position"), Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("inlinks"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 80, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("outlinks"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 96, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public GraphxSpatialGraphDataNode(ulong id) : base(id) { }
		public GraphxSpatialGraphDataNode() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "position":
                    this.position = value.GetValueAsVector3();
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
                case "inlinks":
                    while(this.inlinks.Count <= index) { this.inlinks.Add(default(Fox.Core.Entity)); }
                    this.inlinks[index] = value.GetValueAsEntityHandle();
                    return;
                case "outlinks":
                    while(this.outlinks.Count <= index) { this.outlinks.Add(default(Fox.Core.Entity)); }
                    this.outlinks[index] = value.GetValueAsEntityHandle();
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