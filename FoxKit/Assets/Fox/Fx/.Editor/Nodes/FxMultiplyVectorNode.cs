using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Vector/x")]
    public class FxMultiplyVectorNode : BaseNode
    {
        [Input(name = "Input0")]
        public float Input0;

        [Input(name = "Input1")]
        public float Input1;

        [Output(name = "Output0")]
        public float Output0;

        [SerializeField]
        public float MaskValue;

        [SerializeField]
        public bool SecondMaskW;

        [SerializeField]
        public bool SecondMaskX;

        [SerializeField]
        public bool SecondMaskY;

        [SerializeField]
        public bool SecondMaskZ;

        public override string name => "x";
    }
}