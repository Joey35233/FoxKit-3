using Fox.Core;
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
        private const float USHORT_QUANTA_PER_DEGREE = (UInt16.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (UInt16.MaxValue + 1);

        private enum RouteSetVersion : short
        {
            GZ = 2,
            TPP = 3,
        }

        private enum EventType : byte
        {
            Edge = 0,
            Node = 1,
        }

        public enum GsRouteDataEventAimPointType : byte
        {
            ROUTE_AIM_NO_TARGET = 0,
            ROUTE_AIM_STATIC_POINT = 1,
            ROUTE_AIM_CHARACTER = 2,
            ROUTE_AIM_ROUTE_AS_SIGHT_MOVE_PATH = 3,
            ROUTE_AIM_ROUTE_AS_OBJECT = 4,
        }

        private struct EventSpan
        {
            public ushort Count;
            public ushort StartIndex;
        }

        private struct EventDef
        {
            public StrCode32 Id;
            public EventType Type;
            public GsRouteDataEventAimPointType AimPointType;
            public byte Unknown;
            public bool IsLoop;
            public float Time;
            public float Direction;

            public static EventDef Read(FileStreamReader reader)
            {
                var result = new EventDef
                {
                    Id = reader.ReadStrCode32(),
                    Type = (EventType)reader.ReadByte(),
                    AimPointType = (GsRouteDataEventAimPointType)reader.ReadByte(),
                    Unknown = reader.ReadByte(),
                    IsLoop = reader.ReadBoolean(),
                    Time = (float)(reader.ReadUInt16() + 1) / 60, // TODO: ad hoc formula could be wrong
                    Direction = reader.ReadUInt16() / USHORT_QUANTA_PER_DEGREE,
                };

                Debug.Assert(Enum.IsDefined(typeof(EventType), result.Type));
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
                Debug.LogError($"Read failed. Not a ROUT.");
                return null;
            }

            var fileVersion = (RouteSetVersion)reader.ReadInt16();

            if (fileVersion != RouteSetVersion.TPP & fileVersion != RouteSetVersion.GZ)
            {
                Debug.LogError($"Version {fileVersion} isn't supported");
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

                // Create Unity backing
                var routeGameObject = new GameObject(id.ToString());
                var routeData = new GsRouteData
                {
                    nodes = new DynamicArray<EntityPtr<GraphxSpatialGraphDataNode>>(nodeCount),
                    edges = new DynamicArray<EntityPtr<GraphxSpatialGraphDataEdge>>(nodeCount),
                };
                var routeTransform = TransformEntity.GetDefault();
                routeData.inheritTransform = false;
                routeData.SetTransform(routeTransform);
                routeGameObject.AddComponent<FoxEntity>().Entity = routeData;

                for (int j = 0; j < nodeCount; j++)
                {
                    var edge = new GsRouteDataEdge();
                    edge.SetOwner(routeData);
                    routeData.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(edge));

                    var node = new GsRouteDataNode();
                    node.SetOwner(routeData);
                    routeData.nodes.Add(new EntityPtr<GraphxSpatialGraphDataNode>(node));

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

                        var @event = new GsRouteDataEvent
                        {
                            id = new Kernel.String(eventDef.Id.ToString()),
                        };

                        if (fileVersion == RouteSetVersion.GZ)
                            reader.Skip(4); //inverted isnodeevent thing

                        switch (eventDef.AimPointType)
                        {
                            case GsRouteDataEventAimPointType.ROUTE_AIM_NO_TARGET:
                                var noTarget = new GsRouteDataEvAimPtNoTarget();
                                @event.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(noTarget);

                                reader.SkipPadding(4 * 4);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_STATIC_POINT:
                                var staticPoint = new GsRouteDataEvAimPtStaticPoint();
                                @event.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(staticPoint);

                                staticPoint.position = reader.ReadPositionF();
                                reader.SkipPadding(4);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_CHARACTER:
                                var character = new GsRouteDataEvAimPtCharacter();
                                @event.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(character);

                                character.characterName = new Kernel.String(reader.ReadStrCode32().ToString());
                                reader.SkipPadding(4 * 3);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_ROUTE_AS_SIGHT_MOVE_PATH:
                                var routeAsSightMovePath = new GsRouteDataEvAimPtRouteAsSightMovePath();
                                @event.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(routeAsSightMovePath);

                                for (int l = 0; l < 4; l++)
                                {
                                    routeAsSightMovePath.routeNames[l] = new Kernel.String(reader.ReadStrCode32().ToString());
                                }
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_ROUTE_AS_OBJECT:
                                var routeAsObject = new GsRouteDataEvAimPtRouteAsObject();
                                @event.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(routeAsObject);

                                for (int l = 0; l < 4; l++)
                                {
                                    routeAsObject.routeNames[l] = new Kernel.String(reader.ReadStrCode32().ToString());
                                }
                                break;
                            default:
                                break;
                        }

                        for (int l = 0; l < 4; l++)
                            @event.extensions[l] = reader.ReadUInt32();

                        if (fileVersion == RouteSetVersion.TPP)
                            reader.Skip(4); //snippet

                        if (eventDef.Type == EventType.Edge)
                        {
                            var edgeEvent = new GsRouteDataEdgeEvent
                            {
                                id = new Kernel.String(eventDef.Id.ToString()),
                                aimPoint = @event.aimPoint,
                                extensions = @event.extensions
                            };
                            edge.edgeEvent = new EntityPtr<GsRouteDataEdgeEvent>(edgeEvent);
                        }
                        else if (eventDef.Type == EventType.Node)
                        {
                            var nodeEvent = new GsRouteDataNodeEvent
                            {
                                id = new Kernel.String(eventDef.Id.ToString()),
                                aimPoint = @event.aimPoint,
                                extensions = @event.extensions,
                                isLoop = eventDef.IsLoop,
                                time = eventDef.Time,
                                dir = eventDef.Direction,
                            };

                            node.nodeEvents.Add(new EntityPtr<GsRouteDataNodeEvent>(nodeEvent));
                        }
                    }
                }

                // RouteData has been staged. Initialize it.
                routeData.InitializeGameObject(routeGameObject);
            }

            return scene;
        }
    }
}
