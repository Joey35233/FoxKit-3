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

namespace Fox.Grx
{
	[UnityEditor.InitializeOnLoad]
	public partial class GlobalCameraSettings : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float focalDistance { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float focalLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float aperture { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shutterSpeed { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected uint flags { get; set; }
		
		public bool isIgnoreDofCameraSetting { get => Get_isIgnoreDofCameraSetting(); set { Set_isIgnoreDofCameraSetting(value); } }
		private partial bool Get_isIgnoreDofCameraSetting();
		private partial void Set_isIgnoreDofCameraSetting(bool value);
		
		public bool isIgnoreMotionBlurCameraSetting { get => Get_isIgnoreMotionBlurCameraSetting(); set { Set_isIgnoreMotionBlurCameraSetting(value); } }
		private partial bool Get_isIgnoreMotionBlurCameraSetting();
		private partial void Set_isIgnoreMotionBlurCameraSetting(bool value);
		
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
		static GlobalCameraSettings()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GlobalCameraSettings"), typeof(GlobalCameraSettings), Fox.Core.Data.ClassInfo, 0, "Config", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("focalDistance"), Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("focalLength"), Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("aperture"), Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shutterSpeed"), Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("flags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isIgnoreDofCameraSetting"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isIgnoreMotionBlurCameraSetting"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "focalDistance":
					return new Fox.Core.Value(focalDistance);
				case "focalLength":
					return new Fox.Core.Value(focalLength);
				case "aperture":
					return new Fox.Core.Value(aperture);
				case "shutterSpeed":
					return new Fox.Core.Value(shutterSpeed);
				case "flags":
					return new Fox.Core.Value(flags);
				case "isIgnoreDofCameraSetting":
					return new Fox.Core.Value(isIgnoreDofCameraSetting);
				case "isIgnoreMotionBlurCameraSetting":
					return new Fox.Core.Value(isIgnoreMotionBlurCameraSetting);
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
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "focalDistance":
					this.focalDistance = value.GetValueAsFloat();
					return;
				case "focalLength":
					this.focalLength = value.GetValueAsFloat();
					return;
				case "aperture":
					this.aperture = value.GetValueAsFloat();
					return;
				case "shutterSpeed":
					this.shutterSpeed = value.GetValueAsFloat();
					return;
				case "flags":
					this.flags = value.GetValueAsUInt32();
					return;
				case "isIgnoreDofCameraSetting":
					this.isIgnoreDofCameraSetting = value.GetValueAsBool();
					return;
				case "isIgnoreMotionBlurCameraSetting":
					this.isIgnoreMotionBlurCameraSetting = value.GetValueAsBool();
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
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}