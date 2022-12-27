using System;
using System.ComponentModel;

namespace Fox.Geox
{
    public partial class GeoxPathEdge : Fox.Graphx.GraphxSpatialGraphDataEdge
    {
        [Flags]
        public enum Tags : uint
        {
            [Description("Stand")]
            Stand = 0x1,
            [Description("Squat")]
            Squat = 0x2,
            [Description("BEHIND_LOW")]
            BEHIND_LOW = 0x4,
            [Description("FenceElude")]
            FenceElude = 0x8,

            [Description("Elude")]
            Elude = 0x10,
            [Description("Jump")]
            Jump = 0x20,
            [Description("Fence")]
            Fence = 0x40,
            [Description("StepOn")]
            StepOn = 0x80,

            [Description("Behind")]
            Behind = 0x100,
            [Description("Urgent")]
            Urgent = 0x200,
            [Description("NoEnd")]
            NoEnd = 0x400,
            [Description("NoStart")]
            NoStart = 0x800,

            [Description("FenceJump")]
            FenceJump = 0x1000,
            [Description("Wall")]
            Wall = 0x2000,
            [Description("NoWall")]
            NoWall = 0x4000,
            [Description("ToIdle")]
            ToIdle = 0x8000,

            [Description("EnableFall")]
            EnableFall = 0x10000,
            [Description("NoFreeFall")]
            NoFreeFall = 0x20000,
            [Description("Fulton")]
            Fulton = 0x40000,
            [Description("BEHIND_SNAP")]
            BEHIND_SNAP = 0x80000,

            [Description("LineCheck")]
            LineCheck = 0x100000,
            [Description("FallNear")]
            FallNear = 0x200000,
            [Description("FenceToStepOn")]
            FenceToStepOn = 0x400000,
            [Description("ForceFallCatch")]
            ForceFallCatch = 0x800000,

            [Description("Window")]
            Window = 0x1000000,
            [Description("AimIsBack")]
            AimIsBack = 0x2000000,
        };
    }
}
