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

namespace Tpp.GameKit
{
	[UnityEditor.InitializeOnLoad]
	public partial class ObjectBrushPluginBushDataElement : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> lodMeshName { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> lodDistance { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> lodDistanceHighEnd { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		public float rotationRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float elasticRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float alphaMinimizeDist { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float alphaMaximizeDist { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float baseDensity { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float camoufDensity { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float camofRadius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float camofHeight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float modelRadius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float stopEyeRadius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float stopEyeHeight { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String noiseSeType { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint bushFlags { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float baseCycleSpeedRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float windAmplitude { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool windDirYAxisFixZero { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float windOffsetFactor { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr bulletEffect { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr fairEffect { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr rainEffect { get; set; }
		
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
		static ObjectBrushPluginBushDataElement()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("ObjectBrushPluginBushDataElement"), typeof(ObjectBrushPluginBushDataElement), Fox.Core.DataElement.ClassInfo, 224, null, 20);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodMeshName"), Fox.Core.PropertyInfo.PropertyType.String, 56, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodDistanceHighEnd"), Fox.Core.PropertyInfo.PropertyType.Float, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotationRate"), Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("elasticRate"), Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("alphaMinimizeDist"), Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("alphaMaximizeDist"), Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseDensity"), Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("camoufDensity"), Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("camofRadius"), Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("camofHeight"), Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelRadius"), Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("stopEyeRadius"), Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("stopEyeHeight"), Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseSeType"), Fox.Core.PropertyInfo.PropertyType.String, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bushFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("baseCycleSpeedRate"), Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("windAmplitude"), Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("windDirYAxisFixZero"), Fox.Core.PropertyInfo.PropertyType.Bool, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("windOffsetFactor"), Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("bulletEffect"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fairEffect"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rainEffect"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "lodMeshName":
					return new Fox.Core.Value(lodMeshName);
				case "lodDistance":
					return new Fox.Core.Value(lodDistance);
				case "lodDistanceHighEnd":
					return new Fox.Core.Value(lodDistanceHighEnd);
				case "rotationRate":
					return new Fox.Core.Value(rotationRate);
				case "elasticRate":
					return new Fox.Core.Value(elasticRate);
				case "alphaMinimizeDist":
					return new Fox.Core.Value(alphaMinimizeDist);
				case "alphaMaximizeDist":
					return new Fox.Core.Value(alphaMaximizeDist);
				case "baseDensity":
					return new Fox.Core.Value(baseDensity);
				case "camoufDensity":
					return new Fox.Core.Value(camoufDensity);
				case "camofRadius":
					return new Fox.Core.Value(camofRadius);
				case "camofHeight":
					return new Fox.Core.Value(camofHeight);
				case "modelRadius":
					return new Fox.Core.Value(modelRadius);
				case "stopEyeRadius":
					return new Fox.Core.Value(stopEyeRadius);
				case "stopEyeHeight":
					return new Fox.Core.Value(stopEyeHeight);
				case "noiseSeType":
					return new Fox.Core.Value(noiseSeType);
				case "bushFlags":
					return new Fox.Core.Value(bushFlags);
				case "baseCycleSpeedRate":
					return new Fox.Core.Value(baseCycleSpeedRate);
				case "windAmplitude":
					return new Fox.Core.Value(windAmplitude);
				case "windDirYAxisFixZero":
					return new Fox.Core.Value(windDirYAxisFixZero);
				case "windOffsetFactor":
					return new Fox.Core.Value(windOffsetFactor);
				case "bulletEffect":
					return new Fox.Core.Value(bulletEffect);
				case "fairEffect":
					return new Fox.Core.Value(fairEffect);
				case "rainEffect":
					return new Fox.Core.Value(rainEffect);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "lodMeshName":
					return new Fox.Core.Value(this.lodMeshName[index]);
				case "lodDistance":
					return new Fox.Core.Value(this.lodDistance[index]);
				case "lodDistanceHighEnd":
					return new Fox.Core.Value(this.lodDistanceHighEnd[index]);
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
				case "rotationRate":
					this.rotationRate = value.GetValueAsFloat();
					return;
				case "elasticRate":
					this.elasticRate = value.GetValueAsFloat();
					return;
				case "alphaMinimizeDist":
					this.alphaMinimizeDist = value.GetValueAsFloat();
					return;
				case "alphaMaximizeDist":
					this.alphaMaximizeDist = value.GetValueAsFloat();
					return;
				case "baseDensity":
					this.baseDensity = value.GetValueAsFloat();
					return;
				case "camoufDensity":
					this.camoufDensity = value.GetValueAsFloat();
					return;
				case "camofRadius":
					this.camofRadius = value.GetValueAsFloat();
					return;
				case "camofHeight":
					this.camofHeight = value.GetValueAsFloat();
					return;
				case "modelRadius":
					this.modelRadius = value.GetValueAsFloat();
					return;
				case "stopEyeRadius":
					this.stopEyeRadius = value.GetValueAsFloat();
					return;
				case "stopEyeHeight":
					this.stopEyeHeight = value.GetValueAsFloat();
					return;
				case "noiseSeType":
					this.noiseSeType = value.GetValueAsString();
					return;
				case "bushFlags":
					this.bushFlags = value.GetValueAsUInt32();
					return;
				case "baseCycleSpeedRate":
					this.baseCycleSpeedRate = value.GetValueAsFloat();
					return;
				case "windAmplitude":
					this.windAmplitude = value.GetValueAsFloat();
					return;
				case "windDirYAxisFixZero":
					this.windDirYAxisFixZero = value.GetValueAsBool();
					return;
				case "windOffsetFactor":
					this.windOffsetFactor = value.GetValueAsFloat();
					return;
				case "bulletEffect":
					this.bulletEffect = value.GetValueAsFilePtr();
					return;
				case "fairEffect":
					this.fairEffect = value.GetValueAsFilePtr();
					return;
				case "rainEffect":
					this.rainEffect = value.GetValueAsFilePtr();
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
				case "lodMeshName":
					while(this.lodMeshName.Count <= index) { this.lodMeshName.Add(default(Fox.Kernel.String)); }
					this.lodMeshName[index] = value.GetValueAsString();
					return;
				case "lodDistance":
					while(this.lodDistance.Count <= index) { this.lodDistance.Add(default(float)); }
					this.lodDistance[index] = value.GetValueAsFloat();
					return;
				case "lodDistanceHighEnd":
					while(this.lodDistanceHighEnd.Count <= index) { this.lodDistanceHighEnd.Add(default(float)); }
					this.lodDistanceHighEnd[index] = value.GetValueAsFloat();
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