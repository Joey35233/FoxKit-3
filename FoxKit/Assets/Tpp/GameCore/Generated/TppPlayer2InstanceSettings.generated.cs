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
    public partial class TppPlayer2InstanceSettings 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String instancePackagePath { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint instanceBlockSize { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String commonMotionTypeName { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> partsTypeNames { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Kernel.String> partsTypeInitial { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
        
        // PropertyInfo
        private static Fox.Core.EntityInfo classInfo;
        public static  Fox.Core.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public virtual Fox.Core.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static TppPlayer2InstanceSettings()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("TppPlayer2InstanceSettings"), typeof(TppPlayer2InstanceSettings), null, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("instancePackagePath"), Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("instanceBlockSize"), Fox.Core.PropertyInfo.PropertyType.UInt32, 8, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("commonMotionTypeName"), Fox.Core.PropertyInfo.PropertyType.String, 16, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsTypeNames"), Fox.Core.PropertyInfo.PropertyType.String, 24, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsTypeInitial"), Fox.Core.PropertyInfo.PropertyType.String, 40, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		
		public TppPlayer2InstanceSettings()
        {
            
        }
        
        public virtual void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "instancePackagePath":
                    this.instancePackagePath = value.GetValueAsString();
                    return;
                case "instanceBlockSize":
                    this.instanceBlockSize = value.GetValueAsUInt32();
                    return;
                case "commonMotionTypeName":
                    this.commonMotionTypeName = value.GetValueAsString();
                    return;
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "partsTypeNames":
                    while(this.partsTypeNames.Count <= index) { this.partsTypeNames.Add(default(Fox.Kernel.String)); }
                    this.partsTypeNames[index] = value.GetValueAsString();
                    return;
                case "partsTypeInitial":
                    while(this.partsTypeInitial.Count <= index) { this.partsTypeInitial.Add(default(Fox.Kernel.String)); }
                    this.partsTypeInitial[index] = value.GetValueAsString();
                    return;
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
        
        public virtual void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                default:
                    throw new CsSystem.MissingMemberException("Unrecognized property", propertyName.ToString());
            }
        }
    }
}