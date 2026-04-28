using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("System/Root")]
    public class FxModuleGraphNode : BaseNode
    {
        // Note: way the heck more than 1
        [Input(name = "Input0")]
        public float Output0;

        [SerializeField]
        private uint AllFrame;

        [SerializeField]
        private Vector3 BoundingBoxOffsetPos;

        [SerializeField]
        private Vector3 BoundingBoxSize;

        [SerializeField]
        private FxBoundingBoxType BoundingBoxType;

        [SerializeField]
        private bool DebugInfo;

        [SerializeField]
        private ulong EffectName;

        [SerializeField]
        private FxExecutionPriorityType ExecutionPriorityType;

        [SerializeField]
        private uint FadeInEndFrame;

        [SerializeField]
        private uint FadeOutStartFrame;

        [SerializeField]
        private FxPlayModeType PlayMode;

        [SerializeField]
        private FxUpdateType UpdateType;

        public override string name => "Root";
    }
}