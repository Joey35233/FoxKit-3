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

namespace Fox.Ph
{
	[UnityEditor.InitializeOnLoad]
	public partial class PhMultiShoulderConstraintParam : Fox.Ph.PhConstraintParam
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 refVec0 { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 refVec1 { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float refLimit0 { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float refLimit1 { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float velocityMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float torqueMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float velocityRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected bool isPoweredFlag { get; set; }
		
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
		static PhMultiShoulderConstraintParam()
		{
			if (Fox.Ph.PhConstraintParam.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhMultiShoulderConstraintParam"), typeof(PhMultiShoulderConstraintParam), Fox.Ph.PhConstraintParam.ClassInfo, 112, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refVec0"), Fox.Core.PropertyInfo.PropertyType.Vector3, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refVec1"), Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refLimit0"), Fox.Core.PropertyInfo.PropertyType.Float, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refLimit1"), Fox.Core.PropertyInfo.PropertyType.Float, 100, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityMax"), Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("torqueMax"), Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityRate"), Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPoweredFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "refVec0":
					return new Fox.Core.Value(refVec0);
				case "refVec1":
					return new Fox.Core.Value(refVec1);
				case "refLimit0":
					return new Fox.Core.Value(refLimit0);
				case "refLimit1":
					return new Fox.Core.Value(refLimit1);
				case "velocityMax":
					return new Fox.Core.Value(velocityMax);
				case "torqueMax":
					return new Fox.Core.Value(torqueMax);
				case "velocityRate":
					return new Fox.Core.Value(velocityRate);
				case "isPoweredFlag":
					return new Fox.Core.Value(isPoweredFlag);
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
				case "refVec0":
					this.refVec0 = value.GetValueAsVector3();
					return;
				case "refVec1":
					this.refVec1 = value.GetValueAsVector3();
					return;
				case "refLimit0":
					this.refLimit0 = value.GetValueAsFloat();
					return;
				case "refLimit1":
					this.refLimit1 = value.GetValueAsFloat();
					return;
				case "velocityMax":
					this.velocityMax = value.GetValueAsFloat();
					return;
				case "torqueMax":
					this.torqueMax = value.GetValueAsFloat();
					return;
				case "velocityRate":
					this.velocityRate = value.GetValueAsFloat();
					return;
				case "isPoweredFlag":
					this.isPoweredFlag = value.GetValueAsBool();
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