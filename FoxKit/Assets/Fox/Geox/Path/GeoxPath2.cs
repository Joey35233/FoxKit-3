using Fox.Core;
using Fox.Fio;
using Fox.Geo;
using Fox.Graphx;
using Fox.Kernel;
using System;
using System.ComponentModel;
using UnityEngine;
using String = Fox.Kernel.String;

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
        };

        public static GeoxPath2 Deserialize(GeomHeaderContext header)
        {
            FileStreamReader reader = header.Reader;

            Debug.Assert(header.Type == GeoPrimType.Path);

            GeoxPath2 path = new GameObject().AddComponent<GeoxPath2>();
            path.enable = true;

            TransformEntity transformEntity = new GameObject().AddComponent<TransformEntity>();
            path.SetTransform(transformEntity);
            //transformEntity.gameObject.name = $"{header.Name.ToString()}|{transformEntity.GetType().Name}";

            path.tags = TagUtils.GetEnumTags<Tags>((ulong)header.GetTags<Tags>());

            // Working off the assumption that the indices are for the vertices and the edges are implicitly linked
            path.nodes = new DynamicArray<EntityPtr<GraphxSpatialGraphDataNode>>(header.PrimCount + 1);
            for (int i = 0; i < path.nodes.Capacity; i++)
                path.nodes.Add(default);
            path.edges = new DynamicArray<EntityPtr<GraphxSpatialGraphDataEdge>>(header.PrimCount);
            for (int i = 0; i < path.edges.Capacity; i++)
                path.edges.Add(default);

            for (int i = 0; i < header.PrimCount; i++)
            {
                reader.Seek(header.GetDataPosition() + (8 * i));

                GeoxPathEdge edge = new GameObject().AddComponent<GeoxPathEdge>();
                edge.SetOwner(path);
                //edge.gameObject.name = $"{header.Name.ToString()}|{edge.GetType().Name}{i:0000}";

                var geoEdgeTags = (GeoxPathEdge.Tags)reader.ReadUInt32();
                foreach (GeoxPathEdge.Tags tag in Enum.GetValues(geoEdgeTags.GetType()))
                {
                    if (geoEdgeTags.HasFlag(tag))
                        edge.edgeTags.Add(new String(tag.ToString()));
                }

                ushort inNodeIndex = reader.ReadUInt16();
                ushort outNodeIndex = reader.ReadUInt16();
                GraphxSpatialGraphDataNode inNode;
                if (path.nodes[inNodeIndex].IsNull())
                {
                    GeoxPathNode node = new GameObject().AddComponent<GeoxPathNode>();
                    node.SetOwner(path);

                    reader.Seek(header.Position + header.VertexBufferOffset + (16 * inNodeIndex));
                    node.position = reader.ReadPositionF();

                    node.nodeTags = TagUtils.GetEnumTags<GeoxPathNode.Tags>(reader.ReadUInt32());

                    path.nodes[inNodeIndex] = new EntityPtr<GraphxSpatialGraphDataNode>(node);
                    inNode = node;

                    //node.gameObject.name = $"{header.Name.ToString()}|{node.GetType().Name}";
                }
                else
                {
                    inNode = path.nodes[inNodeIndex].Get();
                }
                edge.prevNode = EntityHandle.Get(inNode);
                inNode.outlinks.Add(EntityHandle.Get(edge));

                GraphxSpatialGraphDataNode outNode;
                if (path.nodes[outNodeIndex].IsNull())
                {
                    GeoxPathNode node = new GameObject().AddComponent<GeoxPathNode>();
                    node.SetOwner(path);

                    reader.Seek(header.Position + header.VertexBufferOffset + (16 * outNodeIndex));
                    node.position = reader.ReadPositionF();

                    node.nodeTags = TagUtils.GetEnumTags<GeoxPathNode.Tags>(reader.ReadUInt32());

                    path.nodes[outNodeIndex] = new EntityPtr<GraphxSpatialGraphDataNode>(node);
                    outNode = node;

                    //node.gameObject.name = $"{header.Name.ToString()}|{node.GetType().Name}";
                }
                else
                {
                    outNode = path.nodes[outNodeIndex].Get();
                }
                edge.nextNode = EntityHandle.Get(outNode);
                outNode.inlinks.Add(EntityHandle.Get(edge));

                path.edges[i] = new EntityPtr<GraphxSpatialGraphDataEdge>(edge);
            }

            return path;
        }
    }
}
