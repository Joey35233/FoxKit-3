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
    public partial class GeoxPathEdge : Fox.Graphx.GraphxSpatialGraphDataEdge 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.DynamicArray<Fox.Core.String> edgeTags { get; set; } = new Fox.Core.DynamicArray<Fox.Core.String>();
        
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
        static GeoxPathEdge()
        {
            classInfo = new Fox.EntityInfo("GeoxPathEdge", typeof(GeoxPathEdge), new Fox.Graphx.GraphxSpatialGraphDataEdge().GetClassEntityInfo(), 56, "Geox", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("edgeTags", Fox.Core.PropertyInfo.PropertyType.String, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public GeoxPathEdge(ulong id) : base(id) { }
		public GeoxPathEdge() : base() { }
        
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
                case "edgeTags":
                    while(this.edgeTags.Count <= index) { this.edgeTags.Add(default(Fox.Core.String)); }
                    this.edgeTags[index] = value.GetValueAsString();
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