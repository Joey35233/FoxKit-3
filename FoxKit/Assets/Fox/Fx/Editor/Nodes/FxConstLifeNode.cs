using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

namespace FoxKit.Fx.Editor.Nodes
{
	[System.Serializable, NodeMenuItem("Life/Life")]
	public class FxConstLifeNode : BaseNode
	{
		[Output(name = "Output0")]
		public float Output0;

		[SerializeField]
		public uint LifeFrame;

		public override string name => "Life";
	}
}