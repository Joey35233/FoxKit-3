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
	public partial class SimObject : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Sim.SimObjectParam objectParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected Fox.Sim.SimEngineParam engineParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Sim.SimControlElement> controls { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Sim.SimControlElement>();
		
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
		static SimObject()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimObject"), typeof(SimObject), Fox.Core.Data.ClassInfo, 0, "Sim", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("objectParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimObjectParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("engineParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimEngineParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controls"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimControlElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "objectParam":
					return new Fox.Core.Value(objectParam);
				case "engineParam":
					return new Fox.Core.Value(engineParam);
				case "controls":
					return new Fox.Core.Value(controls);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "controls":
					return new Fox.Core.Value(this.controls[index]);
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
				case "objectParam":
					this.objectParam = value.GetValueAsEntityPtr<Fox.Sim.SimObjectParam>();
					return;
				case "engineParam":
					this.engineParam = value.GetValueAsEntityPtr<Fox.Sim.SimEngineParam>();
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
				case "controls":
					while(this.controls.Count <= index) { this.controls.Add(default(Fox.Sim.SimControlElement)); }
					this.controls[index] = value.GetValueAsEntityPtr<Fox.Sim.SimControlElement>();
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