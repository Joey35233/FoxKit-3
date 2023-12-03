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

namespace Fox.UiScene
{
	[UnityEditor.InitializeOnLoad]
	public partial class UiLayoutData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path layoutPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Color color { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool visible { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int drawPriority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.Entity connection_connectModelDataHandle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String connection_connectModelNodeName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool useParentCamera { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int fontTableIndex { get; set; }
		
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
		static UiLayoutData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UiLayoutData"), typeof(UiLayoutData), Fox.Core.TransformData.ClassInfo, 0, "Ui", 6);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("layoutPath"), Fox.Core.PropertyInfo.PropertyType.Path, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("visible"), Fox.Core.PropertyInfo.PropertyType.Bool, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("drawPriority"), Fox.Core.PropertyInfo.PropertyType.Int32, 340, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connection_connectModelDataHandle"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 352, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connection_connectModelNodeName"), Fox.Core.PropertyInfo.PropertyType.String, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("useParentCamera"), Fox.Core.PropertyInfo.PropertyType.Bool, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fontTableIndex"), Fox.Core.PropertyInfo.PropertyType.Int32, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "layoutPath":
					return new Fox.Core.Value(layoutPath);
				case "color":
					return new Fox.Core.Value(color);
				case "visible":
					return new Fox.Core.Value(visible);
				case "drawPriority":
					return new Fox.Core.Value(drawPriority);
				case "connection_connectModelDataHandle":
					return new Fox.Core.Value(connection_connectModelDataHandle);
				case "connection_connectModelNodeName":
					return new Fox.Core.Value(connection_connectModelNodeName);
				case "useParentCamera":
					return new Fox.Core.Value(useParentCamera);
				case "fontTableIndex":
					return new Fox.Core.Value(fontTableIndex);
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
				case "layoutPath":
					this.layoutPath = value.GetValueAsPath();
					return;
				case "color":
					this.color = value.GetValueAsColor();
					return;
				case "visible":
					this.visible = value.GetValueAsBool();
					return;
				case "drawPriority":
					this.drawPriority = value.GetValueAsInt32();
					return;
				case "connection_connectModelDataHandle":
					this.connection_connectModelDataHandle = value.GetValueAsEntityHandle();
					return;
				case "connection_connectModelNodeName":
					this.connection_connectModelNodeName = value.GetValueAsString();
					return;
				case "useParentCamera":
					this.useParentCamera = value.GetValueAsBool();
					return;
				case "fontTableIndex":
					this.fontTableIndex = value.GetValueAsInt32();
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