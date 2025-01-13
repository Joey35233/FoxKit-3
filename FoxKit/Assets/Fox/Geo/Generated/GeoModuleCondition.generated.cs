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
	public partial class GeoModuleCondition : Fox.Geo.GeoTrapCondition
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool isAndCheck { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> checkFuncNames { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> execFuncNames { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Geo.GeoTrapModuleCallbackDataElement> checkCallbackDataElements { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Geo.GeoTrapModuleCallbackDataElement>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Geo.GeoTrapModuleCallbackDataElement> execCallbackDataElements { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Geo.GeoTrapModuleCallbackDataElement>();
		
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
		static GeoModuleCondition()
		{
			if (Fox.Geo.GeoTrapCondition.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GeoModuleCondition", typeof(GeoModuleCondition), Fox.Geo.GeoTrapCondition.ClassInfo, 352, "Trap", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isAndCheck", Fox.Core.PropertyInfo.PropertyType.Bool, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkFuncNames", Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execFuncNames", Fox.Core.PropertyInfo.PropertyType.String, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkCallbackDataElements", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 360, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Geo.GeoTrapModuleCallbackDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("execCallbackDataElements", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 376, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Geo.GeoTrapModuleCallbackDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "isAndCheck":
					return new Fox.Core.Value(isAndCheck);
				case "checkFuncNames":
					return new Fox.Core.Value(checkFuncNames);
				case "execFuncNames":
					return new Fox.Core.Value(execFuncNames);
				case "checkCallbackDataElements":
					return new Fox.Core.Value(checkCallbackDataElements);
				case "execCallbackDataElements":
					return new Fox.Core.Value(execCallbackDataElements);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "checkFuncNames":
					return new Fox.Core.Value(this.checkFuncNames[index]);
				case "execFuncNames":
					return new Fox.Core.Value(this.execFuncNames[index]);
				case "checkCallbackDataElements":
					return new Fox.Core.Value(this.checkCallbackDataElements[index]);
				case "execCallbackDataElements":
					return new Fox.Core.Value(this.execCallbackDataElements[index]);
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
				case "isAndCheck":
					this.isAndCheck = value.GetValueAsBool();
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
				case "checkFuncNames":
					while(this.checkFuncNames.Count <= index) { this.checkFuncNames.Add(default(string)); }
					this.checkFuncNames[index] = value.GetValueAsString();
					return;
				case "execFuncNames":
					while(this.execFuncNames.Count <= index) { this.execFuncNames.Add(default(string)); }
					this.execFuncNames[index] = value.GetValueAsString();
					return;
				case "checkCallbackDataElements":
					while(this.checkCallbackDataElements.Count <= index) { this.checkCallbackDataElements.Add(default(Fox.Geo.GeoTrapModuleCallbackDataElement)); }
					this.checkCallbackDataElements[index] = value.GetValueAsEntityPtr<Fox.Geo.GeoTrapModuleCallbackDataElement>();
					return;
				case "execCallbackDataElements":
					while(this.execCallbackDataElements.Count <= index) { this.execCallbackDataElements.Add(default(Fox.Geo.GeoTrapModuleCallbackDataElement)); }
					this.execCallbackDataElements[index] = value.GetValueAsEntityPtr<Fox.Geo.GeoTrapModuleCallbackDataElement>();
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