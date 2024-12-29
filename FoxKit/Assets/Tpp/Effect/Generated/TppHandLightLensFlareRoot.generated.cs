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
	public partial class TppHandLightLensFlareRoot : Tpp.Effect.TppLensFlareRootBase
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool independentEditMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool takeover { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool debugFillCheck { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool needCollisionCheck { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float exposureBlend { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string lensFlareName { get; set; }
		
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
		static TppHandLightLensFlareRoot()
		{
			if (Tpp.Effect.TppLensFlareRootBase.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppHandLightLensFlareRoot", typeof(TppHandLightLensFlareRoot), Tpp.Effect.TppLensFlareRootBase.ClassInfo, 688, null, 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("independentEditMode", Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("takeover", Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("debugFillCheck", Fox.Core.PropertyInfo.PropertyType.Bool, 306, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("needCollisionCheck", Fox.Core.PropertyInfo.PropertyType.Bool, 307, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("exposureBlend", Fox.Core.PropertyInfo.PropertyType.Float, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lensFlareName", Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("shapes", Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "independentEditMode":
					return new Fox.Core.Value(independentEditMode);
				case "takeover":
					return new Fox.Core.Value(takeover);
				case "debugFillCheck":
					return new Fox.Core.Value(debugFillCheck);
				case "needCollisionCheck":
					return new Fox.Core.Value(needCollisionCheck);
				case "exposureBlend":
					return new Fox.Core.Value(exposureBlend);
				case "lensFlareName":
					return new Fox.Core.Value(lensFlareName);
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
				case "independentEditMode":
					this.independentEditMode = value.GetValueAsBool();
					return;
				case "takeover":
					this.takeover = value.GetValueAsBool();
					return;
				case "debugFillCheck":
					this.debugFillCheck = value.GetValueAsBool();
					return;
				case "needCollisionCheck":
					this.needCollisionCheck = value.GetValueAsBool();
					return;
				case "exposureBlend":
					this.exposureBlend = value.GetValueAsFloat();
					return;
				case "lensFlareName":
					this.lensFlareName = value.GetValueAsString();
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