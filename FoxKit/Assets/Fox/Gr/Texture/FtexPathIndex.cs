using System.Collections.Generic;
using System.IO;
using Fox.Fs;
using UnityEditor;

namespace Fox.Gr
{
    public static class FtexPathIndex
    {
        private const string CachePath = "Library/FtexPathIndex.txt";

        private const string ScannedThisSessionKey = "Fox.Gr.FtexPathIndex.Scanned";

        private const ulong PathCodeBaseMask = 0x3FFFFFFFFFFFF;

        private const ulong PathCodeUserFlag = 0x4000000000000;

        private static Dictionary<ulong, string> foxPathByPathCode;

        public static string GetFoxPath(ulong pathCode)
        {
            if (foxPathByPathCode == null && SessionState.GetBool(ScannedThisSessionKey, false))
            {
                LoadCache();
            }

            if (foxPathByPathCode == null)
            {
                Build();
            }

            if (foxPathByPathCode == null)
            {
                return null;
            }

            if (foxPathByPathCode.TryGetValue(pathCode & ~PathCodeUserFlag, out string foxPath))
            {
                return foxPath;
            }

            string hashNamedFoxPath = $"/{pathCode & PathCodeBaseMask:x}.ftex";
            if (System.IO.File.Exists(FileSystem.GetExternalPathFromFoxPath(hashNamedFoxPath)))
            {
                return hashNamedFoxPath;
            }

            return null;
        }

        private static void Build()
        {
            string basePath = FsModule.ExternalBasePath;
            if (string.IsNullOrEmpty(basePath) || !Directory.Exists(basePath))
            {
                return;
            }

            var index = new Dictionary<ulong, string>();
            foreach (string externalPath in Directory.EnumerateFiles(basePath, "*.ftex", SearchOption.AllDirectories))
            {
                string foxPath = FileSystem.GetFoxPathFromExternalPath(externalPath).Replace('\\', '/');
                index[Hashing.PathCode(foxPath) & ~PathCodeUserFlag] = foxPath;
            }

            foxPathByPathCode = index;
            System.IO.File.WriteAllLines(CachePath, index.Values);
            SessionState.SetBool(ScannedThisSessionKey, true);
        }

        private static void LoadCache()
        {
            if (!System.IO.File.Exists(CachePath))
            {
                return;
            }

            var index = new Dictionary<ulong, string>();
            foreach (string foxPath in System.IO.File.ReadLines(CachePath))
            {
                index[Hashing.PathCode(foxPath) & ~PathCodeUserFlag] = foxPath;
            }

            foxPathByPathCode = index;
        }
    }
}