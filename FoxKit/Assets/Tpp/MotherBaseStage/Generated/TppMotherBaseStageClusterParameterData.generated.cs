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

namespace Tpp.MotherBaseStage
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppMotherBaseStageClusterParameterData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster00divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster01divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster02divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster03divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster04divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster05divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster06divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<byte> cluster07divisionPackageIds { get; set; } = new Fox.Kernel.StaticArray<byte>(12);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<UnityEngine.Vector3> clusterPositions { get; set; } = new Fox.Kernel.StaticArray<UnityEngine.Vector3>(8);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<uint> clusterRequestRadiuses { get; set; } = new Fox.Kernel.StaticArray<uint>(8);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<uint> clusterRequireRadiuses { get; set; } = new Fox.Kernel.StaticArray<uint>(8);
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster00loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster01loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster02loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster03loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster04loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster05loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster06loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<short> cluster07loadAreaVertices { get; set; } = new Fox.Kernel.DynamicArray<short>();
		
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
		static TppMotherBaseStageClusterParameterData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppMotherBaseStageClusterParameterData"), typeof(TppMotherBaseStageClusterParameterData), Fox.Core.Data.ClassInfo, 496, null, 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 544, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster00divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 120, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster01divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 132, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster02divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 144, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster03divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 156, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster04divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 168, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster05divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 180, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster06divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 192, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster07divisionPackageIds"), Fox.Core.PropertyInfo.PropertyType.UInt8, 204, 12, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("clusterPositions"), Fox.Core.PropertyInfo.PropertyType.Vector3, 224, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("clusterRequestRadiuses"), Fox.Core.PropertyInfo.PropertyType.UInt32, 352, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("clusterRequireRadiuses"), Fox.Core.PropertyInfo.PropertyType.UInt32, 384, 8, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster00loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster01loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 432, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster02loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 448, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster03loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 464, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster04loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 480, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster05loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 496, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster06loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 512, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cluster07loadAreaVertices"), Fox.Core.PropertyInfo.PropertyType.Int16, 528, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppMotherBaseStageClusterParameterData(ulong id) : base(id) { }
		public TppMotherBaseStageClusterParameterData() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "cluster00divisionPackageIds":
					
					this.cluster00divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster01divisionPackageIds":
					
					this.cluster01divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster02divisionPackageIds":
					
					this.cluster02divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster03divisionPackageIds":
					
					this.cluster03divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster04divisionPackageIds":
					
					this.cluster04divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster05divisionPackageIds":
					
					this.cluster05divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster06divisionPackageIds":
					
					this.cluster06divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "cluster07divisionPackageIds":
					
					this.cluster07divisionPackageIds[index] = value.GetValueAsUInt8();
					return;
				case "clusterPositions":
					
					this.clusterPositions[index] = value.GetValueAsVector3();
					return;
				case "clusterRequestRadiuses":
					
					this.clusterRequestRadiuses[index] = value.GetValueAsUInt32();
					return;
				case "clusterRequireRadiuses":
					
					this.clusterRequireRadiuses[index] = value.GetValueAsUInt32();
					return;
				case "cluster00loadAreaVertices":
					while(this.cluster00loadAreaVertices.Count <= index) { this.cluster00loadAreaVertices.Add(default(short)); }
					this.cluster00loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster01loadAreaVertices":
					while(this.cluster01loadAreaVertices.Count <= index) { this.cluster01loadAreaVertices.Add(default(short)); }
					this.cluster01loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster02loadAreaVertices":
					while(this.cluster02loadAreaVertices.Count <= index) { this.cluster02loadAreaVertices.Add(default(short)); }
					this.cluster02loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster03loadAreaVertices":
					while(this.cluster03loadAreaVertices.Count <= index) { this.cluster03loadAreaVertices.Add(default(short)); }
					this.cluster03loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster04loadAreaVertices":
					while(this.cluster04loadAreaVertices.Count <= index) { this.cluster04loadAreaVertices.Add(default(short)); }
					this.cluster04loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster05loadAreaVertices":
					while(this.cluster05loadAreaVertices.Count <= index) { this.cluster05loadAreaVertices.Add(default(short)); }
					this.cluster05loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster06loadAreaVertices":
					while(this.cluster06loadAreaVertices.Count <= index) { this.cluster06loadAreaVertices.Add(default(short)); }
					this.cluster06loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				case "cluster07loadAreaVertices":
					while(this.cluster07loadAreaVertices.Count <= index) { this.cluster07loadAreaVertices.Add(default(short)); }
					this.cluster07loadAreaVertices[index] = value.GetValueAsInt16();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}