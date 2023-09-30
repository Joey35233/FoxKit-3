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
	public partial class TppModelMarkerFilterSettings : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float texRepeatsNear { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float texRepeatsFar { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float texRepeatsMin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float texRepeatsMax { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<UnityEngine.Vector3> alphas { get; private set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<UnityEngine.Vector3> offsets { get; private set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<UnityEngine.Vector3> incidences { get; private set; } = new Fox.Kernel.DynamicArray<UnityEngine.Vector3>();
		
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
		static TppModelMarkerFilterSettings()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppModelMarkerFilterSettings"), typeof(TppModelMarkerFilterSettings), Fox.Core.Data.ClassInfo, 128, "TppEffect", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("texRepeatsNear"), Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("texRepeatsFar"), Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("texRepeatsMin"), Fox.Core.PropertyInfo.PropertyType.Float, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("texRepeatsMax"), Fox.Core.PropertyInfo.PropertyType.Float, 180, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("alphas"), Fox.Core.PropertyInfo.PropertyType.Vector3, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("offsets"), Fox.Core.PropertyInfo.PropertyType.Vector3, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("incidences"), Fox.Core.PropertyInfo.PropertyType.Vector3, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppModelMarkerFilterSettings(ulong id) : base(id) { }
		public TppModelMarkerFilterSettings() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "texRepeatsNear":
					return new Fox.Core.Value(texRepeatsNear);
				case "texRepeatsFar":
					return new Fox.Core.Value(texRepeatsFar);
				case "texRepeatsMin":
					return new Fox.Core.Value(texRepeatsMin);
				case "texRepeatsMax":
					return new Fox.Core.Value(texRepeatsMax);
				case "alphas":
					return new Fox.Core.Value(alphas);
				case "offsets":
					return new Fox.Core.Value(offsets);
				case "incidences":
					return new Fox.Core.Value(incidences);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "alphas":
					return new Fox.Core.Value(this.alphas[index]);
				case "offsets":
					return new Fox.Core.Value(this.offsets[index]);
				case "incidences":
					return new Fox.Core.Value(this.incidences[index]);
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
				case "texRepeatsNear":
					this.texRepeatsNear = value.GetValueAsFloat();
					return;
				case "texRepeatsFar":
					this.texRepeatsFar = value.GetValueAsFloat();
					return;
				case "texRepeatsMin":
					this.texRepeatsMin = value.GetValueAsFloat();
					return;
				case "texRepeatsMax":
					this.texRepeatsMax = value.GetValueAsFloat();
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
				case "alphas":
					while(this.alphas.Count <= index) { this.alphas.Add(default(UnityEngine.Vector3)); }
					this.alphas[index] = value.GetValueAsVector3();
					return;
				case "offsets":
					while(this.offsets.Count <= index) { this.offsets.Add(default(UnityEngine.Vector3)); }
					this.offsets[index] = value.GetValueAsVector3();
					return;
				case "incidences":
					while(this.incidences.Count <= index) { this.incidences.Add(default(UnityEngine.Vector3)); }
					this.incidences[index] = value.GetValueAsVector3();
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