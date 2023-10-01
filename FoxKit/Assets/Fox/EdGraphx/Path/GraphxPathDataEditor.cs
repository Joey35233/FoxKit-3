using Fox.EdCore;
using Fox.Graphx;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGraphx
{
    [CustomEditor(typeof(GraphxPathData), editorForChildClasses: true)]
    public class GraphxPathDataEditor : EntityEditor
    {
        private GraphxPathData Path => (GraphxPathData)target;

        private bool HasFrameBounds() => Path.nodes.Count > 0;

        public Bounds OnGetFrameBounds()
        {
            var bounds = new Bounds(Path.transform.localToWorldMatrix.MultiplyPoint(Path.nodes[0].position), new Vector3(0, 0, 0));
            for (int i = 1; i < Path.nodes.Count; i++)
                bounds.Encapsulate(Path.transform.localToWorldMatrix.MultiplyPoint(Path.nodes[i].position));

            return bounds;
        }
    }
}