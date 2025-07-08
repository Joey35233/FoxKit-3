using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Fox.Geox
{
    public partial class GeoxPath : Fox.Graphx.GraphxPathData
    {
        public override Type GetNodeType() => typeof(GeoxPathNode);
        public override Type GetEdgeType() => typeof(GeoxPathEdge);
        public override bool IsLoop() => false;
    }
}