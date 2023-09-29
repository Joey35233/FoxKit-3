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
	public partial class TppBushManager : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected uint flag { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint totalBlockNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint totalUnitNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint maxBlockNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint maxUnitNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint maxTotalBlockNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint maxTotalUnitNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float realizeRange { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float windShakeRange { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 cameraPos { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<Fox.Kernel.String> existMaterials { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<Fox.Kernel.String> noiseSeType { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.StringMap<Fox.Kernel.String> noiseSeEventNames { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
		
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
		static TppBushManager()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppBushManager"), typeof(TppBushManager), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("flag"), Fox.Core.PropertyInfo.PropertyType.UInt32, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("totalBlockNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 52, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("totalUnitNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxBlockNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 60, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxUnitNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxTotalBlockNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 68, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxTotalUnitNum"), Fox.Core.PropertyInfo.PropertyType.UInt32, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("realizeRange"), Fox.Core.PropertyInfo.PropertyType.Float, 76, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("windShakeRange"), Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraPos"), Fox.Core.PropertyInfo.PropertyType.Vector3, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("existMaterials"), Fox.Core.PropertyInfo.PropertyType.String, 536, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseSeType"), Fox.Core.PropertyInfo.PropertyType.String, 552, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("noiseSeEventNames"), Fox.Core.PropertyInfo.PropertyType.String, 568, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppBushManager(ulong id) : base(id) { }
		public TppBushManager() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "flag":
					return new Fox.Core.Value(flag);
				case "totalBlockNum":
					return new Fox.Core.Value(totalBlockNum);
				case "totalUnitNum":
					return new Fox.Core.Value(totalUnitNum);
				case "maxBlockNum":
					return new Fox.Core.Value(maxBlockNum);
				case "maxUnitNum":
					return new Fox.Core.Value(maxUnitNum);
				case "maxTotalBlockNum":
					return new Fox.Core.Value(maxTotalBlockNum);
				case "maxTotalUnitNum":
					return new Fox.Core.Value(maxTotalUnitNum);
				case "realizeRange":
					return new Fox.Core.Value(realizeRange);
				case "windShakeRange":
					return new Fox.Core.Value(windShakeRange);
				case "cameraPos":
					return new Fox.Core.Value(cameraPos);
				case "existMaterials":
					return new Fox.Core.Value(existMaterials);
				case "noiseSeType":
					return new Fox.Core.Value(noiseSeType);
				case "noiseSeEventNames":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)noiseSeEventNames);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "existMaterials":
					return new Fox.Core.Value(this.existMaterials[index]);
				case "noiseSeType":
					return new Fox.Core.Value(this.noiseSeType[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				case "noiseSeEventNames":
					return new Fox.Core.Value(this.noiseSeEventNames[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "flag":
					this.flag = value.GetValueAsUInt32();
					return;
				case "totalBlockNum":
					this.totalBlockNum = value.GetValueAsUInt32();
					return;
				case "totalUnitNum":
					this.totalUnitNum = value.GetValueAsUInt32();
					return;
				case "maxBlockNum":
					this.maxBlockNum = value.GetValueAsUInt32();
					return;
				case "maxUnitNum":
					this.maxUnitNum = value.GetValueAsUInt32();
					return;
				case "maxTotalBlockNum":
					this.maxTotalBlockNum = value.GetValueAsUInt32();
					return;
				case "maxTotalUnitNum":
					this.maxTotalUnitNum = value.GetValueAsUInt32();
					return;
				case "realizeRange":
					this.realizeRange = value.GetValueAsFloat();
					return;
				case "windShakeRange":
					this.windShakeRange = value.GetValueAsFloat();
					return;
				case "cameraPos":
					this.cameraPos = value.GetValueAsVector3();
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
				case "existMaterials":
					while(this.existMaterials.Count <= index) { this.existMaterials.Add(default(Fox.Kernel.String)); }
					this.existMaterials[index] = value.GetValueAsString();
					return;
				case "noiseSeType":
					while(this.noiseSeType.Count <= index) { this.noiseSeType.Add(default(Fox.Kernel.String)); }
					this.noiseSeType[index] = value.GetValueAsString();
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
				case "noiseSeEventNames":
					this.noiseSeEventNames.Insert(key, value.GetValueAsString());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}