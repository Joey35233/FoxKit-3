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
    public partial class TransformData : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.EntityHandle parent;
        
        public Fox.Core.EntityPtr<Fox.Core.TransformEntity> transform;
        
        public Fox.Core.EntityPtr<Fox.Core.ShearTransformEntity> shearTransform;
        
        public Fox.Core.EntityPtr<Fox.Core.PivotTransformEntity> pivotTransform;
        
        public CsSystem.Collections.Generic.List<Fox.Core.EntityHandle> children = new CsSystem.Collections.Generic.List<Fox.Core.EntityHandle>();
        
        public TransformData_Flags flags;
        
        public bool inheritTransform;
        
        public bool visibility;
        
        public bool selection;
        
        public UnityEngine.Matrix4x4 worldMatrix;
        
        public UnityEngine.Matrix4x4 worldTransform;
        
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
        static TransformData()
        {
            classInfo = new Fox.EntityInfo("TransformData", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 0, null, 4);
			
			classInfo.StaticProperties.Insert("parent", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("transform", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.TransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("shearTransform", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.ShearTransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("pivotTransform", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Core.PivotTransformEntity), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("children", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityHandle, 152, 1, Fox.Core.PropertyInfo.ContainerType.List, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("flags", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, typeof(TransformData_Flags), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("inheritTransform", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("visibility", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("selection", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldMatrix", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Matrix4, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("worldTransform", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Matrix4, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public TransformData(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "parent":
                    this.parent = value.GetValueAsEntityHandle();
                    return;
                case "transform":
                    this.transform = value.GetValueAsEntityPtr<Fox.Core.TransformEntity>();
                    return;
                case "shearTransform":
                    this.shearTransform = value.GetValueAsEntityPtr<Fox.Core.ShearTransformEntity>();
                    return;
                case "pivotTransform":
                    this.pivotTransform = value.GetValueAsEntityPtr<Fox.Core.PivotTransformEntity>();
                    return;
                case "flags":
                    this.flags = (TransformData_Flags)value.GetValueAsUInt32();
                    return;
                case "inheritTransform":
                    this.inheritTransform = value.GetValueAsBool();
                    return;
                case "visibility":
                    this.visibility = value.GetValueAsBool();
                    return;
                case "selection":
                    this.selection = value.GetValueAsBool();
                    return;
                case "worldMatrix":
                    this.worldMatrix = value.GetValueAsMatrix4();
                    return;
                case "worldTransform":
                    this.worldTransform = value.GetValueAsMatrix4();
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
                case "children":
                    while(this.children.Count <= index) { this.children.Add(default(Fox.Core.EntityHandle)); }
                    this.children[index] = value.GetValueAsEntityHandle();
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