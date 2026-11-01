using System.Collections.Generic;
using Fox.Core.Utils;
using Fox.Graphx;
using UnityEngine;

namespace Fox.GameService
{
    public class RouteFileWriter
    {
        public unsafe byte[] Write(UnityEngine.SceneManagement.Scene scene, TaskLogger logger = null)
        {
            GameObject[] rootGameObjects = scene.GetRootGameObjects();
            List<GsRouteData> routes = new List<GsRouteData>(rootGameObjects.Length);
            foreach (GameObject rootGameObject in rootGameObjects)
                if (rootGameObject.TryGetComponent(out GsRouteData route))
                    routes.Add(route);

            int routeCount = routes.Count;
            if (routeCount > ushort.MaxValue)
            {
                logger?.AddError($"Write failed: {routeCount} has more than {ushort.MaxValue} routes.");
                return null;
            }

            List<GsRouteDataEvent>[] routeEvents = new List<GsRouteDataEvent>[routeCount];
            RouteFile.EventSpan[][] routeEventSpans = new RouteFile.EventSpan[routeCount][];
            int totalNodeCount = 0;
            int totalEventCount = 0;
            for (int i = 0; i < routeCount; i++)
            {
                GsRouteData route = routes[i];
                List<GraphxSpatialGraphDataNode> nodes = route.Nodes;
                List<GraphxSpatialGraphDataEdge> routeEdges = route.Edges;
                int nodeCount = nodes.Count;

                if (routeEdges.Count != nodeCount)
                {
                    logger?.AddError($"Write failed. Route {route.name} has nodeCount {nodeCount} must == edgeCount {routeEdges.Count}.");
                    return null;
                }
                for (int j = 0; j < nodeCount; j++)
                {
                    if (routeEdges[j].PrevNode != nodes[j])
                    {
                        logger?.AddError($"Write failed. Route {route.name} edge {j} does not leave node {j}.");
                        return null;
                    }
                }

                List<GsRouteDataEvent> events = new List<GsRouteDataEvent>();
                RouteFile.EventSpan[] spans = new RouteFile.EventSpan[nodeCount];
                for (int j = 0; j < nodeCount; j++)
                {
                    int start = events.Count;

                    if (routeEdges[j] is GsRouteDataEdge { Event: not null } leavingEdge)
                        events.Add(leavingEdge.Event);

                    if (nodes[j] is GsRouteDataNode routeNode)
                        foreach (GsRouteDataNodeEvent nodeEvent in routeNode.Events)
                            if (nodeEvent != null)
                                events.Add(nodeEvent);

                    // StartIndex is relative to this route's event table
                    if (events.Count > ushort.MaxValue)
                    {
                        logger?.AddError($"Write failed. Route {route.name} has more than {ushort.MaxValue} events.");
                        return null;
                    }
                    spans[j] = new RouteFile.EventSpan { StartIndex = (ushort)start, Count = (ushort)(events.Count - start) };
                }

                if (nodes.Count > ushort.MaxValue)
                {
                    logger?.AddError($"Write failed. Route {route.name} has more than {ushort.MaxValue} nodes.");
                    return null;
                }

                routeEvents[i] = events;
                routeEventSpans[i] = spans;
                totalNodeCount += nodes.Count;
                totalEventCount += events.Count;
            }

            long dataSize = sizeof(RouteFile.HeaderV3)
                            + (long)routeCount * sizeof(StrCode32)
                            + (long)routeCount * sizeof(RouteFile.RouteDef)
                            + (long)totalNodeCount * sizeof(Vector3)
                            + (long)totalNodeCount * sizeof(RouteFile.EventSpan)
                            + (long)totalEventCount * sizeof(RouteFile.EventDef);

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

                for (int i = 0; i < routeCount; i++)
                {
                    GsRouteData route = routes[i];
                    List<GraphxSpatialGraphDataNode> nodes = route.Nodes;

                    GameServiceModule.RouteIdMap.Add(route.name);
                    routeIds[i] = new StrCode32(route.name);

                    RouteFile.RouteDef* routeDef = routeDefs + i;
                    routeDef->NodeCount = (ushort)nodes.Count;
                    routeDef->EventCount = (ushort)routeEvents[i].Count;
                    routeDef->VerticesOffset = (uint)((byte*)vertices - (byte*)routeDef);
                    routeDef->EventSpanOffset = (uint)((byte*)eventSpans - (byte*)routeDef);
                    routeDef->EventsOffset = (uint)((byte*)events - (byte*)routeDef);

                    foreach (GraphxSpatialGraphDataNode node in nodes)
                        *vertices++ = Fox.Math.UnityToFoxVector3(node.transform.position);

                    foreach (RouteFile.EventSpan span in routeEventSpans[i])
                        *eventSpans++ = span;

                    foreach (GsRouteDataEvent routeEvent in routeEvents[i])
                    {
                        RouteFile.EventDef* eventDef = events++;

                        eventDef->Id = new StrCode32(routeEvent.Id);

                        if (routeEvent is GsRouteDataNodeEvent nodeEvent)
                        {
                            eventDef->Type = RouteEventType.Node;
                            eventDef->IsLoop = nodeEvent.IsLoop;
                            eventDef->SetTime(nodeEvent.Time);
                            
                            // TODO: Want to try to use OnSerializeEntity for this if possible.
                            eventDef->SetFoxDirection(Fox.Math.UnityToFoxQuaternion(nodeEvent.Dir));
                        }
                        else
                        {
                            eventDef->Type = RouteEventType.Edge;
                        }

                        byte* aimPointData = eventDef->GetAimPointData(RouteFile.FormatVersion.V3);
                        GsRouteDataEventAimPoint aimPoint = routeEvent.aimPoint;
                        switch (aimPoint)
                        {
                            case GsRouteDataEventAimStaticPoint staticPoint:
                            {
                                eventDef->AimTargetType = GsRouteDataEventAimPoint_TargetType.STATIC_POINT;
                                eventDef->AimBodySection = aimPoint.BodySection;

                                *(Vector3*)aimPointData = Fox.Math.UnityToFoxVector3(staticPoint.Position);
                            }
                                break;
                            case GsRouteDataEventAimCharacter character:
                            {
                                eventDef->AimTargetType = GsRouteDataEventAimPoint_TargetType.CHARACTER;
                                eventDef->AimBodySection = aimPoint.BodySection;
                                
                                GameServiceModule.CharacterIdMap.Add(character.characterId);
                                *(StrCode32*)aimPointData = new StrCode32(character.characterId);
                            }
                                break;
                            case GsRouteDataEventAimRouteAsSightMovePath sightMovePath:
                            {
                                eventDef->AimTargetType = GsRouteDataEventAimPoint_TargetType.ROUTE_AS_SIGHT_MOVE_PATH;
                                eventDef->AimBodySection = aimPoint.BodySection;
                                
                                StrCode32* ids = (StrCode32*)aimPointData;
                                int idCount = sightMovePath.routeId_GetContainerSize();
                                for (int j = 0; j < 4; j++)
                                {
                                    string targetId = j < idCount ? sightMovePath.routeId_Get(j) : "";
                                    GameServiceModule.RouteIdMap.Add(targetId);
                                    ids[j] = new StrCode32(targetId);
                                }
                            }
                                break;
                            case GsRouteDataEventAimRouteAsObject routeAsObject:
                            {
                                eventDef->AimTargetType = GsRouteDataEventAimPoint_TargetType.ROUTE_AS_OBJECT;
                                eventDef->AimBodySection = aimPoint.BodySection;
                                
                                StrCode32* ids = (StrCode32*)aimPointData;
                                int idCount = routeAsObject.routeId_GetContainerSize();
                                for (int j = 0; j < 4; j++)
                                {
                                    string targetId = j < idCount ? routeAsObject.routeId_Get(j) : "";
                                    GameServiceModule.RouteIdMap.Add(targetId);
                                    ids[j] = new StrCode32(targetId);
                                }
                            }
                                break;
                            default:
                            {
                                eventDef->AimTargetType = GsRouteDataEventAimPoint_TargetType.NO_TARGET;

                                if (aimPoint != null)
                                    logger?.AddWarning($"Event {routeEvent.Id} in {route.name} has unsupported aim point type {aimPoint.GetType().Name}.");
                            }
                                break;
                        }

                        uint[] extensions = routeEvent.GetExtensions();
                        uint* extensionData = eventDef->GetExtensionData(RouteFile.FormatVersion.V3);
                        for (int j = 0; j < 4; j++)
                            extensionData[j] = extensions[j];
                    }
                }
            }

            GameServiceModule.SaveRouteIdMaps();

            return data;
        }
    }
}
