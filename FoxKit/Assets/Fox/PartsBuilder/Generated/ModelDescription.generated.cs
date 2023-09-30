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

namespace Fox.PartsBuilder
{
	[UnityEditor.InitializeOnLoad]
	public partial class ModelDescription : Fox.PartsBuilder.PartDescription
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr modelFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr connectPointFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr gameRigFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr helpBoneFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr lipAdjustBinaryFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr facialSettingFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> invisibleMeshNames { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public float lodFarPixelSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lodNearPixelSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float lodPolygonSize { get; set; }
		
		[field: UnityEngine.SerializeField]
		public ModelDescription_DrawRejectionLevel drawRejectionLevel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public ModelDescription_RejectFarRangeShadowCast rejectFarRangeShadowCast { get; set; }
		
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
		static ModelDescription()
		{
			if (Fox.PartsBuilder.PartDescription.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("ModelDescription"), typeof(ModelDescription), Fox.PartsBuilder.PartDescription.ClassInfo, 288, "PartsBuilder", 12);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connectPointFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 176, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("gameRigFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("helpBoneFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lipAdjustBinaryFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("facialSettingFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("invisibleMeshNames"), Fox.Core.PropertyInfo.PropertyType.String, 296, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodFarPixelSize"), Fox.Core.PropertyInfo.PropertyType.Float, 316, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodNearPixelSize"), Fox.Core.PropertyInfo.PropertyType.Float, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("lodPolygonSize"), Fox.Core.PropertyInfo.PropertyType.Float, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawRejectionLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(ModelDescription_DrawRejectionLevel), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rejectFarRangeShadowCast"), Fox.Core.PropertyInfo.PropertyType.Int32, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(ModelDescription_RejectFarRangeShadowCast), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public ModelDescription(ulong id) : base(id) { }
		public ModelDescription() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "modelFile":
					return new Fox.Core.Value(modelFile);
				case "connectPointFile":
					return new Fox.Core.Value(connectPointFile);
				case "gameRigFile":
					return new Fox.Core.Value(gameRigFile);
				case "helpBoneFile":
					return new Fox.Core.Value(helpBoneFile);
				case "lipAdjustBinaryFile":
					return new Fox.Core.Value(lipAdjustBinaryFile);
				case "facialSettingFile":
					return new Fox.Core.Value(facialSettingFile);
				case "invisibleMeshNames":
					return new Fox.Core.Value(invisibleMeshNames);
				case "lodFarPixelSize":
					return new Fox.Core.Value(lodFarPixelSize);
				case "lodNearPixelSize":
					return new Fox.Core.Value(lodNearPixelSize);
				case "lodPolygonSize":
					return new Fox.Core.Value(lodPolygonSize);
				case "drawRejectionLevel":
					return new Fox.Core.Value(drawRejectionLevel);
				case "rejectFarRangeShadowCast":
					return new Fox.Core.Value(rejectFarRangeShadowCast);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "invisibleMeshNames":
					return new Fox.Core.Value(this.invisibleMeshNames[index]);
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
				case "modelFile":
					this.modelFile = value.GetValueAsFilePtr();
					return;
				case "connectPointFile":
					this.connectPointFile = value.GetValueAsFilePtr();
					return;
				case "gameRigFile":
					this.gameRigFile = value.GetValueAsFilePtr();
					return;
				case "helpBoneFile":
					this.helpBoneFile = value.GetValueAsFilePtr();
					return;
				case "lipAdjustBinaryFile":
					this.lipAdjustBinaryFile = value.GetValueAsFilePtr();
					return;
				case "facialSettingFile":
					this.facialSettingFile = value.GetValueAsFilePtr();
					return;
				case "lodFarPixelSize":
					this.lodFarPixelSize = value.GetValueAsFloat();
					return;
				case "lodNearPixelSize":
					this.lodNearPixelSize = value.GetValueAsFloat();
					return;
				case "lodPolygonSize":
					this.lodPolygonSize = value.GetValueAsFloat();
					return;
				case "drawRejectionLevel":
					this.drawRejectionLevel = (ModelDescription_DrawRejectionLevel)value.GetValueAsInt32();
					return;
				case "rejectFarRangeShadowCast":
					this.rejectFarRangeShadowCast = (ModelDescription_RejectFarRangeShadowCast)value.GetValueAsInt32();
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
				case "invisibleMeshNames":
					while(this.invisibleMeshNames.Count <= index) { this.invisibleMeshNames.Add(default(Fox.Kernel.String)); }
					this.invisibleMeshNames[index] = value.GetValueAsString();
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