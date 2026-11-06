using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Geo
{
    public class GeoModule : Module
    {
        public static GeoModule Instance { get; private set; }

        // GEOM
        internal static Dictionary<GeoPrimType, Func<GeomHeaderContext, TransformData>> GeoPrimDeserializationMap = new();

        // RAIL
        public static readonly string[] RailNoteNames = new string[15];

        public static readonly StringId32Map RailIdMap = new StringId32Map();

        public GeoModule() : base("Fox.Geo")
        {
            Instance = this;

            RegisterRailNote(0, "junction");
        }

        public static void RegisterGeomHeaderDeserializationCallback(GeoPrimType type, Func<GeomHeaderContext, TransformData> deserializeFunc)
        {
            Debug.Assert(Enum.IsDefined(typeof(GeoPrimType), type));
            Debug.Assert(deserializeFunc != null);

            Debug.Assert(GeoPrimDeserializationMap.TryAdd(type, deserializeFunc));
        }

        public static void RegisterRailNote(byte index, string name)
        {
            if (index < RailNoteNames.Length)
            {
                RailNoteNames[index] = name;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static byte GetRailNoteId(string type)
        {
            int index = Array.IndexOf(RailNoteNames, type);
            
            return index < RailNoteNames.Length ? (byte)index : (byte)RailNoteNames.Length;
        }
    }
}
