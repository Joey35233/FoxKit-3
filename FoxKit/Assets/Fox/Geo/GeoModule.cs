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
        public const int MaxRailNoteTypes = 15;
        public static readonly string[] RailNoteNames = new string[MaxRailNoteTypes];

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

        public static byte GetRailNoteTypeId(string type)
        {
            int index = type == null ? -1 : Array.IndexOf(RailNoteNames, type);
            if (index < 0)
                throw new ArgumentException($"Unknown rail note type '{type}'.", nameof(type));
            return (byte)index;
        }
    }
}
