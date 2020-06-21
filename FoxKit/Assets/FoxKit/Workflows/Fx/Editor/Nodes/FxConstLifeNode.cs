using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

[System.Serializable, NodeMenuItem("Life/FxConstLifeNode")]
public class FxConstLifeNode : BaseNode
{
	[Output(name = "Output0")]
	public float Output0;

	[SerializeField]
	public uint LifeFrame;

	public override string name => "FxConstLifeNode";
}