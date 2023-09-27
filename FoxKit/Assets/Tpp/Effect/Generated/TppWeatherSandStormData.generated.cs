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
	public partial class TppWeatherSandStormData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileSandStormStart { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileSandStormFar { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileSandStormNear { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr vfxFileSandStormCamera { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sandStormFarDistance { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sandStormFarHeight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sandStormNearDistance { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float sandStormNearHeight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float noiseScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float noiseOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float noiseCutScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float noiseCutOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color noiseColor { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool noiseSunLightColorMul { get; set; }
		
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
		static TppWeatherSandStormData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppWeatherSandStormData"), typeof(TppWeatherSandStormData), Fox.Core.Data.ClassInfo, 240, "TppEffect", 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFileSandStormStart"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFileSandStormFar"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFileSandStormNear"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFileSandStormCamera"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sandStormFarDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sandStormFarHeight"), Fox.Core.PropertyInfo.PropertyType.Float, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sandStormNearDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 228, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sandStormNearHeight"), Fox.Core.PropertyInfo.PropertyType.Float, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseScale"), Fox.Core.PropertyInfo.PropertyType.Float, 240, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseOffset"), Fox.Core.PropertyInfo.PropertyType.Float, 244, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseCutScale"), Fox.Core.PropertyInfo.PropertyType.Float, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseCutOffset"), Fox.Core.PropertyInfo.PropertyType.Float, 252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseColor"), Fox.Core.PropertyInfo.PropertyType.Color, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseSunLightColorMul"), Fox.Core.PropertyInfo.PropertyType.Bool, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppWeatherSandStormData(ulong id) : base(id) { }
		public TppWeatherSandStormData() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "vfxFileSandStormStart":
					this.vfxFileSandStormStart = value.GetValueAsFilePtr();
					return;
				case "vfxFileSandStormFar":
					this.vfxFileSandStormFar = value.GetValueAsFilePtr();
					return;
				case "vfxFileSandStormNear":
					this.vfxFileSandStormNear = value.GetValueAsFilePtr();
					return;
				case "vfxFileSandStormCamera":
					this.vfxFileSandStormCamera = value.GetValueAsFilePtr();
					return;
				case "sandStormFarDistance":
					this.sandStormFarDistance = value.GetValueAsFloat();
					return;
				case "sandStormFarHeight":
					this.sandStormFarHeight = value.GetValueAsFloat();
					return;
				case "sandStormNearDistance":
					this.sandStormNearDistance = value.GetValueAsFloat();
					return;
				case "sandStormNearHeight":
					this.sandStormNearHeight = value.GetValueAsFloat();
					return;
				case "noiseScale":
					this.noiseScale = value.GetValueAsFloat();
					return;
				case "noiseOffset":
					this.noiseOffset = value.GetValueAsFloat();
					return;
				case "noiseCutScale":
					this.noiseCutScale = value.GetValueAsFloat();
					return;
				case "noiseCutOffset":
					this.noiseCutOffset = value.GetValueAsFloat();
					return;
				case "noiseColor":
					this.noiseColor = value.GetValueAsColor();
					return;
				case "noiseSunLightColorMul":
					this.noiseSunLightColorMul = value.GetValueAsBool();
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