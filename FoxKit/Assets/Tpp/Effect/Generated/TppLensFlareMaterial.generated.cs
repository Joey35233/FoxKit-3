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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppEffect/TppLensFlareMaterial")]
	public partial class TppLensFlareMaterial : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Path texture { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink arcAlphaField { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float arcAlphaFadeAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float arcAlphaBaseAngle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink maskShape { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool debugDrawMaskShape { get; set; }
		
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
		static TppLensFlareMaterial()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppLensFlareMaterial", typeof(TppLensFlareMaterial), Fox.Core.Data.ClassInfo, 208, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("texture", Fox.Core.PropertyInfo.PropertyType.Path, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("arcAlphaField", Fox.Core.PropertyInfo.PropertyType.EntityLink, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("arcAlphaFadeAngle", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("arcAlphaBaseAngle", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maskShape", Fox.Core.PropertyInfo.PropertyType.EntityLink, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("debugDrawMaskShape", Fox.Core.PropertyInfo.PropertyType.Bool, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "texture":
					return new Fox.Core.Value(texture);
				case "arcAlphaField":
					return new Fox.Core.Value(arcAlphaField);
				case "arcAlphaFadeAngle":
					return new Fox.Core.Value(arcAlphaFadeAngle);
				case "arcAlphaBaseAngle":
					return new Fox.Core.Value(arcAlphaBaseAngle);
				case "maskShape":
					return new Fox.Core.Value(maskShape);
				case "debugDrawMaskShape":
					return new Fox.Core.Value(debugDrawMaskShape);
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
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "texture":
					this.texture = value.GetValueAsPath();
					return;
				case "arcAlphaField":
					this.arcAlphaField = value.GetValueAsEntityLink();
					return;
				case "arcAlphaFadeAngle":
					this.arcAlphaFadeAngle = value.GetValueAsFloat();
					return;
				case "arcAlphaBaseAngle":
					this.arcAlphaBaseAngle = value.GetValueAsFloat();
					return;
				case "maskShape":
					this.maskShape = value.GetValueAsEntityLink();
					return;
				case "debugDrawMaskShape":
					this.debugDrawMaskShape = value.GetValueAsBool();
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
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}