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
	public partial class PhBallsocketConstraint : Fox.Ph.PhConstraint
	{
		// Properties
		public bool limitedFlag { get => Get_limitedFlag(); set { Set_limitedFlag(value); } }
		private partial bool Get_limitedFlag();
		private partial void Set_limitedFlag(bool value);
		
		public UnityEngine.Quaternion refA { get => Get_refA(); set { Set_refA(value); } }
		private partial UnityEngine.Quaternion Get_refA();
		private partial void Set_refA(UnityEngine.Quaternion value);
		
		public UnityEngine.Quaternion refB { get => Get_refB(); set { Set_refB(value); } }
		private partial UnityEngine.Quaternion Get_refB();
		private partial void Set_refB(UnityEngine.Quaternion value);
		
		public float limit { get => Get_limit(); set { Set_limit(value); } }
		private partial float Get_limit();
		private partial void Set_limit(float value);
		
		public bool springFlag { get => Get_springFlag(); set { Set_springFlag(value); } }
		private partial bool Get_springFlag();
		private partial void Set_springFlag(bool value);
		
		public bool springRefCustomFlag { get => Get_springRefCustomFlag(); set { Set_springRefCustomFlag(value); } }
		private partial bool Get_springRefCustomFlag();
		private partial void Set_springRefCustomFlag(bool value);
		
		public UnityEngine.Quaternion springRef { get => Get_springRef(); set { Set_springRef(value); } }
		private partial UnityEngine.Quaternion Get_springRef();
		private partial void Set_springRef(UnityEngine.Quaternion value);
		
		public float springConstant { get => Get_springConstant(); set { Set_springConstant(value); } }
		private partial float Get_springConstant();
		private partial void Set_springConstant(float value);
		
		public float flexibility { get => Get_flexibility(); set { Set_flexibility(value); } }
		private partial float Get_flexibility();
		private partial void Set_flexibility(float value);
		
		public bool stopTwist { get => Get_stopTwist(); set { Set_stopTwist(value); } }
		private partial bool Get_stopTwist();
		private partial void Set_stopTwist(bool value);
		
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
		static PhBallsocketConstraint()
		{
			if (Fox.Ph.PhConstraint.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhBallsocketConstraint", typeof(PhBallsocketConstraint), Fox.Ph.PhConstraint.ClassInfo, 0, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limitedFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("refA", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("refB", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("limit", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springRefCustomFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springRef", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("springConstant", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flexibility", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("stopTwist", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "limitedFlag":
					return new Fox.Core.Value(limitedFlag);
				case "refA":
					return new Fox.Core.Value(refA);
				case "refB":
					return new Fox.Core.Value(refB);
				case "limit":
					return new Fox.Core.Value(limit);
				case "springFlag":
					return new Fox.Core.Value(springFlag);
				case "springRefCustomFlag":
					return new Fox.Core.Value(springRefCustomFlag);
				case "springRef":
					return new Fox.Core.Value(springRef);
				case "springConstant":
					return new Fox.Core.Value(springConstant);
				case "flexibility":
					return new Fox.Core.Value(flexibility);
				case "stopTwist":
					return new Fox.Core.Value(stopTwist);
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
				case "limitedFlag":
					this.limitedFlag = value.GetValueAsBool();
					return;
				case "refA":
					this.refA = value.GetValueAsQuat();
					return;
				case "refB":
					this.refB = value.GetValueAsQuat();
					return;
				case "limit":
					this.limit = value.GetValueAsFloat();
					return;
				case "springFlag":
					this.springFlag = value.GetValueAsBool();
					return;
				case "springRefCustomFlag":
					this.springRefCustomFlag = value.GetValueAsBool();
					return;
				case "springRef":
					this.springRef = value.GetValueAsQuat();
					return;
				case "springConstant":
					this.springConstant = value.GetValueAsFloat();
					return;
				case "flexibility":
					this.flexibility = value.GetValueAsFloat();
					return;
				case "stopTwist":
					this.stopTwist = value.GetValueAsBool();
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