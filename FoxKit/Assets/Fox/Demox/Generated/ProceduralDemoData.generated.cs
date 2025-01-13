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

namespace Fox.Demox
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Demox/ProceduralDemoData")]
	public partial class ProceduralDemoData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> evfFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> eventFiles { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public int priority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string demoId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<string> stringParams { get; private set; } = new CsSystem.Collections.Generic.List<string>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.EntityLink> entityParams { get; private set; } = new Fox.StringMap<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<Fox.Core.FilePtr> fileParams { get; private set; } = new Fox.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.StringMap<int> objectNum { get; private set; } = new Fox.StringMap<int>();
		
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
		static ProceduralDemoData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("ProceduralDemoData", typeof(ProceduralDemoData), Fox.Core.TransformData.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("evfFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("eventFiles", Fox.Core.PropertyInfo.PropertyType.FilePtr, 352, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("priority", Fox.Core.PropertyInfo.PropertyType.Int32, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("demoId", Fox.Core.PropertyInfo.PropertyType.String, 408, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("stringParams", Fox.Core.PropertyInfo.PropertyType.String, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("entityParams", Fox.Core.PropertyInfo.PropertyType.EntityLink, 432, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("fileParams", Fox.Core.PropertyInfo.PropertyType.FilePtr, 480, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("objectNum", Fox.Core.PropertyInfo.PropertyType.Int32, 528, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "evfFiles":
					return new Fox.Core.Value((Fox.IStringMap)evfFiles);
				case "eventFiles":
					return new Fox.Core.Value((Fox.IStringMap)eventFiles);
				case "priority":
					return new Fox.Core.Value(priority);
				case "demoId":
					return new Fox.Core.Value(demoId);
				case "stringParams":
					return new Fox.Core.Value(stringParams);
				case "entityParams":
					return new Fox.Core.Value((Fox.IStringMap)entityParams);
				case "fileParams":
					return new Fox.Core.Value((Fox.IStringMap)fileParams);
				case "objectNum":
					return new Fox.Core.Value((Fox.IStringMap)objectNum);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "stringParams":
					return new Fox.Core.Value(this.stringParams[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				case "evfFiles":
					return new Fox.Core.Value(this.evfFiles[key]);
				case "eventFiles":
					return new Fox.Core.Value(this.eventFiles[key]);
				case "entityParams":
					return new Fox.Core.Value(this.entityParams[key]);
				case "fileParams":
					return new Fox.Core.Value(this.fileParams[key]);
				case "objectNum":
					return new Fox.Core.Value(this.objectNum[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "priority":
					this.priority = value.GetValueAsInt32();
					return;
				case "demoId":
					this.demoId = value.GetValueAsString();
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
				case "stringParams":
					while(this.stringParams.Count <= index) { this.stringParams.Add(default(string)); }
					this.stringParams[index] = value.GetValueAsString();
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
				case "evfFiles":
					if (this.evfFiles.ContainsKey(key))
						this.evfFiles[key] = value.GetValueAsFilePtr();
					else
						this.evfFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "eventFiles":
					if (this.eventFiles.ContainsKey(key))
						this.eventFiles[key] = value.GetValueAsFilePtr();
					else
						this.eventFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "entityParams":
					if (this.entityParams.ContainsKey(key))
						this.entityParams[key] = value.GetValueAsEntityLink();
					else
						this.entityParams.Insert(key, value.GetValueAsEntityLink());
					return;
				case "fileParams":
					if (this.fileParams.ContainsKey(key))
						this.fileParams[key] = value.GetValueAsFilePtr();
					else
						this.fileParams.Insert(key, value.GetValueAsFilePtr());
					return;
				case "objectNum":
					if (this.objectNum.ContainsKey(key))
						this.objectNum[key] = value.GetValueAsInt32();
					else
						this.objectNum.Insert(key, value.GetValueAsInt32());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}