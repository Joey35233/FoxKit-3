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

namespace Fox.Phx
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Phx/PhxWheelConstraintParam")]
	public partial class PhxWheelConstraintParam : Fox.Ph.PhConstraintParam
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Quaternion defaultRotation { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 positionL { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 frontL { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 upL { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected UnityEngine.Vector3 wheelPositionOffset { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float radius { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float suspensionLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float maxSuspensionForce { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float dampingFactorElong { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float dampingFactorCompress { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float friction { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float restitution { get; set; }
		
		[field: UnityEngine.SerializeField]
		protected float inertia { get; set; }
		
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
		static PhxWheelConstraintParam()
		{
			if (Fox.Ph.PhConstraintParam.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhxWheelConstraintParam", typeof(PhxWheelConstraintParam), Fox.Ph.PhConstraintParam.ClassInfo, 160, "Phx", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultRotation", Fox.Core.PropertyInfo.PropertyType.Quat, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("positionL", Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("frontL", Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("upL", Fox.Core.PropertyInfo.PropertyType.Vector3, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("wheelPositionOffset", Fox.Core.PropertyInfo.PropertyType.Vector3, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("radius", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("suspensionLength", Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxSuspensionForce", Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dampingFactorElong", Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("dampingFactorCompress", Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("friction", Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("restitution", Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inertia", Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "defaultRotation":
					return new Fox.Core.Value(defaultRotation);
				case "positionL":
					return new Fox.Core.Value(positionL);
				case "frontL":
					return new Fox.Core.Value(frontL);
				case "upL":
					return new Fox.Core.Value(upL);
				case "wheelPositionOffset":
					return new Fox.Core.Value(wheelPositionOffset);
				case "radius":
					return new Fox.Core.Value(radius);
				case "suspensionLength":
					return new Fox.Core.Value(suspensionLength);
				case "maxSuspensionForce":
					return new Fox.Core.Value(maxSuspensionForce);
				case "dampingFactorElong":
					return new Fox.Core.Value(dampingFactorElong);
				case "dampingFactorCompress":
					return new Fox.Core.Value(dampingFactorCompress);
				case "friction":
					return new Fox.Core.Value(friction);
				case "restitution":
					return new Fox.Core.Value(restitution);
				case "inertia":
					return new Fox.Core.Value(inertia);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
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
				case "defaultRotation":
					this.defaultRotation = value.GetValueAsQuat();
					return;
				case "positionL":
					this.positionL = value.GetValueAsVector3();
					return;
				case "frontL":
					this.frontL = value.GetValueAsVector3();
					return;
				case "upL":
					this.upL = value.GetValueAsVector3();
					return;
				case "wheelPositionOffset":
					this.wheelPositionOffset = value.GetValueAsVector3();
					return;
				case "radius":
					this.radius = value.GetValueAsFloat();
					return;
				case "suspensionLength":
					this.suspensionLength = value.GetValueAsFloat();
					return;
				case "maxSuspensionForce":
					this.maxSuspensionForce = value.GetValueAsFloat();
					return;
				case "dampingFactorElong":
					this.dampingFactorElong = value.GetValueAsFloat();
					return;
				case "dampingFactorCompress":
					this.dampingFactorCompress = value.GetValueAsFloat();
					return;
				case "friction":
					this.friction = value.GetValueAsFloat();
					return;
				case "restitution":
					this.restitution = value.GetValueAsFloat();
					return;
				case "inertia":
					this.inertia = value.GetValueAsFloat();
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