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
    public partial class PhRigidBodyParam : Fox.Core.Entity 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 defaultPosition { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Quaternion defaultRotation { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float mass { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float friction { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float restitution { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float maxLinearVelocity { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float maxAngularVelocity { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float linearVelocityDamp { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float angularVelocityDamp { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float permittedDepth { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected bool sleepEnable { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float sleepLinearVelocityTh { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float sleepAngularVelocityTh { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float sleepTimeTh { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected ushort collisionGroup { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected ushort collisionType { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected uint collisionId { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 centerOfMassOffset { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected PhRigidBodyType motionType { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected Fox.Core.String material { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected bool isNoGravity { get; set; }
        
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
        static PhRigidBodyParam()
        {
            classInfo = new Fox.EntityInfo("PhRigidBodyParam", typeof(PhRigidBodyParam), new Fox.Core.Entity().GetClassEntityInfo(), 320, "Ph", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultPosition", Fox.Core.PropertyInfo.PropertyType.Vector3, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("defaultRotation", Fox.Core.PropertyInfo.PropertyType.Quat, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("mass", Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("friction", Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("restitution", Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxLinearVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("maxAngularVelocity", Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("linearVelocityDamp", Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("angularVelocityDamp", Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("permittedDepth", Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepEnable", Fox.Core.PropertyInfo.PropertyType.Bool, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepLinearVelocityTh", Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepAngularVelocityTh", Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("sleepTimeTh", Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionGroup", Fox.Core.PropertyInfo.PropertyType.UInt16, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionType", Fox.Core.PropertyInfo.PropertyType.UInt16, 150, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("collisionId", Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("centerOfMassOffset", Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("motionType", Fox.Core.PropertyInfo.PropertyType.Int32, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, typeof(PhRigidBodyType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("material", Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isNoGravity", Fox.Core.PropertyInfo.PropertyType.Bool, 161, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public PhRigidBodyParam(ulong id) : base(id) { }
		public PhRigidBodyParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
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
                case "isNoGravity":
                    this.isNoGravity = value.GetValueAsBool();
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