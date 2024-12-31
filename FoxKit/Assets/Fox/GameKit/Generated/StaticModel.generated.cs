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
	public partial class StaticModel : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr modelFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr geomFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isVisibleGeom { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isIsolated { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lodFarSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lodNearSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lodPolygonSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public StaticModel_DrawRejectionLevel drawRejectionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public StaticModel_DrawMode drawMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public StaticModel_RejectFarRangeShadowCast rejectFarRangeShadowCast { get; set; }
		
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
		static StaticModel()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("StaticModel", typeof(StaticModel), Fox.Core.TransformData.ClassInfo, 352, "Model", 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("geomFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isVisibleGeom", Fox.Core.PropertyInfo.PropertyType.Bool, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isIsolated", Fox.Core.PropertyInfo.PropertyType.Bool, 353, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodFarSize", Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodNearSize", Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodPolygonSize", Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("color", Fox.Core.PropertyInfo.PropertyType.Color, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModel_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawMode", Fox.Core.PropertyInfo.PropertyType.Int32, 388, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModel_DrawMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rejectFarRangeShadowCast", Fox.Core.PropertyInfo.PropertyType.Int32, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(StaticModel_RejectFarRangeShadowCast), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "modelFile":
					return new Fox.Core.Value(modelFile);
				case "geomFile":
					return new Fox.Core.Value(geomFile);
				case "isVisibleGeom":
					return new Fox.Core.Value(isVisibleGeom);
				case "isIsolated":
					return new Fox.Core.Value(isIsolated);
				case "lodFarSize":
					return new Fox.Core.Value(lodFarSize);
				case "lodNearSize":
					return new Fox.Core.Value(lodNearSize);
				case "lodPolygonSize":
					return new Fox.Core.Value(lodPolygonSize);
				case "color":
					return new Fox.Core.Value(color);
				case "drawRejectionLevel":
					return new Fox.Core.Value(drawRejectionLevel);
				case "drawMode":
					return new Fox.Core.Value(drawMode);
				case "rejectFarRangeShadowCast":
					return new Fox.Core.Value(rejectFarRangeShadowCast);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
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
				case "modelFile":
					this.modelFile = value.GetValueAsFilePtr();
					return;
				case "geomFile":
					this.geomFile = value.GetValueAsFilePtr();
					return;
				case "isVisibleGeom":
					this.isVisibleGeom = value.GetValueAsBool();
					return;
				case "isIsolated":
					this.isIsolated = value.GetValueAsBool();
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
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "drawRejectionLevel":
					this.drawRejectionLevel = (StaticModel_DrawRejectionLevel)value.GetValueAsInt32();
					return;
				case "drawMode":
					this.drawMode = (StaticModel_DrawMode)value.GetValueAsInt32();
					return;
				case "rejectFarRangeShadowCast":
					this.rejectFarRangeShadowCast = (StaticModel_RejectFarRangeShadowCast)value.GetValueAsInt32();
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