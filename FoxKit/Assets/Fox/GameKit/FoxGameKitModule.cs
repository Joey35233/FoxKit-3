using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.GameKit
{
    [InitializeOnLoad]
    public static class FoxGameKitModule
    {
        static FoxGameKitModule()
        {
        }
        
        public static Dictionary<string, ObjectBrush> ObjectBrushRegistry = new();
    }
}
