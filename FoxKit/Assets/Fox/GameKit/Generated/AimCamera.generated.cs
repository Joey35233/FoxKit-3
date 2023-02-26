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

namespace Fox.GameKit
{
    [UnityEditor.InitializeOnLoad]
    public partial class AimCamera : Fox.GameKit.Camera 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected UnityEngine.Vector3 aim { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float distance { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float rotX { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float rotY { get; set; }
        
        [field: UnityEngine.SerializeField]
        protected float rotZ { get; set; }
        
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
        static AimCamera()
        {
            if (Fox.GameKit.Camera.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("AimCamera"), typeof(AimCamera), Fox.GameKit.Camera.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("aim"), Fox.Core.PropertyInfo.PropertyType.Vector3, 464, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("distance"), Fox.Core.PropertyInfo.PropertyType.Float, 480, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotX"), Fox.Core.PropertyInfo.PropertyType.Float, 484, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotY"), Fox.Core.PropertyInfo.PropertyType.Float, 488, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("rotZ"), Fox.Core.PropertyInfo.PropertyType.Float, 492, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public AimCamera(ulong id) : base(id) { }
		public AimCamera() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "aim":
                    this.aim = value.GetValueAsVector3();
                    return;
                case "distance":
                    this.distance = value.GetValueAsFloat();
                    return;
                case "rotX":
                    this.rotX = value.GetValueAsFloat();
                    return;
                case "rotY":
                    this.rotY = value.GetValueAsFloat();
                    return;
                case "rotZ":
                    this.rotZ = value.GetValueAsFloat();
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