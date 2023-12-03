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
	public partial class TppParasite2Parameter : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr partsFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr motionGraphFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr mtarFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> partsFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> vfxFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> fmdlFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> geomFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> fovaFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
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
		static TppParasite2Parameter()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppParasite2Parameter"), typeof(TppParasite2Parameter), Fox.Core.DataElement.ClassInfo, 344, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 56, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("motionGraphFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mtarFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vfxFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fmdlFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("geomFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 272, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fovaFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 320, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "partsFile":
					return new Fox.Core.Value(partsFile);
				case "motionGraphFile":
					return new Fox.Core.Value(motionGraphFile);
				case "mtarFile":
					return new Fox.Core.Value(mtarFile);
				case "partsFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)partsFiles);
				case "vfxFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)vfxFiles);
				case "fmdlFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)fmdlFiles);
				case "geomFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)geomFiles);
				case "fovaFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)fovaFiles);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				case "partsFiles":
					return new Fox.Core.Value(this.partsFiles[key]);
				case "vfxFiles":
					return new Fox.Core.Value(this.vfxFiles[key]);
				case "fmdlFiles":
					return new Fox.Core.Value(this.fmdlFiles[key]);
				case "geomFiles":
					return new Fox.Core.Value(this.geomFiles[key]);
				case "fovaFiles":
					return new Fox.Core.Value(this.fovaFiles[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "partsFiles":
					if (this.partsFiles.ContainsKey(key))
						this.partsFiles[key] = value.GetValueAsFilePtr();
					else
						this.partsFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "vfxFiles":
					if (this.vfxFiles.ContainsKey(key))
						this.vfxFiles[key] = value.GetValueAsFilePtr();
					else
						this.vfxFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "fmdlFiles":
					if (this.fmdlFiles.ContainsKey(key))
						this.fmdlFiles[key] = value.GetValueAsFilePtr();
					else
						this.fmdlFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "geomFiles":
					if (this.geomFiles.ContainsKey(key))
						this.geomFiles[key] = value.GetValueAsFilePtr();
					else
						this.geomFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "fovaFiles":
					if (this.fovaFiles.ContainsKey(key))
						this.fovaFiles[key] = value.GetValueAsFilePtr();
					else
						this.fovaFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}