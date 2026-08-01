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
                        routeData.nodes.Add(node);

                        // Position
                        if (version == RouteFile.FormatVersion.V2)
                        {
                            ulong packedVertex = *(ulong*)((byte*)routeDef + routeDef->VerticesOffset)[j];

                            uint packedX = (uint)(packedVertex & 0x003FFFFF);
                            if ((packedX & (1 << 21)) != 0)
                                packedX |= 0xFFC00000;
                            float x = (float)(int)packedX / 1024;

                            uint packedY = (uint)((packedVertex >> 22) & 0x000FFFFF);
                            if ((packedY & (1 << 19)) != 0)
                                packedY |= 0xFFF00000;
                            float y = (float)(int)packedY / 1024;

                            uint packedZ = (uint)((packedVertex >> 42) & 0x003FFFFF);
                            if ((packedZ & (1 << 21)) != 0)
                                packedZ |= 0xFFC00000;
                            float z = (float)(int)packedZ / 1024;

                            node.position = new Vector3(x, y, z) + origin;
                        }
                        else
                        {
                            Vector3 vertex = ((Vector3*)((byte*)routeDef + routeDef->VerticesOffset))[j];
                            node.position = vertex;
                        }
                        
                        GsRouteDataEdge edge = new GameObject($"GsRouteDataEdge{j:D4}").AddComponent<GsRouteDataEdge>();
                        edge.SetOwner(routeData);
                        routeData.edges.Add(edge);

                        // Events
                        RouteFile.EventSpan* eventSpan = (RouteFile.EventSpan*)((byte*)routeDef + routeDef->EventSpanOffset) + j;

                        for (ushort k = 0; k < eventSpan->Count; k++)
                        {
                            RouteFile.EventDef* eventDef = (RouteFile.EventDef*)((byte*)routeDef + routeDef->EventsOffset) + (eventSpan->StartIndex + k);

                            Debug.Assert(eventDef->BodySectionType == RouteBodySectionType.Head);
                            
                            GameServiceModule.EventIdMap.Resolve(eventDef->Id, out string eventId);
                            GameObject eventGameObject = new GameObject();
                            GsRouteDataEvent @event = null;

                            if (eventDef->Type == RouteEventType.Node)
                            {
                                GsRouteDataNodeEvent nodeEvent = (GsRouteDataNodeEvent)(GameServiceModule.RouteNodeEventTypeMap.TryGetValue(eventDef->Id, out Type eventType)
                                    ? eventGameObject.AddComponent(eventType)
                                    : eventGameObject.AddComponent<GsRouteDataNodeEvent>());

                                nodeEvent.id = eventId;
                                nodeEvent.isLoop = eventDef->IsLoop;
                                nodeEvent.time = eventDef->Time;
                                nodeEvent.dir = eventDef->Dir;
                                
                                node.events.Add(nodeEvent);
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
                                
                                edgeEvent.id = eventId;
                                
                                edge.@event = edgeEvent;
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
                                case RouteAimTargetType.NoTarget:
                                    break;
                                case RouteAimTargetType.StaticPoint:
                                {
                                    GsRouteDataEventAimStaticPoint aimStaticPoint = new GameObject().AddComponent<GsRouteDataEventAimStaticPoint>();
                                    
                                    Vector3 position = *(Vector3*)aimPointData;
                                    aimStaticPoint.position = position;
                                    
                                    aimPoint = aimStaticPoint;
                                    break;
                                }
                                case RouteAimTargetType.Character:
                                {
                                    GsRouteDataEventAimCharacter aimCharacter = new GameObject().AddComponent<GsRouteDataEventAimCharacter>();
                                    
                                    StrCode32 characterId = *(StrCode32*)aimPointData;
                                    aimCharacter.characterId = characterId.ToString();
                                    
                                    aimPoint = aimCharacter;
                                    break;
                                }
                                case RouteAimTargetType.RouteAsSightMovePath:
                                {
                                    GsRouteDataEventAimRouteAsSightMovePath aimRouteAsSightMovePath = new GameObject().AddComponent<GsRouteDataEventAimRouteAsSightMovePath>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;

                                    string resolvedRouteId;
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[0], out resolvedRouteId);
                                    aimRouteAsSightMovePath.routeId_AddElement(0, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[1], out resolvedRouteId);
                                    aimRouteAsSightMovePath.routeId_AddElement(1, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[2], out resolvedRouteId);
                                    aimRouteAsSightMovePath.routeId_AddElement(2, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[3], out resolvedRouteId);
                                    aimRouteAsSightMovePath.routeId_AddElement(3, resolvedRouteId);

                                    aimPoint = aimRouteAsSightMovePath;
                                    break;
                                }
                                case RouteAimTargetType.RouteAsObject:
                                {
                                    GsRouteDataEventAimRouteAsObject aimRouteAsObject = new GameObject().AddComponent<GsRouteDataEventAimRouteAsObject>();
                                    
                                    StrCode32* aimPointRouteIds = (StrCode32*)aimPointData;

                                    string resolvedRouteId;
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[0], out resolvedRouteId);
                                    aimRouteAsObject.routeId_AddElement(0, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[1], out resolvedRouteId);
                                    aimRouteAsObject.routeId_AddElement(1, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[2], out resolvedRouteId);
                                    aimRouteAsObject.routeId_AddElement(2, resolvedRouteId);
                                    GameServiceModule.RouteIdMap.Resolve(aimPointRouteIds[3], out resolvedRouteId);
                                    aimRouteAsObject.routeId_AddElement(3, resolvedRouteId);
                                    
                                    aimPoint = aimRouteAsObject;
                                    break;
                                }
                            }

                            if (aimPoint is not null)
                            {
                                @event.aimPoint = aimPoint;
                                aimPoint.SetOwner(routeData);
                                aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                                
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
                                    logger.AddWarning($"Event {@event.id} in {routeData.name} has nonzero extensions ({@event.extensions[0]}, {@event.extensions[1]}, {@event.extensions[2]}, {@event.extensions[3]}).");
                            }
#endif
                        }
                    }

                    for (int j = 0; j < routeDef->NodeCount; j++)
                    {
                        GraphxSpatialGraphDataNode node = routeData.nodes[j];
                        GraphxSpatialGraphDataEdge prevEdge = routeData.edges[j];
                        GraphxSpatialGraphDataEdge nextEdge = routeData.edges[(j + 1 + routeDef->NodeCount) % routeDef->NodeCount];

                        node.outlinks.Add(prevEdge);
                        prevEdge.nextNode = node;
                        node.outlinks.Add(nextEdge);
                        nextEdge.prevNode = node;
                    }
                }

                // In the future, we'll probably want to move the importers into a general "de-converted DataSet" context that handles these calls automatically
                foreach (GsRouteData route in routeDatas)
                {
                    foreach (GsRouteDataNode node in route.nodes)
                    {
                        foreach (GsRouteDataNodeEvent nodeEvent in node.events)
                        {
                            nodeEvent.aimPoint?.OnDeserializeEntity(logger);
                            
                            nodeEvent.OnDeserializeEntity(logger);
                        }
                        
                        node.OnDeserializeEntity(logger);
                    }
                    
                    foreach (GsRouteDataEdge edge in route.edges)
                    {
                        edge.@event?.aimPoint?.OnDeserializeEntity(logger);
                        
                        edge.@event?.OnDeserializeEntity(logger);
                        
                        edge.OnDeserializeEntity(logger);
                    }
                    
                    route.OnDeserializeEntity(logger);
                }

                return scene;
            }
        }
    }
}