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
	public partial class PhHingeConstraint : Fox.Ph.PhConstraint
	{
		// Properties
		public UnityEngine.Quaternion axis { get => Get_axis(); set { Set_axis(value); } }
		private partial UnityEngine.Quaternion Get_axis();
		private partial void Set_axis(UnityEngine.Quaternion value);
		
		public bool limitedFlag { get => Get_limitedFlag(); set { Set_limitedFlag(value); } }
		private partial bool Get_limitedFlag();
		private partial void Set_limitedFlag(bool value);
		
		public float limitHi { get => Get_limitHi(); set { Set_limitHi(value); } }
		private partial float Get_limitHi();
		private partial void Set_limitHi(float value);
		
		public float limitLo { get => Get_limitLo(); set { Set_limitLo(value); } }
		private partial float Get_limitLo();
		private partial void Set_limitLo(float value);
		
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
		static PhHingeConstraint()
		{
			if (Fox.Ph.PhConstraint.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhHingeConstraint", typeof(PhHingeConstraint), Fox.Ph.PhConstraint.ClassInfo, 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("axis", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitedFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitHi", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitLo", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "axis":
					return new Fox.Core.Value(axis);
				case "limitedFlag":
					return new Fox.Core.Value(limitedFlag);
				case "limitHi":
					return new Fox.Core.Value(limitHi);
				case "limitLo":
					return new Fox.Core.Value(limitLo);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "axis":
					this.axis = value.GetValueAsQuat();
					return;
				case "limitedFlag":
					this.limitedFlag = value.GetValueAsBool();
					return;
				case "limitHi":
					this.limitHi = value.GetValueAsFloat();
					return;
				case "limitLo":
					this.limitLo = value.GetValueAsFloat();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}