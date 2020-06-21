using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Shape/PlaneRot")]
public class FxPlaneRotShapeNode : BaseNode
{
	[Input(name = "Input0")]
	public object Input0;

	[Input(name = "Input1")]
	public object Input1;

	[Input(name = "Input2")]
	public object Input2;

	[Input(name = "Input3")]
	public object Input3;

	[Input(name = "Input4")]
	public object Input4;

	[Input(name = "Input5")]
	public object Input5;

	[Input(name = "Input6")]
	public object Input6;

	[Input(name = "Input7")]
	public object Input7;

	[Output(name = "Output0")]
	public object Output0;

	[SerializeField]
	public Vector4 AutoBoundingBoxMargin;

	[SerializeField]
	public int AxisFix;

	[SerializeField]
	public string AxisFixParticleDirectionPoolName;

	[SerializeField]
	public Quaternion BaseRot;

	[SerializeField]
	public float BaseSizeScale;

	[SerializeField]
	public int BoundingBoxType;

	[SerializeField]
	public float CenterU;

	[SerializeField]
	public float CenterV;

	[SerializeField]
	public bool CullFace;

	[SerializeField]
	public new bool Enable;

	[SerializeField]
	public bool LocalSpace;

	[SerializeField]
	public Vector3 ManualBoundingBoxOffset;

	[SerializeField]
	public Vector3 ManualBoundingBoxSize;

	[SerializeField]
	public uint NumSimulatedMaxParticle;

	[SerializeField]
	public bool RotGlobal;

	[SerializeField]
	public int RotateOrderType;

	[SerializeField]
	public int SortMode;

	[SerializeField]
	public float SortOffset;

	public override string name => "PlaneRot";
}