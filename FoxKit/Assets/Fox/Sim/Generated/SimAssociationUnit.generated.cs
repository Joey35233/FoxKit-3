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
	public partial class SimAssociationUnit : Fox.Phx.PhxAssociationUnitElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnitParam> param { get; set; } = new Fox.Core.EntityPtr<Fox.Sim.SimAssociationUnitParam>();
		
		public Fox.Kernel.String boneName { get => Get_boneName(); set { Set_boneName(value); } }
		protected partial Fox.Kernel.String Get_boneName();
		protected partial void Set_boneName(Fox.Kernel.String value);
		
		public bool initialized { get => Get_initialized(); set { Set_initialized(value); } }
		protected partial bool Get_initialized();
		protected partial void Set_initialized(bool value);
		
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
		static SimAssociationUnit()
		{
			if (Fox.Phx.PhxAssociationUnitElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimAssociationUnit"), typeof(SimAssociationUnit), Fox.Phx.PhxAssociationUnitElement.ClassInfo, 160, "Sim", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("param"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimAssociationUnitParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("boneName"), Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("initialized"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public SimAssociationUnit(ulong id) : base(id) { }
		public SimAssociationUnit() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "param":
					this.param = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnitParam>();
					return;
				case "boneName":
					this.boneName = value.GetValueAsString();
					return;
				case "initialized":
					this.initialized = value.GetValueAsBool();
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