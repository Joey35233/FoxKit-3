using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Color/Color")]
public class FxColorVectorNode : BaseNode
{
	[Output(name = "Output0")]
	public Color Output0;

	[SerializeField]
	public Color Color;

	public override string name => "Color";
}