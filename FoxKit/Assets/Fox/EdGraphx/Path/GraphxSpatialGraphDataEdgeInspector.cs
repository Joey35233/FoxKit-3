using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxSpatialGraphDataEdge), editorForChildClasses: true)]
    public class GraphxSpatialGraphDataEdgeInspector : BaseEntityEditor
    {
        private GraphxSpatialGraphDataEdge Edge => (GraphxSpatialGraphDataEdge)target;

        private bool HasFrameBounds() => Edge.transform.parent.GetComponent<GraphxSpatialGraphData>() is not null && Edge.prevNode is not null && Edge.nextNode is not null;

        private void OnEnable()
        {
            Tools.hidden = true;
        }

        private void OnDisable()
        {
            Tools.hidden = false;
        }

        public Bounds OnGetFrameBounds()
        {
            GraphxSpatialGraphData graph = Edge.transform.parent.GetComponent<GraphxSpatialGraphData>();

            var bounds = new Bounds(graph.GetGraphWorldPosition((Edge.prevNode as GraphxSpatialGraphDataNode).position),
                new Vector3(0, 0, 0));
            bounds.Encapsulate(graph.GetGraphWorldPosition((Edge.nextNode as GraphxSpatialGraphDataNode).position));

            return bounds;
        }
    }
}