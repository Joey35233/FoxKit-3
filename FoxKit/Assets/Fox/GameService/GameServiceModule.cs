using Fox;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Fox.GameService
{
    public class GameServiceModule : Module
    {
        public static GameServiceModule Instance { get; private set; }

        public const int ExtensionCount = 4;

        internal static Dictionary<StrCode32, Type> RouteEdgeEventTypeMap = new();
        internal static Dictionary<StrCode32, Type> RouteNodeEventTypeMap = new();

        public static readonly List<string> RouteEdgeEvents = new();
        public static readonly List<string> RouteNodeEvents = new();

        public static readonly StringId32Map RouteIdMap = new StringId32Map();
        public static readonly StringId32Map EventIdMap = new StringId32Map();
        public static StringId32Map CharacterIdMap { get; private set; } = new StringId32Map();
        public static void RegisterCharacterIdMap(StringId32Map map) => CharacterIdMap = map;

        private static Action RouteIdMapsSaver;
        public static void RegisterRouteIdMapsSaver(Action saver) => RouteIdMapsSaver = saver;

        public static void SaveRouteIdMaps()
        {
            RouteIdMap.Save();

            RouteIdMapsSaver?.Invoke();
        }

        public GameServiceModule() : base("Fox.GameService")
        {
            Instance = this;
            
            AddDependencyModule("Fox.Kernel");
            AddDependencyModule("Fox.Core");
            AddDependencyModule("Fox.Graphx");
        }

        public static void RegisterRouteNodeEventTypeOverride(StrCode32 id, Type type)
        {
            Debug.Assert(RouteNodeEventTypeMap.TryAdd(id, type));
        }

        public static void RegisterRouteEdgeEventTypeOverride(StrCode32 id, Type type)
        {
            Debug.Assert(RouteEdgeEventTypeMap.TryAdd(id, type));
        }

        public static void RegisterEventInfo(string eventInfoPath, string title)
        {
            List<(StrCode32, string)> eventIds = new List<(StrCode32, string)>();

            // Skip header row
            string[] eventInfo = Fox.Fs.FileSystem.ReadLines(eventInfoPath);
            for (uint i = 1; i < eventInfo.Length; i++)
            {
                string[] lineData = eventInfo[i].Split(',');

                string id = lineData[0];
                
                StrCode32 idHash = new StrCode32(lineData[1]);

                bool include = false;
                string[] testedInTitles = lineData[5].Split(';');
                foreach (string testedTitle in testedInTitles)
                {
                    if (testedTitle == title)
                    {
                        include = true;
                        break;
                    }
                }
                if (!include)
                    continue;

                eventIds.Add((idHash, id));

                string idString = (id == "" && idHash != new StrCode32("")) ? idHash.ToString() : id;
                
                if (lineData[2] == "Node")
                    RouteNodeEvents.Add(idString);
                else
                    RouteEdgeEvents.Add(idString);
            }

            EventIdMap.RegisterBaseEntries(eventIds);
        }
    }
}
