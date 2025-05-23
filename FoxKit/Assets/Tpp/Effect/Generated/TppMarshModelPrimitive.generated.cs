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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppMarshModelPrimitive")]
	public partial class TppMarshModelPrimitive : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Path baseTexturePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path normalTexturePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path specularTexturePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path cubeMapPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool visibility { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float depthBlendLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float scrollSpeed0U { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float scrollSpeed0V { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float scrollSpeed1U { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float scrollSpeed1V { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool useHnmTexture { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool debugReset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> staticModels { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
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
		static TppMarshModelPrimitive()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppMarshModelPrimitive", typeof(TppMarshModelPrimitive), Fox.Core.Data.ClassInfo, 0, null, 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("baseTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("normalTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("specularTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("cubeMapPath", Fox.Core.PropertyInfo.PropertyType.Path, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("visibility", Fox.Core.PropertyInfo.PropertyType.Bool, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("depthBlendLength", Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scrollSpeed0U", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scrollSpeed0V", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scrollSpeed1U", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("scrollSpeed1V", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useHnmTexture", Fox.Core.PropertyInfo.PropertyType.Bool, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("debugReset", Fox.Core.PropertyInfo.PropertyType.Bool, 177, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("staticModels", Fox.Core.PropertyInfo.PropertyType.EntityLink, 184, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "baseTexturePath":
					return new Fox.Core.Value(baseTexturePath);
				case "normalTexturePath":
					return new Fox.Core.Value(normalTexturePath);
				case "specularTexturePath":
					return new Fox.Core.Value(specularTexturePath);
				case "cubeMapPath":
					return new Fox.Core.Value(cubeMapPath);
				case "visibility":
					return new Fox.Core.Value(visibility);
				case "depthBlendLength":
					return new Fox.Core.Value(depthBlendLength);
				case "scrollSpeed0U":
					return new Fox.Core.Value(scrollSpeed0U);
				case "scrollSpeed0V":
					return new Fox.Core.Value(scrollSpeed0V);
				case "scrollSpeed1U":
					return new Fox.Core.Value(scrollSpeed1U);
				case "scrollSpeed1V":
					return new Fox.Core.Value(scrollSpeed1V);
				case "useHnmTexture":
					return new Fox.Core.Value(useHnmTexture);
				case "debugReset":
					return new Fox.Core.Value(debugReset);
				case "staticModels":
					return new Fox.Core.Value(staticModels);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "staticModels":
					return new Fox.Core.Value(this.staticModels[index]);
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
				case "baseTexturePath":
					this.baseTexturePath = value.GetValueAsPath();
					return;
				case "normalTexturePath":
					this.normalTexturePath = value.GetValueAsPath();
					return;
				case "specularTexturePath":
					this.specularTexturePath = value.GetValueAsPath();
					return;
				case "cubeMapPath":
					this.cubeMapPath = value.GetValueAsPath();
					return;
				case "visibility":
					this.visibility = value.GetValueAsBool();
					return;
				case "depthBlendLength":
					this.depthBlendLength = value.GetValueAsFloat();
					return;
				case "scrollSpeed0U":
					this.scrollSpeed0U = value.GetValueAsFloat();
					return;
				case "scrollSpeed0V":
					this.scrollSpeed0V = value.GetValueAsFloat();
					return;
				case "scrollSpeed1U":
					this.scrollSpeed1U = value.GetValueAsFloat();
					return;
				case "scrollSpeed1V":
					this.scrollSpeed1V = value.GetValueAsFloat();
					return;
				case "useHnmTexture":
					this.useHnmTexture = value.GetValueAsBool();
					return;
				case "debugReset":
					this.debugReset = value.GetValueAsBool();
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
				case "staticModels":
					while(this.staticModels.Count <= index) { this.staticModels.Add(default(Fox.Core.EntityLink)); }
					this.staticModels[index] = value.GetValueAsEntityLink();
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