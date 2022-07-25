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
        protected Fox.Core.EntityPtr<Fox.Ph.PhRigidBodyParam> param { get; set; } = new Fox.Core.EntityPtr<Fox.Ph.PhRigidBodyParam>();
        
        public UnityEngine.Vector3 defaultPosition { get => Get_defaultPosition(); set { Set_defaultPosition(value); } }
        protected partial UnityEngine.Vector3 Get_defaultPosition();
        protected partial void Set_defaultPosition(UnityEngine.Vector3 value);
        
        public UnityEngine.Quaternion defaultRotation { get => Get_defaultRotation(); set { Set_defaultRotation(value); } }
        protected partial UnityEngine.Quaternion Get_defaultRotation();
        protected partial void Set_defaultRotation(UnityEngine.Quaternion value);
        
        public float mass { get => Get_mass(); set { Set_mass(value); } }
        protected partial float Get_mass();
        protected partial void Set_mass(float value);
        
        public float friction { get => Get_friction(); set { Set_friction(value); } }
        protected partial float Get_friction();
        protected partial void Set_friction(float value);
        
        public float restitution { get => Get_restitution(); set { Set_restitution(value); } }
        protected partial float Get_restitution();
        protected partial void Set_restitution(float value);
        
        public float maxLinearVelocity { get => Get_maxLinearVelocity(); set { Set_maxLinearVelocity(value); } }
        protected partial float Get_maxLinearVelocity();
        protected partial void Set_maxLinearVelocity(float value);
        
        public float maxAngularVelocity { get => Get_maxAngularVelocity(); set { Set_maxAngularVelocity(value); } }
        protected partial float Get_maxAngularVelocity();
        protected partial void Set_maxAngularVelocity(float value);
        
        public float linearVelocityDamp { get => Get_linearVelocityDamp(); set { Set_linearVelocityDamp(value); } }
        protected partial float Get_linearVelocityDamp();
        protected partial void Set_linearVelocityDamp(float value);
        
        public float angularVelocityDamp { get => Get_angularVelocityDamp(); set { Set_angularVelocityDamp(value); } }
        protected partial float Get_angularVelocityDamp();
        protected partial void Set_angularVelocityDamp(float value);
        
        public float permittedDepth { get => Get_permittedDepth(); set { Set_permittedDepth(value); } }
        protected partial float Get_permittedDepth();
        protected partial void Set_permittedDepth(float value);
        
        public bool sleepEnable { get => Get_sleepEnable(); set { Set_sleepEnable(value); } }
        protected partial bool Get_sleepEnable();
        protected partial void Set_sleepEnable(bool value);
        
        public float sleepLinearVelocityTh { get => Get_sleepLinearVelocityTh(); set { Set_sleepLinearVelocityTh(value); } }
        protected partial float Get_sleepLinearVelocityTh();
        protected partial void Set_sleepLinearVelocityTh(float value);
        
        public float sleepAngularVelocityTh { get => Get_sleepAngularVelocityTh(); set { Set_sleepAngularVelocityTh(value); } }
        protected partial float Get_sleepAngularVelocityTh();
        protected partial void Set_sleepAngularVelocityTh(float value);
        
        public float sleepTimeTh { get => Get_sleepTimeTh(); set { Set_sleepTimeTh(value); } }
        protected partial float Get_sleepTimeTh();
        protected partial void Set_sleepTimeTh(float value);
        
        public ushort collisionGroup { get => Get_collisionGroup(); set { Set_collisionGroup(value); } }
        protected partial ushort Get_collisionGroup();
        protected partial void Set_collisionGroup(ushort value);
        
        public ushort collisionType { get => Get_collisionType(); set { Set_collisionType(value); } }
        protected partial ushort Get_collisionType();
        protected partial void Set_collisionType(ushort value);
        
        public uint collisionId { get => Get_collisionId(); set { Set_collisionId(value); } }
        protected partial uint Get_collisionId();
        protected partial void Set_collisionId(uint value);
        
        public UnityEngine.Vector3 centerOfMassOffset { get => Get_centerOfMassOffset(); set { Set_centerOfMassOffset(value); } }
        protected partial UnityEngine.Vector3 Get_centerOfMassOffset();
        protected partial void Set_centerOfMassOffset(UnityEngine.Vector3 value);
        
        public PhRigidBodyType motionType { get => Get_motionType(); set { Set_motionType(value); } }
        protected partial PhRigidBodyType Get_motionType();
        protected partial void Set_motionType(PhRigidBodyType value);
        
        public Fox.FoxKernel.String material { get => Get_material(); set { Set_material(value); } }
        protected partial Fox.FoxKernel.String Get_material();
        protected partial void Set_material(Fox.FoxKernel.String value);
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static PhRigidBody()
        {
            classInfo = new Fox.EntityInfo("PhRigidBody", typeof(PhRigidBody), new Fox.Ph.PhSubObject().GetClassEntityInfo(), 0, "Ph", 3);
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
        }

        // Constructors
		public PhRigidBody(ulong id) : base(id) { }
		public PhRigidBody() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
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
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}