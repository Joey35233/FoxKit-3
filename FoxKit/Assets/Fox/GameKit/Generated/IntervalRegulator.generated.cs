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
	public partial class IntervalRegulator : Fox.Core.Entity
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.StringMap<double> intervalTimers { get; private set; } = new Fox.Kernel.StringMap<double>();
		
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
		static IntervalRegulator()
		{
			if (Fox.Core.Entity.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("IntervalRegulator"), typeof(IntervalRegulator), Fox.Core.Entity.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("intervalTimers"), Fox.Core.PropertyInfo.PropertyType.Double, 48, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "intervalTimers":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)intervalTimers);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				case "intervalTimers":
					return new Fox.Core.Value(this.intervalTimers[key]);
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "intervalTimers":
					if (this.intervalTimers.ContainsKey(key))
						this.intervalTimers[key] = value.GetValueAsDouble();
					else
						this.intervalTimers.Insert(key, value.GetValueAsDouble());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}