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

namespace Fox.Ph
{
	[UnityEditor.InitializeOnLoad]
	public partial class PhRigidBody : Fox.Ph.PhSubObject
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Ph.PhRigidBodyParam param { get; set; }
		
		public UnityEngine.Vector3 defaultPosition { get => Get_defaultPosition(); set { Set_defaultPosition(value); } }
		private partial UnityEngine.Vector3 Get_defaultPosition();
		private partial void Set_defaultPosition(UnityEngine.Vector3 value);
		
		public UnityEngine.Quaternion defaultRotation { get => Get_defaultRotation(); set { Set_defaultRotation(value); } }
		private partial UnityEngine.Quaternion Get_defaultRotation();
		private partial void Set_defaultRotation(UnityEngine.Quaternion value);
		
		public float mass { get => Get_mass(); set { Set_mass(value); } }
		private partial float Get_mass();
		private partial void Set_mass(float value);
		
		public float friction { get => Get_friction(); set { Set_friction(value); } }
		private partial float Get_friction();
		private partial void Set_friction(float value);
		
		public float restitution { get => Get_restitution(); set { Set_restitution(value); } }
		private partial float Get_restitution();
		private partial void Set_restitution(float value);
		
		public float maxLinearVelocity { get => Get_maxLinearVelocity(); set { Set_maxLinearVelocity(value); } }
		private partial float Get_maxLinearVelocity();
		private partial void Set_maxLinearVelocity(float value);
		
		public float maxAngularVelocity { get => Get_maxAngularVelocity(); set { Set_maxAngularVelocity(value); } }
		private partial float Get_maxAngularVelocity();
		private partial void Set_maxAngularVelocity(float value);
		
		public float linearVelocityDamp { get => Get_linearVelocityDamp(); set { Set_linearVelocityDamp(value); } }
		private partial float Get_linearVelocityDamp();
		private partial void Set_linearVelocityDamp(float value);
		
		public float angularVelocityDamp { get => Get_angularVelocityDamp(); set { Set_angularVelocityDamp(value); } }
		private partial float Get_angularVelocityDamp();
		private partial void Set_angularVelocityDamp(float value);
		
		public float permittedDepth { get => Get_permittedDepth(); set { Set_permittedDepth(value); } }
		private partial float Get_permittedDepth();
		private partial void Set_permittedDepth(float value);
		
		public bool sleepEnable { get => Get_sleepEnable(); set { Set_sleepEnable(value); } }
		private partial bool Get_sleepEnable();
		private partial void Set_sleepEnable(bool value);
		
		public float sleepLinearVelocityTh { get => Get_sleepLinearVelocityTh(); set { Set_sleepLinearVelocityTh(value); } }
		private partial float Get_sleepLinearVelocityTh();
		private partial void Set_sleepLinearVelocityTh(float value);
		
		public float sleepAngularVelocityTh { get => Get_sleepAngularVelocityTh(); set { Set_sleepAngularVelocityTh(value); } }
		private partial float Get_sleepAngularVelocityTh();
		private partial void Set_sleepAngularVelocityTh(float value);
		
		public float sleepTimeTh { get => Get_sleepTimeTh(); set { Set_sleepTimeTh(value); } }
		private partial float Get_sleepTimeTh();
		private partial void Set_sleepTimeTh(float value);
		
		public ushort collisionGroup { get => Get_collisionGroup(); set { Set_collisionGroup(value); } }
		private partial ushort Get_collisionGroup();
		private partial void Set_collisionGroup(ushort value);
		
		public ushort collisionType { get => Get_collisionType(); set { Set_collisionType(value); } }
		private partial ushort Get_collisionType();
		private partial void Set_collisionType(ushort value);
		
		public uint collisionId { get => Get_collisionId(); set { Set_collisionId(value); } }
		private partial uint Get_collisionId();
		private partial void Set_collisionId(uint value);
		
		public UnityEngine.Vector3 centerOfMassOffset { get => Get_centerOfMassOffset(); set { Set_centerOfMassOffset(value); } }
		private partial UnityEngine.Vector3 Get_centerOfMassOffset();
		private partial void Set_centerOfMassOffset(UnityEngine.Vector3 value);
		
		public PhRigidBodyType motionType { get => Get_motionType(); set { Set_motionType(value); } }
		private partial PhRigidBodyType Get_motionType();
		private partial void Set_motionType(PhRigidBodyType value);
		
		public string material { get => Get_material(); set { Set_material(value); } }
		private partial string Get_material();
		private partial void Set_material(string value);
		
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
		static PhRigidBody()
		{
			if (Fox.Ph.PhSubObject.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("PhRigidBody", typeof(PhRigidBody), Fox.Ph.PhSubObject.ClassInfo, 0, "Ph", 3);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("param", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Ph.PhRigidBodyParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultPosition", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultRotation", Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mass", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("friction", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("restitution", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxLinearVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxAngularVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("linearVelocityDamp", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("angularVelocityDamp", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("permittedDepth", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepLinearVelocityTh", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepAngularVelocityTh", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepTimeTh", Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionGroup", Fox.Core.PropertyInfo.PropertyType.UInt16, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionType", Fox.Core.PropertyInfo.PropertyType.UInt16, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionId", Fox.Core.PropertyInfo.PropertyType.UInt32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("centerOfMassOffset", Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("motionType", Fox.Core.PropertyInfo.PropertyType.Int32, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(PhRigidBodyType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("material", Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "param":
					return new Fox.Core.Value(param);
				case "defaultPosition":
					return new Fox.Core.Value(defaultPosition);
				case "defaultRotation":
					return new Fox.Core.Value(defaultRotation);
				case "mass":
					return new Fox.Core.Value(mass);
				case "friction":
					return new Fox.Core.Value(friction);
				case "restitution":
					return new Fox.Core.Value(restitution);
				case "maxLinearVelocity":
					return new Fox.Core.Value(maxLinearVelocity);
				case "maxAngularVelocity":
					return new Fox.Core.Value(maxAngularVelocity);
				case "linearVelocityDamp":
					return new Fox.Core.Value(linearVelocityDamp);
				case "angularVelocityDamp":
					return new Fox.Core.Value(angularVelocityDamp);
				case "permittedDepth":
					return new Fox.Core.Value(permittedDepth);
				case "sleepEnable":
					return new Fox.Core.Value(sleepEnable);
				case "sleepLinearVelocityTh":
					return new Fox.Core.Value(sleepLinearVelocityTh);
				case "sleepAngularVelocityTh":
					return new Fox.Core.Value(sleepAngularVelocityTh);
				case "sleepTimeTh":
					return new Fox.Core.Value(sleepTimeTh);
				case "collisionGroup":
					return new Fox.Core.Value(collisionGroup);
				case "collisionType":
					return new Fox.Core.Value(collisionType);
				case "collisionId":
					return new Fox.Core.Value(collisionId);
				case "centerOfMassOffset":
					return new Fox.Core.Value(centerOfMassOffset);
				case "motionType":
					return new Fox.Core.Value(motionType);
				case "material":
					return new Fox.Core.Value(material);
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
				case "param":
					this.param = value.GetValueAsEntityPtr<Fox.Ph.PhRigidBodyParam>();
					return;
				case "defaultPosition":
					this.defaultPosition = value.GetValueAsVector3();
					return;
				case "defaultRotation":
					this.defaultRotation = value.GetValueAsQuat();
					return;
				case "mass":
					this.mass = value.GetValueAsFloat();
					return;
				case "friction":
					this.friction = value.GetValueAsFloat();
					return;
				case "restitution":
					this.restitution = value.GetValueAsFloat();
					return;
				case "maxLinearVelocity":
					this.maxLinearVelocity = value.GetValueAsFloat();
					return;
				case "maxAngularVelocity":
					this.maxAngularVelocity = value.GetValueAsFloat();
					return;
				case "linearVelocityDamp":
					this.linearVelocityDamp = value.GetValueAsFloat();
					return;
				case "angularVelocityDamp":
					this.angularVelocityDamp = value.GetValueAsFloat();
					return;
				case "permittedDepth":
					this.permittedDepth = value.GetValueAsFloat();
					return;
				case "sleepEnable":
					this.sleepEnable = value.GetValueAsBool();
					return;
				case "sleepLinearVelocityTh":
					this.sleepLinearVelocityTh = value.GetValueAsFloat();
					return;
				case "sleepAngularVelocityTh":
					this.sleepAngularVelocityTh = value.GetValueAsFloat();
					return;
				case "sleepTimeTh":
					this.sleepTimeTh = value.GetValueAsFloat();
					return;
				case "collisionGroup":
					this.collisionGroup = value.GetValueAsUInt16();
					return;
				case "collisionType":
					this.collisionType = value.GetValueAsUInt16();
					return;
				case "collisionId":
					this.collisionId = value.GetValueAsUInt32();
					return;
				case "centerOfMassOffset":
					this.centerOfMassOffset = value.GetValueAsVector3();
					return;
				case "motionType":
					this.motionType = (PhRigidBodyType)value.GetValueAsInt32();
					return;
				case "material":
					this.material = value.GetValueAsString();
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