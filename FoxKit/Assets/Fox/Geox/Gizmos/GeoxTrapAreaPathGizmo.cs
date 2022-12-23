using Fox.Graphx;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Geox
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GeoxTrapAreaPathGizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.red;
        public void DrawGizmos(bool isSelected)
        {
            var entityComponent = gameObject.GetComponent<Fox.Core.FoxEntity>();
            if (entityComponent == null)
                return;

            GeoxTrapAreaPath entity = entityComponent.Entity as GeoxTrapAreaPath;
            if (entity == null)
                return;
            if (isSelected)
                Gizmos.color = Color.white;
            else
                Gizmos.color = Color;

            Gizmos.DrawWireCube(transform.position, Vector3.one * 0.25f);

            for (int side = 0; side <= 1; side++)
            {
                for (int nodeIndex = 0; nodeIndex < entity.nodes.Count; nodeIndex++)
                {
                    GraphxSpatialGraphDataNode prevNode;
                    if (nodeIndex == 0)
                        prevNode = entity.nodes[entity.nodes.Count - 1].Get();
                    else
                        prevNode = entity.nodes[nodeIndex - 1].Get();
                    var nextNode = entity.nodes[nodeIndex].Get();


                    var prevNodePosition = Kernel.Math.FoxToUnityVector3(prevNode.position);
                    var nextNodePosition = Kernel.Math.FoxToUnityVector3(nextNode.position);
                    var globalPrevNodePosition = transform.position + prevNodePosition;
                    var globalNextNodePosition = transform.position + nextNodePosition;

                    var globalPrevNodePositionCenter = globalPrevNodePosition;
                    var globalNextNodePositionCenter = globalNextNodePosition;

                    globalPrevNodePositionCenter.y = transform.position.y;
                    globalNextNodePositionCenter.y = transform.position.y;

                    var globalPrevNodePositionTop = globalPrevNodePosition;
                    var globalNextNodePositionTop = globalNextNodePosition;
                    globalPrevNodePositionTop.y += entity.height;
                    globalNextNodePositionTop.y += entity.height;

                    if (side > 0)
                    {
                        Gizmos.DrawLine(globalNextNodePosition, globalNextNodePositionTop);
                    }

                    Gizmos.DrawLine(globalPrevNodePosition, globalNextNodePosition);
                    Gizmos.DrawLine(globalPrevNodePositionTop, globalNextNodePositionTop);
                };
            }
        }
        public void OnDrawGizmos()
        {
            DrawGizmos(false);
        }
        public void OnDrawGizmosSelected()
        {
            DrawGizmos(true);
        }
    }
}
