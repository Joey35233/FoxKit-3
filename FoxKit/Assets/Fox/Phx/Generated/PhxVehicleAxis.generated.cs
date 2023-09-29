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

namespace Fox.Phx
{
	[UnityEditor.InitializeOnLoad]
	public partial class PhxVehicleAxis : Fox.Core.Data
	{
		// Properties
		[field: UnityEngine.SerializeField]
		protected Fox.Core.EntityPtr<Fox.Phx.PhVehicleAxisParam> vehicleAxisParam { get; set; } = new Fox.Core.EntityPtr<Fox.Phx.PhVehicleAxisParam>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Core.EntityPtr<Fox.Phx.PhxWheelConstraintParam> wheelConstraintParam { get; set; } = new Fox.Core.EntityPtr<Fox.Phx.PhxWheelConstraintParam>();
		
		[field: UnityEngine.SerializeField]
		protected Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>> wheelAssociationUnitParams { get; private set; } = new Fox.Kernel.DynamicArray<Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> torqueDistributions { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		[field: UnityEngine.SerializeField]
		public Fox.Kernel.DynamicArray<float> gearRatios { get; private set; } = new Fox.Kernel.DynamicArray<float>();
		
		public UnityEngine.Vector3 wheelFront { get => Get_wheelFront(); set { Set_wheelFront(value); } }
		private partial UnityEngine.Vector3 Get_wheelFront();
		private partial void Set_wheelFront(UnityEngine.Vector3 value);
		
		public UnityEngine.Vector3 wheelUp { get => Get_wheelUp(); set { Set_wheelUp(value); } }
		private partial UnityEngine.Vector3 Get_wheelUp();
		private partial void Set_wheelUp(UnityEngine.Vector3 value);
		
		public UnityEngine.Vector3 wheelPositionOffset { get => Get_wheelPositionOffset(); set { Set_wheelPositionOffset(value); } }
		private partial UnityEngine.Vector3 Get_wheelPositionOffset();
		private partial void Set_wheelPositionOffset(UnityEngine.Vector3 value);
		
		public float wheelRadius { get => Get_wheelRadius(); set { Set_wheelRadius(value); } }
		private partial float Get_wheelRadius();
		private partial void Set_wheelRadius(float value);
		
		public float wheelFriction { get => Get_wheelFriction(); set { Set_wheelFriction(value); } }
		private partial float Get_wheelFriction();
		private partial void Set_wheelFriction(float value);
		
		public float wheelRestitution { get => Get_wheelRestitution(); set { Set_wheelRestitution(value); } }
		private partial float Get_wheelRestitution();
		private partial void Set_wheelRestitution(float value);
		
		public float wheelInertia { get => Get_wheelInertia(); set { Set_wheelInertia(value); } }
		private partial float Get_wheelInertia();
		private partial void Set_wheelInertia(float value);
		
		public float suspentionLength { get => Get_suspentionLength(); set { Set_suspentionLength(value); } }
		private partial float Get_suspentionLength();
		private partial void Set_suspentionLength(float value);
		
		public float maxSuspentionForceCoeff { get => Get_maxSuspentionForceCoeff(); set { Set_maxSuspentionForceCoeff(value); } }
		private partial float Get_maxSuspentionForceCoeff();
		private partial void Set_maxSuspentionForceCoeff(float value);
		
		public float dampingCoeffElong { get => Get_dampingCoeffElong(); set { Set_dampingCoeffElong(value); } }
		private partial float Get_dampingCoeffElong();
		private partial void Set_dampingCoeffElong(float value);
		
		public float dampingCoeffCompress { get => Get_dampingCoeffCompress(); set { Set_dampingCoeffCompress(value); } }
		private partial float Get_dampingCoeffCompress();
		private partial void Set_dampingCoeffCompress(float value);
		
		public float maxBreakTorqueCoeff { get => Get_maxBreakTorqueCoeff(); set { Set_maxBreakTorqueCoeff(value); } }
		private partial float Get_maxBreakTorqueCoeff();
		private partial void Set_maxBreakTorqueCoeff(float value);
		
		public bool useDifferential { get => Get_useDifferential(); set { Set_useDifferential(value); } }
		private partial bool Get_useDifferential();
		private partial void Set_useDifferential(bool value);
		
		public Fox.Kernel.DynamicArray<Fox.Kernel.String> AssignedBoneNames { get => Get_AssignedBoneNames(); set { Set_AssignedBoneNames(value); } }
		private partial Fox.Kernel.DynamicArray<Fox.Kernel.String> Get_AssignedBoneNames();
		private partial void Set_AssignedBoneNames(Fox.Kernel.DynamicArray<Fox.Kernel.String> value);
		
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
		static PhxVehicleAxis()
		{
			if (Fox.Core.Data.ClassInfoInitialized)
				classInfo = new Fox.Core.EntityInfo(new Fox.Kernel.String("PhxVehicleAxis"), typeof(PhxVehicleAxis), Fox.Core.Data.ClassInfo, 128, "Phx", 1);
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("vehicleAxisParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 120, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhVehicleAxisParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelConstraintParam"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 128, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhxWheelConstraintParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelAssociationUnitParams"), Fox.Core.PropertyInfo.PropertyType.EntityPtr, 136, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.Never, Fox.Core.PropertyInfo.PropertyExport.Never, typeof(Fox.Phx.PhxWheelAssociationUnitParam), null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("torqueDistributions"), Fox.Core.PropertyInfo.PropertyType.Float, 152, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("gearRatios"), Fox.Core.PropertyInfo.PropertyType.Float, 168, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Field));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelFront"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelUp"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelPositionOffset"), Fox.Core.PropertyInfo.PropertyType.Vector3, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelRadius"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelFriction"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelRestitution"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("wheelInertia"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("suspentionLength"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxSuspentionForceCoeff"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dampingCoeffElong"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("dampingCoeffCompress"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("maxBreakTorqueCoeff"), Fox.Core.PropertyInfo.PropertyType.Float, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("useDifferential"), Fox.Core.PropertyInfo.PropertyType.Bool, 0, 1, Fox.Core.PropertyInfo.ContainerType.StaticArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));
			classInfo.AddStaticProperty(new Fox.Core.PropertyInfo(new Fox.Kernel.String("AssignedBoneNames"), Fox.Core.PropertyInfo.PropertyType.String, 0, 1, Fox.Core.PropertyInfo.ContainerType.DynamicArray, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, Fox.Core.PropertyInfo.PropertyExport.EditorAndGame, null, null, Fox.Core.PropertyInfo.PropertyStorage.Instance, Fox.Core.PropertyInfo.BackingType.Accessor));

			ClassInfoInitialized = true;
		}

		// Constructors
		public PhxVehicleAxis(ulong id) : base(id) { }
		public PhxVehicleAxis() : base() { }
		
		public override Fox.Core.Value GetProperty(Fox.Kernel.String propertyName)
		{
			switch (propertyName.CString)
			{
				case "vehicleAxisParam":
					return new Fox.Core.Value(vehicleAxisParam);
				case "wheelConstraintParam":
					return new Fox.Core.Value(wheelConstraintParam);
				case "wheelAssociationUnitParams":
					return new Fox.Core.Value(wheelAssociationUnitParams);
				case "torqueDistributions":
					return new Fox.Core.Value(torqueDistributions);
				case "gearRatios":
					return new Fox.Core.Value(gearRatios);
				case "wheelFront":
					return new Fox.Core.Value(wheelFront);
				case "wheelUp":
					return new Fox.Core.Value(wheelUp);
				case "wheelPositionOffset":
					return new Fox.Core.Value(wheelPositionOffset);
				case "wheelRadius":
					return new Fox.Core.Value(wheelRadius);
				case "wheelFriction":
					return new Fox.Core.Value(wheelFriction);
				case "wheelRestitution":
					return new Fox.Core.Value(wheelRestitution);
				case "wheelInertia":
					return new Fox.Core.Value(wheelInertia);
				case "suspentionLength":
					return new Fox.Core.Value(suspentionLength);
				case "maxSuspentionForceCoeff":
					return new Fox.Core.Value(maxSuspentionForceCoeff);
				case "dampingCoeffElong":
					return new Fox.Core.Value(dampingCoeffElong);
				case "dampingCoeffCompress":
					return new Fox.Core.Value(dampingCoeffCompress);
				case "maxBreakTorqueCoeff":
					return new Fox.Core.Value(maxBreakTorqueCoeff);
				case "useDifferential":
					return new Fox.Core.Value(useDifferential);
				case "AssignedBoneNames":
					return new Fox.Core.Value(AssignedBoneNames);
				default:
					return base.GetProperty(propertyName);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, ushort index)
		{
			switch (propertyName.CString)
			{
				case "wheelAssociationUnitParams":
					return new Fox.Core.Value(this.wheelAssociationUnitParams[index]);
				case "torqueDistributions":
					return new Fox.Core.Value(this.torqueDistributions[index]);
				case "gearRatios":
					return new Fox.Core.Value(this.gearRatios[index]);
				case "AssignedBoneNames":
					return new Fox.Core.Value(this.AssignedBoneNames[index]);
				default:
					return base.GetPropertyElement(propertyName, index);
			}
		}

		public override Fox.Core.Value GetPropertyElement(Fox.Kernel.String propertyName, Fox.Kernel.String key)
		{
			switch (propertyName.CString)
			{
				default:
					return base.GetPropertyElement(propertyName, key);
			}
		}

		public override void SetProperty(Fox.Kernel.String propertyName, Fox.Core.Value value)
		{
			switch (propertyName.CString)
			{
				case "vehicleAxisParam":
					this.vehicleAxisParam = value.GetValueAsEntityPtr<Fox.Phx.PhVehicleAxisParam>();
					return;
				case "wheelConstraintParam":
					this.wheelConstraintParam = value.GetValueAsEntityPtr<Fox.Phx.PhxWheelConstraintParam>();
					return;
				case "wheelFront":
					this.wheelFront = value.GetValueAsVector3();
					return;
				case "wheelUp":
					this.wheelUp = value.GetValueAsVector3();
					return;
				case "wheelPositionOffset":
					this.wheelPositionOffset = value.GetValueAsVector3();
					return;
				case "wheelRadius":
					this.wheelRadius = value.GetValueAsFloat();
					return;
				case "wheelFriction":
					this.wheelFriction = value.GetValueAsFloat();
					return;
				case "wheelRestitution":
					this.wheelRestitution = value.GetValueAsFloat();
					return;
				case "wheelInertia":
					this.wheelInertia = value.GetValueAsFloat();
					return;
				case "suspentionLength":
					this.suspentionLength = value.GetValueAsFloat();
					return;
				case "maxSuspentionForceCoeff":
					this.maxSuspentionForceCoeff = value.GetValueAsFloat();
					return;
				case "dampingCoeffElong":
					this.dampingCoeffElong = value.GetValueAsFloat();
					return;
				case "dampingCoeffCompress":
					this.dampingCoeffCompress = value.GetValueAsFloat();
					return;
				case "maxBreakTorqueCoeff":
					this.maxBreakTorqueCoeff = value.GetValueAsFloat();
					return;
				case "useDifferential":
					this.useDifferential = value.GetValueAsBool();
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
				case "wheelAssociationUnitParams":
					while(this.wheelAssociationUnitParams.Count <= index) { this.wheelAssociationUnitParams.Add(default(Fox.Core.EntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>)); }
					this.wheelAssociationUnitParams[index] = value.GetValueAsEntityPtr<Fox.Phx.PhxWheelAssociationUnitParam>();
					return;
				case "torqueDistributions":
					while(this.torqueDistributions.Count <= index) { this.torqueDistributions.Add(default(float)); }
					this.torqueDistributions[index] = value.GetValueAsFloat();
					return;
				case "gearRatios":
					while(this.gearRatios.Count <= index) { this.gearRatios.Add(default(float)); }
					this.gearRatios[index] = value.GetValueAsFloat();
					return;
				case "AssignedBoneNames":
					while(this.AssignedBoneNames.Count <= index) { this.AssignedBoneNames.Add(default(Fox.Kernel.String)); }
					this.AssignedBoneNames[index] = value.GetValueAsString();
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
				default:
					base.SetPropertyElement(propertyName, key, value);
					return;
			}
		}
	}
}