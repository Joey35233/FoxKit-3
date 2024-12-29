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
	[UnityEditor.InitializeOnLoad]
	public partial class SubtitlesPackage : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.FilePtr> subtitlesPackage { get; private set; } = new Fox.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.DynamicArray<Fox.Core.FilePtr> subtitlesStreamData { get; private set; } = new Fox.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.DynamicArray<Fox.Path> subtitlesStreamPath { get; private set; } = new Fox.DynamicArray<Fox.Path>();
		
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
		static SubtitlesPackage()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("SubtitlesPackage", typeof(SubtitlesPackage), Fox.Core.Data.ClassInfo, 112, "Subtitles", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("subtitlesPackage", Fox.Core.PropertyInfo.PropertyType.FilePtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("subtitlesStreamData", Fox.Core.PropertyInfo.PropertyType.FilePtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("subtitlesStreamPath", Fox.Core.PropertyInfo.PropertyType.Path, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "subtitlesPackage":
					return new Fox.Core.Value(subtitlesPackage);
				case "subtitlesStreamData":
					return new Fox.Core.Value(subtitlesStreamData);
				case "subtitlesStreamPath":
					return new Fox.Core.Value(subtitlesStreamPath);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "subtitlesPackage":
					return new Fox.Core.Value(this.subtitlesPackage[index]);
				case "subtitlesStreamData":
					return new Fox.Core.Value(this.subtitlesStreamData[index]);
				case "subtitlesStreamPath":
					return new Fox.Core.Value(this.subtitlesStreamPath[index]);
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
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "subtitlesPackage":
					while(this.subtitlesPackage.Count <= index) { this.subtitlesPackage.Add(default(Fox.Core.FilePtr)); }
					this.subtitlesPackage[index] = value.GetValueAsFilePtr();
					return;
				case "subtitlesStreamData":
					while(this.subtitlesStreamData.Count <= index) { this.subtitlesStreamData.Add(default(Fox.Core.FilePtr)); }
					this.subtitlesStreamData[index] = value.GetValueAsFilePtr();
					return;
				case "subtitlesStreamPath":
					while(this.subtitlesStreamPath.Count <= index) { this.subtitlesStreamPath.Add(default(Fox.Path)); }
					this.subtitlesStreamPath[index] = value.GetValueAsPath();
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