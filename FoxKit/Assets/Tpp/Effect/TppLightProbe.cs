using Fox.Core.Utils;
using Fox;
using System.ComponentModel;
using UnityEngine;
using CsSystem = System;
using UnityEditor;
using Fox.Core;
using System.Collections.Generic;
using System;

namespace Tpp.Effect
{
    public partial class TppLightProbe : Fox.Core.TransformData
    {
        public enum TppLightProbe_DebugMode : int
        {
            [Description("DEBUG_OFF")]
            DEBUG_OFF = 0,
            [Description("DEBUG_CUBEMAP")]
            DEBUG_CUBEMAP = 1,
            [Description("DEBUG_SH_VALUE")]
            DEBUG_SH_VALUE = 2,
            [Description("DEBUG_SH_OCCLUSION")]
            DEBUG_SH_OCCLUSION = 3,
            [Description("DEBUG_SH_WITH_SKY")]
            DEBUG_SH_WITH_SKY = 4,
            [Description("DEBUG_SH_ONLY_COL")]
            DEBUG_SH_ONLY_COL = 5,
            [Description("DEBUG_SH_ONLY_SUB_COL")]
            DEBUG_SH_ONLY_SUB_COL = 6,
            [Description("DEBUG_SH_ONLY_LIGHT_ALL")]
            DEBUG_SH_ONLY_LIGHT_ALL = 7,
        }


        public enum TppLightProbe_DrawRejectionLevel : int
        {
            [Description("LEVEL0(size:0.5m)")]
            LEVEL0 = 0,
            [Description("LEVEL1(size:1m)")]
            LEVEL1 = 1,
            [Description("LEVEL2(size:2m)")]
            LEVEL2 = 2,
            [Description("LEVEL3(size:4m)")]
            LEVEL3 = 3,
            [Description("LEVEL4(size:8m)")]
            LEVEL4 = 4,
            [Description("LEVEL5(size:16m)")]
            LEVEL5 = 5,
            [Description("LEVEL6(size:32m)")]
            LEVEL6 = 6,
            [Description("NO_REJECT")]
            NO_REJECT = 7,
        }


        public enum TppLightProbe_PackingGeneration : int
        {
            [Description("GENERATION_ALL")]
            GENERATION_ALL = 0,
            [Description("GENERATION_7")]
            GENERATION_7 = 1,
            [Description("GENERATION_8")]
            GENERATION_8 = 2,
        }


        public enum TppLightProbe_ShapeType : int
        {
            [Description("DEFAULT")]
            DEFAULT = 0,
            [Description("TRIALGULAR_PRISM")]
            TRIALGULAR_PRISM = 1,
            [Description("SEMI_CYLINDRICAL")]
            SEMI_CYLINDRICAL = 2,
            [Description("HALF_SQUARE")]
            HALF_SQUARE = 2,
        }

        private partial bool Get_enable24hSH() => FlagUtils.GetFlag(localFlags, 0);
        private partial void Set_enable24hSH(bool value) => localFlags = FlagUtils.SetFlag(localFlags, 0, value);

        private partial bool Get_enableWeatherSH() => FlagUtils.GetFlag(localFlags, 1);
        private partial void Set_enableWeatherSH(bool value) => localFlags = FlagUtils.SetFlag(localFlags, 1, value);

        private partial bool Get_enableRelatedLightSH() => FlagUtils.GetFlag(localFlags, 2);
        private partial void Set_enableRelatedLightSH(bool value) => localFlags = FlagUtils.SetFlag(localFlags, 2, value);

        private partial bool Get_enableOcclusionMode() => FlagUtils.GetFlag(localFlags, 3);
        private partial void Set_enableOcclusionMode(bool value) => localFlags = FlagUtils.SetFlag(localFlags, 3, value);

        private partial TppLightProbe_PackingGeneration Get_packingGeneration() => throw new CsSystem.NotImplementedException();
        private partial void Set_packingGeneration(TppLightProbe_PackingGeneration value) => throw new CsSystem.NotImplementedException();

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            float _xNegative = innerScaleXNegative;
            float _xPositive = innerScaleXPositive;
            innerScaleXNegative = _xPositive;
            innerScaleXPositive = _xNegative;
        }
        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            float _xNegative = innerScaleXNegative;
            float _xPositive = innerScaleXPositive;
            context.OverrideProperty(nameof(innerScaleXNegative), _xPositive);
            context.OverrideProperty(nameof(innerScaleXPositive), _xNegative);
        }
        public override void Reset()
        {
            base.Reset();
            enable = true;
            innerScaleXNegative = 1;
            innerScaleXPositive = 1;
            innerScaleYNegative = 1;
            innerScaleYPositive = 1;
            innerScaleZNegative = 1;
            innerScaleZPositive = 1;
            drawRejectionLevel = TppLightProbe_DrawRejectionLevel.NO_REJECT;
        }
        private Vector3 GetInnerShapeCenter()
        {
            float xOffsetPos = innerScaleXPositive / 4;
            float xOffsetNeg = innerScaleXNegative / 4;
            float yOffsetPos = innerScaleYPositive / 4;
            float yOffsetNeg = innerScaleYNegative / 4;
            float zOffsetPos = innerScaleZPositive / 4;
            float zOffsetNeg = innerScaleZNegative / 4;
            return new(
                (xOffsetPos > xOffsetNeg ? xOffsetPos - xOffsetNeg : -(xOffsetNeg - xOffsetPos)),
                (yOffsetPos > yOffsetNeg ? yOffsetPos - yOffsetNeg : -(yOffsetNeg - yOffsetPos)),
                (zOffsetPos > zOffsetNeg ? zOffsetPos - zOffsetNeg : -(zOffsetNeg - zOffsetPos))
            );
        }
        private Vector3 GetInnerShapeScale()
        {
            return new(
                (innerScaleXPositive + innerScaleXNegative) / 2,
                (innerScaleYPositive + innerScaleYNegative) / 2,
                (innerScaleZPositive + innerScaleZNegative) / 2
            );
        }
        private Vector3[] GetCubeInnerVertices()
        {
            return new Vector3[8]{
                new(innerScaleXPositive / 2, innerScaleYPositive / 2, innerScaleZPositive / 2),
                new(innerScaleXPositive / 2, -innerScaleYNegative / 2, innerScaleZPositive / 2),
                new(innerScaleXPositive / 2, innerScaleYPositive / 2, -innerScaleZNegative / 2),
                new(innerScaleXPositive / 2, -innerScaleYNegative / 2, -innerScaleZNegative / 2),
                new(-innerScaleXNegative / 2, -innerScaleYNegative / 2, -innerScaleZNegative / 2),
                new(-innerScaleXNegative / 2, -innerScaleYNegative / 2, innerScaleZPositive / 2),
                new(-innerScaleXNegative / 2, innerScaleYPositive / 2, innerScaleZPositive / 2),
                new(-innerScaleXNegative / 2, innerScaleYPositive / 2, -innerScaleZNegative / 2)
            };
        }
        private static Vector3[] CubeOuterVertices = new Vector3[8]{
                new(0.5f, 0.5f, 0.5f),
                new(0.5f, -0.5f, 0.5f),
                new(0.5f, 0.5f, -0.5f),
                new(0.5f, -0.5f, -0.5f),
                new(-0.5f, -0.5f, -0.5f),
                new(-0.5f, -0.5f, 0.5f),
                new(-0.5f, 0.5f, 0.5f),
                new(-0.5f, 0.5f, -0.5f)
        };
        private void DrawDefault(bool isSelected)
        {
            Color colorOuterEdge = isSelected ? Color.white : new Color(0, 1, 0, 1);
            Color colorOuterSide = isSelected ? new Color(0, 1, 0, 0.5f) : new Color(0, 1, 0, 0.05f);
            Color colorInnerEdge = isSelected ? Color.white : new Color(1, 1, 0, 1);
            Color colorInnerFace = isSelected ? new Color(1, 1, 0, 0.75f) : new Color(1, 1, 0, 0.1f);

            Vector3 innerOffset = GetInnerShapeCenter();
            Vector3 innerScale = GetInnerShapeScale();

            //Draw outer box edge
            Gizmos.color = colorOuterEdge;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            //Draw outer box face
            Gizmos.color = colorOuterSide;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);

            //Draw inner box edge
            Gizmos.color = colorInnerEdge;
            Gizmos.DrawWireCube(innerOffset,innerScale);

            //Draw inner box face
            Gizmos.color = colorInnerFace;
            Gizmos.DrawCube(innerOffset,innerScale);

            //Draw tesseract connection to scale
            Gizmos.color = colorInnerEdge;
            Vector3[] innerVerties = GetCubeInnerVertices();
            for (int i = 0; i<8;i++)
                Gizmos.DrawLine(innerVerties[i], CubeOuterVertices[i]);
        }
        private Vector3 OffsetScaleVertex(Vector3 vertex, Vector3 offset, Vector3 scale)
        {
            return new Vector3()
            {
                x = offset.x + (vertex.x * scale.x),
                y = offset.y + (vertex.y * scale.y),
                z = offset.z + (vertex.z * scale.z),
            };
        }
        private readonly static Vector3[] TriangularPrismVertices = new Vector3[6]{
                new(0.5f, -0.5f, -0.5f),
                new(0.5f, -0.5f, 0.5f),
                new(-0.5f, -0.5f, 0.5f),
                new(-0.5f, -0.5f, -0.5f),

                new(0.5f, 0.5f, 0),
                new(-0.5f, 0.5f, 0)
        };
        private void DrawTriangularPrismEdges(Vector3 offset, Vector3 scale)
        {
            Vector3[] vertices = new Vector3[TriangularPrismVertices.Length];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = OffsetScaleVertex(TriangularPrismVertices[i], offset, scale);

            Gizmos.DrawLine(vertices[0], vertices[1]);
            Gizmos.DrawLine(vertices[1], vertices[2]);
            Gizmos.DrawLine(vertices[2], vertices[3]);
            Gizmos.DrawLine(vertices[3], vertices[0]);

            Gizmos.DrawLine(vertices[4], vertices[0]);
            Gizmos.DrawLine(vertices[4], vertices[1]);

            Gizmos.DrawLine(vertices[4], vertices[5]);

            Gizmos.DrawLine(vertices[5], vertices[2]);
            Gizmos.DrawLine(vertices[5], vertices[3]);
        }
        private void DrawTriangularPrism(bool isSelected)
        {
            Color colorOuterEdge = isSelected ? Color.white : new Color(0, 1, 0, 1);
            Color colorOuterSide = isSelected ? new Color(0, 1, 0, 0.5f) : new Color(0, 1, 0, 0.05f);
            Color colorInnerEdge = isSelected ? Color.white : new Color(1, 1, 0, 1);
            Color colorInnerFace = isSelected ? new Color(1, 1, 0, 0.75f) : new Color(1, 1, 0, 0.1f);

            Gizmos.matrix = gameObject.transform.localToWorldMatrix;
            Mesh TriangularPrism = new()
            {
                vertices = TriangularPrismVertices,
                triangles = new int[]
                {
                    0,1,2,
                    2,3,0,

                    5,3,2,
                    0,4,1,

                    0,3,4,
                    5,4,3,

                    2,1,5,
                    1,4,5,
                },
                normals = new Vector3[]
                {
                    new(0.49f, -0.735f, -0.49f),
                    new(0.45f, 0, 0.89f),
                    new(-0.49f, -0.73f, 0.49f),
                    new(-0.45f,0, -0.89f),
                    new(0.49f, 0.73f, -0.49f),
                    new(-0.49f, 0.73f, 0.49f),
                }
            };

            // outer edges
            Gizmos.color = colorOuterEdge;
            Gizmos.DrawWireMesh(TriangularPrism,Vector3.zero,Quaternion.identity,Vector3.one);

            // outer faces
            Gizmos.color = colorOuterSide;
            Gizmos.DrawMesh(TriangularPrism, Vector3.zero, Quaternion.identity, Vector3.one);

            // inner edges
            Gizmos.color = colorInnerEdge;
            Vector3 innerOffset = GetInnerShapeCenter();
            Vector3 innerScale = GetInnerShapeScale();
            Gizmos.DrawWireMesh(TriangularPrism, innerOffset, Quaternion.identity,innerScale);

            //inner faces
            Gizmos.color = colorInnerFace;
            Gizmos.DrawMesh(TriangularPrism, innerOffset, Quaternion.identity, innerScale);

            // tesseract edges
            Gizmos.color = colorInnerEdge;
            for (int i = 0; i < TriangularPrismVertices.Length; i++)
                Gizmos.DrawLine(TriangularPrismVertices[i], OffsetScaleVertex(TriangularPrismVertices[i], innerOffset, innerScale));
        }
        private readonly static Vector3[] SemiCylinderVertices = new Vector3[14]{
                new(0.5f, -0.5f, -0.5f),
                new(0.5f, -0.5f, 0.5f),
                new(-0.5f, -0.5f, 0.5f),
                new(-0.5f, -0.5f, -0.5f),

                new(0.5f, 0.0f, -0.433f),
                new(0.5f, 0.366f, -0.25f),
                new(0.5f, 0.5f, 0),
                new(0.5f, 0.366f, 0.25f),
                new(0.5f, 0.0f, 0.433f),

                new(-0.5f, 0.0f, 0.433f),
                new(-0.5f, 0.366f, 0.25f),
                new(-0.5f, 0.5f, 0),
                new(-0.5f, 0.366f, -0.25f),
                new(-0.5f, 0.0f, -0.433f),
        };
        private void DrawSemiCylinderEdges(Vector3 offset, Vector3 scale)
        {
            Vector3[] vertices = new Vector3[SemiCylinderVertices.Length];
            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = OffsetScaleVertex(SemiCylinderVertices[i], offset, scale);

            //bottom
            Gizmos.DrawLine(vertices[0], vertices[1]);
            Gizmos.DrawLine(vertices[1], vertices[2]);
            Gizmos.DrawLine(vertices[2], vertices[3]);
            Gizmos.DrawLine(vertices[3], vertices[0]);

            //pos arc
            Gizmos.DrawLine(vertices[0], vertices[4]);
            Gizmos.DrawLine(vertices[4], vertices[5]);
            Gizmos.DrawLine(vertices[5], vertices[6]);
            Gizmos.DrawLine(vertices[6], vertices[7]);
            Gizmos.DrawLine(vertices[7], vertices[8]);
            Gizmos.DrawLine(vertices[8], vertices[1]);

            //roof
            Gizmos.DrawLine(vertices[4], vertices[13]);
            Gizmos.DrawLine(vertices[5], vertices[12]);
            Gizmos.DrawLine(vertices[6], vertices[11]);
            Gizmos.DrawLine(vertices[7], vertices[10]);
            Gizmos.DrawLine(vertices[8], vertices[9]);

            //neg arc
            Gizmos.DrawLine(vertices[2], vertices[9]);
            Gizmos.DrawLine(vertices[9], vertices[10]);
            Gizmos.DrawLine(vertices[10], vertices[11]);
            Gizmos.DrawLine(vertices[11], vertices[12]);
            Gizmos.DrawLine(vertices[12], vertices[13]);
            Gizmos.DrawLine(vertices[13], vertices[3]);
        }
        private void DrawSemiCylinder(bool isSelected)
        {
            Color colorOuterEdge = isSelected ? Color.white : new Color(0, 1, 0, 1);
            Color colorOuterSide = isSelected ? new Color(0, 1, 0, 0.5f) : new Color(0, 1, 0, 0.05f);
            Color colorInnerEdge = isSelected ? Color.white : new Color(1, 1, 0, 1);
            Color colorInnerFace = isSelected ? new Color(1, 1, 0, 0.75f) : new Color(1, 1, 0, 0.1f);

            Gizmos.matrix = gameObject.transform.localToWorldMatrix;

            Mesh SemiCylinder = new()
            {
                vertices = SemiCylinderVertices,
                triangles = new int[]
                {
                    //bottom
                    0,1,2,
                    0,2,3,

                    //x pos side
                    4,1,0,
                    1,4,8,
                    4,5,8,
                    5,7,8,
                    5,6,7,

                    //z pos side
                    8,2,1,
                    8,9,2,
                    9,8,7,
                    10,9,7,
                    10,7,6,
                    11,10,6,

                    //x neg side
                    9,3,2,
                    3,9,13,
                    9,10,13,
                    10,12,13,
                    10,11,12,

                    //z neg side
                    0,3,13,
                    13,4,0,
                    13,12,4,
                    12,5,4,
                    12,11,5,
                    11,6,5,
                },
                normals = new Vector3[]
                {
                    new(0.23f, -0.86f, -0.46f), 
                    new(0.66f, -0.66f, 0.35f), 
                    new(-0.23f, -0.86f, 0.46f), 
                    new(-0.66f, -0.66f, -0.35f), 
                    new(0.69f, 0.24f, -0.68f), 
                    new(0.52f, 0.63f, -0.58f), 
                    new(0.09f, 0.98f, 0.18f), 
                    new(0.23f, 0.56f, 0.79f), 
                    new(0.55f, 0.19f, 0.81f), 
                    new(-0.69f, 0.24f, 0.68f), 
                    new(-0.52f, 0.63f, 0.58f), 
                    new(-0.09f, 0.98f, -0.18f), 
                    new(-0.23f, 0.56f, -0.79f), 
                    new(-0.55f, 0.19f, -0.81f),
                }
            };

            // outer edges
            Gizmos.color = colorOuterEdge;
            Gizmos.DrawWireMesh(SemiCylinder, Vector3.zero, Quaternion.identity, Vector3.one);

            // outer faces
            Gizmos.color = colorOuterSide;
            Gizmos.DrawMesh(SemiCylinder,Vector3.zero,Quaternion.identity,Vector3.one);

            // inner edges
            Gizmos.color = colorInnerEdge;
            Vector3 innerOffset = GetInnerShapeCenter();
            Vector3 innerScale = GetInnerShapeScale();
            Gizmos.DrawWireMesh(SemiCylinder, innerOffset, Quaternion.identity, innerScale);

            // inner faces
            Gizmos.color = colorInnerFace;
            Gizmos.DrawMesh(SemiCylinder, innerOffset, Quaternion.identity, innerScale);

            // tesseract edges
            Gizmos.color = colorInnerEdge;
            for (int i = 0; i < SemiCylinderVertices.Length; i++)
                Gizmos.DrawLine(SemiCylinderVertices[i], OffsetScaleVertex(SemiCylinderVertices[i], innerOffset, innerScale));
        }
        private void DrawHalfSquare(bool isSelected)
        {
            //TODO
        }
        private void DrawGizmos(bool isSelected)
        {
            switch (shapeType)
            {
                case TppLightProbe_ShapeType.DEFAULT:
                default:
                    DrawDefault(isSelected);
                    break;
                case TppLightProbe_ShapeType.TRIALGULAR_PRISM:
                    DrawTriangularPrism(isSelected);
                    break;
                case TppLightProbe_ShapeType.SEMI_CYLINDRICAL:
                    DrawSemiCylinder(isSelected);
                    break;
            }
            

            if (!isSelected)
                Handles.Label(transform.position, gameObject.name);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
