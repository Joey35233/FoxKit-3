using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Color/Color")]
    public class FxColorVectorNode : BaseNode
    {
        [Output(name = "Output0")]
        public Color Output0;

        [SerializeField]
        public Color Color;

        public override string name => "Color";
    }
}