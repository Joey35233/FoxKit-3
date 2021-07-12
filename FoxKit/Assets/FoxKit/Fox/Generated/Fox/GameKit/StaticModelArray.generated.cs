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
    public partial class StaticModelArray : Fox.Core.Data 
    {
        // Properties
        public Fox.Core.FilePtr<Fox.Core.File> modelFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> geomFile;
        
        public bool isVisibleGeom;
        
        public float lodFarSize;
        
        public float lodNearSize;
        
        public float lodPolygonSize;
        
        public StaticModelArray_DrawRejectionLevel drawRejectionLevel;
        
        public StaticModelArray_DrawMode drawMode;
        
        public StaticModelArray_RejectFarRangeShadowCast rejectFarRangeShadowCast;
        
        public Fox.Core.EntityLink parentLocator;
        
        public Fox.Core.DynamicArray<UnityEngine.Matrix4x4> transforms = new Fox.Core.DynamicArray<UnityEngine.Matrix4x4>();
        
        public Fox.Core.DynamicArray<uint> colors = new Fox.Core.DynamicArray<uint>();
        
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
        static StaticModelArray()
        {
            classInfo = new Fox.EntityInfo("StaticModelArray", new Fox.Core.Data(0, 0, 0).GetClassEntityInfo(), 208, "Model", 4);
			
			classInfo.StaticProperties.Insert("modelFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("geomFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isVisibleGeom", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodFarSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodNearSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("lodPolygonSize", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("drawRejectionLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModelArray_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("drawMode", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModelArray_DrawMode), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("rejectFarRangeShadowCast", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModelArray_RejectFarRangeShadowCast), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("parentLocator", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("transforms", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Matrix4, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("colors", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructor
		public StaticModelArray(ulong address, ushort idA, ushort idB) : base(address, idA, idB) { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "modelFile":
                    this.modelFile = value.GetValueAsFilePtr();
                    return;
                case "geomFile":
                    this.geomFile = value.GetValueAsFilePtr();
                    return;
                case "isVisibleGeom":
                    this.isVisibleGeom = value.GetValueAsBool();
                    return;
                case "lodFarSize":
                    this.lodFarSize = value.GetValueAsFloat();
                    return;
                case "lodNearSize":
                    this.lodNearSize = value.GetValueAsFloat();
                    return;
                case "lodPolygonSize":
                    this.lodPolygonSize = value.GetValueAsFloat();
                    return;
                case "drawRejectionLevel":
                    this.drawRejectionLevel = (StaticModelArray_DrawRejectionLevel)value.GetValueAsInt32();
                    return;
                case "drawMode":
                    this.drawMode = (StaticModelArray_DrawMode)value.GetValueAsInt32();
                    return;
                case "rejectFarRangeShadowCast":
                    this.rejectFarRangeShadowCast = (StaticModelArray_RejectFarRangeShadowCast)value.GetValueAsInt32();
                    return;
                case "parentLocator":
                    this.parentLocator = value.GetValueAsEntityLink();
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
                case "transforms":
                    while(this.transforms.Count <= index) { this.transforms.Add(default(UnityEngine.Matrix4x4)); }
                    this.transforms[index] = value.GetValueAsMatrix4();
                    return;
                case "colors":
                    while(this.colors.Count <= index) { this.colors.Add(default(uint)); }
                    this.colors[index] = value.GetValueAsUInt32();
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