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

namespace Fox.Sim
{
	[UnityEditor.InitializeOnLoad]
	public partial class SimOnPhysics : Fox.Sim.SimObject
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit> simRootBones { get; private set; } = new Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit> simBones { get; private set; } = new Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit> simTransBones { get; private set; } = new Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit> simHitBones { get; private set; } = new Fox.Kernel.StringMap<Fox.Sim.SimAssociationUnit>();
		
		[field: UnityEngine.SerializeField]
		public uint formatVersion { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink physicsData { get; set; }
		
		public SimLodLevelName minLodLevel { get => Get_minLodLevel(); set { Set_minLodLevel(value); } }
		private partial SimLodLevelName Get_minLodLevel();
		private partial void Set_minLodLevel(SimLodLevelName value);
		
		public SimLodLevelName maxLodLevel { get => Get_maxLodLevel(); set { Set_maxLodLevel(value); } }
		private partial SimLodLevelName Get_maxLodLevel();
		private partial void Set_maxLodLevel(SimLodLevelName value);
		
		public bool isEnableGeoCheck { get => Get_isEnableGeoCheck(); set { Set_isEnableGeoCheck(value); } }
		private partial bool Get_isEnableGeoCheck();
		private partial void Set_isEnableGeoCheck(bool value);
		
		public bool convertMoveToWind { get => Get_convertMoveToWind(); set { Set_convertMoveToWind(value); } }
		private partial bool Get_convertMoveToWind();
		private partial void Set_convertMoveToWind(bool value);
		
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
		static SimOnPhysics()
		{
			if (Fox.Sim.SimObject.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimOnPhysics"), typeof(SimOnPhysics), Fox.Sim.SimObject.ClassInfo, 328, "Sim", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simRootBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 152, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 200, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simTransBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 248, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("simHitBones"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 296, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Sim.SimAssociationUnit), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("formatVersion"), Fox.Core.PropertyInfo.PropertyType.UInt32, 344, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("physicsData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("minLodLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxLodLevel"), Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SimLodLevelName), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isEnableGeoCheck"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("convertMoveToWind"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public SimOnPhysics(ulong id) : base(id) { }
		public SimOnPhysics() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "simRootBones":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)simRootBones);
				case "simBones":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)simBones);
				case "simTransBones":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)simTransBones);
				case "simHitBones":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)simHitBones);
				case "formatVersion":
					return new Fox.Core.Value(formatVersion);
				case "physicsData":
					return new Fox.Core.Value(physicsData);
				case "minLodLevel":
					return new Fox.Core.Value(minLodLevel);
				case "maxLodLevel":
					return new Fox.Core.Value(maxLodLevel);
				case "isEnableGeoCheck":
					return new Fox.Core.Value(isEnableGeoCheck);
				case "convertMoveToWind":
					return new Fox.Core.Value(convertMoveToWind);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				case "simRootBones":
					return new Fox.Core.Value(this.simRootBones[key]);
				case "simBones":
					return new Fox.Core.Value(this.simBones[key]);
				case "simTransBones":
					return new Fox.Core.Value(this.simTransBones[key]);
				case "simHitBones":
					return new Fox.Core.Value(this.simHitBones[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "formatVersion":
					this.formatVersion = value.GetValueAsUInt32();
					return;
				case "physicsData":
					this.physicsData = value.GetValueAsEntityLink();
					return;
				case "minLodLevel":
					this.minLodLevel = (SimLodLevelName)value.GetValueAsInt32();
					return;
				case "maxLodLevel":
					this.maxLodLevel = (SimLodLevelName)value.GetValueAsInt32();
					return;
				case "isEnableGeoCheck":
					this.isEnableGeoCheck = value.GetValueAsBool();
					return;
				case "convertMoveToWind":
					this.convertMoveToWind = value.GetValueAsBool();
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
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "simRootBones":
					if (this.simRootBones.ContainsKey(key))
						this.simRootBones[key] = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>();
					else
						this.simRootBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
					return;
				case "simBones":
					if (this.simBones.ContainsKey(key))
						this.simBones[key] = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>();
					else
						this.simBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
					return;
				case "simTransBones":
					if (this.simTransBones.ContainsKey(key))
						this.simTransBones[key] = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>();
					else
						this.simTransBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
					return;
				case "simHitBones":
					if (this.simHitBones.ContainsKey(key))
						this.simHitBones[key] = value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>();
					else
						this.simHitBones.Insert(key, value.GetValueAsEntityPtr<Fox.Sim.SimAssociationUnit>());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}