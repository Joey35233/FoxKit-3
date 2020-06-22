using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("System/Root")]
    public class FxModuleGraphNode : BaseNode
    {
        // Note: way the heck more than 1
        [Input(name = "Input0")]
        public float Output0;

        [SerializeField]
        uint AllFrame;

        [SerializeField]
        Vector3 BoundingBoxOffsetPos;

        [SerializeField]
        Vector3 BoundingBoxSize;

        [SerializeField]
        FxBoundingBoxType BoundingBoxType;

        [SerializeField]
        bool DebugInfo;

        [SerializeField]
        ulong EffectName;

        [SerializeField]
        FxExecutionPriorityType ExecutionPriorityType;

        [SerializeField]
        uint FadeInEndFrame;

        [SerializeField]
        uint FadeOutStartFrame;

        [SerializeField]
        FxPlayModeType PlayMode;

        [SerializeField]
        FxUpdateType UpdateType;

        public override string name => "Root";
    }
}