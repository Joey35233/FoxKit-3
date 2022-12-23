using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fox.Geox
{
    [DisallowMultipleComponent, ExecuteInEditMode, SelectionBase]
    public class GeoxPath2Gizmo : MonoBehaviour
    {
        [HideInInspector]
        public Color Color = Color.white;
        [HideInInspector]
        public Vector3 Scale = Vector3.one * 0.1f;
        [HideInInspector]
        public Vector3 ScaleNode = Vector3.one * 0.25f;
        public void OnDrawGizmos()
        {
            var entityComponent = gameObject.GetComponent<Fox.Core.FoxEntity>();
            if (entityComponent == null)
                return;

            GeoxPath2 entity = entityComponent.Entity as GeoxPath2;
            if (entity == null)
                return;

            Gizmos.DrawWireCube(transform.position, Scale);

            for (int nodeIndex = 0; nodeIndex < entity.nodes.Count; nodeIndex++)
            {
                var node = entity.nodes[nodeIndex].Get();
                var globalNodePosition = transform.TransformPoint(node.position);

                Gizmos.DrawWireCube(globalNodePosition, ScaleNode);

                for (int edgeIndex = 0; edgeIndex < node.outlinks.Count; edgeIndex++)
                {
                    var edge = node.outlinks[edgeIndex].Entity as GeoxPathEdge;

                    var prevNode = edge.prevNode.Entity as GeoxPathNode;
                    var globalPrevNodePosition = transform.TransformPoint(prevNode.position);

                    var nextNode = edge.nextNode.Entity as GeoxPathNode;
                    var globalNextNodePosition = transform.TransformPoint(nextNode.position);

                    Gizmos.DrawLine(globalPrevNodePosition, globalNextNodePosition);
                }
            }
        }
    }
}
