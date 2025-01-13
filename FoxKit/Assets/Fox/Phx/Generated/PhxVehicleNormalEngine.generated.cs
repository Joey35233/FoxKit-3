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

namespace Fox.Phx
{
	[UnityEditor.InitializeOnLoad]
	public partial class PhxVehicleNormalEngine : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> vehicleAxes { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<float> torqueDistributions { get; private set; } = new CsSystem.Collections.Generic.List<float>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<float> gearRatios { get; private set; } = new CsSystem.Collections.Generic.List<float>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Phx.PhVehicleNormalEngineParam vehicleNormalEngineParam { get; set; }
		
		public CsSystem.Collections.Generic.List<float> specPointAngularVelocity { get => Get_specPointAngularVelocity(); }
		private partial CsSystem.Collections.Generic.List<float> Get_specPointAngularVelocity();
		
		public CsSystem.Collections.Generic.List<float> specPointTorque { get => Get_specPointTorque(); }
		private partial CsSystem.Collections.Generic.List<float> Get_specPointTorque();
		
		public CsSystem.Collections.Generic.List<float> specPointBreakTorque { get => Get_specPointBreakTorque(); }
		private partial CsSystem.Collections.Generic.List<float> Get_specPointBreakTorque();
		
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
		static PhxVehicleNormalEngine()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhxVehicleNormalEngine", typeof(PhxVehicleNormalEngine), Fox.Core.Data.ClassInfo, 120, "Phx", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vehicleAxes", Fox.Core.PropertyInfo.PropertyType.EntityLink, 128, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("torqueDistributions", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("gearRatios", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vehicleNormalEngineParam", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhVehicleNormalEngineParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointAngularVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointTorque", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specPointBreakTorque", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "vehicleAxes":
					return new Fox.Core.Value(vehicleAxes);
				case "torqueDistributions":
					return new Fox.Core.Value(torqueDistributions);
				case "gearRatios":
					return new Fox.Core.Value(gearRatios);
				case "vehicleNormalEngineParam":
					return new Fox.Core.Value(vehicleNormalEngineParam);
				case "specPointAngularVelocity":
					return new Fox.Core.Value(specPointAngularVelocity);
				case "specPointTorque":
					return new Fox.Core.Value(specPointTorque);
				case "specPointBreakTorque":
					return new Fox.Core.Value(specPointBreakTorque);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "vehicleAxes":
					return new Fox.Core.Value(this.vehicleAxes[index]);
				case "torqueDistributions":
					return new Fox.Core.Value(this.torqueDistributions[index]);
				case "gearRatios":
					return new Fox.Core.Value(this.gearRatios[index]);
				case "specPointAngularVelocity":
					return new Fox.Core.Value(this.specPointAngularVelocity[index]);
				case "specPointTorque":
					return new Fox.Core.Value(this.specPointTorque[index]);
				case "specPointBreakTorque":
					return new Fox.Core.Value(this.specPointBreakTorque[index]);
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
				case "vehicleNormalEngineParam":
					this.vehicleNormalEngineParam = value.GetValueAsEntityPtr<Fox.Phx.PhVehicleNormalEngineParam>();
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
				case "vehicleAxes":
					while(this.vehicleAxes.Count <= index) { this.vehicleAxes.Add(default(Fox.Core.EntityLink)); }
					this.vehicleAxes[index] = value.GetValueAsEntityLink();
					return;
				case "torqueDistributions":
					while(this.torqueDistributions.Count <= index) { this.torqueDistributions.Add(default(float)); }
					this.torqueDistributions[index] = value.GetValueAsFloat();
					return;
				case "gearRatios":
					while(this.gearRatios.Count <= index) { this.gearRatios.Add(default(float)); }
					this.gearRatios[index] = value.GetValueAsFloat();
					return;
				case "specPointAngularVelocity":
					while(this.specPointAngularVelocity.Count <= index) { this.specPointAngularVelocity.Add(default(float)); }
					this.specPointAngularVelocity[index] = value.GetValueAsFloat();
					return;
				case "specPointTorque":
					while(this.specPointTorque.Count <= index) { this.specPointTorque.Add(default(float)); }
					this.specPointTorque[index] = value.GetValueAsFloat();
					return;
				case "specPointBreakTorque":
					while(this.specPointBreakTorque.Count <= index) { this.specPointBreakTorque.Add(default(float)); }
					this.specPointBreakTorque[index] = value.GetValueAsFloat();
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