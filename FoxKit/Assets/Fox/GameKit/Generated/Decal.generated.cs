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
	public partial class Decal : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink material { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Decal_ProjectionMode projectionMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float nearClipScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Decal_ProjectionTarget projectionTarget { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float repeatU { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float repeatV { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float transparency { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Decal_PolygonDataSource polygonDataSource { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int renderingPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> targets { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Decal_DrawRejectionLevel drawRejectionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float drawRejectionDegree { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint decalFlags { get; set; }
		
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
		static Decal()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("Decal"), typeof(Decal), Fox.Core.TransformData.ClassInfo, 0, "Decal", 12);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("material"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("projectionMode"), Fox.Core.PropertyInfo.PropertyType.Int32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Decal_ProjectionMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("nearClipScale"), Fox.Core.PropertyInfo.PropertyType.Float, 348, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("projectionTarget"), Fox.Core.PropertyInfo.PropertyType.Int32, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Decal_ProjectionTarget), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("repeatU"), Fox.Core.PropertyInfo.PropertyType.Float, 356, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("repeatV"), Fox.Core.PropertyInfo.PropertyType.Float, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("transparency"), Fox.Core.PropertyInfo.PropertyType.Float, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("polygonDataSource"), Fox.Core.PropertyInfo.PropertyType.Int32, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Decal_PolygonDataSource), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("renderingPriority"), Fox.Core.PropertyInfo.PropertyType.Int32, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targets"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawRejectionLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Decal_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawRejectionDegree"), Fox.Core.PropertyInfo.PropertyType.Float, 380, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("decalFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDisableAlbedo"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPreserveAspect"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isWrap"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isVisibleGeom"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isSSDecal"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public Decal(ulong id) : base(id) { }
		public Decal() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
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
				case "renderingPriority":
					return new Fox.Core.Value(renderingPriority);
				case "targets":
					return new Fox.Core.Value(targets);
				case "drawRejectionLevel":
					return new Fox.Core.Value(drawRejectionLevel);
				case "drawRejectionDegree":
					return new Fox.Core.Value(drawRejectionDegree);
				case "decalFlags":
					return new Fox.Core.Value(decalFlags);
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

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "targets":
					return new Fox.Core.Value(this.targets[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "material":
					this.material = value.GetValueAsEntityLink();
					return;
				case "projectionMode":
					this.projectionMode = (Decal_ProjectionMode)value.GetValueAsInt32();
					return;
				case "nearClipScale":
					this.nearClipScale = value.GetValueAsFloat();
					return;
				case "projectionTarget":
					this.projectionTarget = (Decal_ProjectionTarget)value.GetValueAsInt32();
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
					this.polygonDataSource = (Decal_PolygonDataSource)value.GetValueAsInt32();
					return;
				case "renderingPriority":
					this.renderingPriority = value.GetValueAsInt32();
					return;
				case "drawRejectionLevel":
					this.drawRejectionLevel = (Decal_DrawRejectionLevel)value.GetValueAsInt32();
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

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "targets":
					while(this.targets.Count <= index) { this.targets.Add(default(Fox.Core.EntityLink)); }
					this.targets[index] = value.GetValueAsEntityLink();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}