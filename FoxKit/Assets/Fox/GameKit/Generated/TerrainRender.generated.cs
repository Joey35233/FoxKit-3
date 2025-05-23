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

namespace Fox.GameKit
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxGameKit/TerrainRender")]
	public partial class TerrainRender : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Path filePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path loadFilePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path dummyFilePath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr filePtr { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float meterPerOneRepeat { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float meterPerPixel { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isWireFrame { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool lodFlag { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isDebugMaterial { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink[] materials { get; private set; } = new Fox.Core.EntityLink[16];
		
		[field: UnityEngine.SerializeField]
		public float lodParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Core.EntityLink> materialConfigs { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Path packedAlbedoTexturePath { get; protected set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path packedNormalTexturePath { get; protected set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path packedSrmTexturePath { get; protected set; }
		
		[field: UnityEngine.SerializeField]
		public ulong packedMaterialIdentify { get; protected set; }
		
		[field: UnityEngine.SerializeField]
		public bool isFourceUsePackedMaterialTexture { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Path baseColorTexture { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float materialLodScale { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float materialLodNearOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float materialLodFarOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float materialLodHeightOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		public WolrdTerrainTextureMode worldTextureMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint worldTextureDividedNumX { get; set; }
		
		[field: UnityEngine.SerializeField]
		public uint worldTextureDividedNumZ { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.Path> worldTextureTilePathes { get; private set; } = new CsSystem.Collections.Generic.List<Fox.Path>();
		
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
		static TerrainRender()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TerrainRender", typeof(TerrainRender), Fox.Core.TransformData.ClassInfo, 960, null, 9);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("filePath", Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("loadFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dummyFilePath", Fox.Core.PropertyInfo.PropertyType.Path, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("filePtr", Fox.Core.PropertyInfo.PropertyType.FilePtr, 968, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("meterPerOneRepeat", Fox.Core.PropertyInfo.PropertyType.Float, 996, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("meterPerPixel", Fox.Core.PropertyInfo.PropertyType.Float, 1000, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isWireFrame", Fox.Core.PropertyInfo.PropertyType.Bool, 992, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodFlag", Fox.Core.PropertyInfo.PropertyType.Bool, 993, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isDebugMaterial", Fox.Core.PropertyInfo.PropertyType.Bool, 1004, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materials", Fox.Core.PropertyInfo.PropertyType.EntityLink, 328, 16, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("lodParam", Fox.Core.PropertyInfo.PropertyType.Float, 1008, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialConfigs", Fox.Core.PropertyInfo.PropertyType.EntityLink, 1080, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("packedAlbedoTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 1104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("packedNormalTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 1112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("packedSrmTexturePath", Fox.Core.PropertyInfo.PropertyType.Path, 1120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("packedMaterialIdentify", Fox.Core.PropertyInfo.PropertyType.UInt64, 1096, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isFourceUsePackedMaterialTexture", Fox.Core.PropertyInfo.PropertyType.Bool, 1072, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("baseColorTexture", Fox.Core.PropertyInfo.PropertyType.Path, 1016, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodScale", Fox.Core.PropertyInfo.PropertyType.Float, 1024, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodNearOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1032, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodFarOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1028, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("materialLodHeightOffset", Fox.Core.PropertyInfo.PropertyType.Float, 1036, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldTextureMode", Fox.Core.PropertyInfo.PropertyType.Int32, 1044, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(WolrdTerrainTextureMode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldTextureDividedNumX", Fox.Core.PropertyInfo.PropertyType.UInt32, 1048, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldTextureDividedNumZ", Fox.Core.PropertyInfo.PropertyType.UInt32, 1052, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("worldTextureTilePathes", Fox.Core.PropertyInfo.PropertyType.Path, 1056, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "filePath":
					return new Fox.Core.Value(filePath);
				case "loadFilePath":
					return new Fox.Core.Value(loadFilePath);
				case "dummyFilePath":
					return new Fox.Core.Value(dummyFilePath);
				case "filePtr":
					return new Fox.Core.Value(filePtr);
				case "meterPerOneRepeat":
					return new Fox.Core.Value(meterPerOneRepeat);
				case "meterPerPixel":
					return new Fox.Core.Value(meterPerPixel);
				case "isWireFrame":
					return new Fox.Core.Value(isWireFrame);
				case "lodFlag":
					return new Fox.Core.Value(lodFlag);
				case "isDebugMaterial":
					return new Fox.Core.Value(isDebugMaterial);
				case "materials":
					return new Fox.Core.Value(materials);
				case "lodParam":
					return new Fox.Core.Value(lodParam);
				case "materialConfigs":
					return new Fox.Core.Value(materialConfigs);
				case "packedAlbedoTexturePath":
					return new Fox.Core.Value(packedAlbedoTexturePath);
				case "packedNormalTexturePath":
					return new Fox.Core.Value(packedNormalTexturePath);
				case "packedSrmTexturePath":
					return new Fox.Core.Value(packedSrmTexturePath);
				case "packedMaterialIdentify":
					return new Fox.Core.Value(packedMaterialIdentify);
				case "isFourceUsePackedMaterialTexture":
					return new Fox.Core.Value(isFourceUsePackedMaterialTexture);
				case "baseColorTexture":
					return new Fox.Core.Value(baseColorTexture);
				case "materialLodScale":
					return new Fox.Core.Value(materialLodScale);
				case "materialLodNearOffset":
					return new Fox.Core.Value(materialLodNearOffset);
				case "materialLodFarOffset":
					return new Fox.Core.Value(materialLodFarOffset);
				case "materialLodHeightOffset":
					return new Fox.Core.Value(materialLodHeightOffset);
				case "worldTextureMode":
					return new Fox.Core.Value(worldTextureMode);
				case "worldTextureDividedNumX":
					return new Fox.Core.Value(worldTextureDividedNumX);
				case "worldTextureDividedNumZ":
					return new Fox.Core.Value(worldTextureDividedNumZ);
				case "worldTextureTilePathes":
					return new Fox.Core.Value(worldTextureTilePathes);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "materials":
					return new Fox.Core.Value(this.materials[index]);
				case "materialConfigs":
					return new Fox.Core.Value(this.materialConfigs[index]);
				case "worldTextureTilePathes":
					return new Fox.Core.Value(this.worldTextureTilePathes[index]);
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
				case "filePath":
					this.filePath = value.GetValueAsPath();
					return;
				case "loadFilePath":
					this.loadFilePath = value.GetValueAsPath();
					return;
				case "dummyFilePath":
					this.dummyFilePath = value.GetValueAsPath();
					return;
				case "filePtr":
					this.filePtr = value.GetValueAsFilePtr();
					return;
				case "meterPerOneRepeat":
					this.meterPerOneRepeat = value.GetValueAsFloat();
					return;
				case "meterPerPixel":
					this.meterPerPixel = value.GetValueAsFloat();
					return;
				case "isWireFrame":
					this.isWireFrame = value.GetValueAsBool();
					return;
				case "lodFlag":
					this.lodFlag = value.GetValueAsBool();
					return;
				case "isDebugMaterial":
					this.isDebugMaterial = value.GetValueAsBool();
					return;
				case "lodParam":
					this.lodParam = value.GetValueAsFloat();
					return;
				case "packedAlbedoTexturePath":
					this.packedAlbedoTexturePath = value.GetValueAsPath();
					return;
				case "packedNormalTexturePath":
					this.packedNormalTexturePath = value.GetValueAsPath();
					return;
				case "packedSrmTexturePath":
					this.packedSrmTexturePath = value.GetValueAsPath();
					return;
				case "packedMaterialIdentify":
					this.packedMaterialIdentify = value.GetValueAsUInt64();
					return;
				case "isFourceUsePackedMaterialTexture":
					this.isFourceUsePackedMaterialTexture = value.GetValueAsBool();
					return;
				case "baseColorTexture":
					this.baseColorTexture = value.GetValueAsPath();
					return;
				case "materialLodScale":
					this.materialLodScale = value.GetValueAsFloat();
					return;
				case "materialLodNearOffset":
					this.materialLodNearOffset = value.GetValueAsFloat();
					return;
				case "materialLodFarOffset":
					this.materialLodFarOffset = value.GetValueAsFloat();
					return;
				case "materialLodHeightOffset":
					this.materialLodHeightOffset = value.GetValueAsFloat();
					return;
				case "worldTextureMode":
					this.worldTextureMode = (WolrdTerrainTextureMode)value.GetValueAsInt32();
					return;
				case "worldTextureDividedNumX":
					this.worldTextureDividedNumX = value.GetValueAsUInt32();
					return;
				case "worldTextureDividedNumZ":
					this.worldTextureDividedNumZ = value.GetValueAsUInt32();
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
				case "materials":
					
					this.materials[index] = value.GetValueAsEntityLink();
					return;
				case "materialConfigs":
					while(this.materialConfigs.Count <= index) { this.materialConfigs.Add(default(Fox.Core.EntityLink)); }
					this.materialConfigs[index] = value.GetValueAsEntityLink();
					return;
				case "worldTextureTilePathes":
					while(this.worldTextureTilePathes.Count <= index) { this.worldTextureTilePathes.Add(default(Fox.Path)); }
					this.worldTextureTilePathes[index] = value.GetValueAsPath();
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