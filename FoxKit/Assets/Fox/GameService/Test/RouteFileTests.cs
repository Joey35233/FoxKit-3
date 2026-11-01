using System.Collections.Generic;
using System.Linq;
using Fox.Core.Utils;
using Fox.Graphx;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fox.GameService.Tests
{
    public class RouteFileTests
    {
        private static ulong PackVertexV2(int x, int y, int z) =>
            ((ulong)x & 0x3FFFFF) | (((ulong)y & 0xFFFFF) << 22) | (((ulong)z & 0x3FFFFF) << 42);

        [Test]
        public void EventDefTimeRoundTrips()
        {
            RouteFile.EventDef def = default;
            for (int encoded = 0; encoded <= ushort.MaxValue; encoded++)
            {
                def.EncodedTime = (ushort)encoded;
                float time = def.GetTime();

                RouteFile.EventDef other = default;
                other.SetTime(time);
                Assert.AreEqual(encoded, other.EncodedTime);
            }
        }

        [Test]
        public void EventDefDirectionRoundTrips()
        {
            RouteFile.EventDef def = default;
            for (int encoded = 0; encoded <= ushort.MaxValue; encoded++)
            {
                def.EncodedDir = (ushort)encoded;
                Quaternion foxDirection = def.GetFoxDirection();

                RouteFile.EventDef other = default;
                other.SetFoxDirection(foxDirection);
                Assert.AreEqual(encoded, other.EncodedDir);
            }
        }

        [Test]
        public void EventDefDirectionIsFoxSpaceYaw()
        {
            RouteFile.EventDef def = default;
            def.SetFoxDirection(Quaternion.AngleAxis(90f, Vector3.up));
            Assert.AreEqual(16384, def.EncodedDir);

            def.SetFoxDirection(Quaternion.identity);
            Assert.AreEqual(0, def.EncodedDir);
        }

        [Test]
        public void UnpackVertexV2()
        {
            Assert.AreEqual(Vector3.zero, RouteFile.UnpackVertexV2(0));
            Assert.AreEqual(new Vector3(1f, -2f, 3f / 1024f), RouteFile.UnpackVertexV2(PackVertexV2(1024, -2048, 3)));
            Assert.AreEqual(new Vector3(-2048f, -512f, -2048f), RouteFile.UnpackVertexV2(PackVertexV2(-(1 << 21), -(1 << 19), -(1 << 21))));
            Assert.AreEqual(new Vector3(((1 << 21) - 1) / 1024f, ((1 << 19) - 1) / 1024f, ((1 << 21) - 1) / 1024f),
                RouteFile.UnpackVertexV2(PackVertexV2((1 << 21) - 1, (1 << 19) - 1, (1 << 21) - 1)));
        }

        private static GsRouteData BuildRoute(string name, Vector3[] positions)
        {
            GsRouteData route = new GameObject().AddComponent<GsRouteData>();
            route.name = name;

            for (int i = 0; i < positions.Length; i++)
            {
                GsRouteDataNode node = new GameObject().AddComponent<GsRouteDataNode>();
                node.transform.position = positions[i];
                route.Nodes.Add(node);

                route.Edges.Add(new GameObject().AddComponent<GsRouteDataEdge>());
            }

            // Edge i leaves node i
            for (int i = 0; i < positions.Length; i++)
            {
                GsRouteDataNode from = (GsRouteDataNode)route.Nodes[i];
                GsRouteDataNode to = (GsRouteDataNode)route.Nodes[(i + 1) % positions.Length];
                GraphxSpatialGraphDataEdge edge = route.Edges[i];
                edge.PrevNode = from;
                edge.NextNode = to;
                from.Outlinks.Add(edge);
                to.Outlinks.Add(edge);
            }

            return route;
        }

        private static GsRouteDataNodeEvent AddNodeEvent(GsRouteData route, int nodeIndex, string id, float time, Quaternion dir)
        {
            GsRouteDataNodeEvent nodeEvent = new GameObject().AddComponent<GsRouteDataNodeEvent>();
            nodeEvent.Id = id;
            nodeEvent.IsLoop = true;
            nodeEvent.Time = time;
            nodeEvent.Dir = dir;
            ((GsRouteDataNode)route.Nodes[nodeIndex]).Events.Add(nodeEvent);
            return nodeEvent;
        }

        [Test]
        public void WriteFailsOnUnknownEventId()
        {
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            GsRouteData route = BuildRoute("0x0000abcd", new Vector3[] { new(0, 0, 0), new(1, 0, 0) });
            AddNodeEvent(route, 0, "NotARegisteredEvent", 1f, Quaternion.identity);

            Assert.IsNull(new RouteFileWriter().Write(scene));
        }
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ReadThenWritePreservesRouteConnections(int nodeCount)
        {
            Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            Vector3[] positions = Enumerable.Range(0, nodeCount).Select(i => new Vector3(i, 0, 0)).ToArray();
            BuildRoute("0x0000abcd", positions);

            byte[] data = new RouteFileWriter().Write(scene);
            Assert.NotNull(data);

            Scene? readScene = new RouteFileReader().Read(data, new TaskLogger("RouteFileTests"));
            Assert.NotNull(readScene);
            GsRouteData route = readScene.Value.GetRootGameObjects()
                .Select(go => go.GetComponent<GsRouteData>()).Single(r => r != null);
            Assert.AreEqual(nodeCount, route.Nodes.Count);
            Assert.AreEqual(nodeCount, route.Edges.Count);
            for (int i = 0; i < nodeCount; i++)
            {
                GraphxSpatialGraphDataEdge edge = route.Edges[i];
                Assert.AreSame(route.Nodes[i], edge.PrevNode);
                Assert.AreSame(route.Nodes[(i + 1) % nodeCount], edge.NextNode);
                CollectionAssert.Contains(route.Nodes[i].Outlinks, edge);
                CollectionAssert.Contains(route.Nodes[(i + 1) % nodeCount].Outlinks, edge);
            }

            byte[] rewritten = new RouteFileWriter().Write(readScene.Value);
            Assert.NotNull(rewritten);
            CollectionAssert.AreEqual(data, rewritten);
        }

        [Test]
        public void WriteThenReadRoundTrips()
        {
            GameServiceModule.RegisterCharacterIdMap(new StringId32Map());
            GameServiceModule.EventIdMap.RegisterBaseEntries(new List<(StrCode32, string)>
            {
                (new StrCode32("TestNodeEventA"), "TestNodeEventA"),
                (new StrCode32("TestNodeEventB"), "TestNodeEventB"),
                (new StrCode32("TestNodeEventC"), "TestNodeEventC"),
                (new StrCode32("TestNodeEventD"), "TestNodeEventD"),
                (new StrCode32("TestEdgeEventA"), "TestEdgeEventA"),
            });

            Scene writeScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

            Vector3[] positionsA = { new(1, 2, 3), new(-4, 5, 6), new(7, 8, -9) };
            Vector3[] positionsB = { new(10, 0, 0), new(0, 0, 10) };
            Quaternion dir = Quaternion.AngleAxis(90f, Vector3.up);

            GsRouteData routeA = BuildRoute("0x0000abcd", positionsA);
            GsRouteData routeB = BuildRoute("0x0000abce", positionsB);

            // Route A: node 0 gets an event with a static aim point and extensions; edge 2 gets an edge event
            GsRouteDataNodeEvent nodeEventA = AddNodeEvent(routeA, 0, "TestNodeEventA", 8f, dir);
            nodeEventA.extensions[0] = 0xDEADBEEF;
            GsRouteDataEventAimStaticPoint aimPoint = new GameObject().AddComponent<GsRouteDataEventAimStaticPoint>();
            aimPoint.Position = new Vector3(1, 2, 3);
            aimPoint.BodySection = GsRouteDataEventAimPoint_BodySection.BREAST;
            nodeEventA.aimPoint = aimPoint;

            GsRouteDataEdgeEvent edgeEventA = new GameObject().AddComponent<GsRouteDataEdgeEvent>();
            edgeEventA.Id = "TestEdgeEventA";
            ((GsRouteDataEdge)routeA.Edges[2]).Event = edgeEventA;

            // Route B: events live on node 1, so a route-local span index matters
            AddNodeEvent(routeB, 1, "TestNodeEventD", 2f, Quaternion.identity);

            // Aim points: character, and a route list with fewer than 4 ids
            GsRouteDataNodeEvent characterEvent = AddNodeEvent(routeA, 1, "TestNodeEventB", 1f, Quaternion.identity);
            GsRouteDataEventAimCharacter aimCharacter = new GameObject().AddComponent<GsRouteDataEventAimCharacter>();
            aimCharacter.characterId = "0x0000c0de";
            characterEvent.aimPoint = aimCharacter;

            GsRouteDataNodeEvent routeEvent = AddNodeEvent(routeA, 2, "TestNodeEventC", 1f, Quaternion.identity);
            GsRouteDataEventAimRouteAsObject aimRoute = new GameObject().AddComponent<GsRouteDataEventAimRouteAsObject>();
            aimRoute.routeId_AddElement(0, "0x0000aaaa");
            aimRoute.routeId_AddElement(1, "0x0000bbbb");
            routeEvent.aimPoint = aimRoute;

            byte[] data = new RouteFileWriter().Write(writeScene);
            Assert.NotNull(data);

            TaskLogger logger = new TaskLogger("RouteFileTests");
            Scene? readScene = new RouteFileReader().Read(data, logger);
            Assert.NotNull(readScene);

            GsRouteData[] routes = readScene.Value.GetRootGameObjects()
                .Select(go => go.GetComponent<GsRouteData>())
                .Where(r => r != null)
                .ToArray();
            Assert.AreEqual(2, routes.Length);

            GsRouteData readA = routes.Single(r => r.name == "0x0000abcd");
            GsRouteData readB = routes.Single(r => r.name == "0x0000abce");

            Assert.AreEqual(3, readA.Nodes.Count);
            for (int i = 0; i < 3; i++)
                Assert.That(Vector3.Distance(positionsA[i], readA.Nodes[i].transform.position), Is.LessThan(1e-4f));

            GsRouteDataNode readNode0 = (GsRouteDataNode)readA.Nodes[0];
            Assert.AreEqual(1, readNode0.Events.Count);
            GsRouteDataNodeEvent readNodeEvent = readNode0.Events[0];
            Assert.AreEqual("TestNodeEventA", readNodeEvent.Id);
            Assert.IsTrue(readNodeEvent.IsLoop);
            Assert.That(readNodeEvent.Time, Is.EqualTo(8f).Within(1f / 30f));
            Assert.That(Quaternion.Angle(dir, readNodeEvent.Dir), Is.LessThan(0.1f));
            Assert.AreEqual(0xDEADBEEF, readNodeEvent.extensions[0]);

            Assert.IsInstanceOf<GsRouteDataEventAimStaticPoint>(readNodeEvent.aimPoint);
            Assert.AreEqual(GsRouteDataEventAimPoint_BodySection.BREAST, readNodeEvent.aimPoint.BodySection);
            Assert.That(Vector3.Distance(new Vector3(1, 2, 3), readNodeEvent.aimPoint.Position), Is.LessThan(1e-4f));

            // The edge event comes back on the edge leaving node 2
            GsRouteDataEdge readEdge2 = (GsRouteDataEdge)readA.Edges.Single(e => e.PrevNode == readA.Nodes[2]);
            Assert.NotNull(readEdge2.Event);
            Assert.AreEqual("TestEdgeEventA", readEdge2.Event.Id);

            GsRouteDataNodeEvent readCharacterEvent = ((GsRouteDataNode)readA.Nodes[1]).Events[0];
            Assert.IsInstanceOf<GsRouteDataEventAimCharacter>(readCharacterEvent.aimPoint);
            Assert.AreEqual("0x0000c0de", ((GsRouteDataEventAimCharacter)readCharacterEvent.aimPoint).characterId);

            GsRouteDataNodeEvent readRouteEvent = ((GsRouteDataNode)readA.Nodes[2]).Events[0];
            Assert.IsInstanceOf<GsRouteDataEventAimRouteAsObject>(readRouteEvent.aimPoint);
            GsRouteDataEventAimRouteAsObject readAimRoute = (GsRouteDataEventAimRouteAsObject)readRouteEvent.aimPoint;
            Assert.AreEqual(2, readAimRoute.routeId_GetContainerSize());
            Assert.AreEqual("0x0000aaaa", readAimRoute.routeId_Get(0));
            Assert.AreEqual("0x0000bbbb", readAimRoute.routeId_Get(1));

            Assert.AreEqual(0, ((GsRouteDataNode)readB.Nodes[0]).Events.Count);
            GsRouteDataNode readBNode1 = (GsRouteDataNode)readB.Nodes[1];
            Assert.AreEqual(1, readBNode1.Events.Count);
            Assert.AreEqual("TestNodeEventD", readBNode1.Events[0].Id);

            byte[] rewritten = new RouteFileWriter().Write(readScene.Value);
            Assert.NotNull(rewritten);
            CollectionAssert.AreEqual(data, rewritten);
        }
    }
}
