using Fox.Core.Utils;
using Fox.Graphx;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Fox.GameService
{
    public class RouteFileReader
    {
        public unsafe UnityEngine.SceneManagement.Scene? Read(ReadOnlySpan<byte> data, TaskLogger logger)
        {
            fixed (byte* dataPtr = data)
            {
                if (data.Length < sizeof(RouteFile.BaseHeader))
                {
                    logger.AddError($"Read failed. File is too small to be a ROUT.");
                    return null;
                }

                RouteFile.BaseHeader* baseHeader = (RouteFile.BaseHeader*)dataPtr;

                if (baseHeader->Signature != RouteFile.Signature)
                {
                    logger.AddError($"Read failed. Not a ROUT.");
                    return null;
                }

                RouteFile.FormatVersion version = (RouteFile.FormatVersion)baseHeader->Version;
                if (version != RouteFile.FormatVersion.V2 && version != RouteFile.FormatVersion.V3)
                {
                    logger.AddError($"Version {version} isn't supported");
                    return null;
                }

                UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

                ushort routeCount;
                Vector3 origin;
                StrCode32* routeIds;
                RouteFile.RouteDef* routeDefs;
                if (version == RouteFile.FormatVersion.V2)
                {
                    RouteFile.HeaderV2* header = (RouteFile.HeaderV2*)dataPtr;

                    routeCount = header->RouteCount;
                    origin = header->Origin;
                    routeIds = (StrCode32*)(dataPtr + header->RouteIdsOffset);
                    routeDefs = (RouteFile.RouteDef*)(dataPtr + header->RouteDefinitionsOffset);
                }
                else
                {
                    RouteFile.HeaderV3* header = (RouteFile.HeaderV3*)dataPtr;

                    routeCount = header->RouteCount;
                    origin = Vector3.zero;
                    routeIds = (StrCode32*)(dataPtr + header->RouteIdsOffset);
                    routeDefs = (RouteFile.RouteDef*)(dataPtr + header->RouteDefinitionsOffset);
                }
                
                List<GsRouteData> routeDatas = new List<GsRouteData>(routeCount);
                for (int i = 0; i < routeCount; i++)
                {
                    GameServiceModule.RouteIdMap.Resolve(routeIds[i], out string routeId);

                    RouteFile.RouteDef* routeDef = routeDefs + i;

                    GsRouteData routeData = new GameObject().AddComponent<GsRouteData>();
                    routeData.name = routeId;
                    routeDatas.Add(routeData);

                    for (int j = 0; j < routeDef->NodeCount; j++)
                    {
                        GsRouteDataNode node = new GameObject($"GsRouteDataNode{j:D4}").AddComponent<GsRouteDataNode>();
                        node.SetOwner(routeData);
                        routeData.Nodes.Add(node);

                        // Position
                        if (version == RouteFile.FormatVersion.V2)
                        {
                            ulong packedVertex = ((ulong*)((byte*)routeDef + routeDef->VerticesOffset))[j];
                            node.Position = RouteFile.UnpackVertexV2(packedVertex) + origin;
                        }
                        else
                        {
                            Vector3 vertex = ((Vector3*)((byte*)routeDef + routeDef->VerticesOffset))[j];
                            node.Position = vertex;
                        }
                        
                        GsRouteDataEdge edge = new GameObject($"GsRouteDataEdge{j:D4}").AddComponent<GsRouteDataEdge>();
                        edge.SetOwner(routeData);
                        routeData.Edges.Add(edge);

                        // Events
                        RouteFile.EventSpan* eventSpan = (RouteFile.EventSpan*)((byte*)routeDef + routeDef->EventSpanOffset) + j;

                        for (ushort k = 0; k < eventSpan->Count; k++)
                        {
                            RouteFile.EventDef* eventDef = (RouteFile.EventDef*)((byte*)routeDef + routeDef->EventsOffset) + (eventSpan->StartIndex + k);
                            
                            GameServiceModule.EventIdMap.Resolve(eventDef->Id, out string eventId);
                            GameObject eventGameObject = new GameObject();
                            GsRouteDataEvent @event = null;

                            if (eventDef->Type == RouteEventType.Node)
                            {
                                GsRouteDataNodeEvent nodeEvent = (GsRouteDataNodeEvent)(GameServiceModule.RouteNodeEventTypeMap.TryGetValue(eventDef->Id, out Type eventType)
                                    ? eventGameObject.AddComponent(eventType)
                                    : eventGameObject.AddComponent<GsRouteDataNodeEvent>());

                                nodeEvent.Id = eventId;
                                nodeEvent.IsLoop = eventDef->IsLoop;
                                nodeEvent.Time = eventDef->GetTime();
                                // Still in Fox space; converted to Unity space by OnDeserializeEntity
                                nodeEvent.Dir = eventDef->GetFoxDirection();
                                
                                node.Events.Add(nodeEvent);
                                nodeEvent.SetOwner(routeData);
                                nodeEvent.name = nodeEvent.GenerateName(k);

                                // Bit of a hack for organization - even though the GsRouteData officially owns everything, parent to node
                                nodeEvent.transform.parent = node.transform;

                                @event = nodeEvent;
                            }
                            else
                            {
                                GsRouteDataEdgeEvent edgeEvent = (GsRouteDataEdgeEvent)(GameServiceModule.RouteEdgeEventTypeMap.TryGetValue(eventDef->Id, out Type eventType)
                                    ? eventGameObject.AddComponent(eventType)
                                    : eventGameObject.AddComponent<GsRouteDataEdgeEvent>());
                                
                                edgeEvent.Id = eventId;

                                if (edge.Event != null)
                                    logger.AddWarning($"Edge {j} in {routeData.name} has more than one edge event; only the last is kept.");

                                edge.Event = edgeEvent;
                                edgeEvent.SetOwner(routeData);
                                edgeEvent.name = edgeEvent.GenerateName(k);
                                
                                // Bit of a hack for organization - even though the GsRouteData officially owns everything, parent to edge
                                edgeEvent.transform.parent = edge.transform;

                                @event = edgeEvent;
                            }

                            byte* aimPointData = eventDef->GetAimPointData(version);
                            GsRouteDataEventAimPoint aimPoint = null;
                            switch (eventDef->AimTargetType)
                            {
                                case GsRouteDataEventAimPoint_TargetType.NO_TARGET:
                                    break;
                                case GsRouteDataEventAimPoint_TargetType.STATIC_POINT:
                                {
                                    GsRouteDataEventAimStaticPoint aimStaticPoint = new GameObject().AddComponent<GsRouteDataEventAimStaticPoint>();
                                    
                                    Vector3 position = *(Vector3*)aimPointData;
                                    aimStaticPoint.Position = position;
                                    
                                    aimPoint = aimStaticPoint;
                                    break;
                                }
                                case GsRouteDataEventAimPoint_TargetType.CHARACTER:
                                {
                                    GsRouteDataEventAimCharacter aimCharacter = new GameObject().AddComponent<GsRouteDataEventAimCharacter>();
                                    
                                    StrCode32 characterId = *(StrCode32*)aimPointData;
                                    GameServiceModule.CharacterIdMap.Resolve(characterId, out string resolvedCharacterId);
                                    aimCharacter.characterId = resolvedCharacterId;
                                    
                                    aimPoint = aimCharacter;
                                    break;
                                }
                                case GsRouteDataEventAimPoint_TargetType.ROUTE_AS_SIGHT_MOVE_PATH:
                                {
                                    GsRouteDataEventAimRouteAsSightMovePath aimRouteAsSightMovePath = new GameObject().AddComponent<GsRouteDataEventAimRouteAsSightMovePath>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;

                                    for (int l = 0; l < 4; l++)
                                    {
                                        if (!aimPointRouteIds[l].IsValid() || aimPointRouteIds[l] == new StrCode32(""))
                                            break;

                                        GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[l], out string resolvedRouteId);
                                        aimRouteAsSightMovePath.routeId_AddElement(l, resolvedRouteId);
                                    }

                                    aimPoint = aimRouteAsSightMovePath;
                                    break;
                                }
                                case GsRouteDataEventAimPoint_TargetType.ROUTE_AS_OBJECT:
                                {
                                    GsRouteDataEventAimRouteAsObject aimRouteAsObject = new GameObject().AddComponent<GsRouteDataEventAimRouteAsObject>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;

                                    for (int l = 0; l < 4; l++)
                                    {
                                        if (!aimPointRouteIds[l].IsValid() || aimPointRouteIds[l] == new StrCode32(""))
                                            break;

                                        GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[l], out string resolvedRouteId);
                                        aimRouteAsObject.routeId_AddElement(l, resolvedRouteId);
                                    }

                                    aimPoint = aimRouteAsObject;
                                    break;
                                }
                            }

                            if (aimPoint is not null)
                            {
                                @event.aimPoint = aimPoint;
                                aimPoint.SetOwner(routeData);
                                aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                                Debug.Assert(eventDef->AimBodySection == GsRouteDataEventAimPoint_BodySection.HEAD);
                                aimPoint.BodySection = eventDef->AimBodySection;
                                
                                // Bit of a hack for organization - even though the GsRouteData officially owns everything, parent to node/edge
                                aimPoint.transform.parent = @event.transform;
                            }
                            
                            uint* extensions = eventDef->GetExtensionData(version);
                            @event.extensions[0] = extensions[0];
                            @event.extensions[1] = extensions[1];
                            @event.extensions[2] = extensions[2];
                            @event.extensions[3] = extensions[3];

#if DEBUG
                            if (@event.GetType() == typeof(GsRouteDataNodeEvent) || @event.GetType() == typeof(GsRouteDataEdgeEvent))
                            {
                                if (!(@event.extensions[0] == 0 && @event.extensions[1] == 0 && @event.extensions[2] == 0 && @event.extensions[3] == 0))
                                    //Debug.LogWarning($"Event {@event.id} in {routeData} has nonzero extensions ({@event.extensions[0]}, {@event.extensions[1]}, {@event.extensions[2]}, {@event.extensions[3]}).", @event);
                                    logger.AddWarning($"Event {@event.Id} in {routeData.name} has nonzero extensions ({@event.extensions[0]}, {@event.extensions[1]}, {@event.extensions[2]}, {@event.extensions[3]}).");
                            }
#endif
                        }
                    }

                    for (int j = 0; j < routeDef->NodeCount; j++)
                    {
                        GraphxSpatialGraphDataNode node = routeData.Nodes[j];
                        // The event span for node j contains the event on the edge leaving it.
                        GraphxSpatialGraphDataEdge prevEdge = routeData.Edges[(j + routeDef->NodeCount - 1) % routeDef->NodeCount];
                        GraphxSpatialGraphDataEdge nextEdge = routeData.Edges[j];

                        node.Outlinks.Add(prevEdge);
                        prevEdge.NextNode = node;
                        node.Outlinks.Add(nextEdge);
                        nextEdge.PrevNode = node;
                    }
                }

                // In the future, we'll probably want to move the importers into a general "de-converted DataSet" context that handles these calls automatically
                foreach (GsRouteData route in routeDatas)
                {
                    foreach (GsRouteDataNode node in route.Nodes)
                    {
                        foreach (GsRouteDataNodeEvent nodeEvent in node.Events)
                        {
                            nodeEvent.aimPoint?.OnDeserializeEntity(logger);
                            
                            nodeEvent.OnDeserializeEntity(logger);
                        }
                        
                        node.OnDeserializeEntity(logger);
                    }
                    
                    foreach (GsRouteDataEdge edge in route.Edges)
                    {
                        edge.Event?.aimPoint?.OnDeserializeEntity(logger);
                        
                        edge.Event?.OnDeserializeEntity(logger);
                        
                        edge.OnDeserializeEntity(logger);
                    }
                    
                    route.OnDeserializeEntity(logger);
                }

                return scene;
            }
        }
    }
}
