using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

namespace FoxKit.Fx.Editor.Nodes
{
	[System.Serializable, NodeMenuItem("Vector/UniformVelocityTime")]
	public class FxUniformVelocityTimeVectorNode : BaseNode
	{
		[Input(name = "Input0")]
		public float Input0;

		[Input(name = "Input1")]
		public float Input1;

		[Output(name = "Output0")]
		public float Output0;

		public override string name => "UniformVelocityTime";
	}
}