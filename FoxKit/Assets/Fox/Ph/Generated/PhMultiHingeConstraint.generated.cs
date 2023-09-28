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
	public partial class PhMultiHingeConstraint : Fox.Ph.PhConstraint
	{
		// Properties
		public UnityEngine.Quaternion axis { get => Get_axis(); set { Set_axis(value); } }
		private partial UnityEngine.Quaternion Get_axis();
		private partial void Set_axis(UnityEngine.Quaternion value);
		
		public bool limitedFlag { get => Get_limitedFlag(); set { Set_limitedFlag(value); } }
		private partial bool Get_limitedFlag();
		private partial void Set_limitedFlag(bool value);
		
		public bool isPoweredFlag { get => Get_isPoweredFlag(); set { Set_isPoweredFlag(value); } }
		private partial bool Get_isPoweredFlag();
		private partial void Set_isPoweredFlag(bool value);
		
		public float limitHi { get => Get_limitHi(); set { Set_limitHi(value); } }
		private partial float Get_limitHi();
		private partial void Set_limitHi(float value);
		
		public float limitLo { get => Get_limitLo(); set { Set_limitLo(value); } }
		private partial float Get_limitLo();
		private partial void Set_limitLo(float value);
		
		public uint powerControlType { get => Get_powerControlType(); set { Set_powerControlType(value); } }
		private partial uint Get_powerControlType();
		private partial void Set_powerControlType(uint value);
		
		public float velocityMax { get => Get_velocityMax(); set { Set_velocityMax(value); } }
		private partial float Get_velocityMax();
		private partial void Set_velocityMax(float value);
		
		public float torqueMax { get => Get_torqueMax(); set { Set_torqueMax(value); } }
		private partial float Get_torqueMax();
		private partial void Set_torqueMax(float value);
		
		public float targetTheta { get => Get_targetTheta(); set { Set_targetTheta(value); } }
		private partial float Get_targetTheta();
		private partial void Set_targetTheta(float value);
		
		public float targetVelocity { get => Get_targetVelocity(); set { Set_targetVelocity(value); } }
		private partial float Get_targetVelocity();
		private partial void Set_targetVelocity(float value);
		
		public float velocityRate { get => Get_velocityRate(); set { Set_velocityRate(value); } }
		private partial float Get_velocityRate();
		private partial void Set_velocityRate(float value);
		
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
		static PhMultiHingeConstraint()
		{
			if (Fox.Ph.PhConstraint.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhMultiHingeConstraint"), typeof(PhMultiHingeConstraint), Fox.Ph.PhConstraint.ClassInfo, 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("axis"), Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitedFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isPoweredFlag"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitHi"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("limitLo"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("powerControlType"), Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityMax"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("torqueMax"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetTheta"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetVelocity"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("velocityRate"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public PhMultiHingeConstraint(ulong id) : base(id) { }
		public PhMultiHingeConstraint() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "axis":
					this.axis = value.GetValueAsQuat();
					return;
				case "limitedFlag":
					this.limitedFlag = value.GetValueAsBool();
					return;
				case "isPoweredFlag":
					this.isPoweredFlag = value.GetValueAsBool();
					return;
				case "limitHi":
					this.limitHi = value.GetValueAsFloat();
					return;
				case "limitLo":
					this.limitLo = value.GetValueAsFloat();
					return;
				case "powerControlType":
					this.powerControlType = value.GetValueAsUInt32();
					return;
				case "velocityMax":
					this.velocityMax = value.GetValueAsFloat();
					return;
				case "torqueMax":
					this.torqueMax = value.GetValueAsFloat();
					return;
				case "targetTheta":
					this.targetTheta = value.GetValueAsFloat();
					return;
				case "targetVelocity":
					this.targetVelocity = value.GetValueAsFloat();
					return;
				case "velocityRate":
					this.velocityRate = value.GetValueAsFloat();
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