using Fox.Fio;
using Fox;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.Fs
{
    [InitializeOnLoad]
    public static class FsModule
    {
        public static void RegisterFsConfigAsset(FsConfig config)
        {
            FsConfig.Instance = config;
        }
    }
}
