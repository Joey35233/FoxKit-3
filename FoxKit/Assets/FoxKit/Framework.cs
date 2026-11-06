using Fox;
using System;
using System.Collections.Generic;
using Fox.Fs;
using UnityEditor;
using UnityEngine;

namespace FoxKit
{
    public static class Framework
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            FsModule.UnityBasePath = SettingsManager.UnityBasePath;
            FsModule.ExternalBasePath = SettingsManager.ExternalBasePath;
            FsModule.LooseBasePath = SettingsManager.LooseBasePath;
            
            // TEMP: Get list from TypeCache
            List<Module> modules = new();
            foreach (Type type in TypeCache.GetTypesDerivedFrom<Module>())
            {
                if (type.IsAbstract)
                    continue;

                modules.Add((Module)Activator.CreateInstance(type));
            }

            List<Module> initializationList = SortByDependencies(modules);

            foreach (Module module in initializationList)
            {
                module.Init();
            }
        }

        private static List<Module> SortByDependencies(List<Module> modules)
        {
            foreach (Module module in modules)
            {
                if (Module.IndexMap[module.Name].Module != module)
                {
                    Debug.LogError($"Duplicate module name '{module.Name}'; ignoring the duplicate.");
                }
            }

            List<Module> remaining = new(modules);
            List<Module> sorted = new();
            ulong completedMask = 0;

            while (remaining.Count > 0)
            {
                bool progressed = false;
                for (int i = remaining.Count - 1; i >= 0; i--)
                {
                    Module module = remaining[i];
                    if ((module.Dependencies & ~completedMask) != 0)
                    {
                        continue;
                    }

                    completedMask |= 1UL << module.Index;
                    sorted.Add(module);
                    remaining.RemoveAt(i);
                    progressed = true;
                }

                if (!progressed)
                {
                    Debug.LogError($"Could not resolve module initialization order.");
                    break;
                }
            }

            return sorted;
        }
    }
}
