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

namespace Tpp.GameCore
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppSnipePoint2Data : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public SnipePointType type { get; set; }
		
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
		static TppSnipePoint2Data()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppSnipePoint2Data"), typeof(TppSnipePoint2Data), Fox.Core.TransformData.ClassInfo, 272, "BuddyQuiet2", 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("type"), Fox.Core.PropertyInfo.PropertyType.Int32, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(SnipePointType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppSnipePoint2Data(ulong id) : base(id) { }
		public TppSnipePoint2Data() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "type":
					this.type = (SnipePointType)value.GetValueAsInt32();
					return;
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
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