using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Color/Color")]
public class FxColorVectorNode : BaseNode
{
	[Output(name = "Color"), SerializeField]
	public Color Color;

	public override string name => "Color";
}