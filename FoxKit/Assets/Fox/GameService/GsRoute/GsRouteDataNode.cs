using UnityEditor;

namespace Fox.GameService
{
    public partial class GsRouteDataNode : Fox.Graphx.GraphxSpatialGraphDataNode
    {
        public override int GetDirectionCount() => nodeEvents.Count;

        public override float GetDirection(int index)
        {
            if (index >= 0 && index < nodeEvents.Count && nodeEvents[index] != null)
                return nodeEvents[index].direction;

            return 0f;
        }

        public override void SetDirection(int index, float value)
        {
            if (index < 0 || index >= nodeEvents.Count || nodeEvents[index] == null)
                return;

            Undo.RecordObject(nodeEvents[index], "Set Node Event Direction");
            nodeEvents[index].direction = value;
        }

        public override System.Type GetNodeEventTypeAt(int index)
        {
            if (index >= 0 && index < nodeEvents.Count && nodeEvents[index] != null)
                return nodeEvents[index].GetType();

            return null;
        }
    }
}
