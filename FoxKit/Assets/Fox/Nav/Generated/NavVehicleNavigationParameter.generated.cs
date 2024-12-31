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

namespace Fox.Nav
{
	[UnityEditor.InitializeOnLoad]
	public partial class NavVehicleNavigationParameter : Fox.Nav.NavNavigationParameter
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.DynamicArray<float> turningRadii { get; private set; } = new Fox.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.DynamicArray<float> turningSpeeds { get; private set; } = new Fox.DynamicArray<float>();
		
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
		static NavVehicleNavigationParameter()
		{
			if (Fox.Nav.NavNavigationParameter.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("NavVehicleNavigationParameter", typeof(NavVehicleNavigationParameter), Fox.Nav.NavNavigationParameter.ClassInfo, 0, "Nav", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("turningRadii", Fox.Core.PropertyInfo.PropertyType.Float, 48, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("turningSpeeds", Fox.Core.PropertyInfo.PropertyType.Float, 64, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "turningRadii":
					return new Fox.Core.Value(turningRadii);
				case "turningSpeeds":
					return new Fox.Core.Value(turningSpeeds);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "turningRadii":
					return new Fox.Core.Value(this.turningRadii[index]);
				case "turningSpeeds":
					return new Fox.Core.Value(this.turningSpeeds[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "turningRadii":
					while(this.turningRadii.Count <= index) { this.turningRadii.Add(default(float)); }
					this.turningRadii[index] = value.GetValueAsFloat();
					return;
				case "turningSpeeds":
					while(this.turningSpeeds.Count <= index) { this.turningSpeeds.Add(default(float)); }
					this.turningSpeeds[index] = value.GetValueAsFloat();
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