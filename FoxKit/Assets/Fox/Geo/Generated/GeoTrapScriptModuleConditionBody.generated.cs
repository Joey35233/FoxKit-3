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

namespace Fox.Geo
{
	[UnityEditor.InitializeOnLoad]
	public partial class GeoTrapScriptModuleConditionBody : Fox.Geo.GeoTrapConditionBody
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<Fox.Core.SafeScript> checkScriptArray { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.SafeScript>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<Fox.Core.SafeScript> execScriptArray { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.SafeScript>();
		
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
		static GeoTrapScriptModuleConditionBody()
		{
			if (Fox.Geo.GeoTrapConditionBody.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoTrapScriptModuleConditionBody"), typeof(GeoTrapScriptModuleConditionBody), Fox.Geo.GeoTrapConditionBody.ClassInfo, 0, "Trap", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("checkScriptArray"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.SafeScript), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("execScriptArray"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Core.SafeScript), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "checkScriptArray":
					return new Fox.Core.Value(checkScriptArray);
				case "execScriptArray":
					return new Fox.Core.Value(execScriptArray);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "checkScriptArray":
					return new Fox.Core.Value(this.checkScriptArray[index]);
				case "execScriptArray":
					return new Fox.Core.Value(this.execScriptArray[index]);
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
				case "checkScriptArray":
					while(this.checkScriptArray.Count <= index) { this.checkScriptArray.Add(default(Fox.Core.SafeScript)); }
					this.checkScriptArray[index] = value.GetValueAsEntityPtr<Fox.Core.SafeScript>();
					return;
				case "execScriptArray":
					while(this.execScriptArray.Count <= index) { this.execScriptArray.Add(default(Fox.Core.SafeScript)); }
					this.execScriptArray[index] = value.GetValueAsEntityPtr<Fox.Core.SafeScript>();
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