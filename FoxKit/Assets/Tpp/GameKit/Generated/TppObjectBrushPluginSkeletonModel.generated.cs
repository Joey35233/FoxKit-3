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
	[UnityEditor.InitializeOnLoad]
	public partial class TppObjectBrushPluginSkeletonModel : Fox.GameKit.ObjectBrushPlugin
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.FilePtr> modelFile { get; private set; } = new Fox.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.FilePtr> geomFile { get; private set; } = new Fox.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Path> animFile { get; private set; } = new Fox.DynamicArray<Fox.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Path> animWindyFile { get; private set; } = new Fox.DynamicArray<Fox.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr mtarFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string soundSeType { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float minSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float maxSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isGeomActivity { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float thinkOutRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float extensionRadius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint reserveResourcePlugin { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint reserveResourcePerBlock { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float[] lodLength { get; private set; } = new float[4];
		
		[field: UnityEngine.SerializeField]
		public float[] lodLengthForHighEnd { get; private set; } = new float[4];
		
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
		static TppObjectBrushPluginSkeletonModel()
		{
			if (Fox.GameKit.ObjectBrushPlugin.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppObjectBrushPluginSkeletonModel", typeof(TppObjectBrushPluginSkeletonModel), Fox.GameKit.ObjectBrushPlugin.ClassInfo, 248, null, 7);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("modelFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("geomFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 160, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("animFile", Fox.Core.PropertyInfo.PropertyType.Path, 176, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("animWindyFile", Fox.Core.PropertyInfo.PropertyType.Path, 192, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mtarFile", Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("soundSeType", Fox.Core.PropertyInfo.PropertyType.String, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("minSize", Fox.Core.PropertyInfo.PropertyType.Float, 256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxSize", Fox.Core.PropertyInfo.PropertyType.Float, 260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isGeomActivity", Fox.Core.PropertyInfo.PropertyType.Bool, 264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("thinkOutRate", Fox.Core.PropertyInfo.PropertyType.Float, 268, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("extensionRadius", Fox.Core.PropertyInfo.PropertyType.Float, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reserveResourcePlugin", Fox.Core.PropertyInfo.PropertyType.UInt32, 276, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("reserveResourcePerBlock", Fox.Core.PropertyInfo.PropertyType.UInt32, 280, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodLength", Fox.Core.PropertyInfo.PropertyType.Float, 284, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodLengthForHighEnd", Fox.Core.PropertyInfo.PropertyType.Float, 300, 4, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "modelFile":
					return new Fox.Core.Value(modelFile);
				case "geomFile":
					return new Fox.Core.Value(geomFile);
				case "animFile":
					return new Fox.Core.Value(animFile);
				case "animWindyFile":
					return new Fox.Core.Value(animWindyFile);
				case "mtarFile":
					return new Fox.Core.Value(mtarFile);
				case "soundSeType":
					return new Fox.Core.Value(soundSeType);
				case "minSize":
					return new Fox.Core.Value(minSize);
				case "maxSize":
					return new Fox.Core.Value(maxSize);
				case "isGeomActivity":
					return new Fox.Core.Value(isGeomActivity);
				case "thinkOutRate":
					return new Fox.Core.Value(thinkOutRate);
				case "extensionRadius":
					return new Fox.Core.Value(extensionRadius);
				case "reserveResourcePlugin":
					return new Fox.Core.Value(reserveResourcePlugin);
				case "reserveResourcePerBlock":
					return new Fox.Core.Value(reserveResourcePerBlock);
				case "lodLength":
					return new Fox.Core.Value(lodLength);
				case "lodLengthForHighEnd":
					return new Fox.Core.Value(lodLengthForHighEnd);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "modelFile":
					return new Fox.Core.Value(this.modelFile[index]);
				case "geomFile":
					return new Fox.Core.Value(this.geomFile[index]);
				case "animFile":
					return new Fox.Core.Value(this.animFile[index]);
				case "animWindyFile":
					return new Fox.Core.Value(this.animWindyFile[index]);
				case "lodLength":
					return new Fox.Core.Value(this.lodLength[index]);
				case "lodLengthForHighEnd":
					return new Fox.Core.Value(this.lodLengthForHighEnd[index]);
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
				case "mtarFile":
					this.mtarFile = value.GetValueAsFilePtr();
					return;
				case "soundSeType":
					this.soundSeType = value.GetValueAsString();
					return;
				case "minSize":
					this.minSize = value.GetValueAsFloat();
					return;
				case "maxSize":
					this.maxSize = value.GetValueAsFloat();
					return;
				case "isGeomActivity":
					this.isGeomActivity = value.GetValueAsBool();
					return;
				case "thinkOutRate":
					this.thinkOutRate = value.GetValueAsFloat();
					return;
				case "extensionRadius":
					this.extensionRadius = value.GetValueAsFloat();
					return;
				case "reserveResourcePlugin":
					this.reserveResourcePlugin = value.GetValueAsUInt32();
					return;
				case "reserveResourcePerBlock":
					this.reserveResourcePerBlock = value.GetValueAsUInt32();
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
				case "modelFile":
					while(this.modelFile.Count <= index) { this.modelFile.Add(default(Fox.Core.FilePtr)); }
					this.modelFile[index] = value.GetValueAsFilePtr();
					return;
				case "geomFile":
					while(this.geomFile.Count <= index) { this.geomFile.Add(default(Fox.Core.FilePtr)); }
					this.geomFile[index] = value.GetValueAsFilePtr();
					return;
				case "animFile":
					while(this.animFile.Count <= index) { this.animFile.Add(default(Fox.Path)); }
					this.animFile[index] = value.GetValueAsPath();
					return;
				case "animWindyFile":
					while(this.animWindyFile.Count <= index) { this.animWindyFile.Add(default(Fox.Path)); }
					this.animWindyFile[index] = value.GetValueAsPath();
					return;
				case "lodLength":
					
					this.lodLength[index] = value.GetValueAsFloat();
					return;
				case "lodLengthForHighEnd":
					
					this.lodLengthForHighEnd[index] = value.GetValueAsFloat();
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