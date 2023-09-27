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

namespace Fox.Grx
{
	[UnityEditor.InitializeOnLoad]
	public partial class PointLight : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 reachPoint { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink lightArea { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink irradiationPoint { get; set; }
		
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
		public float dimmer { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shadowBias { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodFarSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodNearSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float LodShadowDrawRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint lightFlags { get; set; }
		
		[field: UnityEngine.SerializeField]
		public PointLight_LodRadiusLevel lodRadiusLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte lodFadeType { get; set; }
		
		public bool enable { get => Get_enable(); set { Set_enable(value); } }
		protected partial bool Get_enable();
		protected partial void Set_enable(bool value);
		
		public PointLight_PackingGeneration packingGeneration { get => Get_packingGeneration(); set { Set_packingGeneration(value); } }
		protected partial PointLight_PackingGeneration Get_packingGeneration();
		protected partial void Set_packingGeneration(PointLight_PackingGeneration value);
		
		public bool castShadow { get => Get_castShadow(); set { Set_castShadow(value); } }
		protected partial bool Get_castShadow();
		protected partial void Set_castShadow(bool value);
		
		public bool isBounced { get => Get_isBounced(); set { Set_isBounced(value); } }
		protected partial bool Get_isBounced();
		protected partial void Set_isBounced(bool value);
		
		public bool showObject { get => Get_showObject(); set { Set_showObject(value); } }
		protected partial bool Get_showObject();
		protected partial void Set_showObject(bool value);
		
		public bool showRange { get => Get_showRange(); set { Set_showRange(value); } }
		protected partial bool Get_showRange();
		protected partial void Set_showRange(bool value);
		
		public bool isDebugLightVolumeBound { get => Get_isDebugLightVolumeBound(); set { Set_isDebugLightVolumeBound(value); } }
		protected partial bool Get_isDebugLightVolumeBound();
		protected partial void Set_isDebugLightVolumeBound(bool value);
		
		public bool hasSpecular { get => Get_hasSpecular(); set { Set_hasSpecular(value); } }
		protected partial bool Get_hasSpecular();
		protected partial void Set_hasSpecular(bool value);
		
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
		static PointLight()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PointLight"), typeof(PointLight), Fox.Core.TransformData.ClassInfo, 416, "Light", 14);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("reachPoint"), Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightArea"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("irradiationPoint"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 376, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("outerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("innerRange"), Fox.Core.PropertyInfo.PropertyType.Float, 420, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("temperature"), Fox.Core.PropertyInfo.PropertyType.Float, 424, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("colorDeflection"), Fox.Core.PropertyInfo.PropertyType.Float, 428, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lumen"), Fox.Core.PropertyInfo.PropertyType.Float, 432, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightSize"), Fox.Core.PropertyInfo.PropertyType.Float, 436, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dimmer"), Fox.Core.PropertyInfo.PropertyType.Float, 440, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shadowBias"), Fox.Core.PropertyInfo.PropertyType.Float, 444, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodFarSize"), Fox.Core.PropertyInfo.PropertyType.Float, 448, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodNearSize"), Fox.Core.PropertyInfo.PropertyType.Float, 452, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("LodShadowDrawRate"), Fox.Core.PropertyInfo.PropertyType.Float, 456, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 460, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodRadiusLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PointLight_LodRadiusLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodFadeType"), Fox.Core.PropertyInfo.PropertyType.UInt8, 468, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("packingGeneration"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PointLight_PackingGeneration), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("castShadow"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isBounced"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showObject"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("showRange"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isDebugLightVolumeBound"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("hasSpecular"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public PointLight(ulong id) : base(id) { }
		public PointLight() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
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
				case "dimmer":
					this.dimmer = value.GetValueAsFloat();
					return;
				case "shadowBias":
					this.shadowBias = value.GetValueAsFloat();
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
					this.lodRadiusLevel = (PointLight_LodRadiusLevel)value.GetValueAsInt32();
					return;
				case "lodFadeType":
					this.lodFadeType = value.GetValueAsUInt8();
					return;
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "packingGeneration":
					this.packingGeneration = (PointLight_PackingGeneration)value.GetValueAsInt32();
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
				case "hasSpecular":
					this.hasSpecular = value.GetValueAsBool();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}