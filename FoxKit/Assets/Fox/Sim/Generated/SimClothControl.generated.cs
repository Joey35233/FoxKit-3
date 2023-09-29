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
	public partial class SimClothControl : Fox.Sim.SimControlElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.EntityPtr<Fox.Sim.SimClothControlParam> controlParam { get; set; } = new Fox.Core.EntityPtr<Fox.Sim.SimClothControlParam>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Sim.SimClothControlUnit>> clothControlUnits { get; protected set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Sim.SimClothControlUnit>>();
		
		public float windCoefficient { get => Get_windCoefficient(); set { Set_windCoefficient(value); } }
		private partial float Get_windCoefficient();
		private partial void Set_windCoefficient(float value);
		
		public bool isLoop { get => Get_isLoop(); set { Set_isLoop(value); } }
		private partial bool Get_isLoop();
		private partial void Set_isLoop(bool value);
		
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
		static SimClothControl()
		{
			if (Fox.Sim.SimControlElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimClothControl"), typeof(SimClothControl), Fox.Sim.SimControlElement.ClassInfo, 72, "Sim", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimClothControlParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("clothControlUnits"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 80, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimClothControlUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("windCoefficient"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isLoop"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public SimClothControl(ulong id) : base(id) { }
		public SimClothControl() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "controlParam":
					return new Fox.Core.Value(controlParam);
				case "clothControlUnits":
					return new Fox.Core.Value(clothControlUnits);
				case "windCoefficient":
					return new Fox.Core.Value(windCoefficient);
				case "isLoop":
					return new Fox.Core.Value(isLoop);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "clothControlUnits":
					return new Fox.Core.Value(this.clothControlUnits[index]);
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
				case "controlParam":
					this.controlParam = value.GetValueAsEntityPtr<Fox.Sim.SimClothControlParam>();
					return;
				case "windCoefficient":
					this.windCoefficient = value.GetValueAsFloat();
					return;
				case "isLoop":
					this.isLoop = value.GetValueAsBool();
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
				case "clothControlUnits":
					while(this.clothControlUnits.Count <= index) { this.clothControlUnits.Add(default(Fox.Core.EntityPtr<Fox.Sim.SimClothControlUnit>)); }
					this.clothControlUnits[index] = value.GetValueAsEntityPtr<Fox.Sim.SimClothControlUnit>();
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