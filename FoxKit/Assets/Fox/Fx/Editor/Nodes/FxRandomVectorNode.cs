using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Vector/Random")]
    public class FxRandomVectorNode : BaseNode
    {
        [Output(name = "Output0")]
        public float Output0;

        [SerializeField]
        public float Force;

        [SerializeField]
        public bool Global;

        [SerializeField]
        public bool GlobalEvaluateRealTimeRootRotate;

        [SerializeField]
        public uint RandomGatherSeedValue;

        [SerializeField]
        public int RandomGatherType;

        [SerializeField]
        public Vector4 RandomMax;

        [SerializeField]
        public Vector4 RandomMin;

        [SerializeField]
        public int VectorType;

        [SerializeField]
        public bool XySquere;

        public override string name => "Random";
    }
}