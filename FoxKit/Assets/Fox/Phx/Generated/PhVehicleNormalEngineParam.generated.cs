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
	public partial class PhVehicleNormalEngineParam : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> specPointAngularVelocity { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> specPointTorque { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> specPointBreakTorque { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
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
		static PhVehicleNormalEngineParam()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhVehicleNormalEngineParam"), typeof(PhVehicleNormalEngineParam), Fox.Core.Entity.ClassInfo, 72, "Phx", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("specPointAngularVelocity"), Fox.Core.PropertyInfo.PropertyType.Float, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("specPointTorque"), Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("specPointBreakTorque"), Fox.Core.PropertyInfo.PropertyType.Float, 80, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
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

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
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