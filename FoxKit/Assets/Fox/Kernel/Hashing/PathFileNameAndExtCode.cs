using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
    public struct PathFileNameAndExtCode : IEquatable<ulong>
    {
        [SerializeField]
        private ulong _hash;

        internal ulong Backing => _hash;

        public String Extension => GetExtension();

        public PathFileNameAndExtCode(string str)
        {
            _hash = Hashing.PathFileNameAndExtCode(str);
        }

        internal PathFileNameAndExtCode(ulong hash)
        {
            _hash = hash;
        }

        // Kernel.StrCode
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
            new String("1.ftexs"),
            new String("1.nav2"),
            new String("2.ftexs"),
            new String("3.ftexs"),
            new String("4.ftexs"),
            new String("5.ftexs"),
            new String("6.ftexs"),
            new String("ag.evf"),
            new String("aia"),
            new String("aib"),
            new String("aibc"),
            new String("aig"),
            new String("aigc"),
            new String("aim"),
            new String("aip"),
            new String("ait"),
            new String("atsh"),
            new String("bnd"),
            new String("bnk"),
            new String("cc.evf"),
            new String("clo"),
            new String("csnav"),
            new String("dat"),
            new String("des"),
            new String("dnav"),
            new String("dnav2"),
            new String("eng.lng"),
            new String("ese"),
            new String("evb"),
            new String("evf"),
            new String("fag"),
            new String("fage"),
            new String("fago"),
            new String("fagp"),
            new String("fagx"),
            new String("fclo"),
            new String("fcnp"),
            new String("fcnpx"),
            new String("fdes"),
            new String("fdmg"),
            new String("ffnt"),
            new String("fmdl"),
            new String("fmdlb"),
            new String("fmtt"),
            new String("fnt"),
            new String("fova"),
            new String("fox"),
            new String("fox2"),
            new String("fpk"),
            new String("fpkd"),
            new String("fpkl"),
            new String("frdv"),
            new String("fre.lng"),
            new String("frig"),
            new String("frt"),
            new String("fsd"),
            new String("fsm"),
            new String("fsml"),
            new String("fsop"),
            new String("fstb"),
            new String("ftex"),
            new String("fv2"),
            new String("fx.evf"),
            new String("fxp"),
            new String("gani"),
            new String("geom"),
            new String("ger.lng"),
            new String("gpfp"),
            new String("grxla"),
            new String("grxoc"),
            new String("gskl"),
            new String("htre"),
            new String("info"),
            new String("ita.lng"),
            new String("jpn.lng"),
            new String("json"),
            new String("lad"),
            new String("ladb"),
            new String("lani"),
            new String("las"),
            new String("lba"),
            new String("lng"),
            new String("lpsh"),
            new String("lua"),
            new String("mas"),
            new String("mbl"),
            new String("mog"),
            new String("mtar"),
            new String("mtl"),
            new String("nav2"),
            new String("nta"),
            new String("obr"),
            new String("obrb"),
            new String("param"),
            new String("parts"),
            new String("path"),
            new String("pftxs"),
            new String("ph"),
            new String("phep"),
            new String("phsd"),
            new String("por.lng"),
            new String("qar"),
            new String("rbs"),
            new String("rdb"),
            new String("rdf"),
            new String("rnav"),
            new String("rus.lng"),
            new String("sad"),
            new String("sand"),
            new String("sani"),
            new String("sbp"),
            new String("sd.evf"),
            new String("sdf"),
            new String("sim"),
            new String("simep"),
            new String("snav"),
            new String("spa.lng"),
            new String("spch"),
            new String("sub"),
            new String("subp"),
            new String("tgt"),
            new String("tre2"),
            new String("txt"),
            new String("uia"),
            new String("uif"),
            new String("uig"),
            new String("uigb"),
            new String("uil"),
            new String("uilb"),
            new String("utxl"),
            new String("veh"),
            new String("vfx"),
            new String("vfxbin"),
            new String("vfxdb"),
            new String("vnav"),
            new String("vo.evf"),
            new String("vpc"),
            new String("wem"),
            new String("wmv"),
            new String("xml")
        };

        private static readonly Dictionary<ulong, String> ExtensionDictionary = FileExtensions.ToDictionary(ext => Hashing.PathFileNameCode(ext.CString) & 0x1FFF);

        private String GetExtension()
        {
            _ = (ushort)((_hash >> 51) & 0x1FFF);

            _ = ExtensionDictionary.TryGetValue(_hash, out String result);

            return result;
        }
    }
}