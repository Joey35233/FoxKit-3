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
		public Fox.DynamicArray<Fox.Core.EntityLink> shapes { get; private set; } = new Fox.DynamicArray<Fox.Core.EntityLink>();
		
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
				classInfo = new Fox.Core.EntityInfo("TppLensFlareRoot", typeof(TppLensFlareRoot), Tpp.Effect.TppLensFlareRootBase.ClassInfo, 0, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useDebugLightPosition", Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightPositionX", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lightPositionY", Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shieldCheckLength", Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shapes", Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
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

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "shapes":
					return new Fox.Core.Value(this.shapes[index]);
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

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
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