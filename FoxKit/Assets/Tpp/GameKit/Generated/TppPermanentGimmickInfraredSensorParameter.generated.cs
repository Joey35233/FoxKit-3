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

namespace Tpp.GameKit
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppPermanentGimmickInfraredSensorParameter : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint flag { get; set; }
		
		public bool checkHostAndLocalPlayer { get => Get_checkHostAndLocalPlayer(); set { Set_checkHostAndLocalPlayer(value); } }
		private partial bool Get_checkHostAndLocalPlayer();
		private partial void Set_checkHostAndLocalPlayer(bool value);
		
		public bool checkPlayer { get => Get_checkPlayer(); set { Set_checkPlayer(value); } }
		private partial bool Get_checkPlayer();
		private partial void Set_checkPlayer(bool value);
		
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
		static TppPermanentGimmickInfraredSensorParameter()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppPermanentGimmickInfraredSensorParameter", typeof(TppPermanentGimmickInfraredSensorParameter), Fox.Core.DataElement.ClassInfo, 32, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flag", Fox.Core.PropertyInfo.PropertyType.UInt32, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkHostAndLocalPlayer", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("checkPlayer", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "flag":
					return new Fox.Core.Value(flag);
				case "checkHostAndLocalPlayer":
					return new Fox.Core.Value(checkHostAndLocalPlayer);
				case "checkPlayer":
					return new Fox.Core.Value(checkPlayer);
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
				case "flag":
					this.flag = value.GetValueAsUInt32();
					return;
				case "checkHostAndLocalPlayer":
					this.checkHostAndLocalPlayer = value.GetValueAsBool();
					return;
				case "checkPlayer":
					this.checkPlayer = value.GetValueAsBool();
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