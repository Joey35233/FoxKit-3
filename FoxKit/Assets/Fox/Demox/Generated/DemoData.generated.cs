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
	[UnityEditor.InitializeOnLoad]
	public partial class DemoData : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.FilePtr> evfFiles { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public bool onMemory { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int demoLength { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int priority { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path scriptPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> fmdlFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> helpBoneFiles { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demo.PartsDesc> partsDesc { get; private set; } = new Fox.Kernel.StringMap<Fox.Demo.PartsDesc>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Demo.ClipData> clipDatas { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Demo.ClipData>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.Path> loadFiles { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String demoId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink playingRoot { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink streamAnimation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path demoStreamPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path motionPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr motionFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.Path audioPath { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr subtitleFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr subtitleBinaryFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.FilePtr nodeDataFile { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> stringParams { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.EntityLink> entityParams { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.FilePtr> fileParams { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.FilePtr>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demo.DemoControlCharacterDesc> controlCharacters { get; private set; } = new Fox.Kernel.StringMap<Fox.Demo.DemoControlCharacterDesc>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Core.EntityLink> controlDatas { get; private set; } = new Fox.Kernel.StringMap<Fox.Core.EntityLink>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.String> controlCollectibles { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Demo.DemoParameter> parameters { get; private set; } = new Fox.Kernel.StringMap<Fox.Demo.DemoParameter>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<Fox.Kernel.String> setupLights { get; private set; } = new Fox.Kernel.StringMap<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Utility_InterpType cameraInterpType { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int cameraInterpFrame { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraInterpCurveRate { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraInterpScurveCenter { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 cameraTranslation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Quaternion cameraRotation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraDistanceToLookAt { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Vector3 cameraStartTranslation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public UnityEngine.Quaternion cameraStartRotation { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraStartParam { get; set; }
		
		[field: UnityEngine.SerializeField]
		public float cameraStartDistanceToLookAt { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int eventCacheNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int eventInterpCacheNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		public int eventSkipCacheNum { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> highestTextureStreamModel { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.Path> highestTexture { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.Path>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.StringMap<int> objectNum { get; private set; } = new Fox.Kernel.StringMap<int>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink blockPositionSetter { get; set; }
		
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
		static DemoData()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("DemoData"), typeof(DemoData), Fox.Core.TransformData.ClassInfo, 1264, null, 36);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("evfFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 304, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("onMemory"), Fox.Core.PropertyInfo.PropertyType.Bool, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoLength"), Fox.Core.PropertyInfo.PropertyType.Int32, 324, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("priority"), Fox.Core.PropertyInfo.PropertyType.Int32, 328, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("scriptPath"), Fox.Core.PropertyInfo.PropertyType.Path, 336, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fmdlFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 344, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("helpBoneFiles"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 392, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("partsDesc"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 440, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.PartsDesc), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("clipDatas"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 488, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.ClipData), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("loadFiles"), Fox.Core.PropertyInfo.PropertyType.Path, 504, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoId"), Fox.Core.PropertyInfo.PropertyType.String, 608, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("playingRoot"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 616, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("streamAnimation"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 656, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("demoStreamPath"), Fox.Core.PropertyInfo.PropertyType.Path, 696, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("motionPath"), Fox.Core.PropertyInfo.PropertyType.Path, 704, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("motionFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 712, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("audioPath"), Fox.Core.PropertyInfo.PropertyType.Path, 736, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("subtitleFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 744, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("subtitleBinaryFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 768, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("nodeDataFile"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 792, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("stringParams"), Fox.Core.PropertyInfo.PropertyType.String, 816, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("entityParams"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 832, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("fileParams"), Fox.Core.PropertyInfo.PropertyType.FilePtr, 880, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlCharacters"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 928, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.DemoControlCharacterDesc), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlDatas"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 976, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("controlCollectibles"), Fox.Core.PropertyInfo.PropertyType.String, 1024, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("parameters"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 1072, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Demo.DemoParameter), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("setupLights"), Fox.Core.PropertyInfo.PropertyType.String, 560, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraInterpType"), Fox.Core.PropertyInfo.PropertyType.Int32, 1152, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, typeof(Utility_InterpType), Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraInterpFrame"), Fox.Core.PropertyInfo.PropertyType.Int32, 1156, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraInterpCurveRate"), Fox.Core.PropertyInfo.PropertyType.Float, 1160, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraInterpScurveCenter"), Fox.Core.PropertyInfo.PropertyType.Float, 1164, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraTranslation"), Fox.Core.PropertyInfo.PropertyType.Vector3, 1168, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraRotation"), Fox.Core.PropertyInfo.PropertyType.Quat, 1184, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraParam"), Fox.Core.PropertyInfo.PropertyType.Float, 1200, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraDistanceToLookAt"), Fox.Core.PropertyInfo.PropertyType.Float, 1204, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraStartTranslation"), Fox.Core.PropertyInfo.PropertyType.Vector3, 1216, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraStartRotation"), Fox.Core.PropertyInfo.PropertyType.Quat, 1232, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraStartParam"), Fox.Core.PropertyInfo.PropertyType.Float, 1248, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("cameraStartDistanceToLookAt"), Fox.Core.PropertyInfo.PropertyType.Float, 1252, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("eventCacheNum"), Fox.Core.PropertyInfo.PropertyType.Int32, 1256, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("eventInterpCacheNum"), Fox.Core.PropertyInfo.PropertyType.Int32, 1260, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("eventSkipCacheNum"), Fox.Core.PropertyInfo.PropertyType.Int32, 1264, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("highestTextureStreamModel"), Fox.Core.PropertyInfo.PropertyType.String, 1120, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("highestTexture"), Fox.Core.PropertyInfo.PropertyType.Path, 1136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("objectNum"), Fox.Core.PropertyInfo.PropertyType.Int32, 1272, 1, Fox.Core.PropertyInfo.ContainerType.StringMap, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("blockPositionSetter"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 520, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "evfFiles":
					return new Fox.Core.Value(evfFiles);
				case "onMemory":
					return new Fox.Core.Value(onMemory);
				case "demoLength":
					return new Fox.Core.Value(demoLength);
				case "priority":
					return new Fox.Core.Value(priority);
				case "scriptPath":
					return new Fox.Core.Value(scriptPath);
				case "fmdlFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)fmdlFiles);
				case "helpBoneFiles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)helpBoneFiles);
				case "partsDesc":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)partsDesc);
				case "clipDatas":
					return new Fox.Core.Value(clipDatas);
				case "loadFiles":
					return new Fox.Core.Value(loadFiles);
				case "demoId":
					return new Fox.Core.Value(demoId);
				case "playingRoot":
					return new Fox.Core.Value(playingRoot);
				case "streamAnimation":
					return new Fox.Core.Value(streamAnimation);
				case "demoStreamPath":
					return new Fox.Core.Value(demoStreamPath);
				case "motionPath":
					return new Fox.Core.Value(motionPath);
				case "motionFile":
					return new Fox.Core.Value(motionFile);
				case "audioPath":
					return new Fox.Core.Value(audioPath);
				case "subtitleFile":
					return new Fox.Core.Value(subtitleFile);
				case "subtitleBinaryFile":
					return new Fox.Core.Value(subtitleBinaryFile);
				case "nodeDataFile":
					return new Fox.Core.Value(nodeDataFile);
				case "stringParams":
					return new Fox.Core.Value(stringParams);
				case "entityParams":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)entityParams);
				case "fileParams":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)fileParams);
				case "controlCharacters":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)controlCharacters);
				case "controlDatas":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)controlDatas);
				case "controlCollectibles":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)controlCollectibles);
				case "parameters":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)parameters);
				case "setupLights":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)setupLights);
				case "cameraInterpType":
					return new Fox.Core.Value(cameraInterpType);
				case "cameraInterpFrame":
					return new Fox.Core.Value(cameraInterpFrame);
				case "cameraInterpCurveRate":
					return new Fox.Core.Value(cameraInterpCurveRate);
				case "cameraInterpScurveCenter":
					return new Fox.Core.Value(cameraInterpScurveCenter);
				case "cameraTranslation":
					return new Fox.Core.Value(cameraTranslation);
				case "cameraRotation":
					return new Fox.Core.Value(cameraRotation);
				case "cameraParam":
					return new Fox.Core.Value(cameraParam);
				case "cameraDistanceToLookAt":
					return new Fox.Core.Value(cameraDistanceToLookAt);
				case "cameraStartTranslation":
					return new Fox.Core.Value(cameraStartTranslation);
				case "cameraStartRotation":
					return new Fox.Core.Value(cameraStartRotation);
				case "cameraStartParam":
					return new Fox.Core.Value(cameraStartParam);
				case "cameraStartDistanceToLookAt":
					return new Fox.Core.Value(cameraStartDistanceToLookAt);
				case "eventCacheNum":
					return new Fox.Core.Value(eventCacheNum);
				case "eventInterpCacheNum":
					return new Fox.Core.Value(eventInterpCacheNum);
				case "eventSkipCacheNum":
					return new Fox.Core.Value(eventSkipCacheNum);
				case "highestTextureStreamModel":
					return new Fox.Core.Value(highestTextureStreamModel);
				case "highestTexture":
					return new Fox.Core.Value(highestTexture);
				case "objectNum":
					return new Fox.Core.Value((Fox.Kernel.IStringMap)objectNum);
				case "blockPositionSetter":
					return new Fox.Core.Value(blockPositionSetter);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "evfFiles":
					return new Fox.Core.Value(this.evfFiles[index]);
				case "clipDatas":
					return new Fox.Core.Value(this.clipDatas[index]);
				case "loadFiles":
					return new Fox.Core.Value(this.loadFiles[index]);
				case "stringParams":
					return new Fox.Core.Value(this.stringParams[index]);
				case "highestTextureStreamModel":
					return new Fox.Core.Value(this.highestTextureStreamModel[index]);
				case "highestTexture":
					return new Fox.Core.Value(this.highestTexture[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				case "fmdlFiles":
					return new Fox.Core.Value(this.fmdlFiles[key]);
				case "helpBoneFiles":
					return new Fox.Core.Value(this.helpBoneFiles[key]);
				case "partsDesc":
					return new Fox.Core.Value(this.partsDesc[key]);
				case "entityParams":
					return new Fox.Core.Value(this.entityParams[key]);
				case "fileParams":
					return new Fox.Core.Value(this.fileParams[key]);
				case "controlCharacters":
					return new Fox.Core.Value(this.controlCharacters[key]);
				case "controlDatas":
					return new Fox.Core.Value(this.controlDatas[key]);
				case "controlCollectibles":
					return new Fox.Core.Value(this.controlCollectibles[key]);
				case "parameters":
					return new Fox.Core.Value(this.parameters[key]);
				case "setupLights":
					return new Fox.Core.Value(this.setupLights[key]);
				case "objectNum":
					return new Fox.Core.Value(this.objectNum[key]);
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
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

		public override void SetPropertyElement(Fox.Kernel.String propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "evfFiles":
					while(this.evfFiles.Count <= index) { this.evfFiles.Add(default(Fox.Core.FilePtr)); }
					this.evfFiles[index] = value.GetValueAsFilePtr();
					return;
				case "clipDatas":
					while(this.clipDatas.Count <= index) { this.clipDatas.Add(default(Fox.Demo.ClipData)); }
					this.clipDatas[index] = value.GetValueAsEntityPtr<Fox.Demo.ClipData>();
					return;
				case "loadFiles":
					while(this.loadFiles.Count <= index) { this.loadFiles.Add(default(Fox.Kernel.Path)); }
					this.loadFiles[index] = value.GetValueAsPath();
					return;
				case "stringParams":
					while(this.stringParams.Count <= index) { this.stringParams.Add(default(Fox.Kernel.String)); }
					this.stringParams[index] = value.GetValueAsString();
					return;
				case "highestTextureStreamModel":
					while(this.highestTextureStreamModel.Count <= index) { this.highestTextureStreamModel.Add(default(Fox.Kernel.String)); }
					this.highestTextureStreamModel[index] = value.GetValueAsString();
					return;
				case "highestTexture":
					while(this.highestTexture.Count <= index) { this.highestTexture.Add(default(Fox.Kernel.Path)); }
					this.highestTexture[index] = value.GetValueAsPath();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "fmdlFiles":
					if (this.fmdlFiles.ContainsKey(key))
						this.fmdlFiles[key] = value.GetValueAsFilePtr();
					else
						this.fmdlFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "helpBoneFiles":
					if (this.helpBoneFiles.ContainsKey(key))
						this.helpBoneFiles[key] = value.GetValueAsFilePtr();
					else
						this.helpBoneFiles.Insert(key, value.GetValueAsFilePtr());
					return;
				case "partsDesc":
					if (this.partsDesc.ContainsKey(key))
						this.partsDesc[key] = value.GetValueAsEntityPtr<Fox.Demo.PartsDesc>();
					else
						this.partsDesc.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.PartsDesc>());
					return;
				case "entityParams":
					if (this.entityParams.ContainsKey(key))
						this.entityParams[key] = value.GetValueAsEntityLink();
					else
						this.entityParams.Insert(key, value.GetValueAsEntityLink());
					return;
				case "fileParams":
					if (this.fileParams.ContainsKey(key))
						this.fileParams[key] = value.GetValueAsFilePtr();
					else
						this.fileParams.Insert(key, value.GetValueAsFilePtr());
					return;
				case "controlCharacters":
					if (this.controlCharacters.ContainsKey(key))
						this.controlCharacters[key] = value.GetValueAsEntityPtr<Fox.Demo.DemoControlCharacterDesc>();
					else
						this.controlCharacters.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.DemoControlCharacterDesc>());
					return;
				case "controlDatas":
					if (this.controlDatas.ContainsKey(key))
						this.controlDatas[key] = value.GetValueAsEntityLink();
					else
						this.controlDatas.Insert(key, value.GetValueAsEntityLink());
					return;
				case "controlCollectibles":
					if (this.controlCollectibles.ContainsKey(key))
						this.controlCollectibles[key] = value.GetValueAsString();
					else
						this.controlCollectibles.Insert(key, value.GetValueAsString());
					return;
				case "parameters":
					if (this.parameters.ContainsKey(key))
						this.parameters[key] = value.GetValueAsEntityPtr<Fox.Demo.DemoParameter>();
					else
						this.parameters.Insert(key, value.GetValueAsEntityPtr<Fox.Demo.DemoParameter>());
					return;
				case "setupLights":
					if (this.setupLights.ContainsKey(key))
						this.setupLights[key] = value.GetValueAsString();
					else
						this.setupLights.Insert(key, value.GetValueAsString());
					return;
				case "objectNum":
					if (this.objectNum.ContainsKey(key))
						this.objectNum[key] = value.GetValueAsInt32();
					else
						this.objectNum.Insert(key, value.GetValueAsInt32());
					return;
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}