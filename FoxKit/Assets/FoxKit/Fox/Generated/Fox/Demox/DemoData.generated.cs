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

namespace Fox.Demox
{
    public partial class DemoData : Fox.Core.TransformData 
    {
        // Properties
        public Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>> evfFiles = new Fox.Core.DynamicArray<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public bool onMemory;
        
        public int demoLength;
        
        public int priority;
        
        public Fox.Core.Path scriptPath;
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> fmdlFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> helpBoneFiles = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.PartsDesc>> partsDesc = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.PartsDesc>>();
        
        public Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Demo.ClipData>> clipDatas = new Fox.Core.DynamicArray<Fox.Core.EntityPtr<Fox.Demo.ClipData>>();
        
        public Fox.Core.DynamicArray<Fox.Core.Path> loadFiles = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
        public Fox.String demoId;
        
        public Fox.Core.EntityLink playingRoot;
        
        public Fox.Core.EntityLink streamAnimation;
        
        public Fox.Core.Path demoStreamPath;
        
        public Fox.Core.Path motionPath;
        
        public Fox.Core.FilePtr<Fox.Core.File> motionFile;
        
        public Fox.Core.Path audioPath;
        
        public Fox.Core.FilePtr<Fox.Core.File> subtitleFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> subtitleBinaryFile;
        
        public Fox.Core.FilePtr<Fox.Core.File> nodeDataFile;
        
        public Fox.Core.DynamicArray<Fox.String> stringParams = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.StringMap<Fox.Core.EntityLink> entityParams = new Fox.Core.StringMap<Fox.Core.EntityLink>();
        
        public Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>> fileParams = new Fox.Core.StringMap<Fox.Core.FilePtr<Fox.Core.File>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.DemoControlCharacterDesc>> controlCharacters = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.DemoControlCharacterDesc>>();
        
        public Fox.Core.StringMap<Fox.Core.EntityLink> controlDatas = new Fox.Core.StringMap<Fox.Core.EntityLink>();
        
        public Fox.Core.StringMap<Fox.String> controlCollectibles = new Fox.Core.StringMap<Fox.String>();
        
        public Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.DemoParameter>> parameters = new Fox.Core.StringMap<Fox.Core.EntityPtr<Fox.Demo.DemoParameter>>();
        
        public Fox.Core.StringMap<Fox.String> setupLights = new Fox.Core.StringMap<Fox.String>();
        
        public Utility_InterpType cameraInterpType;
        
        public int cameraInterpFrame;
        
        public float cameraInterpCurveRate;
        
        public float cameraInterpScurveCenter;
        
        public UnityEngine.Vector3 cameraTranslation;
        
        public UnityEngine.Quaternion cameraRotation;
        
        public float cameraParam;
        
        public float cameraDistanceToLookAt;
        
        public UnityEngine.Vector3 cameraStartTranslation;
        
        public UnityEngine.Quaternion cameraStartRotation;
        
        public float cameraStartParam;
        
        public float cameraStartDistanceToLookAt;
        
        public int eventCacheNum;
        
        public int eventInterpCacheNum;
        
        public int eventSkipCacheNum;
        
        public Fox.Core.DynamicArray<Fox.String> highestTextureStreamModel = new Fox.Core.DynamicArray<Fox.String>();
        
        public Fox.Core.DynamicArray<Fox.Core.Path> highestTexture = new Fox.Core.DynamicArray<Fox.Core.Path>();
        
        public Fox.Core.StringMap<int> objectNum = new Fox.Core.StringMap<int>();
        
        public Fox.Core.EntityLink blockPositionSetter;
        
        // PropertyInfo
        private static Fox.EntityInfo classInfo;
        public static new Fox.EntityInfo ClassInfo
        {
            get
            {
                return classInfo;
            }
        }
        public  override Fox.EntityInfo GetClassEntityInfo()
        {
            return classInfo;
        }
        static DemoData()
        {
            classInfo = new Fox.EntityInfo("DemoData", new Fox.Core.TransformData().GetClassEntityInfo(), 1264, null, 36);
			
			classInfo.StaticProperties.Insert("evfFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("onMemory", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Bool, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("demoLength", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("priority", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("scriptPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fmdlFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 344, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("helpBoneFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 392, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("partsDesc", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 440, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.PartsDesc), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("clipDatas", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 488, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.ClipData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("loadFiles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 504, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("demoId", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 608, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("playingRoot", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 616, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("streamAnimation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 656, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("demoStreamPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 696, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("motionPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 704, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("motionFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 712, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("audioPath", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 736, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("subtitleFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 744, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("subtitleBinaryFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 768, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("nodeDataFile", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 792, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("stringParams", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 816, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("entityParams", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 832, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("fileParams", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.FilePtr, 880, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("controlCharacters", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 928, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.DemoControlCharacterDesc), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("controlDatas", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 976, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("controlCollectibles", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 1024, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("parameters", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityPtr, 1072, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.DemoParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("setupLights", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 560, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraInterpType", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Utility_InterpType), Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraInterpFrame", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraInterpCurveRate", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraInterpScurveCenter", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraTranslation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 1168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraRotation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 1184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraParam", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraDistanceToLookAt", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraStartTranslation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Vector3, 1216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraStartRotation", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Quat, 1232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraStartParam", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("cameraStartDistanceToLookAt", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Float, 1252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("eventCacheNum", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("eventInterpCacheNum", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("eventSkipCacheNum", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("highestTextureStreamModel", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.String, 1120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("highestTexture", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Path, 1136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("objectNum", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.Int32, 1272, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
			classInfo.StaticProperties.Insert("blockPositionSetter", new Fox.Core.PropertyInfo(Fox.Core.PropertyInfo.PropertyType.EntityLink, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance));
        }

        // Constructors
		public DemoData(ulong address, ulong id) : base(address, id) { }
		public DemoData() : base() { }
        
        public override void SetProperty(string propertyName, Fox.Value value)
        {
            switch(propertyName)
            {
                case "onMemory":
                    this.onMemory = value.GetValueAsBool();
                    return;
                case "demoLength":
                    this.demoLength = value.GetValueAsInt32();
                    return;
                case "priority":
                    this.priority = value.GetValueAsInt32();
                    return;
                case "scriptPath":
                    this.scriptPath = value.GetValueAsPath();
                    return;
                case "demoId":
                    this.demoId = value.GetValueAsString();
                    return;
                case "playingRoot":
                    this.playingRoot = value.GetValueAsEntityLink();
                    return;
                case "streamAnimation":
                    this.streamAnimation = value.GetValueAsEntityLink();
                    return;
                case "demoStreamPath":
                    this.demoStreamPath = value.GetValueAsPath();
                    return;
                case "motionPath":
                    this.motionPath = value.GetValueAsPath();
                    return;
                case "motionFile":
                    this.motionFile = value.GetValueAsFilePtr();
                    return;
                case "audioPath":
                    this.audioPath = value.GetValueAsPath();
                    return;
                case "subtitleFile":
                    this.subtitleFile = value.GetValueAsFilePtr();
                    return;
                case "subtitleBinaryFile":
                    this.subtitleBinaryFile = value.GetValueAsFilePtr();
                    return;
                case "nodeDataFile":
                    this.nodeDataFile = value.GetValueAsFilePtr();
                    return;
                case "cameraInterpType":
                    this.cameraInterpType = (Utility_InterpType)value.GetValueAsInt32();
                    return;
                case "cameraInterpFrame":
                    this.cameraInterpFrame = value.GetValueAsInt32();
                    return;
                case "cameraInterpCurveRate":
                    this.cameraInterpCurveRate = value.GetValueAsFloat();
                    return;
                case "cameraInterpScurveCenter":
                    this.cameraInterpScurveCenter = value.GetValueAsFloat();
                    return;
                case "cameraTranslation":
                    this.cameraTranslation = value.GetValueAsVector3();
                    return;
                case "cameraRotation":
                    this.cameraRotation = value.GetValueAsQuat();
                    return;
                case "cameraParam":
                    this.cameraParam = value.GetValueAsFloat();
                    return;
                case "cameraDistanceToLookAt":
                    this.cameraDistanceToLookAt = value.GetValueAsFloat();
                    return;
                case "cameraStartTranslation":
                    this.cameraStartTranslation = value.GetValueAsVector3();
                    return;
                case "cameraStartRotation":
                    this.cameraStartRotation = value.GetValueAsQuat();
                    return;
                case "cameraStartParam":
                    this.cameraStartParam = value.GetValueAsFloat();
                    return;
                case "cameraStartDistanceToLookAt":
                    this.cameraStartDistanceToLookAt = value.GetValueAsFloat();
                    return;
                case "eventCacheNum":
                    this.eventCacheNum = value.GetValueAsInt32();
                    return;
                case "eventInterpCacheNum":
                    this.eventInterpCacheNum = value.GetValueAsInt32();
                    return;
                case "eventSkipCacheNum":
                    this.eventSkipCacheNum = value.GetValueAsInt32();
                    return;
                case "blockPositionSetter":
                    this.blockPositionSetter = value.GetValueAsEntityLink();
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
                case "evfFiles":
                    while(this.evfFiles.Count <= index) { this.evfFiles.Add(default(Fox.Core.FilePtr<Fox.Core.File>)); }
                    this.evfFiles[index] = value.GetValueAsFilePtr();
                    return;
                case "clipDatas":
                    while(this.clipDatas.Count <= index) { this.clipDatas.Add(default(Fox.Core.EntityPtr<Fox.Demo.ClipData>)); }
                    this.clipDatas[index] = value.GetValueAsEntityPtr<Fox.Demo.ClipData>();
                    return;
                case "loadFiles":
                    while(this.loadFiles.Count <= index) { this.loadFiles.Add(default(Fox.Core.Path)); }
                    this.loadFiles[index] = value.GetValueAsPath();
                    return;
                case "stringParams":
                    while(this.stringParams.Count <= index) { this.stringParams.Add(default(Fox.String)); }
                    this.stringParams[index] = value.GetValueAsString();
                    return;
                case "highestTextureStreamModel":
                    while(this.highestTextureStreamModel.Count <= index) { this.highestTextureStreamModel.Add(default(Fox.String)); }
                    this.highestTextureStreamModel[index] = value.GetValueAsString();
                    return;
                case "highestTexture":
                    while(this.highestTexture.Count <= index) { this.highestTexture.Add(default(Fox.Core.Path)); }
                    this.highestTexture[index] = value.GetValueAsPath();
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, index, value);
                    return;
            }
        }
        
        public override void SetPropertyElement(string propertyName, string key, Fox.Value value)
        {
            switch(propertyName)
            {
                case "fmdlFiles":
                    this.fmdlFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "helpBoneFiles":
                    this.helpBoneFiles.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "partsDesc":
                    this.partsDesc.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.PartsDesc>());
                    return;
                case "entityParams":
                    this.entityParams.Insert(key, value.GetValueAsEntityLink());
                    return;
                case "fileParams":
                    this.fileParams.Insert(key, value.GetValueAsFilePtr());
                    return;
                case "controlCharacters":
                    this.controlCharacters.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.DemoControlCharacterDesc>());
                    return;
                case "controlDatas":
                    this.controlDatas.Insert(key, value.GetValueAsEntityLink());
                    return;
                case "controlCollectibles":
                    this.controlCollectibles.Insert(key, value.GetValueAsString());
                    return;
                case "parameters":
                    this.parameters.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.DemoParameter>());
                    return;
                case "setupLights":
                    this.setupLights.Insert(key, value.GetValueAsString());
                    return;
                case "objectNum":
                    this.objectNum.Insert(key, value.GetValueAsInt32());
                    return;
                default:
					
                    base.SetPropertyElement(propertyName, key, value);
                    return;
            }
        }
    }
}