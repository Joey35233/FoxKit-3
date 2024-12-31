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
	public partial class UiAnimData : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr data { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr data_s { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink model { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float speed { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UiAnimDataFlag flag { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<string> srcNodeNames { get; private set; } = new Fox.DynamicArray<string>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<string> destNodeNames { get; private set; } = new Fox.DynamicArray<string>();
		
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
		static UiAnimData()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("UiAnimData", typeof(UiAnimData), Fox.Core.Data.ClassInfo, 0, "Ui", 4);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("data", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("data_s", Fox.Core.PropertyInfo.PropertyType.FilePtr, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("model", Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("speed", Fox.Core.PropertyInfo.PropertyType.Float, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("flag", Fox.Core.PropertyInfo.PropertyType.UInt32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(UiAnimDataFlag), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("srcNodeNames", Fox.Core.PropertyInfo.PropertyType.String, 216, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("destNodeNames", Fox.Core.PropertyInfo.PropertyType.String, 232, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "data":
					return new Fox.Core.Value(data);
				case "data_s":
					return new Fox.Core.Value(data_s);
				case "model":
					return new Fox.Core.Value(model);
				case "speed":
					return new Fox.Core.Value(speed);
				case "flag":
					return new Fox.Core.Value(flag);
				case "srcNodeNames":
					return new Fox.Core.Value(srcNodeNames);
				case "destNodeNames":
					return new Fox.Core.Value(destNodeNames);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "srcNodeNames":
					return new Fox.Core.Value(this.srcNodeNames[index]);
				case "destNodeNames":
					return new Fox.Core.Value(this.destNodeNames[index]);
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
				case "data":
					this.data = value.GetValueAsFilePtr();
					return;
				case "data_s":
					this.data_s = value.GetValueAsFilePtr();
					return;
				case "model":
					this.model = value.GetValueAsEntityLink();
					return;
				case "speed":
					this.speed = value.GetValueAsFloat();
					return;
				case "flag":
					this.flag = (UiAnimDataFlag)value.GetValueAsUInt32();
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
				case "srcNodeNames":
					while(this.srcNodeNames.Count <= index) { this.srcNodeNames.Add(default(string)); }
					this.srcNodeNames[index] = value.GetValueAsString();
					return;
				case "destNodeNames":
					while(this.destNodeNames.Count <= index) { this.destNodeNames.Add(default(string)); }
					this.destNodeNames[index] = value.GetValueAsString();
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