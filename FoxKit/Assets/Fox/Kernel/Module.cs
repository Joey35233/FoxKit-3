using System.Collections.Generic;
using UnityEngine;

namespace Fox
{
    public struct RegModInfo
    {
        public int Index;
        public Module Module;
    }
    
    public abstract class Module
    {
        private static readonly Dictionary<string, RegModInfo> _IndexMap = new();
        private static readonly Dictionary<int, string> _ModDictionary = new();

        public static IReadOnlyDictionary<string, RegModInfo> IndexMap => _IndexMap;
        public static IReadOnlyDictionary<int, string> ModDictionary => _ModDictionary;

        public string Name { get; private set; }

        public int Index { get; private set; }

        public ulong Dependencies { get; private set; }

        protected Module(string name)
        {
            Name = name;
            AddModuleMap(name, this);
        }

        public virtual void Init()
        {
        }

        protected void AddDependencyModule(string name)
        {
            AddModuleMap(name, null);
            
            Dependencies |= 1UL << IndexMap[name].Index;
        }

        private static void AddModuleMap(string name, Module module)
        {
            if (!IndexMap.TryGetValue(name, out RegModInfo existingInfo))
            {
                RegModInfo info = new RegModInfo
                {
                    Index = IndexMap.Count,
                    Module = module,
                };

                if (module != null)
                    module.Index = info.Index;
                
                _IndexMap[name] = info;
            }
            else if (module != null)
            {
                existingInfo.Module = module;
                module.Index = existingInfo.Index;
                
                _IndexMap[name] = existingInfo;
            }
        }
    }
}
