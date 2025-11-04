using Assets.Fox.EdGraphx;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxPathData), editorForChildClasses: true)]
    public class GraphxPathDataEditor : GraphxSpatialGraphDataEditor
    {
        private GraphxPathData Path => (GraphxPathData)target;

        private bool HasFrameBounds() => Path.nodes.Count > 0;

        public Bounds OnGetFrameBounds()
        {
            var bounds = new Bounds(Path.GetGraphWorldPosition(Path.nodes[0].position), new Vector3(0, 0, 0));
            for (int i = 1; i < Path.nodes.Count; i++)
                bounds.Encapsulate(Path.GetGraphWorldPosition(Path.nodes[i].position));

            return bounds;
        }
    }
}