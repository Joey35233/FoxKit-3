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

namespace Fox.UiScene
{
    [UnityEditor.InitializeOnLoad]
    public partial class UiModelData : Fox.Core.TransformData
    {
        // Properties
        [field: UnityEngine.SerializeField]
        public Fox.Core.FilePtr data { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String sceneName { get; set; }

        [field: UnityEngine.SerializeField]
        public int priority { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityLink> animations { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityLink>();

        [field: UnityEngine.SerializeField]
        public bool useLayoutCamera { get; set; }

        [field: UnityEngine.SerializeField]
        public UiModelDataFlag flag { get; set; }

        [field: UnityEngine.SerializeField]
        public float billboardMin { get; set; }

        [field: UnityEngine.SerializeField]
        public float billboardMax { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Core.Entity connection_connectModelDataHandle { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.String connection_connectModelNodeName { get; set; }

        [field: UnityEngine.SerializeField]
        public UnityEngine.Color color { get; set; }

        [field: UnityEngine.SerializeField]
        public UiInheritanceSetting inheritanceSetting { get; set; }

        [field: UnityEngine.SerializeField]
        public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>> modelNodes { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>>();

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
        static UiModelData()
        {
            if (Fox.Core.TransformData.ClassInfoInitialized)
                classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("UiModelData"), typeof(UiModelData), Fox.Core.TransformData.ClassInfo, 0, "Ui", 6);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("data"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("sceneName"), Fox.Core.PropertyInfo.PropertyType.String, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("priority"), Fox.Core.PropertyInfo.PropertyType.Int32, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("animations"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 344, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("useLayoutCamera"), Fox.Core.PropertyInfo.PropertyType.Bool, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("flag"), Fox.Core.PropertyInfo.PropertyType.UInt32, 364, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(UiModelDataFlag), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("billboardMin"), Fox.Core.PropertyInfo.PropertyType.Float, 368, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("billboardMax"), Fox.Core.PropertyInfo.PropertyType.Float, 372, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connection_connectModelDataHandle"), Fox.Core.PropertyInfo.PropertyType.EntityHandle, 384, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("connection_connectModelNodeName"), Fox.Core.PropertyInfo.PropertyType.String, 392, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("color"), Fox.Core.PropertyInfo.PropertyType.Color, 400, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("inheritanceSetting"), Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(UiInheritanceSetting), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("modelNodes"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 424, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.UiScene.UiModelNodeElement), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

            ClassInfoInitialized = true;
        }

        // Constructors
		public UiModelData(ulong id) : base(id) { }
		public UiModelData() : base() { }

        public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
        {
            switch(propertyName.CString)
            {
                case "data":
                    this.data = value.GetValueAsFilePtr();
                    return;
                case "sceneName":
                    this.sceneName = value.GetValueAsString();
                    return;
                case "priority":
                    this.priority = value.GetValueAsInt32();
                    return;
                case "useLayoutCamera":
                    this.useLayoutCamera = value.GetValueAsBool();
                    return;
                case "flag":
                    this.flag = (UiModelDataFlag)value.GetValueAsUInt32();
                    return;
                case "billboardMin":
                    this.billboardMin = value.GetValueAsFloat();
                    return;
                case "billboardMax":
                    this.billboardMax = value.GetValueAsFloat();
                    return;
                case "connection_connectModelDataHandle":
                    this.connection_connectModelDataHandle = value.GetValueAsEntityHandle();
                    return;
                case "connection_connectModelNodeName":
                    this.connection_connectModelNodeName = value.GetValueAsString();
                    return;
                case "color":
                    this.color = value.GetValueAsColor();
                    return;
                case "inheritanceSetting":
                    this.inheritanceSetting = (UiInheritanceSetting)value.GetValueAsUInt32();
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
                case "animations":
                    while(this.animations.Count <= index) { this.animations.Add(default(Fox.Core.EntityLink)); }
                    this.animations[index] = value.GetValueAsEntityLink();
                    return;
                case "modelNodes":
                    while(this.modelNodes.Count <= index) { this.modelNodes.Add(default(Fox.Core.EntityPtr<Fox.UiScene.UiModelNodeElement>)); }
                    this.modelNodes[index] = value.GetValueAsEntityPtr<Fox.UiScene.UiModelNodeElement>();
                    return;
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