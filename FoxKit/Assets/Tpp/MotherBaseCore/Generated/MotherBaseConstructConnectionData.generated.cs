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

namespace Tpp.MotherBaseCore
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppMotherBaseCore/MotherBaseConstructConnectionData")]
	public partial class MotherBaseConstructConnectionData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<ulong> constructConnectionList { get; private set; } = new CsSystem.Collections.Generic.List<ulong>();
		
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
		static MotherBaseConstructConnectionData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("MotherBaseConstructConnectionData", typeof(MotherBaseConstructConnectionData), Fox.Core.Data.ClassInfo, 80, "TppMotherBase", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("constructConnectionList", Fox.Core.PropertyInfo.PropertyType.UInt64, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "constructConnectionList":
					return new Fox.Core.Value(constructConnectionList);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "constructConnectionList":
					return new Fox.Core.Value(this.constructConnectionList[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "constructConnectionList":
					while(this.constructConnectionList.Count <= index) { this.constructConnectionList.Add(default(ulong)); }
					this.constructConnectionList[index] = value.GetValueAsUInt64();
					return;
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