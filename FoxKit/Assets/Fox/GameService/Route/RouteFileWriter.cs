using System.Collections.Generic;
using Fox.Graphx;
using UnityEngine;

namespace Fox.GameService
{
    public class RouteFileWriter
    {
        public unsafe byte[] Write(UnityEngine.SceneManagement.Scene scene)
        {
            GameObject[] rootGameObjects = scene.GetRootGameObjects();
            List<GsRouteData> routes = new List<GsRouteData>(rootGameObjects.Length);
            foreach (GameObject rootGameObject in rootGameObjects)
                if (rootGameObject.TryGetComponent(out GsRouteData route))
                    routes.Add(route);
            
            int routeCount = routes.Count;

            uint totalNodeCount = 0;
            uint totalEventCount = 0;
            for (int i = 0; i < routeCount; i++)
            {
                GsRouteData route = routes[i];

                totalNodeCount += (uint)route.nodes.Count;

                foreach (GraphxSpatialGraphDataNode node in route.nodes)
                    if (node is GsRouteDataNode routeNode)
                        foreach (GsRouteDataEvent @event in routeNode.events)
                            totalEventCount += @event != null ? 1u : 0u;

                foreach (GraphxSpatialGraphDataEdge edge in route.edges)
                    if (edge is GsRouteDataEdge routeEdge)
                        totalEventCount += routeEdge.@event != null ? 1u : 0u;
            }

            if (routeCount > ushort.MaxValue || totalEventCount > ushort.MaxValue)
                return null;

            long dataSize = sizeof(RouteFile.HeaderV3)
                            + routeCount * sizeof(StrCode32)
                            + routeCount * sizeof(RouteFile.RouteDef)
                            + totalNodeCount * sizeof(Vector3)
                            + totalNodeCount * sizeof(RouteFile.EventSpan)
                            + totalEventCount * sizeof(RouteFile.EventDef);

            byte[] data = new byte[dataSize];
            fixed (byte* dataPtr = data)
            {
                RouteFile.HeaderV3* header = (RouteFile.HeaderV3*)dataPtr;
                header->Signature = RouteFile.Signature;
                header->Version = RouteFile.FormatVersion.V3;
                header->RouteCount = (ushort)routeCount;

                StrCode32* routeIds = (StrCode32*)(header + 1);
                RouteFile.RouteDef* routeDefs = (RouteFile.RouteDef*)(routeIds + routeCount);
                Vector3* vertices = (Vector3*)(routeDefs + routeCount);
                RouteFile.EventSpan* eventSpans = (RouteFile.EventSpan*)(vertices + totalNodeCount);
                RouteFile.EventDef* events = (RouteFile.EventDef*)(eventSpans + totalNodeCount);

                header->RouteIdsOffset = (uint)((byte*)routeIds - dataPtr);
                header->RouteDefinitionsOffset = (uint)((byte*)routeDefs - dataPtr);
                header->RouteNodesOffset = (uint)((byte*)vertices - dataPtr);
                header->RouteEventTablesOffset = (uint)((byte*)eventSpans - dataPtr);
                header->RouteEventsOffset = (uint)((byte*)events - dataPtr);

                ushort eventWriteIndex = 0;
                for (int i = 0; i < routeCount; i++)
                {
                    GsRouteData route = routes[i];
                    List<GraphxSpatialGraphDataNode> nodes = route.nodes;

                    GameServiceModule.RouteIdMap.Add(route.name);
                    routeIds[i] = new StrCode32(route.name);

                    RouteFile.RouteDef* routeDef = routeDefs + i;

                    routeDef->VerticesOffset = (uint)((byte*)vertices - (byte*)routeDef);
                    routeDef->NodeCount = (ushort)nodes.Count;
                    foreach (GraphxSpatialGraphDataNode node in nodes)
                        *vertices++ = Math.UnityToFoxVector3(node.transform.position);

                    routeDef->EventSpanOffset = (uint)((byte*)eventSpans - (byte*)routeDef);
                    foreach (GraphxSpatialGraphDataNode node in nodes)
                    {
                        if (node is GsRouteDataNode routeNode)
                        {
                            RouteFile.EventSpan nodeEvents = new RouteFile.EventSpan { StartIndex = eventWriteIndex, Count = (ushort)routeNode.events.Count };
                            *eventSpans++ = nodeEvents;

                            eventWriteIndex += nodeEvents.Count;
                        }
                    }

                    List<GsRouteDataEvent> events_ = routeEvents[i];
                    routeDef->EventsOffset = (uint)((byte*)events - (byte*)routeDef);
                    routeDef->EventCount = (ushort)events_.Count;
                    foreach (GsRouteDataEvent routeEvent in events_)
                    {
                        WriteEvent(events, routeEvent);
                        events++;
                    }
                }
            }

            GameServiceModule.RouteIdMap.Save();

            return data;
        }

        private static unsafe void WriteEvent(RouteFile.EventDef* eventDef, GsRouteDataEvent routeEvent)
        {
            eventDef->Id = new StrCode32(routeEvent.id);
            eventDef->Type = routeEvent is GsRouteDataNodeEvent ? RouteEventType.Node : RouteEventType.Edge;
            eventDef->AimTargetType = GetAimPointType(routeEvent.aimPoint);
            eventDef->AimBodySection = RouteBodySectionType.Head;
            
            
            // if (aimPoint is GsRouteDataEventAimStaticPoint)
            //     return RouteAimTargetType.StaticPoint;
            // if (aimPoint is GsRouteDataEventAimCharacter)
            //     return RouteAimTargetType.Character;
            // if (aimPoint is GsRouteDataEventAimRouteAsSightMovePath)
            //     return RouteAimTargetType.RouteAsSightMovePath;
            // if (aimPoint is GsRouteDataEventAimRouteAsObject)
            //     return RouteAimTargetType.RouteAsObject;
            // return RouteAimTargetType.NoTarget;

            if (routeEvent is GsRouteDataNodeEvent nodeEvent)
            {
                eventDef->IsLoop = nodeEvent.isLoop;
                eventDef->EncodedTime = QuantizeTime(nodeEvent.time);
                eventDef->EncodedDir = QuantizeDirection(nodeEvent.dir);
            }

            byte* aimPointData = eventDef->GetAimPointData(RouteFile.FormatVersion.V3);
            WriteAimPointPayload(aimPointData, routeEvent.aimPoint);

            uint* extensions = (uint*)(aimPointData + 16);
            for (int i = 0; i < 4; i++)
                extensions[i] = routeEvent.extensions[i];
        }

        private static unsafe void WriteAimPointPayload(byte* aimPointData, GsRouteDataEventAimPoint aimPoint)
        {
            if (aimPoint is GsRouteDataEventAimStaticPoint staticPoint)
            {
                *(Vector3*)aimPointData = Math.UnityToFoxVector3(staticPoint.position);
                return;
            }

            if (aimPoint is GsRouteDataEventAimCharacter character)
            {
                *(StrCode32*)aimPointData = new StrCode32(character.characterId);
                return;
            }

            if (aimPoint is GsRouteDataEventAimRouteAsSightMovePath sightMovePath)
            {
                StrCode32* ids = (StrCode32*)aimPointData;
                int idCount = sightMovePath.routeId_GetContainerSize();
                for (int i = 0; i < 4; i++)
                    ids[i] = new StrCode32(i < idCount ? sightMovePath.routeId_Get(i) : "");
                return;
            }

            if (aimPoint is GsRouteDataEventAimRouteAsObject routeAsObject)
            {
                StrCode32* ids = (StrCode32*)aimPointData;
                int idCount = routeAsObject.routeId_GetContainerSize();
                for (int i = 0; i < 4; i++)
                    ids[i] = new StrCode32(i < idCount ? routeAsObject.routeId_Get(i) : "");
                return;
            }
        }

        private static ushort QuantizeTime(float time)
        {
            int raw = Mathf.RoundToInt(time * 60f) - 1;
            return (ushort)Mathf.Clamp(raw, 0, ushort.MaxValue);
        }

        private static ushort QuantizeDirection(Quaternion direction)
        {
            Math.UnityToFoxQuaternion(direction).ToAngleAxis(out float angle, out _);

            const float quantaPerDegree = (ushort.MaxValue + 1) / 360f;
            int raw = Mathf.RoundToInt(angle * quantaPerDegree);
            return (ushort)Mathf.Clamp(raw, 0, ushort.MaxValue);
        }
    }
}
