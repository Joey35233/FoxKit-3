using System.Collections.Generic;
using UnityEngine;

namespace Fox.GameService
{
    public class RouteFileWriter
    {
        public unsafe byte[] Write(UnityEngine.SceneManagement.Scene sceneToExport)
        {
            List<GsRouteData> routes = GetRoutesToExport(sceneToExport);
            uint routeCount = (uint)routes.Count;

            Vector3[][] nodePositions = new Vector3[routeCount][];
            RouteFile.EventSpan[][] eventSpans = new RouteFile.EventSpan[routeCount][];
            List<GsRouteDataEvent>[] routeEvents = new List<GsRouteDataEvent>[routeCount];

            uint nodeCount = 0;
            uint eventCount = 0;
            for (uint i = 0; i < routeCount; i++)
            {
                GsRouteData route = routes[(int)i];
                int routeNodeCount = route.Nodes.Count;

                Vector3[] positions = new Vector3[routeNodeCount];
                RouteFile.EventSpan[] spans = new RouteFile.EventSpan[routeNodeCount];
                List<GsRouteDataEvent> events = new();

                ushort running = 0;
                for (int j = 0; j < routeNodeCount; j++)
                {
                    // Takes the GsRouteData (the parent of the nodes) Transform into account.
                    positions[j] = route.transform.TransformPoint(route.Nodes[j].Position);

                    ushort start = running;

                    if (j < route.Edges.Count)
                    {
                        GsRouteDataEdgeEvent edgeEvent = ((GsRouteDataEdge)route.Edges[j]).Event;
                        if (edgeEvent != null)
                        {
                            events.Add(edgeEvent);
                            running++;
                        }
                    }

                    foreach (GsRouteDataNodeEvent nodeEvent in ((GsRouteDataNode)route.Nodes[j]).Events)
                    {
                        events.Add(nodeEvent);
                        running++;
                    }

                    spans[j] = new RouteFile.EventSpan { StartIndex = start, Count = (ushort)(running - start) };
                }

                nodePositions[i] = positions;
                eventSpans[i] = spans;
                routeEvents[i] = events;

                nodeCount += (uint)routeNodeCount;
                eventCount += (uint)events.Count;
            }

            long dataSize = sizeof(RouteFile.HeaderV3)
                            + routeCount * sizeof(StrCode32)
                            + routeCount * sizeof(RouteFile.RouteDef)
                            + nodeCount * sizeof(Vector3)
                            + nodeCount * sizeof(RouteFile.EventSpan)
                            + eventCount * sizeof(RouteFile.EventDef);

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
                RouteFile.EventSpan* spans = (RouteFile.EventSpan*)(vertices + nodeCount);
                RouteFile.EventDef* events = (RouteFile.EventDef*)(spans + nodeCount);

                header->RouteIdsOffset = (uint)((byte*)routeIds - dataPtr);
                header->RouteDefinitionsOffset = (uint)((byte*)routeDefs - dataPtr);
                header->RouteNodesOffset = (uint)((byte*)vertices - dataPtr);
                header->RouteEventTablesOffset = (uint)((byte*)spans - dataPtr);
                header->RouteEventsOffset = (uint)((byte*)events - dataPtr);

                for (uint i = 0; i < routeCount; i++)
                {
                    GsRouteData route = routes[(int)i];

                    GameServiceModule.RouteIdMap.Add(route.name);
                    routeIds[i] = new StrCode32(route.name);

                    RouteFile.RouteDef* routeDef = routeDefs + i;

                    Vector3[] positions = nodePositions[i];
                    routeDef->VerticesOffset = (uint)((byte*)vertices - (byte*)routeDef);
                    routeDef->NodeCount = (ushort)positions.Length;
                    for (int j = 0; j < positions.Length; j++)
                        vertices[j] = Math.UnityToFoxVector3(positions[j]);
                    vertices += positions.Length;

                    RouteFile.EventSpan[] routeSpans = eventSpans[i];
                    routeDef->EventSpanOffset = (uint)((byte*)spans - (byte*)routeDef);
                    for (int j = 0; j < routeSpans.Length; j++)
                        spans[j] = routeSpans[j];
                    spans += routeSpans.Length;

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

        private static List<GsRouteData> GetRoutesToExport(UnityEngine.SceneManagement.Scene sceneToExport)
        {
            GsRouteData[] routes = UnityEngine.Object.FindObjectsByType<GsRouteData>(FindObjectsSortMode.InstanceID);
            List<GsRouteData> writeableRoutes = new();
            foreach (GsRouteData route in routes)
            {
                if (route.gameObject.scene == sceneToExport)
                    writeableRoutes.Add(route);
            }

            writeableRoutes.Sort((a, b) => a.transform.GetSiblingIndex().CompareTo(b.transform.GetSiblingIndex()));
            return writeableRoutes;
        }

        private static unsafe void WriteEvent(RouteFile.EventDef* eventDef, GsRouteDataEvent routeEvent)
        {
            eventDef->Id = new StrCode32(routeEvent.Id);
            eventDef->Type = routeEvent is GsRouteDataNodeEvent ? RouteEventType.Node : RouteEventType.Edge;
            eventDef->AimTargetType = GetAimPointType(routeEvent.aimPoint);
            eventDef->BodySectionType = RouteBodySectionType.Head;

            if (routeEvent is GsRouteDataNodeEvent nodeEvent)
            {
                eventDef->IsLoop = nodeEvent.IsLoop;
                eventDef->EncodedTime = QuantizeTime(nodeEvent.Time);
                eventDef->EncodedDir = QuantizeDirection(nodeEvent.Dir);
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
                *(Vector3*)aimPointData = Math.UnityToFoxVector3(staticPoint.Position);
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

        private static RouteAimTargetType GetAimPointType(GsRouteDataEventAimPoint aimPoint)
        {
            if (aimPoint is GsRouteDataEventAimStaticPoint)
                return RouteAimTargetType.StaticPoint;
            if (aimPoint is GsRouteDataEventAimCharacter)
                return RouteAimTargetType.Character;
            if (aimPoint is GsRouteDataEventAimRouteAsSightMovePath)
                return RouteAimTargetType.RouteAsSightMovePath;
            if (aimPoint is GsRouteDataEventAimRouteAsObject)
                return RouteAimTargetType.RouteAsObject;
            return RouteAimTargetType.NoTarget;
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
