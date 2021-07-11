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
    public partial class GraphxSpatialGraphDataNode : Fox.Core.DataElement 
    {
        // Properties
        public UnityEngine.Vector3 position;
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityHandle> inlinks = new CsSystem.Collections.Generic.List<Fox.Core.EntityHandle>();
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityHandle> outlinks = new CsSystem.Collections.Generic.List<Fox.Core.EntityHandle>();
        
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
        static GraphxSpatialGraphDataNode()
        {
            classInfo = new Fox.EntityInfo("GraphxSpatialGraphDataNode", new Fox.Core.DataElement(0, 0, 0).GetClassEntityInfo(), 80, "Graphx", 0);
			
			classInfo.StaticProperties.Insert("position", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inlinks", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 80, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("outlinks", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 96, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public GraphxSpatialGraphDataNode(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "position":
                    this.position = value.GetValueAsVector3();
                    return;
                default:
				    
                    base.SetProperty(propertyName, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                case "inlinks":
                    while(this.inlinks.Count <= index) { this.inlinks.Add(default(Fox.Core.EntityHandle)); }
                    this.inlinks[index] = value.GetValueAsEntityHandle();
                    return;
                case "outlinks":
                    while(this.outlinks.Count <= index) { this.outlinks.Add(default(Fox.Core.EntityHandle)); }
                    this.outlinks[index] = value.GetValueAsEntityHandle();
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