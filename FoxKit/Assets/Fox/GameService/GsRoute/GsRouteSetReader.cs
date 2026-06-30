using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Graphx;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Fox.GameService
{
    public class GsRouteSetReader
    {
        private readonly TaskLogger logger = new TaskLogger("ImportFRT");

        private enum RouteSetVersion : short
        {
            GZ = 2,
            TPP = 3,
        }

        private enum EventAffinity
        {
            Edge = 0,
            Node = 1,
        }

        private const float USHORT_QUANTA_PER_DEGREE = (UInt16.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (UInt16.MaxValue + 1);

        private struct EventSpan
        {
            public ushort Count;
            public ushort StartIndex;
        }

        private struct EventDef
        {
            public StrCode32 Id;
            public EventAffinity Affinity;
            public RouteAimTargetType AimPointRouteAimTargetType;
            public byte Unknown;
            public bool IsLoop;
            public float Time;
            public float Direction;

            public static EventDef Read(FileStreamReader reader)
            {
                var result = new EventDef
                {
                    Id = reader.ReadStrCode32(),
                    Affinity = (EventAffinity)reader.ReadByte(),
                    AimPointRouteAimTargetType = (RouteAimTargetType)reader.ReadByte(),
                    Unknown = reader.ReadByte(),
                    IsLoop = reader.ReadBoolean(),
                    Time = (float)(reader.ReadUInt16() + 1) / 60, // TODO: ad hoc formula could be wrong
                    Direction = reader.ReadUInt16() / USHORT_QUANTA_PER_DEGREE,
                };

                Debug.Assert(Enum.IsDefined(typeof(EventAffinity), result.Affinity));
                Debug.Assert(result.Unknown == 0);

                return result;
            }
        }

        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            uint signature = reader.ReadUInt32();
            if (signature != 0x54554F52) // ROUT
            {
                logger.AddError($"Read failed. Not a ROUT.");
                return null;
            }

            var fileVersion = (RouteSetVersion)reader.ReadInt16();

            if (fileVersion != RouteSetVersion.TPP && fileVersion != RouteSetVersion.GZ)
            {
                logger.AddError($"Version {fileVersion} isn't supported");
                return null;
            }

            int nodePositionSizeInBytes = fileVersion switch
            {
                RouteSetVersion.GZ => 8,
                RouteSetVersion.TPP => 12,
                _ => 0,
            };

            ushort routeCount = reader.ReadUInt16();

            Vector3 origin = Vector3.zero;

            if (fileVersion == RouteSetVersion.GZ)
            {
                reader.Skip(4 * 2); //Irrelevant memory leak bytes
                origin = reader.ReadPositionF();
                reader.Skip(4); //Irrelevant memory leak bytes
            }

            uint routeIdsOffset = reader.ReadUInt32();
            uint routeDefinitionsOffset = reader.ReadUInt32();

            // TODO: usage
            uint routeNodesOffset = reader.ReadUInt32();

            // TODO: usage
            uint routeEventTablesOffset = reader.ReadUInt32();

            // TODO: usage
            uint routeEventsOffset = reader.ReadUInt32();

            if (fileVersion == RouteSetVersion.GZ)
                reader.Skip(4 * 2); //Irrelevant memory leak bytes

            var routeRoots = new List<GsRouteData>(routeCount);

            for (int i = 0; i < routeCount; i++)
            {
                // Get id
                reader.Seek(routeIdsOffset + (i * 4));
                StrCode32 id = reader.ReadStrCode32();

                // RouteDef
                long routeDefPosition = routeDefinitionsOffset + (i * 16);
                reader.Seek(routeDefPosition);

                uint positionsOffset = reader.ReadUInt32();
                uint eventSpanOffset = reader.ReadUInt32();
                uint eventsOffset = reader.ReadUInt32();
                ushort nodeCount = reader.ReadUInt16();
                ushort eventCount = reader.ReadUInt16();

                string routeId = GameServiceModule.RouteIdMap.Resolve(id, out string resolvedRouteIdString) ? resolvedRouteIdString : id.ToString();
                GsRouteData routeData = new GameObject().AddComponent<GsRouteData>();
                routeData.SetTransform(TransformEntity.GetDefault());

                routeRoots.Add(routeData);

                for (int j = 0; j < nodeCount; j++)
                {
                    GsRouteDataEdge edge = new GameObject($"GsRouteDataEdge{j:D4}").AddComponent<GsRouteDataEdge>();
                    edge.SetOwner(routeData);
                    routeData.edges.Add(edge);

                    GsRouteDataNode node = new GameObject($"GsRouteDataNode{j:D4}").AddComponent<GsRouteDataNode>();
                    node.SetOwner(routeData);
                    routeData.nodes.Add(node);
                    edge.transform.parent = node.gameObject.transform;

                    // Position
                    reader.Seek(routeDefPosition + positionsOffset + (j * nodePositionSizeInBytes));
                    if (fileVersion == RouteSetVersion.GZ)
                    {
                        // Vector3 Bit Unpacking by Joey:
                        // https://discord.com/channels/364177293133873153/364178190588968970/894215344099573760
                        // https://cdn.discordapp.com/attachments/364178190588968970/894215342069538907/unknown.png

                        long packedPosition = reader.ReadInt64();

                        uint packedX = (uint)(packedPosition & 0x003FFFFF);
                        if ((packedX & (1 << 21)) != 0)
                            packedX |= 0xFFC00000;
                        float x = (float)(int)packedX / 1024;

                        uint packedY = (uint)((packedPosition >> 22) & 0x000FFFFF);
                        if ((packedY & (1 << 19)) != 0)
                            packedY |= 0xFFF00000;
                        float y = (float)(int)packedY / 1024;

                        uint packedZ = (uint)((packedPosition >> 42) & 0x003FFFFF);
                        if ((packedZ & (1 << 21)) != 0)
                            packedZ |= 0xFFC00000;
                        float z = (float)(int)packedZ / 1024;

                        node.position = Fox.Math.FoxToUnityVector3(new Vector3(x, y, z)) + origin;
                    }
                    else if (fileVersion == RouteSetVersion.TPP)
                    {
                        node.position = reader.ReadPositionF();
                    }

                    // Event span
                    reader.Seek(routeDefPosition + eventSpanOffset + (j * 4));
                    var eventSpan = new EventSpan { Count = reader.ReadUInt16(), StartIndex = reader.ReadUInt16() };

                    for (int k = 0; k < eventSpan.Count; k++)
                    {
                        reader.Seek(routeDefPosition + eventsOffset + ((eventSpan.StartIndex + k) * 48));

                        var eventDef = EventDef.Read(reader);

                        if (fileVersion == RouteSetVersion.GZ)
                            reader.Skip(4); //inverted isnodeevent thing

                        long payloadPosition = reader.BaseStream.Position + 16;

                        GsRouteDataEventAimPoint aimPoint = null;
                        switch(eventDef.AimPointRouteAimTargetType)
                        {
                            case RouteAimTargetType.NoTarget:
                                {
                                    /*
                                    GsRouteDataRtEvAimPointNoTarget result = new GameObject().AddComponent<GsRouteDataRtEvAimPointNoTarget>();
                                    aimPoint = result;
                                    */
                                }
                                break;
                            case RouteAimTargetType.StaticPoint:
                                {
                                    GsRouteDataEventAimStaticPoint result = new GameObject().AddComponent<GsRouteDataEventAimStaticPoint>();
                                    result.position = reader.ReadPositionF();
                                    aimPoint = result;
                                }
                                break;
                            case RouteAimTargetType.Character:
                                {
                                    GsRouteDataEventAimCharacter result = new GameObject().AddComponent<GsRouteDataEventAimCharacter>();
                                    result.characterId = reader.ReadStrCode32().ToString();
                                    aimPoint = result;
                                }
                                break;
                            case RouteAimTargetType.RouteAsSightMovePath:
                                {
                                    GsRouteDataEventAimRouteAsSightMovePath result = new GameObject().AddComponent<GsRouteDataEventAimRouteAsSightMovePath>();
                                    result.routeId_AddElement(0, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(1, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(2, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(3, reader.ReadStrCode32().ToString());
                                    aimPoint = result;
                                }
                                break;
                            case RouteAimTargetType.RouteAsObject:
                                {
                                    GsRouteDataEventAimRouteAsObject result = new GameObject().AddComponent<GsRouteDataEventAimRouteAsObject>();
                                    result.routeId_AddElement(0, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(1, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(2, reader.ReadStrCode32().ToString());
                                    result.routeId_AddElement(3, reader.ReadStrCode32().ToString());
                                    aimPoint = result;
                                }
                                break;
                        };
                        reader.Seek(payloadPosition);

                        var routeEventObject = new GameObject();
                        uint[] binaryData = { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() };

                        if (fileVersion == RouteSetVersion.TPP)
                            reader.Skip(4); //snippet
                        
                        GsRouteDataEvent dataEvent;
                        if (eventDef.Affinity == EventAffinity.Edge)
                        {
                            var edgeEvent = (GsRouteDataEdgeEvent)(GameServiceModule.RouteEdgeEventMap.TryGetValue(eventDef.Id, out Type eventType)
                                            ? routeEventObject.AddComponent(eventType)
                                            : routeEventObject.AddComponent<GsRouteDataEdgeEvent>());
                            edge.@event = edgeEvent;
                            edgeEvent.transform.parent = edge.transform;
                            edgeEvent.name = $"GsRouteDataEdgeEvent{k:D4}|{eventDef.Id}";

                            if (aimPoint is not null)
                            {
                                aimPoint.SetOwner(routeData);
                                edgeEvent.aimPoint = aimPoint;
                                aimPoint.transform.parent = edgeEvent.transform;
                                aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                            }

                            dataEvent = edgeEvent;
                        }
                        else
                        {
                            var nodeEvent = (GsRouteDataNodeEvent)(GameServiceModule.RouteNodeEventMap.TryGetValue(eventDef.Id, out Type eventType)
                                ? routeEventObject.AddComponent(eventType)
                                : routeEventObject.AddComponent<GsRouteDataNodeEvent>());
                            
                            nodeEvent.isLoop = eventDef.IsLoop;
                            nodeEvent.time = eventDef.Time;
                            nodeEvent.dir = Math.FoxToUnityQuaternion(Quaternion.AngleAxis(eventDef.Direction, Math.UnityToFoxVector3(Vector3.up)));
                            
                            node.events.Add(nodeEvent);
                            
                            nodeEvent.transform.parent = node.transform;
                            nodeEvent.name = $"GsRouteDataNodeEvent{k:D4}|{eventDef.Id}";

                            if (aimPoint is not null)
                            {
                                aimPoint.SetOwner(routeData);
                                nodeEvent.aimPoint = aimPoint;
                                aimPoint.transform.parent = nodeEvent.transform;
                                aimPoint.name = $"{aimPoint.GetClassEntityInfo().Name}";
                            }

                            dataEvent = nodeEvent;
                        }
                        
                        dataEvent.SetOwner(routeData);
                    }
                }

                for (int j = 0; j < nodeCount; j++)
                {
                    GraphxSpatialGraphDataNode node = routeData.nodes[j];

                    GraphxSpatialGraphDataEdge prevEdge = routeData.edges[j];
                    GraphxSpatialGraphDataEdge nextEdge = routeData.edges[(j + 1 + nodeCount) % nodeCount];

                    node.outlinks.Add(prevEdge);
                    prevEdge.nextNode = node;
                    node.outlinks.Add(nextEdge);
                    nextEdge.prevNode = node;
                }
            }

            routeRoots.Sort((a, b) =>
            {
                bool aHashed = a.name.StartsWith("0x");
                bool bHashed = b.name.StartsWith("0x");
                if (aHashed && !bHashed)
                    return -1;
                if (!aHashed && bHashed)
                    return 1;
                return string.Compare(a.name, b.name, StringComparison.OrdinalIgnoreCase);
            });

            for (int i = 0; i < routeRoots.Count; i++)
                routeRoots[i].transform.SetSiblingIndex(i);

            return scene;
        }
    }
}
