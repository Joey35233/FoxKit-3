using Fox.Core;
using System;
using System.ComponentModel;

namespace Fox.Geo
{
    [Flags]
    public enum GeoTriggerTrap_Tags : ulong
    {
        [Description("Intrude")]
        Intrude = 0x1,
        [Description("Tower")]
        Tower = 0x2,
        [Description("InRoom")]
        InRoom = 0x4,
        [Description("FallDeath")]
        FallDeath = 0x8,

        [Description("NearCamera1")]
        NearCamera1 = 0x10,
        [Description("NearCamera2")]
        NearCamera2 = 0x20,
        [Description("NearCamera3")]
        NearCamera3 = 0x40,
        [Description("NearCamera4")]
        NearCamera4 = 0x80,

        [Description("NoCliff")]
        NoCliff = 0x100,
        [Description("NoRainEffect")]
        NoRainEffect = 0x200,
        [Description("0x60e79a58dcc3")]
        _60e79a58dcc3 = 0x400,
        [Description("GimmickNoFulton")]
        GimmickNoFulton = 0x800,

        [Description("innerZone")]
        innerZone = 0x1000,
        [Description("outerZone")]
        outerZone = 0x2000,
        [Description("hotZone")]
        hotZone = 0x4000,
        [Description("0x439898dcbf83")]
        _439898dcbf83 = 0x8000,

        [Description("0xe780e431a068")]
        _e780e431a068 = 0x10000,
        [Description("0x53827eed3fbc")]
        _53827eed3fbc = 0x20000,
        [Description("0x7e1121c5cb93")]
        _7e1121c5cb93 = 0x40000,
        [Description("0xcadd57b76a83")]
        _cadd57b76a83 = 0x80000,

        [Description("0xe689072c4df8")]
        _e689072c4df8 = 0x100000,
        [Description("0x6d14396ebbe5")] // from 2020 caplag: "mgo/cuba underground, and also watchtower south of helipad" + "Doors? Something with doors? 2 x 2 x 25"
        _6d14396ebbe5 = 0x200000,
        [Description("NoStepOn")]
        NoStepOn = 0x400000,
        [Description("HalationEffect")]
        HalationEffect = 0x800000,

        [Description("Unnamed1")]
        Unnamed1 = 0x1000000,
        [Description("Unnamed2")]
        Unnamed2 = 0x2000000,

        [Description("0xd6ee65d20b7a")]
        _d6ee65d20b7a = 0x10000000,
        [Description("0xf287ba9cb7e3")]
        _f287ba9cb7e3 = 0x20000000,
        [Description("NoFulton")]
        NoFulton = 0x40000000,
        [Description("Waterfall")]
        Waterfall = 0x80000000, // 0x80000000 for convenience in 010 but the tag is actually 0xffffffff80000000, signalling that there are no higher-value tags
    };

    public enum GeoTriggerTrap_ShapeType : byte
    {
        Box = 2,
        Path = 3
    }

    public partial class GeoTriggerTrap : Fox.Core.TransformData
    {
        protected partial bool Get_enable() => (stateFlag & 1) == 1 ? true : false;
        protected partial void Set_enable(bool value) { stateFlag = value ? 1u : 0u; }
    }
}