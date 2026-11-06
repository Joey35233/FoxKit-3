using Fox.Core;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using System;
using System.ComponentModel;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxPath2 : Fox.Graphx.GraphxPathData
    {
        //https://github.com/TinManTex/mgsv-deminified-lua/blob/3b8d6a0487ce45f69502d40e684b3d653d3b8965/data1/Tpp/start.lua#L292
        [Flags]
        public enum Tags : ulong
        {
            [Description("Elude")]
            Elude = 0x1,
            [Description("Jump")]
            Jump = 0x2,
            [Description("Fence")]
            Fence = 0x4,
            [Description("StepOn")]
            StepOn = 0x8,

            [Description("Behind")]
            Behind = 0x10,
            [Description("Urgent")]
            Urgent = 0x20,
            [Description("Pipe")]
            Pipe = 0x40,
            [Description("Climb")]
            Climb = 0x80,

            [Description("Rail")]
            Rail = 0x100,
            [Description("ForceFallDown")]
            ForceFallDown = 0x200,
            [Description("DontFallWall")]
            DontFallWall = 0x400,
        }

        public override Type GetNodeType() => typeof(GeoxPathNode);
        public override Type GetEdgeType() => typeof(GeoxPathEdge);
        public override bool IsLoop() => false;

        public override void Reset()
        {
            base.Reset();
            enable = true;
        }
        public static GeoxPath2 Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.Path);

            GeoxPath2 path = new GameObject().AddComponent<GeoxPath2>();
            path.SetTransform(TransformEntity.GetDefault());

            TagUtils.AddEnumTags<Tags>(path.tags, (ulong)header.GetTags<Tags>());

            // Working off the assumption that the indices are for the vertices and the edges are implicitly linked
            path.Nodes.Capacity = header.PrimCount + 1;
            for (int i = 0; i < path.Nodes.Capacity; i++)
                path.Nodes.Add(default);
            path.Edges.Capacity = header.PrimCount;
            for (int i = 0; i < path.Edges.Capacity; i++)
                path.Edges.Add(default);

            for (int i = 0; i < header.PrimCount; i++)
            {
                reader.Seek(header.GetDataPosition() + (8 * i));

                GeoxPathEdge edge = new GameObject().AddComponent<GeoxPathEdge>();
                edge.SetOwner(path);
                edge.name = $"{edge.GetType().Name}{i:D4}";

                var geoEdgeTags = (GeoxPathEdge.Tags)reader.ReadUInt32();
                foreach (GeoxPathEdge.Tags tag in Enum.GetValues(geoEdgeTags.GetType()))
                {
                    if (geoEdgeTags.HasFlag(tag))
                        edge.EdgeTags.Add(tag.ToString());
                }

                ushort inNodeIndex = reader.ReadUInt16();
                ushort outNodeIndex = reader.ReadUInt16();
                GraphxSpatialGraphDataNode inNode;
                if (path.Nodes[inNodeIndex] is null)
                {
                    GeoxPathNode node = new GameObject($"GeoxPathNode{inNodeIndex:D4}").AddComponent<GeoxPathNode>();
                    node.SetOwner(path);

                    reader.Seek(header.Position + header.VertexBufferOffset + (16 * inNodeIndex));
                    node.Position = reader.ReadPositionF();
                    node.transform.position = node.Position;

                    TagUtils.AddEnumTags<GeoxPathNode.Tags>(node.NodeTags, reader.ReadUInt32());

                    path.Nodes[inNodeIndex] = node;
                    inNode = node;
                }
                else
                {
                    inNode = path.Nodes[inNodeIndex];
                }
                edge.PrevNode = inNode;
                inNode.Outlinks.Add(edge);

                GraphxSpatialGraphDataNode outNode;
                if (path.Nodes[outNodeIndex] is null)
                {
                    GeoxPathNode node = new GameObject($"GeoxPathNode{outNodeIndex:D4}").AddComponent<GeoxPathNode>();
                    node.SetOwner(path);

                    reader.Seek(header.Position + header.VertexBufferOffset + (16 * outNodeIndex));
                    node.Position = reader.ReadPositionF();
                    node.transform.position = node.Position;

                    TagUtils.AddEnumTags<GeoxPathNode.Tags>(node.NodeTags, reader.ReadUInt32());

                    path.Nodes[outNodeIndex] = node;
                    outNode = node;
                }
                else
                {
                    outNode = path.Nodes[outNodeIndex];
                }
                edge.NextNode = outNode;
                outNode.Outlinks.Add(edge);

                path.Edges[i] = edge;
            }

            return path;
        }
    }
}
