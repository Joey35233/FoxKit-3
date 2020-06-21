using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Time/FxDragTimeVectorNode")]
public class FxDragTimeVectorNode : BaseNode
{
	[Output(name = "Output0")]
	public float Output0;

	[SerializeField]
	public float Drag;
	[SerializeField]
	public int Method;
	[SerializeField]
	public float Scale;

	public override string name => "FxDragTimeVectorNode";
}