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
	public partial class TppTrapExecThunderLightningCallbackDataElement : Fox.Geo.GeoTrapModuleCallbackDataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public TppTrapExecThunder_Type type { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink positionLocator { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float power { get; set; }
		
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
		static TppTrapExecThunderLightningCallbackDataElement()
		{
			if (Fox.Geo.GeoTrapModuleCallbackDataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppTrapExecThunderLightningCallbackDataElement"), typeof(TppTrapExecThunderLightningCallbackDataElement), Fox.Geo.GeoTrapModuleCallbackDataElement.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("type"), Fox.Core.PropertyInfo.PropertyType.Int32, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(TppTrapExecThunder_Type), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("positionLocator"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("power"), Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppTrapExecThunderLightningCallbackDataElement(ulong id) : base(id) { }
		public TppTrapExecThunderLightningCallbackDataElement() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "type":
					this.type = (TppTrapExecThunder_Type)value.GetValueAsInt32();
					return;
				case "positionLocator":
					this.positionLocator = value.GetValueAsEntityLink();
					return;
				case "power":
					this.power = value.GetValueAsFloat();
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