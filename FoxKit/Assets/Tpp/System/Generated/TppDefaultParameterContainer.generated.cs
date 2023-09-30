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

namespace Tpp.System
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppDefaultParameterContainer : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String id { get; set; }

		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Tpp.System.TppDefaultParameterElement> @params { get; private set; } = new Fox.Kernel.StringMap<Tpp.System.TppDefaultParameterElement>();

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
		static TppDefaultParameterContainer()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppDefaultParameterContainer"), typeof(TppDefaultParameterContainer), Fox.Core.Data.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("id"), Fox.Core.PropertyInfo.PropertyType.String, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("params"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, typeof(Tpp.System.TppDefaultParameterElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppDefaultParameterContainer(ulong id) : base(id) { }
		public TppDefaultParameterContainer() : base() { }

		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "id":
					return new Fox.Core.Value(id);
				case "@params":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)@params);
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
				case "@params":
					return new Fox.Core.Value(this.@params[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "id":
					this.id = value.GetValueAsString();
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "@params":
					this.@params.Insert(key, value.GetValueAsEntityPtr<Tpp.System.TppDefaultParameterElement>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}