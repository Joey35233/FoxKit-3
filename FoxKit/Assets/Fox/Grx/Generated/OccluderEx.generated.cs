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

namespace Fox.Grx
{
	[UnityEditor.InitializeOnLoad]
	public partial class OccluderEx : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool isEnable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool isOneSideMode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public OccluderEx_Mode mode { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int numVertices { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StaticArray<UnityEngine.Vector3> positions { get; set; } = new Fox.Kernel.StaticArray<UnityEngine.Vector3>(7);
		
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
		static OccluderEx()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("OccluderEx"), typeof(OccluderEx), Fox.Core.TransformData.ClassInfo, 0, "Area", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isEnable"), Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isOneSideMode"), Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("mode"), Fox.Core.PropertyInfo.PropertyType.Int32, 308, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(OccluderEx_Mode), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("numVertices"), Fox.Core.PropertyInfo.PropertyType.Int32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("positions"), Fox.Core.PropertyInfo.PropertyType.Vector3, 320, 7, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public OccluderEx(ulong id) : base(id) { }
		public OccluderEx() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "isEnable":
					return new Fox.Core.Value(isEnable);
				case "isOneSideMode":
					return new Fox.Core.Value(isOneSideMode);
				case "mode":
					return new Fox.Core.Value(mode);
				case "numVertices":
					return new Fox.Core.Value(numVertices);
				case "positions":
					return new Fox.Core.Value(positions);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "positions":
					return new Fox.Core.Value(this.positions[index]);
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
				case "isEnable":
					this.isEnable = value.GetValueAsBool();
					return;
				case "isOneSideMode":
					this.isOneSideMode = value.GetValueAsBool();
					return;
				case "mode":
					this.mode = (OccluderEx_Mode)value.GetValueAsInt32();
					return;
				case "numVertices":
					this.numVertices = value.GetValueAsInt32();
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
				case "positions":
					
					this.positions[index] = value.GetValueAsVector3();
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