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
    [UnityEditor.InitializeOnLoad]
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
        
        // PropertyInfo
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
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhxWheelConstraintParam"), typeof(PhxWheelConstraintParam), new Fox.Ph.PhConstraintParam().GetClassEntityInfo(), 160, "Phx", 2);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("defaultRotation"), Fox.Core.PropertyInfo.PropertyType.Quat, 64, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("positionL"), Fox.Core.PropertyInfo.PropertyType.Vector3, 80, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("frontL"), Fox.Core.PropertyInfo.PropertyType.Vector3, 96, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("upL"), Fox.Core.PropertyInfo.PropertyType.Vector3, 112, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelPositionOffset"), Fox.Core.PropertyInfo.PropertyType.Vector3, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("radius"), Fox.Core.PropertyInfo.PropertyType.Float, 144, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("suspensionLength"), Fox.Core.PropertyInfo.PropertyType.Float, 148, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxSuspensionForce"), Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dampingFactorElong"), Fox.Core.PropertyInfo.PropertyType.Float, 156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dampingFactorCompress"), Fox.Core.PropertyInfo.PropertyType.Float, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("friction"), Fox.Core.PropertyInfo.PropertyType.Float, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("restitution"), Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("inertia"), Fox.Core.PropertyInfo.PropertyType.Float, 172, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public PhxWheelConstraintParam(ulong id) : base(id) { }
		public PhxWheelConstraintParam() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
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