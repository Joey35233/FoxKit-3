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

namespace Fox.Geox
{
	[UnityEditor.InitializeOnLoad]
	public partial class GeoxPartsTargetUnit : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>> objectArray { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>>();
		
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
		static GeoxPartsTargetUnit()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GeoxPartsTargetUnit"), typeof(GeoxPartsTargetUnit), Fox.Core.Data.ClassInfo, 0, "Target", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("objectArray"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Geox.GeoxPartsTargetObject), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public GeoxPartsTargetUnit(ulong id) : base(id) { }
		public GeoxPartsTargetUnit() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "objectArray":
					while(this.objectArray.Count <= index) { this.objectArray.Add(default(Fox.Core.EntityPtr<Fox.Geox.GeoxPartsTargetObject>)); }
					this.objectArray[index] = value.GetValueAsEntityPtr<Fox.Geox.GeoxPartsTargetObject>();
					return;
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