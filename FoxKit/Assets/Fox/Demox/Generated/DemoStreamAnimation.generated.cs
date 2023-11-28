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

namespace Fox.Demox
{
	[UnityEditor.InitializeOnLoad]
	public partial class DemoStreamAnimation : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path streamPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint demoLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<DemoStreamAnimation_LocatorType> locatorTypes { get; private set; } = new Fox.Kernel.StringMap<DemoStreamAnimation_LocatorType>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<DemoStreamAnimation_CameraType> cameraTypes { get; private set; } = new Fox.Kernel.StringMap<DemoStreamAnimation_CameraType>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> modelFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> helpBoneFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> partsFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> coverModelFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.String> modelPartsDictionary { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.String> coverModelDictionary { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public uint updateJobCount { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.Path> modelProxyPaths { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.Path> partsProxyPaths { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demox.DemoDynamicFileChangeModel> dynamicModel { get; private set; } = new Fox.Kernel.StringMap<Fox.Demox.DemoDynamicFileChangeModel>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demox.DemoDynamicFileChangeModel> dynamicParts { get; private set; } = new Fox.Kernel.StringMap<Fox.Demox.DemoDynamicFileChangeModel>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demox.DemoFv2ResourceMemory> dynamicFv2 { get; private set; } = new Fox.Kernel.StringMap<Fox.Demox.DemoFv2ResourceMemory>();
		
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
		static DemoStreamAnimation()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("DemoStreamAnimation"), typeof(DemoStreamAnimation), Fox.Core.Data.ClassInfo, 712, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("streamPath"), Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoLength"), Fox.Core.PropertyInfo.PropertyType.UInt32, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("locatorTypes"), Fox.Core.PropertyInfo.PropertyType.Int32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DemoStreamAnimation_LocatorType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraTypes"), Fox.Core.PropertyInfo.PropertyType.Int32, 184, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(DemoStreamAnimation_CameraType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 232, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("helpBoneFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 280, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 328, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("coverModelFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 376, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelPartsDictionary"), Fox.Core.PropertyInfo.PropertyType.String, 424, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("coverModelDictionary"), Fox.Core.PropertyInfo.PropertyType.String, 472, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("updateJobCount"), Fox.Core.PropertyInfo.PropertyType.UInt32, 768, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelProxyPaths"), Fox.Core.PropertyInfo.PropertyType.Path, 520, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsProxyPaths"), Fox.Core.PropertyInfo.PropertyType.Path, 568, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dynamicModel"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 616, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demox.DemoDynamicFileChangeModel), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dynamicParts"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 664, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demox.DemoDynamicFileChangeModel), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dynamicFv2"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 712, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demox.DemoFv2ResourceMemory), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public DemoStreamAnimation(ulong id) : base(id) { }
		public DemoStreamAnimation() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "streamPath":
					return new Fox.Core.Value(streamPath);
				case "demoLength":
					return new Fox.Core.Value(demoLength);
				case "locatorTypes":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)locatorTypes);
				case "cameraTypes":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)cameraTypes);
				case "modelFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)modelFiles);
				case "helpBoneFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)helpBoneFiles);
				case "partsFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)partsFiles);
				case "coverModelFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)coverModelFiles);
				case "modelPartsDictionary":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)modelPartsDictionary);
				case "coverModelDictionary":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)coverModelDictionary);
				case "updateJobCount":
					return new Fox.Core.Value(updateJobCount);
				case "modelProxyPaths":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)modelProxyPaths);
				case "partsProxyPaths":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)partsProxyPaths);
				case "dynamicModel":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)dynamicModel);
				case "dynamicParts":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)dynamicParts);
				case "dynamicFv2":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)dynamicFv2);
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
				case "locatorTypes":
					return new Fox.Core.Value(this.locatorTypes[key]);
				case "cameraTypes":
					return new Fox.Core.Value(this.cameraTypes[key]);
				case "modelFiles":
					return new Fox.Core.Value(this.modelFiles[key]);
				case "helpBoneFiles":
					return new Fox.Core.Value(this.helpBoneFiles[key]);
				case "partsFiles":
					return new Fox.Core.Value(this.partsFiles[key]);
				case "coverModelFiles":
					return new Fox.Core.Value(this.coverModelFiles[key]);
				case "modelPartsDictionary":
					return new Fox.Core.Value(this.modelPartsDictionary[key]);
				case "coverModelDictionary":
					return new Fox.Core.Value(this.coverModelDictionary[key]);
				case "modelProxyPaths":
					return new Fox.Core.Value(this.modelProxyPaths[key]);
				case "partsProxyPaths":
					return new Fox.Core.Value(this.partsProxyPaths[key]);
				case "dynamicModel":
					return new Fox.Core.Value(this.dynamicModel[key]);
				case "dynamicParts":
					return new Fox.Core.Value(this.dynamicParts[key]);
				case "dynamicFv2":
					return new Fox.Core.Value(this.dynamicFv2[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "streamPath":
					this.streamPath = value.GetValueAsPath();
					return;
				case "demoLength":
					this.demoLength = value.GetValueAsUInt32();
					return;
				case "updateJobCount":
					this.updateJobCount = value.GetValueAsUInt32();
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
				case "locatorTypes":
					if (this.locatorTypes.ContainsKey(key))
						this.locatorTypes[key] = (DemoStreamAnimation_LocatorType)value.GetValueAsInt32();
					else
						this.locatorTypes.Insert(key, (DemoStreamAnimation_LocatorType)value.GetValueAsInt32());
					return;
				case "cameraTypes":
					if (this.cameraTypes.ContainsKey(key))
						this.cameraTypes[key] = (DemoStreamAnimation_CameraType)value.GetValueAsInt32();
					else
						this.cameraTypes.Insert(key, (DemoStreamAnimation_CameraType)value.GetValueAsInt32());
					return;
				case "modelFiles":
					if (this.modelFiles.ContainsKey(key))
						this.modelFiles[key] = value.GetValueAsFilePtr();
					else
						this.modelFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "helpBoneFiles":
					if (this.helpBoneFiles.ContainsKey(key))
						this.helpBoneFiles[key] = value.GetValueAsFilePtr();
					else
						this.helpBoneFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "partsFiles":
					if (this.partsFiles.ContainsKey(key))
						this.partsFiles[key] = value.GetValueAsFilePtr();
					else
						this.partsFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "coverModelFiles":
					if (this.coverModelFiles.ContainsKey(key))
						this.coverModelFiles[key] = value.GetValueAsFilePtr();
					else
						this.coverModelFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "modelPartsDictionary":
					if (this.modelPartsDictionary.ContainsKey(key))
						this.modelPartsDictionary[key] = value.GetValueAsString();
					else
						this.modelPartsDictionary.Insert(key, value.GetValueAsString());
					return;
				case "coverModelDictionary":
					if (this.coverModelDictionary.ContainsKey(key))
						this.coverModelDictionary[key] = value.GetValueAsString();
					else
						this.coverModelDictionary.Insert(key, value.GetValueAsString());
					return;
				case "modelProxyPaths":
					if (this.modelProxyPaths.ContainsKey(key))
						this.modelProxyPaths[key] = value.GetValueAsPath();
					else
						this.modelProxyPaths.Insert(key, value.GetValueAsPath());
					return;
				case "partsProxyPaths":
					if (this.partsProxyPaths.ContainsKey(key))
						this.partsProxyPaths[key] = value.GetValueAsPath();
					else
						this.partsProxyPaths.Insert(key, value.GetValueAsPath());
					return;
				case "dynamicModel":
					if (this.dynamicModel.ContainsKey(key))
						this.dynamicModel[key] = value.GetValueAsEntityPtr<Fox.Demox.DemoDynamicFileChangeModel>();
					else
						this.dynamicModel.Insert(key, value.GetValueAsEntityPtr<Fox.Demox.DemoDynamicFileChangeModel>());
					return;
				case "dynamicParts":
					if (this.dynamicParts.ContainsKey(key))
						this.dynamicParts[key] = value.GetValueAsEntityPtr<Fox.Demox.DemoDynamicFileChangeModel>();
					else
						this.dynamicParts.Insert(key, value.GetValueAsEntityPtr<Fox.Demox.DemoDynamicFileChangeModel>());
					return;
				case "dynamicFv2":
					if (this.dynamicFv2.ContainsKey(key))
						this.dynamicFv2[key] = value.GetValueAsEntityPtr<Fox.Demox.DemoFv2ResourceMemory>();
					else
						this.dynamicFv2.Insert(key, value.GetValueAsEntityPtr<Fox.Demox.DemoFv2ResourceMemory>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}