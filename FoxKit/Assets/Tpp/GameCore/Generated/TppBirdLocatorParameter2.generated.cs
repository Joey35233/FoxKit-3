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
	public partial class TppBirdLocatorParameter2 : Fox.Core.DataElement
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public uint count { get; set; }
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<UnityEngine.Vector3> grounds { get; private set; } = new CsSystem.Collections.Generic.List<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<UnityEngine.Vector3> perchPoints { get; private set; } = new CsSystem.Collections.Generic.List<UnityEngine.Vector3>();
		
		[field: UnityEngine.SerializeField]
		public byte radius { get; set; }
		
		[field: UnityEngine.SerializeField]
		public byte height { get; set; }
		
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
		static TppBirdLocatorParameter2()
		{
			if (Fox.Core.DataElement.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("TppBirdLocatorParameter2", typeof(TppBirdLocatorParameter2), Fox.Core.DataElement.ClassInfo, 80, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("count", Fox.Core.PropertyInfo.PropertyType.UInt32, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("grounds", Fox.Core.PropertyInfo.PropertyType.Vector3, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("perchPoints", Fox.Core.PropertyInfo.PropertyType.Vector3, 88, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.UInt8, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("height", Fox.Core.PropertyInfo.PropertyType.UInt8, 105, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "count":
					return new Fox.Core.Value(count);
				case "grounds":
					return new Fox.Core.Value(grounds);
				case "perchPoints":
					return new Fox.Core.Value(perchPoints);
				case "radius":
					return new Fox.Core.Value(radius);
				case "height":
					return new Fox.Core.Value(height);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "grounds":
					return new Fox.Core.Value(this.grounds[index]);
				case "perchPoints":
					return new Fox.Core.Value(this.perchPoints[index]);
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
				case "count":
					this.count = value.GetValueAsUInt32();
					return;
				case "radius":
					this.radius = value.GetValueAsUInt8();
					return;
				case "height":
					this.height = value.GetValueAsUInt8();
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
				case "grounds":
					while(this.grounds.Count <= index) { this.grounds.Add(default(UnityEngine.Vector3)); }
					this.grounds[index] = value.GetValueAsVector3();
					return;
				case "perchPoints":
					while(this.perchPoints.Count <= index) { this.perchPoints.Add(default(UnityEngine.Vector3)); }
					this.perchPoints[index] = value.GetValueAsVector3();
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