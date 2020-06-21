using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Vector/TimeScale")]
public class FxTimeScaleVectorNode : BaseNode
{
	[Input(name = "Input0")]
	public float Input0;

	[Output(name = "Output0")]
	public float Output0;

	[SerializeField]
	public float EndScale;

	[SerializeField]
	public bool MaskW;

	[SerializeField]
	public bool MaskX;

	[SerializeField]
	public bool MaskY;

	[SerializeField]
	public bool MaskZ;

	[SerializeField]
	public float StartScale;

	public override string name => "TimeScale";
}