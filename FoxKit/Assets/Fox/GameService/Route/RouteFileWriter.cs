using Fox.Fio;
using Fox;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Fox.GameService
{
    public class RouteFileWriter
    {
        private const uint Signature = 0x54554F52; // "ROUT"
        private const short Version = 3; //TPP
        private const int HeaderSize = 0x1C;

        public void Write(BinaryWriter writer, UnityEngine.SceneManagement.Scene sceneToExport)
        {
            List<GsRouteData> routes = GetRoutesToExport(sceneToExport);

            long headerPosition = writer.BaseStream.Position;
            writer.BaseStream.Position += HeaderSize;

            int routeIdsOffset = WriteRouteIds(writer, routes);
            int routeDefinitionsOffset = WriteRouteDefinitions(writer, routes, out int nodesOffset, out int eventTablesOffset, out int eventsOffset);

            long endPosition = WriteHeader(writer, routes, headerPosition, routeIdsOffset, routeDefinitionsOffset, nodesOffset, eventTablesOffset, eventsOffset);
            writer.BaseStream.Position = endPosition;
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

        private static int WriteRouteIds(BinaryWriter writer, List<GsRouteData> routes)
        {
            int routeIdsOffset = (int)writer.BaseStream.Position;

            // StrCode32
            foreach (GsRouteData route in routes)
            {
                string routeId = route.name;
                
                GameServiceModule.RouteIdMap.Add(routeId);

                writer.WriteStrCode32(new StrCode32(routeId));
            }

            GameServiceModule.RouteIdMap.Save();

            return routeIdsOffset;
        }

        private static int WriteRouteDefinitions(BinaryWriter writer, List<GsRouteData> routes,
            out int nodesOffset, out int eventTablesOffset, out int eventsOffset)
        {
            int routeDefinitionsOffset = (int)writer.BaseStream.Position;
            int routeCount = routes.Count;

            long[] defPositions = new long[routeCount];
            for (int i = 0; i < routeCount; i++)
            {
                defPositions[i] = writer.BaseStream.Position;
                writer.WriteZeros(16);
            }

            var routeEvents = new List<GsRouteDataEvent>[routeCount];
            var spanCounts = new ushort[routeCount][];
            var spanStarts = new ushort[routeCount][];
            for (int i = 0; i < routeCount; i++)
            {
                GsRouteData route = routes[i];
                int nodeCount = route.nodes.Count;
                var events = new List<GsRouteDataEvent>();
                var counts = new ushort[nodeCount];
                var starts = new ushort[nodeCount];
                ushort running = 0;
                for (int j = 0; j < nodeCount; j++)
                {
                    starts[j] = running;

                    if (j < route.edges.Count)
                    {
                        GsRouteDataEdgeEvent edgeEvent = ((GsRouteDataEdge)route.edges[j]).@event;
                        if (edgeEvent != null)
                        {
                            events.Add(edgeEvent);
                            running++;
                        }
                    }

                    foreach (GsRouteDataNodeEvent nodeEvent in ((GsRouteDataNode)route.nodes[j]).events)
                    {
                        events.Add(nodeEvent);
                        running++;
                    }

                    counts[j] = (ushort)(running - starts[j]);
                }
                routeEvents[i] = events;
                spanCounts[i] = counts;
                spanStarts[i] = starts;
            }

            long[] nodesPositions = new long[routeCount];
            nodesOffset = (int)writer.BaseStream.Position;
            for (int i = 0; i < routeCount; i++)
            {
                nodesPositions[i] = writer.BaseStream.Position;
                WriteNodePositions(writer, routes[i]);
            }

            long[] spansPositions = new long[routeCount];
            eventTablesOffset = (int)writer.BaseStream.Position;
            for (int i = 0; i < routeCount; i++)
            {
                spansPositions[i] = writer.BaseStream.Position;
                for (int j = 0; j < spanCounts[i].Length; j++)
                {
                    writer.Write(spanCounts[i][j]);
                    writer.Write(spanStarts[i][j]);
                }
            }

            long[] eventsPositions = new long[routeCount];
            eventsOffset = (int)writer.BaseStream.Position;
            for (int i = 0; i < routeCount; i++)
            {
                eventsPositions[i] = writer.BaseStream.Position;
                foreach (GsRouteDataEvent routeEvent in routeEvents[i])
                    WriteEvent(writer, routeEvent);
            }

            for (int i = 0; i < routeCount; i++)
            {
                long defPosition = defPositions[i];
                PatchRouteDefinition(
                    writer,
                    defPosition,
                    (uint)(nodesPositions[i] - defPosition),
                    (uint)(spansPositions[i] - defPosition),
                    (uint)(eventsPositions[i] - defPosition),
                    (ushort)routes[i].nodes.Count,
                    (ushort)routeEvents[i].Count);
            }

            return routeDefinitionsOffset;
        }

        private static void WriteNodePositions(BinaryWriter writer, GsRouteData route)
        {
            // TPP: 12-byte X-negated Vector3.
            // Now it takes the GsRouteData(The parent of the Nodes) Transform of x, y, z into account.
            foreach (var node in route.nodes)
                writer.WritePositionF(route.transform.TransformPoint(node.position));
        }

        private static void WriteEvent(BinaryWriter writer, GsRouteDataEvent routeEvent)
        {
            // EventDef
            writer.WriteStrCode32(new StrCode32(routeEvent.id));

            byte affinity = 0; // Edge
            if (routeEvent is GsRouteDataNodeEvent)
                affinity = 1; // Node
            writer.Write(affinity);

            writer.Write((byte)GetAimPointType(routeEvent.aimPoint));
            writer.Write((byte)0); // Unknown

            bool isLoop = false;
            ushort time = 0;
            ushort direction = 0;
            if (routeEvent is GsRouteDataNodeEvent nodeEvent)
            {
                isLoop = nodeEvent.isLoop;
                time = QuantizeTime(nodeEvent.time);
                direction = QuantizeDirection(nodeEvent.dir);
            }
            writer.Write(isLoop);
            writer.Write(time);
            writer.Write(direction);

            WriteAimPointPayload(writer, routeEvent.aimPoint);
            
            for (int i = 0; i < 4; i++)
                    writer.Write(routeEvent.extensions[i]);

            writer.Write(0u);
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

        private static void WriteAimPointPayload(BinaryWriter writer, GsRouteDataEventAimPoint aimPoint)
        {
            if (aimPoint is GsRouteDataEventAimStaticPoint staticPoint)
            {
                writer.WritePositionF(staticPoint.position);
                writer.WriteZeros(4);
                return;
            }
            if (aimPoint is GsRouteDataEventAimCharacter character)
            {
                writer.WriteStrCode32(new StrCode32(character.characterId));
                writer.WriteZeros(12);
                return;
            }
            if (aimPoint is GsRouteDataEventAimRouteAsSightMovePath sightMovePath)
            {
                int idCount = sightMovePath.routeId_GetContainerSize();
                
                for (int i = 0; i < idCount; i++)
                    writer.WriteStrCode32(new StrCode32(sightMovePath.routeId_Get(i)));
                
                for (int i = 0; i < (4 - idCount); i++)
                    writer.WriteStrCode32(new StrCode32(""));
                
                return;
            }
            if (aimPoint is GsRouteDataEventAimRouteAsObject routeAsObject)
            {
                int idCount = routeAsObject.routeId_GetContainerSize();
                
                for (int i = 0; i < routeAsObject.routeId_GetContainerSize(); i++)
                    writer.WriteStrCode32(new StrCode32(routeAsObject.routeId_Get(i)));
                
                for (int i = 0; i < (4 - idCount); i++)
                    writer.WriteStrCode32(new StrCode32(""));
                
                return;
            }

            writer.WriteZeros(16);
        }

        private static ushort QuantizeTime(float time)
        {
            int raw = Mathf.RoundToInt(time * 60f) - 1;
            return (ushort)Mathf.Clamp(raw, 0, ushort.MaxValue);
        }

        private static ushort QuantizeDirection(Quaternion direction)
        {
            Fox.Math.UnityToFoxQuaternion(direction).ToAngleAxis(out float angle, out _);
            
            const float quantaPerDegree = (ushort.MaxValue + 1) / 360f;
            int raw = Mathf.RoundToInt(angle * quantaPerDegree);
            return (ushort)Mathf.Clamp(raw, 0, ushort.MaxValue);
        }

        private static void PatchRouteDefinition(BinaryWriter writer, long defPosition, uint positionsOffset, uint eventSpanOffset, uint eventsOffset, ushort nodeCount, ushort eventCount)
        {
            long resume = writer.BaseStream.Position;
            writer.BaseStream.Position = defPosition;

            writer.Write(positionsOffset);
            writer.Write(eventSpanOffset);
            writer.Write(eventsOffset);
            writer.Write(nodeCount);
            writer.Write(eventCount);

            writer.BaseStream.Position = resume;
        }

        private static long WriteHeader(BinaryWriter writer, List<GsRouteData> routes, long headerPosition, int routeIdsOffset, int routeDefinitionsOffset, int nodesOffset, int eventTablesOffset, int eventsOffset)
        {
            long endPosition = writer.BaseStream.Position;
            writer.BaseStream.Position = headerPosition;

            writer.Write(Signature);
            writer.Write(Version);
            writer.Write((ushort)routes.Count);
            writer.Write(routeIdsOffset);
            writer.Write(routeDefinitionsOffset);

            writer.Write(nodesOffset);
            writer.Write(eventTablesOffset);
            writer.Write(eventsOffset);

            return endPosition;
        }
    }
}
