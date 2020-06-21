using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

public enum FxVectorType
{
	Vector = 0,
	Rotates = 1,
	Color = 2,
}

[System.Serializable, NodeMenuItem("Vector/FxConstVectorNode")]
public class FxConstVectorNode : BaseNode
{
	[Output(name = "Output0")]
	public Vector4 Output0;

	[SerializeField]
	public uint Force;
	[SerializeField]
	public bool Global;
	[SerializeField]
	public Vector4 Vector;
	[SerializeField]
	public FxVectorType VectorType;

	public override string name => "FxConstVectorNode";
}