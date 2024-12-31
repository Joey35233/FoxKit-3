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
	public partial class DecalArray : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink material { get; set; }
		
		[field: UnityEngine.SerializeField]
		public DecalArray_ProjectionMode projectionMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float nearClipScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public DecalArray_ProjectionTarget projectionTarget { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float repeatU { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float repeatV { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float transparency { get; set; }
		
		[field: UnityEngine.SerializeField]
		public DecalArray_PolygonDataSource polygonDataSource { get; set; }
		
		[field: UnityEngine.SerializeField]
		public DecalArray_DrawRejectionLevel drawRejectionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float drawRejectionDegree { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint decalFlags { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UnityEngine.Vector3> scales { get; private set; } = new Fox.DynamicArray<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UnityEngine.Quaternion> rotations { get; private set; } = new Fox.DynamicArray<UnityEngine.Quaternion>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<UnityEngine.Vector3> translations { get; private set; } = new Fox.DynamicArray<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.EntityLink> targets { get; private set; } = new Fox.DynamicArray<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<uint> targetIndices { get; private set; } = new Fox.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<uint> targetStartIndices { get; private set; } = new Fox.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<int> renderingPriorities { get; private set; } = new Fox.DynamicArray<int>();
		
		public bool isDisableAlbedo { get => Get_isDisableAlbedo(); set { Set_isDisableAlbedo(value); } }
		private partial bool Get_isDisableAlbedo();
		private partial void Set_isDisableAlbedo(bool value);
		
		public bool isPreserveAspect { get => Get_isPreserveAspect(); set { Set_isPreserveAspect(value); } }
		private partial bool Get_isPreserveAspect();
		private partial void Set_isPreserveAspect(bool value);
		
		public bool isWrap { get => Get_isWrap(); set { Set_isWrap(value); } }
		private partial bool Get_isWrap();
		private partial void Set_isWrap(bool value);
		
		public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
		private partial bool Get_showObject();
		private partial void Set_showObject(bool value);
		
		public bool isVisibleGeom { get => Get_isVisibleGeom(); set { Set_isVisibleGeom(value); } }
		private partial bool Get_isVisibleGeom();
		private partial void Set_isVisibleGeom(bool value);
		
		public bool isSSDecal { get => Get_isSSDecal(); set { Set_isSSDecal(value); } }
		private partial bool Get_isSSDecal();
		private partial void Set_isSSDecal(bool value);
		
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
		static DecalArray()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("DecalArray", typeof(DecalArray), Fox.Core.TransformData.ClassInfo, 448, "Decal", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("material", Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("projectionMode", Fox.Core.PropertyInfo.PropertyType.Int32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nearClipScale", Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("projectionTarget", Fox.Core.PropertyInfo.PropertyType.Int32, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_ProjectionTarget), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("repeatU", Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("repeatV", Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("transparency", Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("polygonDataSource", Fox.Core.PropertyInfo.PropertyType.Int32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_PolygonDataSource), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionLevel", Fox.Core.PropertyInfo.PropertyType.Int32, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DecalArray_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("drawRejectionDegree", Fox.Core.PropertyInfo.PropertyType.Float, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("decalFlags", Fox.Core.PropertyInfo.PropertyType.UInt32, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scales", Fox.Core.PropertyInfo.PropertyType.Vector3, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("rotations", Fox.Core.PropertyInfo.PropertyType.Quat, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("translations", Fox.Core.PropertyInfo.PropertyType.Vector3, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targets", Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetIndices", Fox.Core.PropertyInfo.PropertyType.UInt32, 448, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("targetStartIndices", Fox.Core.PropertyInfo.PropertyType.UInt32, 464, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("renderingPriorities", Fox.Core.PropertyInfo.PropertyType.Int32, 480, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDisableAlbedo", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isPreserveAspect", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isWrap", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("showObject", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isVisibleGeom", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isSSDecal", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "material":
					return new Fox.Core.Value(material);
				case "projectionMode":
					return new Fox.Core.Value(projectionMode);
				case "nearClipScale":
					return new Fox.Core.Value(nearClipScale);
				case "projectionTarget":
					return new Fox.Core.Value(projectionTarget);
				case "repeatU":
					return new Fox.Core.Value(repeatU);
				case "repeatV":
					return new Fox.Core.Value(repeatV);
				case "transparency":
					return new Fox.Core.Value(transparency);
				case "polygonDataSource":
					return new Fox.Core.Value(polygonDataSource);
				case "drawRejectionLevel":
					return new Fox.Core.Value(drawRejectionLevel);
				case "drawRejectionDegree":
					return new Fox.Core.Value(drawRejectionDegree);
				case "decalFlags":
					return new Fox.Core.Value(decalFlags);
				case "scales":
					return new Fox.Core.Value(scales);
				case "rotations":
					return new Fox.Core.Value(rotations);
				case "translations":
					return new Fox.Core.Value(translations);
				case "targets":
					return new Fox.Core.Value(targets);
				case "targetIndices":
					return new Fox.Core.Value(targetIndices);
				case "targetStartIndices":
					return new Fox.Core.Value(targetStartIndices);
				case "renderingPriorities":
					return new Fox.Core.Value(renderingPriorities);
				case "isDisableAlbedo":
					return new Fox.Core.Value(isDisableAlbedo);
				case "isPreserveAspect":
					return new Fox.Core.Value(isPreserveAspect);
				case "isWrap":
					return new Fox.Core.Value(isWrap);
				case "showObject":
					return new Fox.Core.Value(showObject);
				case "isVisibleGeom":
					return new Fox.Core.Value(isVisibleGeom);
				case "isSSDecal":
					return new Fox.Core.Value(isSSDecal);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "scales":
					return new Fox.Core.Value(this.scales[index]);
				case "rotations":
					return new Fox.Core.Value(this.rotations[index]);
				case "translations":
					return new Fox.Core.Value(this.translations[index]);
				case "targets":
					return new Fox.Core.Value(this.targets[index]);
				case "targetIndices":
					return new Fox.Core.Value(this.targetIndices[index]);
				case "targetStartIndices":
					return new Fox.Core.Value(this.targetStartIndices[index]);
				case "renderingPriorities":
					return new Fox.Core.Value(this.renderingPriorities[index]);
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
				case "projectionMode":
					this.projectionMode = (DecalArray_ProjectionMode)value.GetValueAsInt32();
					return;
				case "nearClipScale":
					this.nearClipScale = value.GetValueAsFloat();
					return;
				case "projectionTarget":
					this.projectionTarget = (DecalArray_ProjectionTarget)value.GetValueAsInt32();
					return;
				case "repeatU":
					this.repeatU = value.GetValueAsFloat();
					return;
				case "repeatV":
					this.repeatV = value.GetValueAsFloat();
					return;
				case "transparency":
					this.transparency = value.GetValueAsFloat();
					return;
				case "polygonDataSource":
					this.polygonDataSource = (DecalArray_PolygonDataSource)value.GetValueAsInt32();
					return;
				case "drawRejectionLevel":
					this.drawRejectionLevel = (DecalArray_DrawRejectionLevel)value.GetValueAsInt32();
					return;
				case "drawRejectionDegree":
					this.drawRejectionDegree = value.GetValueAsFloat();
					return;
				case "decalFlags":
					this.decalFlags = value.GetValueAsUInt32();
					return;
				case "isDisableAlbedo":
					this.isDisableAlbedo = value.GetValueAsBool();
					return;
				case "isPreserveAspect":
					this.isPreserveAspect = value.GetValueAsBool();
					return;
				case "isWrap":
					this.isWrap = value.GetValueAsBool();
					return;
				case "showObject":
					this.showObject = value.GetValueAsBool();
					return;
				case "isVisibleGeom":
					this.isVisibleGeom = value.GetValueAsBool();
					return;
				case "isSSDecal":
					this.isSSDecal = value.GetValueAsBool();
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
				case "scales":
					while(this.scales.Count <= index) { this.scales.Add(default(UnityEngine.Vector3)); }
					this.scales[index] = value.GetValueAsVector3();
					return;
				case "rotations":
					while(this.rotations.Count <= index) { this.rotations.Add(default(UnityEngine.Quaternion)); }
					this.rotations[index] = value.GetValueAsQuat();
					return;
				case "translations":
					while(this.translations.Count <= index) { this.translations.Add(default(UnityEngine.Vector3)); }
					this.translations[index] = value.GetValueAsVector3();
					return;
				case "targets":
					while(this.targets.Count <= index) { this.targets.Add(default(Fox.Core.EntityLink)); }
					this.targets[index] = value.GetValueAsEntityLink();
					return;
				case "targetIndices":
					while(this.targetIndices.Count <= index) { this.targetIndices.Add(default(uint)); }
					this.targetIndices[index] = value.GetValueAsUInt32();
					return;
				case "targetStartIndices":
					while(this.targetStartIndices.Count <= index) { this.targetStartIndices.Add(default(uint)); }
					this.targetStartIndices[index] = value.GetValueAsUInt32();
					return;
				case "renderingPriorities":
					while(this.renderingPriorities.Count <= index) { this.renderingPriorities.Add(default(int)); }
					this.renderingPriorities[index] = value.GetValueAsInt32();
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