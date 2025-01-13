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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("UiScene/ModelNodeConnection")]
	public partial class ModelNodeConnection 
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Core.Entity connectModelDataHandle { get; set; }
		
		[field: UnityEngine.SerializeField]
		public string connectModelNodeName { get; set; }
		
		// ClassInfos
		public static  bool ClassInfoInitialized = false;
		private static Fox.Core.EntityInfo classInfo;
		public static  Fox.Core.EntityInfo ClassInfo
		{
			get
			{
				return classInfo;
			}
		}
		public virtual Fox.Core.EntityInfo GetClassEntityInfo()
		{
			return classInfo;
		}
		static ModelNodeConnection()
		{
			classInfo = new Fox.Core.EntityInfo("ModelNodeConnection", typeof(ModelNodeConnection), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectModelDataHandle", Fox.Core.PropertyInfo.PropertyType.EntityHandle, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("connectModelNodeName", Fox.Core.PropertyInfo.PropertyType.String, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public virtual Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "connectModelDataHandle":
					return new Fox.Core.Value(connectModelDataHandle);
				case "connectModelNodeName":
					return new Fox.Core.Value(connectModelNodeName);
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "connectModelDataHandle":
					this.connectModelDataHandle = value.GetValueAsEntityHandle();
					return;
				case "connectModelNodeName":
					this.connectModelNodeName = value.GetValueAsString();
					return;
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}
	}
}