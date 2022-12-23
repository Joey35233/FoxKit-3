using System;
using System.ComponentModel;
using UnityEngine;

namespace Fox.Geox
{
    //https://github.com/TinManTex/mgsv-deminified-lua/blob/3b8d6a0487ce45f69502d40e684b3d653d3b8965/data1/Tpp/start.lua#L292
    [Flags]
    public enum GeoxPath2_PATH_TAG : ulong
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
    public partial class GeoxPath2 : Fox.Graphx.GraphxPathData
    {
        public override void InitializeGameObject(GameObject gameObject)
        {
            base.InitializeGameObject(gameObject);
            gameObject.AddComponent<GeoxPath2Gizmo>();
        }
    }
}
