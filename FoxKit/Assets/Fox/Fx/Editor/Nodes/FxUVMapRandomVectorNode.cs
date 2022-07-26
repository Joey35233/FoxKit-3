using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

namespace FoxKit.Fx.Editor.Nodes
{
	[System.Serializable, NodeMenuItem("Vector/UVMapRandom")]
	public class FxUVMapRandomVectorNode : BaseNode
	{
		[Output(name = "Output0")]
		public float Output0;

		[SerializeField]
		public uint RandomDivisionHeightGrid;

		[SerializeField]
		public uint RandomDivisionWidthGrid;

		[SerializeField]
		public bool RandomFlipU;

		[SerializeField]
		public bool RandomFlipV;

		[SerializeField]
		public uint RandomGatherSeedValue;

		[SerializeField]
		public int RandomGatherType;

		public override string name => "UVMapRandom";
	}
}