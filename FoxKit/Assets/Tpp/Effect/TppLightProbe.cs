using Fox.Core.Utils;
using Fox;
using System.ComponentModel;
using UnityEngine;
using CsSystem = System;

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

        private void DrawGizmos(bool isSelected)
        {
            Gizmos.matrix = this.transform.localToWorldMatrix;

            Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
