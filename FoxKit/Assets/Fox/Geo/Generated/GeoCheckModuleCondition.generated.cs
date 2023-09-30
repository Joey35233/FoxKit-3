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
	public partial class GeoCheckModuleCondition : Fox.Geo.GeoTrapCondition
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool isAndCheck { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> checkFuncNames { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Geo.GeoTrapModuleCallbackDataElement> checkCallbackDataElements { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Geo.GeoTrapModuleCallbackDataElement>();
		
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
		static GeoCheckModuleCondition()
		{
			if (Fox.Geo.GeoTrapCondition.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoCheckModuleCondition"), typeof(GeoCheckModuleCondition), Fox.Geo.GeoTrapCondition.ClassInfo, 0, "Trap", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isAndCheck"), Fox.Core.PropertyInfo.PropertyType.Bool, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("checkFuncNames"), Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("checkCallbackDataElements"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Geo.GeoTrapModuleCallbackDataElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public GeoCheckModuleCondition(ulong id) : base(id) { }
		public GeoCheckModuleCondition() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "isAndCheck":
					return new Fox.Core.Value(isAndCheck);
				case "checkFuncNames":
					return new Fox.Core.Value(checkFuncNames);
				case "checkCallbackDataElements":
					return new Fox.Core.Value(checkCallbackDataElements);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "checkFuncNames":
					return new Fox.Core.Value(this.checkFuncNames[index]);
				case "checkCallbackDataElements":
					return new Fox.Core.Value(this.checkCallbackDataElements[index]);
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
				case "isAndCheck":
					this.isAndCheck = value.GetValueAsBool();
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
				case "checkFuncNames":
					while(this.checkFuncNames.Count <= index) { this.checkFuncNames.Add(default(Fox.Kernel.String)); }
					this.checkFuncNames[index] = value.GetValueAsString();
					return;
				case "checkCallbackDataElements":
					while(this.checkCallbackDataElements.Count <= index) { this.checkCallbackDataElements.Add(default(Fox.Geo.GeoTrapModuleCallbackDataElement)); }
					this.checkCallbackDataElements[index] = value.GetValueAsEntityPtr<Fox.Geo.GeoTrapModuleCallbackDataElement>();
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