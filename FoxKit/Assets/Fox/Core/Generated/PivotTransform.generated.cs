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
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("FoxCore/PivotTransform")]
	public partial class PivotTransform 
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 pivot { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 pivotTranslation { get; set; }
		
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
		static PivotTransform()
		{
			classInfo = new Fox.Core.EntityInfo("PivotTransform", typeof(PivotTransform), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pivot", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("pivotTranslation", Fox.Core.PropertyInfo.PropertyType.Vector3, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public virtual Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "pivot":
					return new Fox.Core.Value(pivot);
				case "pivotTranslation":
					return new Fox.Core.Value(pivotTranslation);
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
				case "pivot":
					this.pivot = value.GetValueAsVector3();
					return;
				case "pivotTranslation":
					this.pivotTranslation = value.GetValueAsVector3();
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