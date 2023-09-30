using Fox.Core;
using Fox.Core.Utils;
using Fox.Fio;
using Fox.Graphx;
using Fox.Kernel;
using System;
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
            public GsRouteDataRouteEventAimPoint.Type AimPointType;
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
                    AimPointType = (GsRouteDataRouteEventAimPoint.Type)reader.ReadByte(),
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

                GsRouteData routeData = new GameObject(id.ToString()).AddComponent<GsRouteData>();
                routeData.SetTransform(TransformEntity.GetDefault());

                for (int j = 0; j < nodeCount; j++)
                {
                    GsRouteDataEdge edge = new GameObject().AddComponent<GsRouteDataEdge>();
                    edge.SetOwner(routeData);
                    routeData.edges.Add(edge);

                    GsRouteDataNode node = new GameObject().AddComponent<GsRouteDataNode>();
                    node.SetOwner(routeData);
                    routeData.nodes.Add(node);

                    // Position
                    reader.Seek(routeDefPosition + positionsOffset + (j * nodePositionSizeInBytes));
                    if (fileVersion == RouteSetVersion.GZ)
                    {
                        // Vector3 Bit Unpacking by Joey:
                        // https://discord.com/channels/364177293133873153/364178190588968970/894215344099573760
                        // https://cdn.discordapp.com/attachments/364178190588968970/894215342069538907/unknown.png

                        long packedPosition = reader.ReadInt64();

                        uint packed_x = (uint)(packedPosition & 0x003FFFFF);
                        if ((packed_x & (1 << 21)) != 0)
                            packed_x |= 0xFFC00000;
                        float x = (float)(int)packed_x / 1024;

                        uint packed_y = (uint)((packedPosition >> 22) & 0x000FFFFF);
                        if ((packed_y & (1 << 19)) != 0)
                            packed_y |= 0xFFF00000;
                        float y = (float)(int)packed_y / 1024;

                        uint packed_z = (uint)((packedPosition >> 42) & 0x003FFFFF);
                        if ((packed_z & (1 << 21)) != 0)
                            packed_z |= 0xFFC00000;
                        float z = (float)(int)packed_z / 1024;

                        node.position = Fox.Kernel.Math.FoxToUnityVector3(new Vector3(x, y, z)) + origin;
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

                        GsRouteDataRouteEventAimPoint aimPoint = null;
                        switch(eventDef.AimPointType)
                        {
                            case GsRouteDataRouteEventAimPoint.Type.NoTarget:
                                {
                                    GsRouteDataRtEvAimPointNoTarget result = new GameObject().AddComponent<GsRouteDataRtEvAimPointNoTarget>();
                                    aimPoint = result;
                                }
                                break;
                            case GsRouteDataRouteEventAimPoint.Type.StaticPoint:
                                {
                                    GsRouteDataRtEvAimPointStaticPoint result = new GameObject().AddComponent<GsRouteDataRtEvAimPointStaticPoint>();
                                    result.position = reader.ReadPositionF();
                                    aimPoint = result;
                                }
                                break;
                            case GsRouteDataRouteEventAimPoint.Type.Character:
                                {
                                    GsRouteDataRtEvAimPointCharacter result = new GameObject().AddComponent<GsRouteDataRtEvAimPointCharacter>();
                                    result.characterName = new Kernel.String(reader.ReadStrCode32().ToString());
                                    aimPoint = result;
                                }
                                break;
                            case GsRouteDataRouteEventAimPoint.Type.RouteAsSightMovePath:
                                {
                                    GsRouteDataRtEvAimPointRouteAsSightMovePath result = new GameObject().AddComponent<GsRouteDataRtEvAimPointRouteAsSightMovePath>();
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    aimPoint = result;
                                }
                                break;
                            case GsRouteDataRouteEventAimPoint.Type.RouteAsObject:
                                {
                                    GsRouteDataRtEvAimPointRouteAsObject result = new GameObject().AddComponent<GsRouteDataRtEvAimPointRouteAsObject>();
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    result.routeNames.Add(new Kernel.String(reader.ReadStrCode32().ToString()));
                                    aimPoint = result;
                                }
                                break;
                        };
                        aimPoint.SetOwner(routeData);
                        reader.Seek(payloadPosition);

                        GsRouteDataRouteEvent routeEvent = GameServiceModule.GsRouteDataEventDeserializationMap[eventDef.Id](reader);
                        routeEvent.SetOwner(routeData);
                        routeEvent.aimPoint = aimPoint;

                        if (fileVersion == RouteSetVersion.TPP)
                            reader.Skip(4); //snippet

                        if (eventDef.Affinity == EventAffinity.Edge)
                        {
                            var edgeEvent = routeEvent as GsRouteDataEdgeEvent;
                            edge.edgeEvent = edgeEvent;
                        }
                        else
                        {
                            var nodeEvent = routeEvent as GsRouteDataNodeEvent;
                            nodeEvent.isLoop = eventDef.IsLoop;
                            nodeEvent.time = eventDef.Time;
                            nodeEvent.direction = eventDef.Direction;
                            node.nodeEvents.Add(nodeEvent);
                        }
                    }
                }

                for (int j = 0; j < nodeCount; j++)
                {
                    GraphxSpatialGraphDataNode node = routeData.nodes[j];

                    GraphxSpatialGraphDataEdge prevEdge = routeData.edges[(j - 1 + nodeCount) % nodeCount];
                    GraphxSpatialGraphDataEdge nextEdge = routeData.edges[j];

                    node.inlinks.Add(prevEdge);
                    prevEdge.nextNode = node;
                    node.outlinks.Add(nextEdge);
                    nextEdge.prevNode = node;
                }
            }

            return scene;
        }
    }
}
