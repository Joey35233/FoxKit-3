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

namespace Fox.GameService
{
	[UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("GameService/GsRouteDataNode")]
	public partial class GsRouteDataNode : Fox.Graphx.GraphxSpatialGraphDataNode
	{
		// Properties
		[field: UnityEngine.SerializeField]
		public CsSystem.Collections.Generic.List<Fox.GameService.GsRouteDataNodeEvent> nodeEvents { get; private set; } = new CsSystem.Collections.Generic.List<Fox.GameService.GsRouteDataNodeEvent>();
		
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
		static GsRouteDataNode()
		{
			if (Fox.Graphx.GraphxSpatialGraphDataNode.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo("GsRouteDataNode", typeof(GsRouteDataNode), Fox.Graphx.GraphxSpatialGraphDataNode.ClassInfo, 0, null, 0);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo("nodeEvents", Fox.Core.PropertyInfo.PropertyType.EntityPtr, 72, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, typeof(Fox.GameService.GsRouteDataNodeEvent), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));

			ClassInfoInitialized = true;
		}
		
		public override Fox.Core.Value GetProperty(string propertyName)
		{
			switch (propertyName)
			{
				case "nodeEvents":
					return new Fox.Core.Value(nodeEvents);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, ushort index)
		{
			switch (propertyName)
			{
				case "nodeEvents":
					return new Fox.Core.Value(this.nodeEvents[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(string propertyName, string key)
		{
			switch (propertyName)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(string propertyName, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetProperty(propertyName, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, ushort index, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				case "nodeEvents":
					while(this.nodeEvents.Count <= index) { this.nodeEvents.Add(default(Fox.GameService.GsRouteDataNodeEvent)); }
					this.nodeEvents[index] = value.GetValueAsEntityPtr<Fox.GameService.GsRouteDataNodeEvent>();
					return;
				default:
					base.SetPropertyElement(propertyName, index, value);
					return;
			}
		}

		public override void SetPropertyElement(string propertyName, string key, Fox.Core.Value value)
		{
			switch (propertyName)
			{
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}