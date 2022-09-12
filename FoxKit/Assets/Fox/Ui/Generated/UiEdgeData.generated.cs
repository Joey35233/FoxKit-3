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

namespace Fox.Ui
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiEdgeData : Fox.Core.Data 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink sourcePort { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int sourcePortType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int sourcePortIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink targetPort { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int targetPortType { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int targetPortIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isVirtual { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int virtualSourcePortIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public int virtualTargetPortIndex { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink virtualSourceNode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink virtualTargetNode { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isInvalid { get; set; }
        
        [field: UnityEngine.SerializeField]
        public Fox.Core.EntityLink connectRealEdge { get; set; }
        
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
        static UiEdgeData()
        {
            classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UiEdgeData"), typeof(UiEdgeData), new Fox.Core.Data().GetClassEntityInfo(), 0, "UiG", 5);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sourcePort"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sourcePortType"), Fox.Core.PropertyInfo.PropertyType.Int32, 160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sourcePortIndex"), Fox.Core.PropertyInfo.PropertyType.Int32, 164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetPort"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetPortType"), Fox.Core.PropertyInfo.PropertyType.Int32, 208, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("targetPortIndex"), Fox.Core.PropertyInfo.PropertyType.Int32, 212, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isVirtual"), Fox.Core.PropertyInfo.PropertyType.Bool, 216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("virtualSourcePortIndex"), Fox.Core.PropertyInfo.PropertyType.Int32, 220, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("virtualTargetPortIndex"), Fox.Core.PropertyInfo.PropertyType.Int32, 224, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("virtualSourceNode"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("virtualTargetNode"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 272, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("isInvalid"), Fox.Core.PropertyInfo.PropertyType.Bool, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connectRealEdge"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public UiEdgeData(ulong id) : base(id) { }
		public UiEdgeData() : base() { }
        
        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "sourcePort":
                    this.sourcePort = value.GetValueAsEntityLink();
                    return;
                case "sourcePortType":
                    this.sourcePortType = value.GetValueAsInt32();
                    return;
                case "sourcePortIndex":
                    this.sourcePortIndex = value.GetValueAsInt32();
                    return;
                case "targetPort":
                    this.targetPort = value.GetValueAsEntityLink();
                    return;
                case "targetPortType":
                    this.targetPortType = value.GetValueAsInt32();
                    return;
                case "targetPortIndex":
                    this.targetPortIndex = value.GetValueAsInt32();
                    return;
                case "isVirtual":
                    this.isVirtual = value.GetValueAsBool();
                    return;
                case "virtualSourcePortIndex":
                    this.virtualSourcePortIndex = value.GetValueAsInt32();
                    return;
                case "virtualTargetPortIndex":
                    this.virtualTargetPortIndex = value.GetValueAsInt32();
                    return;
                case "virtualSourceNode":
                    this.virtualSourceNode = value.GetValueAsEntityLink();
                    return;
                case "virtualTargetNode":
                    this.virtualTargetNode = value.GetValueAsEntityLink();
                    return;
                case "isInvalid":
                    this.isInvalid = value.GetValueAsBool();
                    return;
                case "connectRealEdge":
                    this.connectRealEdge = value.GetValueAsEntityLink();
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