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
    public partial class GraphxSpatialGraphData : Fox.Core.TransformData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>> nodes { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>> edges { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>>();
        
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
        static GraphxSpatialGraphData()
        {
            classInfo = new Fox.Core.EntityInfo("GraphxSpatialGraphData", typeof(GraphxSpatialGraphData), new Fox.Core.TransformData().GetClassEntityInfo(), 0, "Graphx", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nodes", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataNode), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("edges", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataEdge), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GraphxSpatialGraphData(ulong id) : base(id) { }
		public GraphxSpatialGraphData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "nodes":
                    while(this.nodes.Count <= index) { this.nodes.Add(default(Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>)); }
                    this.nodes[index] = value.GetValueAsEntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>();
                    return;
                case "edges":
                    while(this.edges.Count <= index) { this.edges.Add(default(Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>)); }
                    this.edges[index] = value.GetValueAsEntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>();
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