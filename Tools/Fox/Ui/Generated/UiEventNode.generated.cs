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
    public partial class UiEventNode : Fox.Ui.UiNodeData 
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public uint inputPhaseCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public uint inputOperationCount { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool useStartOperation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool useStopOperation { get; set; }
        
        [field: UnityEngine.SerializeField]
        public bool isReEnter { get; set; }
        
        [field: UnityEngine.SerializeField]
        public UiEventNodeKind kind { get; set; }
        
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
        static UiEventNode()
        {
            classInfo = new Fox.Core.EntityInfo("UiEventNode", typeof(UiEventNode), new Fox.Ui.UiNodeData().GetClassEntityInfo(), 0, "UiG", 7);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputPhaseCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 296, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("inputOperationCount", Fox.Core.PropertyInfo.PropertyType.UInt32, 300, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useStartOperation", Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("useStopOperation", Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("isReEnter", Fox.Core.PropertyInfo.PropertyType.Bool, 306, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("kind", Fox.Core.PropertyInfo.PropertyType.Int32, 280, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, typeof(UiEventNodeKind), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
        }

        // Constructors
		public UiEventNode(ulong id) : base(id) { }
		public UiEventNode() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Core.Value value)
        {
            switch(propertyName)
            {
                case "inputPhaseCount":
                    this.inputPhaseCount = value.GetValueAsUInt32();
                    return;
                case "inputOperationCount":
                    this.inputOperationCount = value.GetValueAsUInt32();
                    return;
                case "useStartOperation":
                    this.useStartOperation = value.GetValueAsBool();
                    return;
                case "useStopOperation":
                    this.useStopOperation = value.GetValueAsBool();
                    return;
                case "isReEnter":
                    this.isReEnter = value.GetValueAsBool();
                    return;
                case "kind":
                    this.kind = (UiEventNodeKind)value.GetValueAsInt32();
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