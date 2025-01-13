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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppMotherBaseCore/MotherBaseReplaceTextureData")]
	public partial class MotherBaseReplaceTextureData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<ulong> pathCodes { get; private set; } = new CsSystem.Collections.Generic.List<ulong>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<int> flags { get; private set; } = new Fox.StringMap<int>();
		
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
		static MotherBaseReplaceTextureData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("MotherBaseReplaceTextureData", typeof(MotherBaseReplaceTextureData), Fox.Core.Data.ClassInfo, 128, "TppMotherBase", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pathCodes", Fox.Core.PropertyInfo.PropertyType.UInt64, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flags", Fox.Core.PropertyInfo.PropertyType.Int32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "pathCodes":
					return new Fox.Core.Value(pathCodes);
				case "flags":
					return new Fox.Core.Value((Fox.IStringMap)flags);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "pathCodes":
					return new Fox.Core.Value(this.pathCodes[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				case "flags":
					return new Fox.Core.Value(this.flags[key]);
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
				case "pathCodes":
					while(this.pathCodes.Count <= index) { this.pathCodes.Add(default(ulong)); }
					this.pathCodes[index] = value.GetValueAsUInt64();
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
				case "flags":
					if (this.flags.ContainsKey(key))
						this.flags[key] = value.GetValueAsInt32();
					else
						this.flags.Insert(key, value.GetValueAsInt32());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}