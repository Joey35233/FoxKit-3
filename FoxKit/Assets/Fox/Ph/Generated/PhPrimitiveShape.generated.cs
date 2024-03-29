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

namespace Fox.Ph
{
	[UnityEditor.InitializeOnLoad]
	public partial class PhPrimitiveShape : Fox.Ph.PhShape
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public PhPrimitiveShapeType type { get; set; }
		
		public UnityEngine.Vector3 size { get => Get_size(); set { Set_size(value); } }
		private partial UnityEngine.Vector3 Get_size();
		private partial void Set_size(UnityEngine.Vector3 value);
		
		public float radius { get => Get_radius(); set { Set_radius(value); } }
		private partial float Get_radius();
		private partial void Set_radius(float value);
		
		public float height { get => Get_height(); set { Set_height(value); } }
		private partial float Get_height();
		private partial void Set_height(float value);
		
		public float radius2 { get => Get_radius2(); set { Set_radius2(value); } }
		private partial float Get_radius2();
		private partial void Set_radius2(float value);
		
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
		static PhPrimitiveShape()
		{
			if (Fox.Ph.PhShape.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhPrimitiveShape"), typeof(PhPrimitiveShape), Fox.Ph.PhShape.ClassInfo, 272, "Ph", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("type"), Fox.Core.PropertyInfo.PropertyType.Int32, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PhPrimitiveShapeType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("size"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("radius"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("height"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("radius2"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "type":
					return new Fox.Core.Value(type);
				case "size":
					return new Fox.Core.Value(size);
				case "radius":
					return new Fox.Core.Value(radius);
				case "height":
					return new Fox.Core.Value(height);
				case "radius2":
					return new Fox.Core.Value(radius2);
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
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "type":
					this.type = (PhPrimitiveShapeType)value.GetValueAsInt32();
					return;
				case "size":
					this.size = value.GetValueAsVector3();
					return;
				case "radius":
					this.radius = value.GetValueAsFloat();
					return;
				case "height":
					this.height = value.GetValueAsFloat();
					return;
				case "radius2":
					this.radius2 = value.GetValueAsFloat();
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
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}