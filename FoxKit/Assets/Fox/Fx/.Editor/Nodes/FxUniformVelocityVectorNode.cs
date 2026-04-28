using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Vector/UniformVelocity")]
    public class FxUniformVelocityVectorNode : BaseNode
    {
        [Input(name = "Input0")]
        public float Input0;

        [Output(name = "Output0")]
        public float Output0;

        public override string name => "UniformVelocity";
    }
}