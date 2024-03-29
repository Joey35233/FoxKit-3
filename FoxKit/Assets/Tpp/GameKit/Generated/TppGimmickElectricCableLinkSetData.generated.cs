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
	public partial class TppGimmickElectricCableLinkSetData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink electricCableData { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink poleData { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> electricCable { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> pole { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<byte> cnpIndex { get; private set; } = new Fox.Kernel.DynamicArray<byte>();
		
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
		static TppGimmickElectricCableLinkSetData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppGimmickElectricCableLinkSetData"), typeof(TppGimmickElectricCableLinkSetData), Fox.Core.Data.ClassInfo, 176, "Gimmick", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("electricCableData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("poleData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("electricCable"), Fox.Core.PropertyInfo.PropertyType.String, 200, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("pole"), Fox.Core.PropertyInfo.PropertyType.String, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cnpIndex"), Fox.Core.PropertyInfo.PropertyType.UInt8, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "electricCableData":
					return new Fox.Core.Value(electricCableData);
				case "poleData":
					return new Fox.Core.Value(poleData);
				case "electricCable":
					return new Fox.Core.Value(electricCable);
				case "pole":
					return new Fox.Core.Value(pole);
				case "cnpIndex":
					return new Fox.Core.Value(cnpIndex);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "electricCable":
					return new Fox.Core.Value(this.electricCable[index]);
				case "pole":
					return new Fox.Core.Value(this.pole[index]);
				case "cnpIndex":
					return new Fox.Core.Value(this.cnpIndex[index]);
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
				case "electricCableData":
					this.electricCableData = value.GetValueAsEntityLink();
					return;
				case "poleData":
					this.poleData = value.GetValueAsEntityLink();
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
				case "electricCable":
					while(this.electricCable.Count <= index) { this.electricCable.Add(default(Fox.Kernel.String)); }
					this.electricCable[index] = value.GetValueAsString();
					return;
				case "pole":
					while(this.pole.Count <= index) { this.pole.Add(default(Fox.Kernel.String)); }
					this.pole[index] = value.GetValueAsString();
					return;
				case "cnpIndex":
					while(this.cnpIndex.Count <= index) { this.cnpIndex.Add(default(byte)); }
					this.cnpIndex[index] = value.GetValueAsUInt8();
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