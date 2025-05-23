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

namespace Tpp.Effect
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppVfxFileLoader")]
	public partial class TppVfxFileLoader : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> vfxFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> geoMaterialFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> otherFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
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
		static TppVfxFileLoader()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppVfxFileLoader", typeof(TppVfxFileLoader), Fox.Core.Data.ClassInfo, 208, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vfxFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("geoMaterialFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 168, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("otherFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 216, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "vfxFiles":
					return new Fox.Core.Value((Fox.IStringMap)vfxFiles);
				case "geoMaterialFiles":
					return new Fox.Core.Value((Fox.IStringMap)geoMaterialFiles);
				case "otherFiles":
					return new Fox.Core.Value((Fox.IStringMap)otherFiles);
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
				case "vfxFiles":
					return new Fox.Core.Value(this.vfxFiles[key]);
				case "geoMaterialFiles":
					return new Fox.Core.Value(this.geoMaterialFiles[key]);
				case "otherFiles":
					return new Fox.Core.Value(this.otherFiles[key]);
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "vfxFiles":
					if (this.vfxFiles.ContainsKey(key))
						this.vfxFiles[key] = value.GetValueAsFilePtr();
					else
						this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "geoMaterialFiles":
					if (this.geoMaterialFiles.ContainsKey(key))
						this.geoMaterialFiles[key] = value.GetValueAsFilePtr();
					else
						this.geoMaterialFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "otherFiles":
					if (this.otherFiles.ContainsKey(key))
						this.otherFiles[key] = value.GetValueAsFilePtr();
					else
						this.otherFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}