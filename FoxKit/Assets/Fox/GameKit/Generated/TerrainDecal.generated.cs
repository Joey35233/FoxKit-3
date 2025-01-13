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
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink material { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color gridColor { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float stepLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float width { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float transparency { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float textureRepeatU { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float textureRepeatV { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int renderingPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float edgeTransparencyLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float smoothEdgeLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isTargetBlockTerrain { get; set; }
		
		[field: UnityEngine.SerializeField]
		public TerrainDecal_DrawRejectionLevel drawRejectionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isDisableAlbedo { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool hasSerializedNodes { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<UnityEngine.Vector3> serializedGraphNodes { get; private set; } = new CsSystem.Collections.Generic.List<UnityEngine.Vector3>();
		
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
		static TerrainDecal()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TerrainDecal", typeof(TerrainDecal), Fox.Core.TransformData.ClassInfo, 384, "Terrain", 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("material", Fox.Core.PropertyInfo.PropertyType.EntityLink, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("gridColor", Fox.Core.PropertyInfo.PropertyType.Color, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("stepLength", Fox.Core.PropertyInfo.PropertyType.Float, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("width", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("transparency", Fox.Core.PropertyInfo.PropertyType.Float, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("textureRepeatU", Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("textureRepeatV", Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("renderingPriority", Fox.Core.PropertyInfo.PropertyType.Int32, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("edgeTransparencyLength", Fox.Core.PropertyInfo.PropertyType.Float, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("smoothEdgeLength", Fox.Core.PropertyInfo.PropertyType.Float, 404, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isTargetBlockTerrain", Fox.Core.PropertyInfo.PropertyType.Bool, 413, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TerrainDecal_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDisableAlbedo", Fox.Core.PropertyInfo.PropertyType.Bool, 412, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("hasSerializedNodes", Fox.Core.PropertyInfo.PropertyType.Bool, 414, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("serializedGraphNodes", Fox.Core.PropertyInfo.PropertyType.Vector3, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "material":
					return new Fox.Core.Value(material);
				case "gridColor":
					return new Fox.Core.Value(gridColor);
				case "color":
					return new Fox.Core.Value(color);
				case "stepLength":
					return new Fox.Core.Value(stepLength);
				case "width":
					return new Fox.Core.Value(width);
				case "transparency":
					return new Fox.Core.Value(transparency);
				case "textureRepeatU":
					return new Fox.Core.Value(textureRepeatU);
				case "textureRepeatV":
					return new Fox.Core.Value(textureRepeatV);
				case "renderingPriority":
					return new Fox.Core.Value(renderingPriority);
				case "edgeTransparencyLength":
					return new Fox.Core.Value(edgeTransparencyLength);
				case "smoothEdgeLength":
					return new Fox.Core.Value(smoothEdgeLength);
				case "isTargetBlockTerrain":
					return new Fox.Core.Value(isTargetBlockTerrain);
				case "drawRejectionLevel":
					return new Fox.Core.Value(drawRejectionLevel);
				case "isDisableAlbedo":
					return new Fox.Core.Value(isDisableAlbedo);
				case "hasSerializedNodes":
					return new Fox.Core.Value(hasSerializedNodes);
				case "serializedGraphNodes":
					return new Fox.Core.Value(serializedGraphNodes);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "serializedGraphNodes":
					return new Fox.Core.Value(this.serializedGraphNodes[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
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

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
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

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}