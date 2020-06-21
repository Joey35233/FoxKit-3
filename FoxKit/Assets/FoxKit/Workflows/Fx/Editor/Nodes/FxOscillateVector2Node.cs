using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Vector/OscillateVector2")]
public class FxOscillateVector2Node : BaseNode
{
	[Input(name = "Input0")]
	public float Input0;

	[Input(name = "Input1")]
	public float Input1;

	[Output(name = "Output0")]
	public float Output0;

	[SerializeField]
	public bool Periodicity;

	public override string name => "OscillateVector2";
}