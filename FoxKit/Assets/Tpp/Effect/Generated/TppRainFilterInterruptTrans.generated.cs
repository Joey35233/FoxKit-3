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

namespace Tpp.Effect
{
	[UnityEditor.InitializeOnLoad]
	public partial class TppRainFilterInterruptTrans : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<UnityEngine.Matrix4x4> planeMatrices { get; set; } = new Fox.Kernel.DynamicArray<UnityEngine.Matrix4x4>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.Path> maskTextures { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<uint> interruptFlags { get; set; } = new Fox.Kernel.DynamicArray<uint>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<uint> levels { get; set; } = new Fox.Kernel.DynamicArray<uint>();
		
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
		static TppRainFilterInterruptTrans()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppRainFilterInterruptTrans"), typeof(TppRainFilterInterruptTrans), Fox.Core.TransformData.ClassInfo, 400, null, 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("planeMatrices"), Fox.Core.PropertyInfo.PropertyType.Matrix4, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maskTextures"), Fox.Core.PropertyInfo.PropertyType.Path, 368, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("interruptFlags"), Fox.Core.PropertyInfo.PropertyType.UInt32, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("levels"), Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public TppRainFilterInterruptTrans(ulong id) : base(id) { }
		public TppRainFilterInterruptTrans() : base() { }

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
				case "planeMatrices":
					while(this.planeMatrices.Count <= index) { this.planeMatrices.Add(default(UnityEngine.Matrix4x4)); }
					this.planeMatrices[index] = value.GetValueAsMatrix4();
					return;
				case "maskTextures":
					while(this.maskTextures.Count <= index) { this.maskTextures.Add(default(Fox.Kernel.Path)); }
					this.maskTextures[index] = value.GetValueAsPath();
					return;
				case "interruptFlags":
					while(this.interruptFlags.Count <= index) { this.interruptFlags.Add(default(uint)); }
					this.interruptFlags[index] = value.GetValueAsUInt32();
					return;
				case "levels":
					while(this.levels.Count <= index) { this.levels.Add(default(uint)); }
					this.levels[index] = value.GetValueAsUInt32();
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