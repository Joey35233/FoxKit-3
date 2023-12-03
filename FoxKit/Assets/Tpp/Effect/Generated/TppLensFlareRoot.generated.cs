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
	[UnityEditor.InitializeOnLoad]
	public partial class TppLensFlareRoot : Tpp.Effect.TppLensFlareRootBase
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool useDebugLightPosition { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lightPositionX { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lightPositionY { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float shieldCheckLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> shapes { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();
		
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
		static TppLensFlareRoot()
		{
			if (Tpp.Effect.TppLensFlareRootBase.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppLensFlareRoot"), typeof(TppLensFlareRoot), Tpp.Effect.TppLensFlareRootBase.ClassInfo, 0, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("useDebugLightPosition"), Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightPositionX"), Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lightPositionY"), Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shieldCheckLength"), Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("shapes"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "useDebugLightPosition":
					return new Fox.Core.Value(useDebugLightPosition);
				case "lightPositionX":
					return new Fox.Core.Value(lightPositionX);
				case "lightPositionY":
					return new Fox.Core.Value(lightPositionY);
				case "shieldCheckLength":
					return new Fox.Core.Value(shieldCheckLength);
				case "shapes":
					return new Fox.Core.Value(shapes);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "shapes":
					return new Fox.Core.Value(this.shapes[index]);
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
				case "useDebugLightPosition":
					this.useDebugLightPosition = value.GetValueAsBool();
					return;
				case "lightPositionX":
					this.lightPositionX = value.GetValueAsFloat();
					return;
				case "lightPositionY":
					this.lightPositionY = value.GetValueAsFloat();
					return;
				case "shieldCheckLength":
					this.shieldCheckLength = value.GetValueAsFloat();
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
				case "shapes":
					while(this.shapes.Count <= index) { this.shapes.Add(default(Fox.Core.EntityLink)); }
					this.shapes[index] = value.GetValueAsEntityLink();
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