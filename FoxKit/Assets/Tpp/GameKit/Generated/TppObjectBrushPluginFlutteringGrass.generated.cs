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

namespace Tpp.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("TppGameKit/TppObjectBrushPluginFlutteringGrass")]
	public partial class TppObjectBrushPluginFlutteringGrass : Fox.GameKit.ObjectBrushPluginClone
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public float baseCycleSpeedRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float windAmplitude { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float windOffsetFactor { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool windDirYAxisFixZero { get; set; }
		
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
		static TppObjectBrushPluginFlutteringGrass()
		{
			if (Fox.GameKit.ObjectBrushPluginClone.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppObjectBrushPluginFlutteringGrass", typeof(TppObjectBrushPluginFlutteringGrass), Fox.GameKit.ObjectBrushPluginClone.ClassInfo, 136, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("baseCycleSpeedRate", Fox.Core.PropertyInfo.PropertyType.Float, 184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windAmplitude", Fox.Core.PropertyInfo.PropertyType.Float, 188, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windOffsetFactor", Fox.Core.PropertyInfo.PropertyType.Float, 192, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("windDirYAxisFixZero", Fox.Core.PropertyInfo.PropertyType.Bool, 196, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "baseCycleSpeedRate":
					return new Fox.Core.Value(baseCycleSpeedRate);
				case "windAmplitude":
					return new Fox.Core.Value(windAmplitude);
				case "windOffsetFactor":
					return new Fox.Core.Value(windOffsetFactor);
				case "windDirYAxisFixZero":
					return new Fox.Core.Value(windDirYAxisFixZero);
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
				case "baseCycleSpeedRate":
					this.baseCycleSpeedRate = value.GetValueAsFloat();
					return;
				case "windAmplitude":
					this.windAmplitude = value.GetValueAsFloat();
					return;
				case "windOffsetFactor":
					this.windOffsetFactor = value.GetValueAsFloat();
					return;
				case "windDirYAxisFixZero":
					this.windDirYAxisFixZero = value.GetValueAsBool();
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