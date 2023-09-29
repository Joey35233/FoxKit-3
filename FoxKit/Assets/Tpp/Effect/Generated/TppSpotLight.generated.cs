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

namespace Tpp.Effect
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppSpotLight : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 reachPoint { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<uint> BynaryData { get; set; } = new Fox.Kernel.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink lightArea { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink irradiationPoint { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink lookAtPoint { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float outerRange { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float innerRange { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float temperature { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float colorDeflection { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lumen { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lightSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float umbraAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float penumbraAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float attenuationExponent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shadowUmbraAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shadowPenumbraAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shadowAttenuationExponent { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float dimmer { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shadowBias { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float viewBias { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float powerScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodFarSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodNearSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodShadowDrawRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint lightFlags { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int lodRadiusLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte lodFadeType { get; set; }
		
		public bool enable { get => Get_enable(); set { Set_enable(value); } }
		private partial bool Get_enable();
		private partial void Set_enable(bool value);
		
		public TppSpotLight_PackingGeneration packingGeneration { get => Get_packingGeneration(); set { Set_packingGeneration(value); } }
		private partial TppSpotLight_PackingGeneration Get_packingGeneration();
		private partial void Set_packingGeneration(TppSpotLight_PackingGeneration value);
		
		public bool castShadow { get => Get_castShadow(); set { Set_castShadow(value); } }
		private partial bool Get_castShadow();
		private partial void Set_castShadow(bool value);
		
		public bool isBounced { get => Get_isBounced(); set { Set_isBounced(value); } }
		private partial bool Get_isBounced();
		private partial void Set_isBounced(bool value);
		
		public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
		private partial bool Get_showObject();
		private partial void Set_showObject(bool value);
		
		public bool showRange { get => Get_showRange(); set { Set_showRange(value); } }
		private partial bool Get_showRange();
		private partial void Set_showRange(bool value);
		
		public bool isDebugLightVolumeBound { get => Get_isDebugLightVolumeBound(); set { Set_isDebugLightVolumeBound(value); } }
		private partial bool Get_isDebugLightVolumeBound();
		private partial void Set_isDebugLightVolumeBound(bool value);
		
		public bool useAutoDimmer { get => Get_useAutoDimmer(); set { Set_useAutoDimmer(value); } }
		private partial bool Get_useAutoDimmer();
		private partial void Set_useAutoDimmer(bool value);
		
		public bool hasSpecular { get => Get_hasSpecular(); set { Set_hasSpecular(value); } }
		private partial bool Get_hasSpecular();
		private partial void Set_hasSpecular(bool value);
		
		public Fox.Kernel.Path importFilePath { get => Get_importFilePath(); set { Set_importFilePath(value); } }
		private partial Fox.Kernel.Path Get_importFilePath();
		private partial void Set_importFilePath(Fox.Kernel.Path value);
		
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
		static TppSpotLight()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppSpotLight"), typeof(TppSpotLight), Fox.Core.TransformData.ClassInfo, 496, "Light", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("reachPoint"), Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("BynaryData"), Fox.Core.PropertyInfo.PropertyType.UInt32, 336, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightArea"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("irradiationPoint"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lookAtPoint"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("outerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 472, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("innerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 476, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("temperature"), Fox.Core.PropertyInfo.PropertyType.Float, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("colorDeflection"), Fox.Core.PropertyInfo.PropertyType.Float, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lumen"), Fox.Core.PropertyInfo.PropertyType.Float, 488, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightSize"), Fox.Core.PropertyInfo.PropertyType.Float, 492, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("umbraAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 496, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("penumbraAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 500, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attenuationExponent"), Fox.Core.PropertyInfo.PropertyType.Float, 504, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowUmbraAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 508, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowPenumbraAngle"), Fox.Core.PropertyInfo.PropertyType.Float, 512, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowAttenuationExponent"), Fox.Core.PropertyInfo.PropertyType.Float, 516, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dimmer"), Fox.Core.PropertyInfo.PropertyType.Float, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowBias"), Fox.Core.PropertyInfo.PropertyType.Float, 524, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("viewBias"), Fox.Core.PropertyInfo.PropertyType.Float, 528, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("powerScale"), Fox.Core.PropertyInfo.PropertyType.Float, 532, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodFarSize"), Fox.Core.PropertyInfo.PropertyType.Float, 536, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodNearSize"), Fox.Core.PropertyInfo.PropertyType.Float, 540, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodShadowDrawRate"), Fox.Core.PropertyInfo.PropertyType.Float, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 548, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodRadiusLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 552, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodFadeType"), Fox.Core.PropertyInfo.PropertyType.UInt8, 556, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packingGeneration"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppSpotLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("castShadow"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBounced"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showRange"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDebugLightVolumeBound"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("useAutoDimmer"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hasSpecular"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("importFilePath"), Fox.Core.PropertyInfo.PropertyType.Path, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppSpotLight(ulong id) : base(id) { }
		public TppSpotLight() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "color":
					return new Fox.Core.Value(color);
				case "reachPoint":
					return new Fox.Core.Value(reachPoint);
				case "BynaryData":
					return new Fox.Core.Value(BynaryData);
				case "lightArea":
					return new Fox.Core.Value(lightArea);
				case "irradiationPoint":
					return new Fox.Core.Value(irradiationPoint);
				case "lookAtPoint":
					return new Fox.Core.Value(lookAtPoint);
				case "outerRange":
					return new Fox.Core.Value(outerRange);
				case "innerRange":
					return new Fox.Core.Value(innerRange);
				case "temperature":
					return new Fox.Core.Value(temperature);
				case "colorDeflection":
					return new Fox.Core.Value(colorDeflection);
				case "lumen":
					return new Fox.Core.Value(lumen);
				case "lightSize":
					return new Fox.Core.Value(lightSize);
				case "umbraAngle":
					return new Fox.Core.Value(umbraAngle);
				case "penumbraAngle":
					return new Fox.Core.Value(penumbraAngle);
				case "attenuationExponent":
					return new Fox.Core.Value(attenuationExponent);
				case "shadowUmbraAngle":
					return new Fox.Core.Value(shadowUmbraAngle);
				case "shadowPenumbraAngle":
					return new Fox.Core.Value(shadowPenumbraAngle);
				case "shadowAttenuationExponent":
					return new Fox.Core.Value(shadowAttenuationExponent);
				case "dimmer":
					return new Fox.Core.Value(dimmer);
				case "shadowBias":
					return new Fox.Core.Value(shadowBias);
				case "viewBias":
					return new Fox.Core.Value(viewBias);
				case "powerScale":
					return new Fox.Core.Value(powerScale);
				case "LodFarSize":
					return new Fox.Core.Value(LodFarSize);
				case "LodNearSize":
					return new Fox.Core.Value(LodNearSize);
				case "LodShadowDrawRate":
					return new Fox.Core.Value(LodShadowDrawRate);
				case "lightFlags":
					return new Fox.Core.Value(lightFlags);
				case "lodRadiusLevel":
					return new Fox.Core.Value(lodRadiusLevel);
				case "lodFadeType":
					return new Fox.Core.Value(lodFadeType);
				case "enable":
					return new Fox.Core.Value(enable);
				case "packingGeneration":
					return new Fox.Core.Value(packingGeneration);
				case "castShadow":
					return new Fox.Core.Value(castShadow);
				case "isBounced":
					return new Fox.Core.Value(isBounced);
				case "showObject":
					return new Fox.Core.Value(showObject);
				case "showRange":
					return new Fox.Core.Value(showRange);
				case "isDebugLightVolumeBound":
					return new Fox.Core.Value(isDebugLightVolumeBound);
				case "useAutoDimmer":
					return new Fox.Core.Value(useAutoDimmer);
				case "hasSpecular":
					return new Fox.Core.Value(hasSpecular);
				case "importFilePath":
					return new Fox.Core.Value(importFilePath);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "BynaryData":
					return new Fox.Core.Value(this.BynaryData[index]);
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
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "reachPoint":
					this.reachPoint = value.GetValueAsVector3();
					return;
				case "lightArea":
					this.lightArea = value.GetValueAsEntityLink();
					return;
				case "irradiationPoint":
					this.irradiationPoint = value.GetValueAsEntityLink();
					return;
				case "lookAtPoint":
					this.lookAtPoint = value.GetValueAsEntityLink();
					return;
				case "outerRange":
					this.outerRange = value.GetValueAsFloat();
					return;
				case "innerRange":
					this.innerRange = value.GetValueAsFloat();
					return;
				case "temperature":
					this.temperature = value.GetValueAsFloat();
					return;
				case "colorDeflection":
					this.colorDeflection = value.GetValueAsFloat();
					return;
				case "lumen":
					this.lumen = value.GetValueAsFloat();
					return;
				case "lightSize":
					this.lightSize = value.GetValueAsFloat();
					return;
				case "umbraAngle":
					this.umbraAngle = value.GetValueAsFloat();
					return;
				case "penumbraAngle":
					this.penumbraAngle = value.GetValueAsFloat();
					return;
				case "attenuationExponent":
					this.attenuationExponent = value.GetValueAsFloat();
					return;
				case "shadowUmbraAngle":
					this.shadowUmbraAngle = value.GetValueAsFloat();
					return;
				case "shadowPenumbraAngle":
					this.shadowPenumbraAngle = value.GetValueAsFloat();
					return;
				case "shadowAttenuationExponent":
					this.shadowAttenuationExponent = value.GetValueAsFloat();
					return;
				case "dimmer":
					this.dimmer = value.GetValueAsFloat();
					return;
				case "shadowBias":
					this.shadowBias = value.GetValueAsFloat();
					return;
				case "viewBias":
					this.viewBias = value.GetValueAsFloat();
					return;
				case "powerScale":
					this.powerScale = value.GetValueAsFloat();
					return;
				case "LodFarSize":
					this.LodFarSize = value.GetValueAsFloat();
					return;
				case "LodNearSize":
					this.LodNearSize = value.GetValueAsFloat();
					return;
				case "LodShadowDrawRate":
					this.LodShadowDrawRate = value.GetValueAsFloat();
					return;
				case "lightFlags":
					this.lightFlags = value.GetValueAsUInt32();
					return;
				case "lodRadiusLevel":
					this.lodRadiusLevel = value.GetValueAsInt32();
					return;
				case "lodFadeType":
					this.lodFadeType = value.GetValueAsUInt8();
					return;
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "packingGeneration":
					this.packingGeneration = (TppSpotLight_PackingGeneration)value.GetValueAsInt32();
					return;
				case "castShadow":
					this.castShadow = value.GetValueAsBool();
					return;
				case "isBounced":
					this.isBounced = value.GetValueAsBool();
					return;
				case "showObject":
					this.showObject = value.GetValueAsBool();
					return;
				case "showRange":
					this.showRange = value.GetValueAsBool();
					return;
				case "isDebugLightVolumeBound":
					this.isDebugLightVolumeBound = value.GetValueAsBool();
					return;
				case "useAutoDimmer":
					this.useAutoDimmer = value.GetValueAsBool();
					return;
				case "hasSpecular":
					this.hasSpecular = value.GetValueAsBool();
					return;
				case "importFilePath":
					this.importFilePath = value.GetValueAsPath();
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
				case "BynaryData":
					while(this.BynaryData.Count <= index) { this.BynaryData.Add(default(uint)); }
					this.BynaryData[index] = value.GetValueAsUInt32();
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