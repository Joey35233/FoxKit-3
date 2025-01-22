using Fox.Core.Utils;
using Fox;
using System.ComponentModel;
using UnityEngine;
using CsSystem = System;
using UnityEditor;
using Fox.Core;

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

        private void DrawDefault(bool isSelected)
        {
            Color colorOuterEdge = isSelected ? Color.white : new Color(0, 1, 0, 1);
            Color colorOuterSide = isSelected ? new Color(0, 1, 0, 0.5f) : new Color(0, 1, 0, 0.05f);
            Color colorInnerEdge = isSelected ? Color.white : new Color(1, 1, 0, 1);
            Color colorInnerFace = isSelected ? new Color(1, 1, 0, 0.75f) : new Color(1, 1, 0, 0.1f);

            //Draw outer box face
            Gizmos.color = colorOuterEdge;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);

            //Draw outer box edge
            Gizmos.color = colorOuterSide;
            Gizmos.DrawCube(Vector3.zero, Vector3.one);

            //Draw inner box edge
            Gizmos.color = colorInnerEdge;
            float xOffsetPos = innerScaleXPositive / 4;
            float xOffsetNeg = innerScaleXNegative / 4;
            float yOffsetPos = innerScaleYPositive / 4;
            float yOffsetNeg = innerScaleYNegative / 4;
            float zOffsetPos = innerScaleZPositive / 4;
            float zOffsetNeg = innerScaleZNegative / 4;
            Vector3 innerCenterOffset = new Vector3(
                (xOffsetPos > xOffsetNeg ? xOffsetPos - xOffsetNeg : -(xOffsetNeg - xOffsetPos)),
                (yOffsetPos > yOffsetNeg ? yOffsetPos - yOffsetNeg : -(yOffsetNeg - yOffsetPos)),
                (zOffsetPos > zOffsetNeg ? zOffsetPos - zOffsetNeg : -(zOffsetNeg - zOffsetPos))
            );
            Gizmos.DrawWireCube(
                innerCenterOffset,
                new Vector3(
                    (innerScaleXPositive + innerScaleXNegative) / 2,
                    (innerScaleYPositive + innerScaleYNegative) / 2,
                    (innerScaleZPositive + innerScaleZNegative) / 2
                )
            );

            //Draw inner box face
            Gizmos.color = colorInnerFace;
            Gizmos.DrawCube(
                innerCenterOffset,
                new Vector3(
                    (innerScaleXPositive + innerScaleXNegative) / 2,
                    (innerScaleYPositive + innerScaleYNegative) / 2,
                    (innerScaleZPositive + innerScaleZNegative) / 2
                )
            );

            //Draw tesseract connection to scale
            Gizmos.color = colorInnerEdge;
            Vector3 xPositive = new Vector3(innerScaleXPositive / 2, 0, 0);
            Vector3 yPositive = new Vector3(0, innerScaleYPositive / 2, 0);
            Vector3 zPositive = new Vector3(0, 0, innerScaleZPositive / 2);
            Vector3 xNegative = new Vector3(-(innerScaleXNegative / 2), 0, 0);
            Vector3 yNegative = new Vector3(0, -(innerScaleYNegative / 2), 0);
            Vector3 zNegative = new Vector3(0, 0, -(innerScaleZNegative / 2));
            Vector3 xPositive_yPositive_zPositive = xPositive + yPositive + zPositive;
            Vector3 xPositive_yNegative_zPositive = xPositive + yNegative + zPositive;
            Vector3 xPositive_yPositive_zNegative = xPositive + yPositive + zNegative;
            Vector3 xPositive_yNegative_zNegative = xPositive + yNegative + zNegative;
            Vector3 xNegative_yNegative_zNegative = xNegative + yNegative + zNegative;
            Vector3 xNegative_yNegative_zPositive = xNegative + yNegative + zPositive;
            Vector3 xNegative_yPositive_zPositive = xNegative + yPositive + zPositive;
            Vector3 xNegative_yPositive_zNegative = xNegative + yPositive + zNegative;
            Vector3 xPositiveOuter = new Vector3(0.5f, 0, 0);
            Vector3 yPositiveOuter = new Vector3(0, 0.5f, 0);
            Vector3 zPositiveOuter = new Vector3(0, 0, 0.5f);
            Vector3 xNegativeOuter = new Vector3(-0.5f, 0, 0);
            Vector3 yNegativeOuter = new Vector3(0, -0.5f, 0);
            Vector3 zNegativeOuter = new Vector3(0, 0, -0.5f);
            Vector3 xPositive_yPositive_zPositiveOuter = xPositiveOuter + yPositiveOuter + zPositiveOuter;
            Vector3 xPositive_yNegative_zPositiveOuter = xPositiveOuter + yNegativeOuter + zPositiveOuter;
            Vector3 xPositive_yPositive_zNegativeOuter = xPositiveOuter + yPositiveOuter + zNegativeOuter;
            Vector3 xPositive_yNegative_zNegativeOuter = xPositiveOuter + yNegativeOuter + zNegativeOuter;
            Vector3 xNegative_yNegative_zNegativeOuter = xNegativeOuter + yNegativeOuter + zNegativeOuter;
            Vector3 xNegative_yNegative_zPositiveOuter = xNegativeOuter + yNegativeOuter + zPositiveOuter;
            Vector3 xNegative_yPositive_zPositiveOuter = xNegativeOuter + yPositiveOuter + zPositiveOuter;
            Vector3 xNegative_yPositive_zNegativeOuter = xNegativeOuter + yPositiveOuter + zNegativeOuter;
            Gizmos.DrawLine(xNegative_yPositive_zNegative, xNegative_yPositive_zNegativeOuter);
            Gizmos.DrawLine(xPositive_yPositive_zNegative, xPositive_yPositive_zNegativeOuter);
            Gizmos.DrawLine(xPositive_yPositive_zPositive, xPositive_yPositive_zPositiveOuter);
            Gizmos.DrawLine(xNegative_yPositive_zPositive, xNegative_yPositive_zPositiveOuter);
            Gizmos.DrawLine(xNegative_yNegative_zNegative, xNegative_yNegative_zNegativeOuter);
            Gizmos.DrawLine(xPositive_yNegative_zNegative, xPositive_yNegative_zNegativeOuter);
            Gizmos.DrawLine(xPositive_yNegative_zPositive, xPositive_yNegative_zPositiveOuter);
            Gizmos.DrawLine(xNegative_yNegative_zPositive, xNegative_yNegative_zPositiveOuter);
        }
        private void DrawTriangularPrism(bool isSelected)
        {
            //TODO
        }
        private void DrawSemiCylinder(bool isSelected)
        {
            //TODO
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
