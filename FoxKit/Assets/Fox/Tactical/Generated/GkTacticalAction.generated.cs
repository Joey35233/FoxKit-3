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

namespace Fox.Tactical
{
	[UnityEditor.InitializeOnLoad]
	public partial class GkTacticalAction : Fox.Core.TransformData
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public bool enable { get; set; }
		
		[field: UnityEngine.SerializeField]
		public bool enableInGame { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String worldName { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Core.EntityLink userData { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.String userId { get; set; }
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>> waypoints { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>> edges { get; set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> attributeNames { get; set; } = new Fox.Kernel.DynamicArray<Fox.Kernel.String>();
		
		[field: UnityEngine.SerializeField]
		public uint attribute { get; set; }
		
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
		static GkTacticalAction()
		{
			if (Fox.Core.TransformData.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("GkTacticalAction"), typeof(GkTacticalAction), Fox.Core.TransformData.ClassInfo, 368, "TacticalAction", 7);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enable"), Fox.Core.PropertyInfo.PropertyType.Bool, 304, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("enableInGame"), Fox.Core.PropertyInfo.PropertyType.Bool, 305, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("worldName"), Fox.Core.PropertyInfo.PropertyType.String, 312, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("userData"), Fox.Core.PropertyInfo.PropertyType.EntityLink, 320, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("userId"), Fox.Core.PropertyInfo.PropertyType.String, 360, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("waypoints"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 368, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Tactical.GkTacticalActionWaypoint), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("edges"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 384, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.Tactical.GkTacticalActionEdge), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attributeNames"), Fox.Core.PropertyInfo.PropertyType.String, 400, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("attribute"), Fox.Core.PropertyInfo.PropertyType.UInt32, 416, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, Fox.Core.PropertyInfo.PropertyExport.EditorOnly, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}

		// Constructors
		public GkTacticalAction(ulong id) : base(id) { }
		public GkTacticalAction() : base() { }

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch(propertyName.CString)
			{
				case "enable":
					this.enable = value.GetValueAsBool();
					return;
				case "enableInGame":
					this.enableInGame = value.GetValueAsBool();
					return;
				case "worldName":
					this.worldName = value.GetValueAsString();
					return;
				case "userData":
					this.userData = value.GetValueAsEntityLink();
					return;
				case "userId":
					this.userId = value.GetValueAsString();
					return;
				case "attribute":
					this.attribute = value.GetValueAsUInt32();
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
				case "waypoints":
					while(this.waypoints.Count <= index) { this.waypoints.Add(default(Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionWaypoint>)); }
					this.waypoints[index] = value.GetValueAsEntityPtr<Fox.Tactical.GkTacticalActionWaypoint>();
					return;
				case "edges":
					while(this.edges.Count <= index) { this.edges.Add(default(Fox.Core.EntityPtr<Fox.Tactical.GkTacticalActionEdge>)); }
					this.edges[index] = value.GetValueAsEntityPtr<Fox.Tactical.GkTacticalActionEdge>();
					return;
				case "attributeNames":
					while(this.attributeNames.Count <= index) { this.attributeNames.Add(default(Fox.Kernel.String)); }
					this.attributeNames[index] = value.GetValueAsString();
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