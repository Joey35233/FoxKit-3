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
    public partial class GraphxSpatialGraphData : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>> nodes = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataNode>>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>> edges = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Graphx.GraphxSpatialGraphDataEdge>>();
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static GraphxSpatialGraphData()
        {
            classInfo = new Fox.EntityInfo("GraphxSpatialGraphData", new Fox.Core.TransformData(0, 0, 0).GetClassEntityInfo(), 0, "Graphx", 0);
			
			classInfo.StaticProperties.Insert("nodes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataNode), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("edges", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Fox.Graphx.GraphxSpatialGraphDataEdge), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GraphxSpatialGraphData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
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
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
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