using Fox.Core;
using Fox.Fio;
using Fox.Graphx;
using UnityEditor.SceneManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Fox.GameService
{
    public enum RouteSetVersion : short
    {
        GZ = 2,
        TPP = 3,
    }

    public class GsRouteSetReader
    {
        private const float USHORT_QUANTA_PER_DEGREE = (ushort.MaxValue + 1) / 360f;
        private const float DEGREE_PER_USHORT_QUANTA = 360f / (ushort.MaxValue + 1);

        public UnityEngine.SceneManagement.Scene? Read(FileStreamReader reader)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            string ROUT = new string(reader.ReadChars(4)); 
            if (ROUT != "ROUT")
            {
                Debug.LogError($"ROUT signature is wrong: {ROUT}");
                return null;
            }
            var FileVersion = (RouteSetVersion)reader.ReadInt16(); 

            if (FileVersion != RouteSetVersion.TPP & FileVersion != RouteSetVersion.GZ) 
            {
                Debug.LogError($"Version {FileVersion} isn't supported");
                return null;
            }

            int lengthOfTranslation = 12;
            if (FileVersion == RouteSetVersion.GZ)
                lengthOfTranslation = 8;
            else if (FileVersion == RouteSetVersion.TPP)
                lengthOfTranslation = 12;

            ushort routeCount = reader.ReadUInt16();

            Vector3 origin = Vector3.zero;

            if (FileVersion == RouteSetVersion.GZ)
            {
                reader.Skip(4 * 2); //Irrelevant memory leak bytes
                origin = reader.ReadPositionF();
                reader.Skip(4); //Irrelevant memory leak bytes
            }

            uint offsetToRouteNames = reader.ReadUInt32();
            uint offsetToRouteDefinitions = reader.ReadUInt32();
            uint offsetToRouteTranslations = reader.ReadUInt32();
            uint offsetToRouteEventCounts = reader.ReadUInt32();
            uint offsetToRouteEvents = reader.ReadUInt32();

            if (FileVersion == RouteSetVersion.GZ)
                reader.Skip(4 * 2); //Irrelevant memory leak bytes

            for (int routeIndex = 0; routeIndex < routeCount; routeIndex++)
            {
                //Route name
                reader.Seek(offsetToRouteNames + routeIndex * 4);
                GameObject routeGameObject = new GameObject(reader.ReadStrCode32().ToString());
                GsRouteData routeEntity = new GsRouteData();
                routeGameObject.AddComponent<FoxEntity>().Entity = routeEntity;
                TransformEntity routeTransform = TransformEntity.GetDefault();
                routeEntity.inheritTransform = false;
                routeEntity.SetTransform(routeTransform);
                routeEntity.InitializeGameObject(routeGameObject);

                //Route definition offsets and counts
                var routeDefinitonsPosition = (uint)(offsetToRouteDefinitions + (routeIndex * 16));

                reader.Seek(routeDefinitonsPosition);

                uint nodeOffset = reader.ReadUInt32() + routeDefinitonsPosition;
                uint eventTableOffset = reader.ReadUInt32() + routeDefinitonsPosition;
                uint eventsOffset = reader.ReadUInt32() + routeDefinitonsPosition;
                ushort nodeCount = reader.ReadUInt16();
                ushort eventCount = reader.ReadUInt16();

                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    GsRouteDataEdge edgeEntity = new GsRouteDataEdge();
                    GsRouteDataNode nodeEntity = new GsRouteDataNode();

                    routeEntity.edges.Add(new EntityPtr<GraphxSpatialGraphDataEdge>(edgeEntity));
                    routeEntity.nodes.Add(new EntityPtr<GraphxSpatialGraphDataNode>(nodeEntity));

                    reader.Seek(eventTableOffset + nodeIndex * 4);
                    ushort eventNodeCount = reader.ReadUInt16();
                    ushort eventStartIndex = reader.ReadUInt16();

                    reader.Seek(nodeOffset + nodeIndex * lengthOfTranslation);
                    if (FileVersion == RouteSetVersion.GZ)
                    {
                        //Vector3 Bit Unpacking by Joey:
                        //https://discord.com/channels/364177293133873153/364178190588968970/894215344099573760
                        //https://cdn.discordapp.com/attachments/364178190588968970/894215342069538907/unknown.png
                        //Console.WriteLine($"Translation packed #{nodePacked}");

                        long nodePacked = reader.ReadInt64();

                        uint packed_x = (uint)(nodePacked & 0x003FFFFF);
                        if ((packed_x & (1 << 21)) != 0)
                            packed_x |= 0xFFC00000;
                        var x = (float)(int)packed_x / 1024;

                        uint packed_y = (uint)((nodePacked >> 22) & 0x000FFFFF);
                        if ((packed_y & (1 << 19)) != 0)
                            packed_y |= 0xFFF00000;
                        var y = (float)(int)packed_y / 1024;

                        uint packed_z = (uint)((nodePacked >> 42) & 0x003FFFFF);
                        if ((packed_z & (1 << 21)) != 0)
                            packed_z |= 0xFFC00000;
                        var z = (float)(int)packed_z / 1024;

                        nodeEntity.position = Fox.Kernel.Math.FoxToUnityVector3(new Vector3(x, y, z)) + origin;
                    }
                    else if (FileVersion == RouteSetVersion.TPP)
                        nodeEntity.position = reader.ReadPositionF();

                    for (int eventIndex = 0; eventIndex < eventNodeCount; eventIndex++)
                    {
                        reader.Seek(eventsOffset + (eventIndex * 48)); // event length

                        GsRouteDataEvent eventEntity = new GsRouteDataEvent();

                        eventEntity.id = new Kernel.String(reader.ReadStrCode32().ToString());
                        reader.Skip(1);//var isNode = reader.ReadBoolean();
                        GsRouteDataEventAimPointType aimPointType = (GsRouteDataEventAimPointType)reader.ReadByte();
                        reader.Skip(1);//unknown
                        var isLoop = reader.ReadBoolean();
                        float time = (reader.ReadUInt16() + 1) / 60;
                        float dir = reader.ReadUInt16() / USHORT_QUANTA_PER_DEGREE;

                        if (FileVersion == RouteSetVersion.GZ)
                            reader.Skip(4); //inverted isnodeevent thing

                        switch (aimPointType)
                        {
                            case GsRouteDataEventAimPointType.ROUTE_AIM_NO_TARGET:
                                GsRouteDataEventAimPointNoTarget noTarget = new GsRouteDataEventAimPointNoTarget();
                                eventEntity.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(noTarget);
                                reader.Skip(4 * 4);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_STATIC_POINT:
                                GsRouteDataEventAimPointStaticPoint staticPoint = new GsRouteDataEventAimPointStaticPoint();
                                eventEntity.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(staticPoint);
                                staticPoint.position = reader.ReadPositionF();
                                reader.Skip(4);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_CHARACTER:
                                GsRouteDataEventAimPointCharacter character = new GsRouteDataEventAimPointCharacter();
                                eventEntity.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(character);
                                character.characterName = new Kernel.String(reader.ReadStrCode32().ToString());
                                reader.Skip(4 * 3);
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_ROUTE_AS_SIGHT_MOVE_PATH:
                                GsRouteDataEventAimPointRouteAsSightMovePath routeAsSightMovePath = new GsRouteDataEventAimPointRouteAsSightMovePath();
                                eventEntity.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(routeAsSightMovePath);
                                for (int aimPointRouteParamIndex = 0; aimPointRouteParamIndex < 4; aimPointRouteParamIndex++)
                                {
                                    routeAsSightMovePath.routeNames[aimPointRouteParamIndex] = new Kernel.String(reader.ReadStrCode32().ToString());
                                }
                                break;
                            case GsRouteDataEventAimPointType.ROUTE_AIM_ROUTE_AS_OBJECT:
                                GsRouteDataEventAimPointRouteAsObject routeAsObject = new GsRouteDataEventAimPointRouteAsObject();
                                eventEntity.aimPoint = new EntityPtr<GsRouteDataEventAimPoint>(routeAsObject);
                                for (int aimPointRouteParamIndex = 0; aimPointRouteParamIndex < 4; aimPointRouteParamIndex++)
                                {
                                    routeAsObject.routeNames[aimPointRouteParamIndex] = new Kernel.String(reader.ReadStrCode32().ToString());
                                }
                                break;
                            default:
                                break;
                        }

                        for (int extensionIndex = 0; extensionIndex < 4; extensionIndex++)
                            eventEntity.extensions[extensionIndex] = reader.ReadUInt32();

                        if (FileVersion == RouteSetVersion.TPP)
                            reader.Skip(4); //snippet

                        if (eventIndex == 0)
                        {
                            GsRouteDataEdgeEvent edgeEventEntity = new GsRouteDataEdgeEvent();
                            edgeEventEntity.id = eventEntity.id;
                            edgeEventEntity.aimPoint = eventEntity.aimPoint;
                            edgeEventEntity.extensions = eventEntity.extensions;
                            edgeEntity.edgeEvent = new EntityPtr<GsRouteDataEdgeEvent>(edgeEventEntity);
                            edgeEventEntity.owner = EntityHandle.Get(edgeEntity);
                        }
                        else
                        {
                            GsRouteDataNodeEvent nodeEventEntity = new GsRouteDataNodeEvent();
                            nodeEventEntity.id = eventEntity.id;
                            nodeEventEntity.aimPoint = eventEntity.aimPoint;
                            nodeEventEntity.extensions = eventEntity.extensions;
                            nodeEntity.nodeEvents.Add(new EntityPtr<GsRouteDataNodeEvent>(nodeEventEntity));
                            nodeEventEntity.owner = EntityHandle.Get(nodeEntity);
                            nodeEventEntity.isLoop = isLoop;
                            nodeEventEntity.time = time;
                            nodeEventEntity.dir = dir;
                        }
                    }
                }
            }

            return scene;
        }
    }
}
