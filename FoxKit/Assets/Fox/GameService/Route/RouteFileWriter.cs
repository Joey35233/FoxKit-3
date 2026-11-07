using System;
using System.Collections.Generic;
using Fox.Core;
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

            List<GsRouteDataEvent>[] allEvents = new List<GsRouteDataEvent>[routeCount];
            RouteFile.EventSpan[][] allEventSpans = new RouteFile.EventSpan[routeCount][];
            int totalNodeCount = 0;
            int totalEventCount = 0;
            for (int i = 0; i < routeCount; i++)
            {
                GsRouteData route = routes[i];
                
                List<GraphxSpatialGraphDataNode> routeNodes = route.Nodes;
                int routeNodeCount = routeNodes.Count;

                List<GsRouteDataEvent> routeEvents = new List<GsRouteDataEvent>();
                RouteFile.EventSpan[] routeEventSpans = new RouteFile.EventSpan[routeNodeCount];
                for (int j = 0; j < routeNodeCount; j++)
                {
                    GraphxSpatialGraphDataNode node = routeNodes[j];
                    
                    // Capture start index for current node before adding new events
                    int nodeEventsStartIndex = routeEvents.Count;

                    // 1. Determine and validate uniqueness of "next" edge by searching outlinks for .PrevNode == node
                    GsRouteDataEdge leavingEdge = null;
                    foreach (Entity link in node.Outlinks)
                    {
                        if (link is not GsRouteDataEdge edge || edge.PrevNode != node)
                            continue;
                        if (leavingEdge != null && leavingEdge != edge)
                        {
                            logger?.AddError($"Write failed. Route {route.name} node {j} has multiple next edges.");
                            return null;
                        }
                        leavingEdge = edge;
                    }
                    if (leavingEdge == null)
                    {
                        logger?.AddError($"Write failed. Route {route.name} node {j} has no next edge.");
                        return null;
                    }
                    
                    // Actually add it
                    if (leavingEdge.Event != null)
                        routeEvents.Add(leavingEdge.Event);

                    // 2. Add node events
                    if (node is GsRouteDataNode routeNode)
                        foreach (GsRouteDataNodeEvent nodeEvent in routeNode.Events)
                            if (nodeEvent != null)
                                routeEvents.Add(nodeEvent);

                    // Route events bounds check
                    if (routeEvents.Count > ushort.MaxValue)
                    {
                        logger?.AddError($"Write failed. Route {route.name} has more than {ushort.MaxValue} events.");
                        return null;
                    }
                    
                    routeEventSpans[j] = new RouteFile.EventSpan { StartIndex = (ushort)nodeEventsStartIndex, Count = (ushort)(routeEvents.Count - nodeEventsStartIndex) };
                }

                //  Route nodes bounds check
                if (routeNodes.Count > ushort.MaxValue)
                {
                    logger?.AddError($"Write failed. Route {route.name} has more than {ushort.MaxValue} nodes.");
                    return null;
                }

                allEvents[i] = routeEvents;
                allEventSpans[i] = routeEventSpans;
                totalNodeCount += routeNodes.Count;
                totalEventCount += routeEvents.Count;
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
                    routeDef->EventCount = (ushort)allEvents[i].Count;
                    routeDef->VerticesOffset = (uint)((byte*)vertices - (byte*)routeDef);
                    routeDef->EventSpanOffset = (uint)((byte*)eventSpans - (byte*)routeDef);
                    routeDef->EventsOffset = (uint)((byte*)events - (byte*)routeDef);

                    foreach (GraphxSpatialGraphDataNode node in nodes)
                        *vertices++ = Fox.Math.UnityToFoxVector3(node.transform.position);

                    foreach (RouteFile.EventSpan span in allEventSpans[i])
                        *eventSpans++ = span;

                    foreach (GsRouteDataEvent routeEvent in allEvents[i])
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

                        uint* extensionData = eventDef->GetExtensionData(RouteFile.FormatVersion.V3);
                        routeEvent.WriteExtensions(new Span<uint>(extensionData, GameServiceModule.ExtensionCount));
                    }
                }
            }

            GameServiceModule.SaveRouteIdMaps();

            return data;
        }
    }
}
