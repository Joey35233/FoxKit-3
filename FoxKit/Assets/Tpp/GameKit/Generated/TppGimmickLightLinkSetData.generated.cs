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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppGameKit/TppGimmickLightLinkSetData")]
	public partial class TppGimmickLightLinkSetData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint numLightGimmick { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink ownerGimmick { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> lightList { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
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
		static TppGimmickLightLinkSetData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppGimmickLightLinkSetData", typeof(TppGimmickLightLinkSetData), Fox.Core.Data.ClassInfo, 136, "Gimmick", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("numLightGimmick", Fox.Core.PropertyInfo.PropertyType.UInt32, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("ownerGimmick", Fox.Core.PropertyInfo.PropertyType.EntityLink, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightList", Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "numLightGimmick":
					return new Fox.Core.Value(numLightGimmick);
				case "ownerGimmick":
					return new Fox.Core.Value(ownerGimmick);
				case "lightList":
					return new Fox.Core.Value(lightList);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "lightList":
					return new Fox.Core.Value(this.lightList[index]);
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
				case "numLightGimmick":
					this.numLightGimmick = value.GetValueAsUInt32();
					return;
				case "ownerGimmick":
					this.ownerGimmick = value.GetValueAsEntityLink();
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
				case "lightList":
					while(this.lightList.Count <= index) { this.lightList.Add(default(Fox.Core.EntityLink)); }
					this.lightList[index] = value.GetValueAsEntityLink();
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