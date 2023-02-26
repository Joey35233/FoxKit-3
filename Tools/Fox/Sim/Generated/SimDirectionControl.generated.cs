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

namespace Fox.Sim
{
    [UnityEditor.InitializeOnLoad]
    public partial class SimDirectionControl : Fox.Sim.SimControlElement 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        protected Fox.Core.EntityPtr<Fox.Sim.SimDirectionControlParam> controlParam { get; set; } = new Fox.Core.EntityPtr<Fox.Sim.SimDirectionControlParam>();
        
        public Fox.Kernel.String refBone { get => Get_refBone(); set { Set_refBone(value); } }
        protected partial Fox.Kernel.String Get_refBone();
        protected partial void Set_refBone(Fox.Kernel.String value);
        
        public UnityEngine.Quaternion offset { get => Get_offset(); set { Set_offset(value); } }
        protected partial UnityEngine.Quaternion Get_offset();
        protected partial void Set_offset(UnityEngine.Quaternion value);
        
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
        static SimDirectionControl()
        {
            if (Fox.Sim.SimControlElement.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("SimDirectionControl"), typeof(SimDirectionControl), Fox.Sim.SimControlElement.ClassInfo, 56, "Sim", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Sim.SimDirectionControlParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("refBone"), Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("offset"), Fox.Core.PropertyInfo.PropertyType.Quat, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

            ClassInfoInitialized = true;
        }

        // Constructors
		public SimDirectionControl(ulong id) : base(id) { }
		public SimDirectionControl() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "controlParam":
                    this.controlParam = value.GetValueAsEntityPtr<Fox.Sim.SimDirectionControlParam>();
                    return;
                case "refBone":
                    this.refBone = value.GetValueAsString();
                    return;
                case "offset":
                    this.offset = value.GetValueAsQuat();
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