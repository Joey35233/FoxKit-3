using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct PathFileNameAndExtCode : IEquatable<ulong>
    {
        [FormerlySerializedAs("hash")]
        [SerializeField]
        [FieldOffset(0)] private ulong _hash;
        public PathFileNameAndExtCode(string str)
        {
            _hash = Hashing.PathFileNameAndExtCode(str);
        }

        internal PathFileNameAndExtCode(ulong hash)
        {
            _hash = hash;
        }

        public bool IsValid() => _hash != 0;

        internal ulong Backing => _hash;
        
        public String Extension => GetExtension();

        // Fox.PathFileNameAndExtCode
        public static bool operator ==(PathFileNameAndExtCode a, PathFileNameAndExtCode b) => a._hash == b._hash;

        public static bool operator !=(PathFileNameAndExtCode a, PathFileNameAndExtCode b) => !(a == b);

        // System.UInt64 comparisons
        public static bool operator ==(PathFileNameAndExtCode a, ulong b) => a._hash == b;

        public static bool operator !=(PathFileNameAndExtCode a, ulong b) => !(a == b);

        // Generic overrides
        public override bool Equals(object obj) => obj is PathFileNameAndExtCode rhs && this == rhs;

        public override int GetHashCode() => unchecked((int)_hash);

        public bool Equals(ulong other) => _hash.Equals(other);

        // Bitwise operators
        public static ulong operator &(PathFileNameAndExtCode a, ulong b) => a._hash & b;
        public static uint operator &(PathFileNameAndExtCode a, uint b) => (uint)(a._hash & b);

        public override string ToString() => $"0x{_hash:x16}";

        private static readonly List<String> FileExtensions = new()
        {
            "1.ftexs",
            "1.nav2",
            "2.ftexs",
            "3.ftexs",
            "4.ftexs",
            "5.ftexs",
            "6.ftexs",
            "ag.evf",
            "aia",
            "aib",
            "aibc",
            "aig",
            "aigc",
            "aim",
            "aip",
            "ait",
            "atsh",
            "bnd",
            "bnk",
            "cc.evf",
            "clo",
            "csnav",
            "dat",
            "des",
            "dnav",
            "dnav2",
            "eng.lng",
            "ese",
            "evb",
            "evf",
            "fag",
            "fage",
            "fago",
            "fagp",
            "fagx",
            "fclo",
            "fcnp",
            "fcnpx",
            "fdes",
            "fdmg",
            "ffnt",
            "fmdl",
            "fmdlb",
            "fmtt",
            "fnt",
            "fova",
            "fox",
            "fox2",
            "fpk",
            "fpkd",
            "fpkl",
            "frdv",
            "fre.lng",
            "frig",
            "frt",
            "fsd",
            "fsm",
            "fsml",
            "fsop",
            "fstb",
            "ftex",
            "fv2",
            "fx.evf",
            "fxp",
            "gani",
            "geom",
            "ger.lng",
            "gpfp",
            "grxla",
            "grxoc",
            "gskl",
            "htre",
            "info",
            "ita.lng",
            "jpn.lng",
            "json",
            "lad",
            "ladb",
            "lani",
            "las",
            "lba",
            "lng",
            "lpsh",
            "lua",
            "mas",
            "mbl",
            "mog",
            "mtar",
            "mtl",
            "nav2",
            "nta",
            "obr",
            "obrb",
            "param",
            "parts",
            "path",
            "pftxs",
            "ph",
            "phep",
            "phsd",
            "por.lng",
            "qar",
            "rbs",
            "rdb",
            "rdf",
            "rnav",
            "rus.lng",
            "sad",
            "sand",
            "sani",
            "sbp",
            "sd.evf",
            "sdf",
            "sim",
            "simep",
            "snav",
            "spa.lng",
            "spch",
            "sub",
            "subp",
            "tgt",
            "tre2",
            "txt",
            "uia",
            "uif",
            "uig",
            "uigb",
            "uil",
            "uilb",
            "utxl",
            "veh",
            "vfx",
            "vfxbin",
            "vfxdb",
            "vnav",
            "vo.evf",
            "vpc",
            "wem",
            "wmv",
            "xml",
        };

        private static readonly Dictionary<ulong, string> ExtensionDictionary = FileExtensions.ToDictionary(ext => Hashing.PathFileNameCode(ext) & 0x1FFF);

        private string GetExtension()
        {
            _ = (ushort)((_hash >> 51) & 0x1FFF);

            _ = ExtensionDictionary.TryGetValue(_hash, out string result);

            return result;
        }
    }
}