using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Vector/UniformVelocity")]
public class FxUniformVelocityVectorNode : BaseNode
{
	[Input(name = "Input0")]
	public float Input0;

	[Output(name = "Output0")]
	public float Output0;

	public override string name => "UniformVelocity";
}