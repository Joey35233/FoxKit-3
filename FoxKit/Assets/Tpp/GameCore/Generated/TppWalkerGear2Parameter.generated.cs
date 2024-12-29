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

namespace Tpp.GameCore
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppWalkerGear2Parameter : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr partsFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr motionGraphFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr mtarFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr extensionMtarFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> vfxFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> extraPartsFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
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
		static TppWalkerGear2Parameter()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppWalkerGear2Parameter", typeof(TppWalkerGear2Parameter), Fox.Core.DataElement.ClassInfo, 224, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("partsFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("motionGraphFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mtarFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("extensionMtarFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("vfxFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("extraPartsFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "partsFile":
					return new Fox.Core.Value(partsFile);
				case "motionGraphFile":
					return new Fox.Core.Value(motionGraphFile);
				case "mtarFile":
					return new Fox.Core.Value(mtarFile);
				case "extensionMtarFile":
					return new Fox.Core.Value(extensionMtarFile);
				case "vfxFiles":
					return new Fox.Core.Value((Fox.IStringMap)vfxFiles);
				case "extraPartsFiles":
					return new Fox.Core.Value((Fox.IStringMap)extraPartsFiles);
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
				case "extraPartsFiles":
					return new Fox.Core.Value(this.extraPartsFiles[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "partsFile":
					this.partsFile = value.GetValueAsFilePtr();
					return;
				case "motionGraphFile":
					this.motionGraphFile = value.GetValueAsFilePtr();
					return;
				case "mtarFile":
					this.mtarFile = value.GetValueAsFilePtr();
					return;
				case "extensionMtarFile":
					this.extensionMtarFile = value.GetValueAsFilePtr();
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
				case "vfxFiles":
					if (this.vfxFiles.ContainsKey(key))
						this.vfxFiles[key] = value.GetValueAsFilePtr();
					else
						this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "extraPartsFiles":
					if (this.extraPartsFiles.ContainsKey(key))
						this.extraPartsFiles[key] = value.GetValueAsFilePtr();
					else
						this.extraPartsFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}