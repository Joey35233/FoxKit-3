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
    public partial class TerrainDecal : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.EntityLink material;
        
        public UnityEngine.Color gridColor;
        
        public UnityEngine.Color color;
        
        public float stepLength;
        
        public float width;
        
        public float transparency;
        
        public float textureRepeatU;
        
        public float textureRepeatV;
        
        public int renderingPriority;
        
        public float edgeTransparencyLength;
        
        public float smoothEdgeLength;
        
        public bool isTargetBlockTerrain;
        
        public TerrainDecal_DrawRejectionLevel drawRejectionLevel;
        
        public bool isDisableAlbedo;
        
        public bool hasSerializedNodes;
        
        public Fox.Core.DynamicArray<UnityEngine.Vector3> serializedGraphNodes = new Fox.Core.DynamicArray<UnityEngine.Vector3>();
        
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
        static TerrainDecal()
        {
            classInfo = new Fox.EntityInfo("TerrainDecal", typeof(TerrainDecal), new Fox.Core.TransformData().GetClassEntityInfo(), 384, "Terrain", 9);
			classInfo.StaticProperties.Insert("material", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("gridColor", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("color", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Color, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stepLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("width", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("transparency", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("textureRepeatU", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("textureRepeatV", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("renderingPriority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("edgeTransparencyLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("smoothEdgeLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 404, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isTargetBlockTerrain", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 413, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("drawRejectionLevel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TerrainDecal_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isDisableAlbedo", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 412, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("hasSerializedNodes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 414, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("serializedGraphNodes", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public TerrainDecal(ulong address, ulong id) : base(address, id) { }
		public TerrainDecal() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "material":
                    this.material = value.GetValueAsEntityLink();
                    return;
                case "gridColor":
                    this.gridColor = value.GetValueAsColor();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "stepLength":
                    this.stepLength = value.GetValueAsFloat();
                    return;
                case "width":
                    this.width = value.GetValueAsFloat();
                    return;
                case "transparency":
                    this.transparency = value.GetValueAsFloat();
                    return;
                case "textureRepeatU":
                    this.textureRepeatU = value.GetValueAsFloat();
                    return;
                case "textureRepeatV":
                    this.textureRepeatV = value.GetValueAsFloat();
                    return;
                case "renderingPriority":
                    this.renderingPriority = value.GetValueAsInt32();
                    return;
                case "edgeTransparencyLength":
                    this.edgeTransparencyLength = value.GetValueAsFloat();
                    return;
                case "smoothEdgeLength":
                    this.smoothEdgeLength = value.GetValueAsFloat();
                    return;
                case "isTargetBlockTerrain":
                    this.isTargetBlockTerrain = value.GetValueAsBool();
                    return;
                case "drawRejectionLevel":
                    this.drawRejectionLevel = (TerrainDecal_DrawRejectionLevel)value.GetValueAsInt32();
                    return;
                case "isDisableAlbedo":
                    this.isDisableAlbedo = value.GetValueAsBool();
                    return;
                case "hasSerializedNodes":
                    this.hasSerializedNodes = value.GetValueAsBool();
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
                case "serializedGraphNodes":
                    while(this.serializedGraphNodes.Count <= index) { this.serializedGraphNodes.Add(default(UnityEngine.Vector3)); }
                    this.serializedGraphNodes[index] = value.GetValueAsVector3();
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