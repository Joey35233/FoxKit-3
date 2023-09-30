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

namespace Fox.Sim
{
	[UnityEditor.InitializeOnLoad]
	public partial class SimClothControlUnit : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Sim.SimClothControlUnitParam controlUnitParam { get; set; }
		
		public float mass { get => Get_mass(); set { Set_mass(value); } }
		private partial float Get_mass();
		private partial void Set_mass(float value);
		
		public float thickness { get => Get_thickness(); set { Set_thickness(value); } }
		private partial float Get_thickness();
		private partial void Set_thickness(float value);
		
		public float limit { get => Get_limit(); set { Set_limit(value); } }
		private partial float Get_limit();
		private partial void Set_limit(float value);
		
		public float expansionRatio { get => Get_expansionRatio(); set { Set_expansionRatio(value); } }
		private partial float Get_expansionRatio();
		private partial void Set_expansionRatio(float value);
		
		public float contractionRatio { get => Get_contractionRatio(); set { Set_contractionRatio(value); } }
		private partial float Get_contractionRatio();
		private partial void Set_contractionRatio(float value);
		
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
		static SimClothControlUnit()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimClothControlUnit"), typeof(SimClothControlUnit), Fox.Core.DataElement.ClassInfo, 40, "Sim", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlUnitParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimClothControlUnitParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mass"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("thickness"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limit"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("expansionRatio"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("contractionRatio"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public SimClothControlUnit(ulong id) : base(id) { }
		public SimClothControlUnit() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "controlUnitParam":
					return new Fox.Core.Value(controlUnitParam);
				case "mass":
					return new Fox.Core.Value(mass);
				case "thickness":
					return new Fox.Core.Value(thickness);
				case "limit":
					return new Fox.Core.Value(limit);
				case "expansionRatio":
					return new Fox.Core.Value(expansionRatio);
				case "contractionRatio":
					return new Fox.Core.Value(contractionRatio);
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
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "controlUnitParam":
					this.controlUnitParam = value.GetValueAsEntityPtr<Fox.Sim.SimClothControlUnitParam>();
					return;
				case "mass":
					this.mass = value.GetValueAsFloat();
					return;
				case "thickness":
					this.thickness = value.GetValueAsFloat();
					return;
				case "limit":
					this.limit = value.GetValueAsFloat();
					return;
				case "expansionRatio":
					this.expansionRatio = value.GetValueAsFloat();
					return;
				case "contractionRatio":
					this.contractionRatio = value.GetValueAsFloat();
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
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}