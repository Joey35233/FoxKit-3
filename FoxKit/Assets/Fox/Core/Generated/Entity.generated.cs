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

namespace Fox.Core
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxCore/Entity")]
	public partial class Entity 
	{
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
		static Entity()
		{
			classInfo = new Fox.Core.EntityInfo("Entity", typeof(Entity), null, -1, null, 2);

			ClassInfoInitialized = true;
		}
		
		public virtual Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				default:
					foreach (var dynamicProperty in gameObject.GetComponents<DynamicProperty>())
						if (dynamicProperty.Name == propertyName)
							return dynamicProperty.GetValue();
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				default:
					foreach (var dynamicProperty in gameObject.GetComponents<DynamicProperty>())
						if (dynamicProperty.Name == propertyName && dynamicProperty.GetContainerType() != PropertyInfo.ContainerType.StringMap)
							return dynamicProperty.GetElement(index);
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					foreach (var dynamicProperty in gameObject.GetComponents<DynamicProperty>())
						if (dynamicProperty.Name == propertyName && dynamicProperty.GetContainerType() == PropertyInfo.ContainerType.StringMap)
							return dynamicProperty.GetElement(key);
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					foreach (var dynamicProperty in gameObject.GetComponents<DynamicProperty>())
						if (dynamicProperty.Name == propertyName && dynamicProperty.GetContainerType() != PropertyInfo.ContainerType.StringMap)
						{
							dynamicProperty.SetElement(index, value);
							return;
						}
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}

		public virtual void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					foreach (var dynamicProperty in gameObject.GetComponents<DynamicProperty>())
						if (dynamicProperty.Name == propertyName && dynamicProperty.GetContainerType() == PropertyInfo.ContainerType.StringMap)
						{
							dynamicProperty.SetElement(key, value);
							return;
						}
					throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
			}
		}
	}
}