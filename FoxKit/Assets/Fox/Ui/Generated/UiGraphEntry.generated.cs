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

namespace Fox.Ui
{
	[UnityEditor.InitializeOnLoad]
	public partial class UiGraphEntry : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.FilePtr> files { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.FilePtr> rawFiles { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
		
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
		static UiGraphEntry()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UiGraphEntry"), typeof(UiGraphEntry), Fox.Core.Data.ClassInfo, 96, "Ui", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("files"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rawFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public UiGraphEntry(ulong id) : base(id) { }
		public UiGraphEntry() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "files":
					while(this.files.Count <= index) { this.files.Add(default(Fox.Core.FilePtr)); }
					this.files[index] = value.GetValueAsFilePtr();
					return;
				case "rawFiles":
					while(this.rawFiles.Count <= index) { this.rawFiles.Add(default(Fox.Core.FilePtr)); }
					this.rawFiles[index] = value.GetValueAsFilePtr();
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