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
        public UnityEngine.Vector3 defaultPosition;
        
        public UnityEngine.Quaternion defaultRotation;
        
        public float mass;
        
        public float friction;
        
        public float restitution;
        
        public float maxLinearVelocity;
        
        public float maxAngularVelocity;
        
        public float linearVelocityDamp;
        
        public float angularVelocityDamp;
        
        public float permittedDepth;
        
        public bool sleepEnable;
        
        public float sleepLinearVelocityTh;
        
        public float sleepAngularVelocityTh;
        
        public float sleepTimeTh;
        
        public ushort collisionGroup;
        
        public ushort collisionType;
        
        public uint collisionId;
        
        public UnityEngine.Vector3 centerOfMassOffset;
        
        public int motionType;
        
        public Fox.String material;
        
        public bool isNoGravity;
        
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
			classInfo.StaticProperties.Insert("defaultPosition", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 48, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("defaultRotation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("mass", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 104, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("friction", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 108, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("restitution", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxLinearVelocity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 116, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("maxAngularVelocity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("linearVelocityDamp", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 124, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("angularVelocityDamp", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("permittedDepth", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 132, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sleepEnable", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sleepLinearVelocityTh", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 136, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sleepAngularVelocityTh", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 140, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("sleepTimeTh", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionGroup", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt16, 150, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("collisionId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.UInt32, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("centerOfMassOffset", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("motionType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("material", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("isNoGravity", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 161, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public PhRigidBodyParam(ulong address, ulong id) : base(address, id) { }
		public PhRigidBodyParam() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
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
                    this.motionType = value.GetValueAsInt32();
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
        
        public override void SetPropertyElement(string propertyName, ushort index, Fox.Value value)
        {
            switch(propertyName)
            {
                default:
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
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