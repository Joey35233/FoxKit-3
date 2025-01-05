using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Fox
{
    public static class Hashing
    {
        /// ========================
        /// fox_foundation_win64
        /// ========================
        private const ulong STRING_ID_MASK = 0xFFFFFFFFFFFF;
        
        private const ulong PATH_CODE_BASE_MASK = 0x3FFFFFFFFFFFF;
        private const int PATH_CODE_EXTENSION_OFFSET = 0x33;
        private const ulong PATH_CODE_USER_FLAG_MASK = 0x4000000000000;
        private const ulong PATH_CODE_USER_FLAG_ANTIMASK = unchecked((ulong)-0x4000000000000 - 1);
        private const string ASSET_PATH = "/Assets/";
        
        // ALLOCATION
        private static ulong CityHashPathCodeInner(ReadOnlySpan<char> path)
        {
            const ulong seed0 = 0x9ae16a3b2f90404f;
            ulong seed1 = 0;
            for (int i = path.Length - 1, j = 0; i >= 0 && j < sizeof(ulong); i--, j++)
            {
                seed1 |= (ulong)path[i] << (j * 8);
            }

            return CityHash.CityHash.CityHash64WithSeeds(path, seed0, seed1);
        }

        // ALLOCATION
        private static ulong CityHashStrCodeInner(ReadOnlySpan<char> str)
        {
            const ulong seed0 = 0x9ae16a3b2f90404f;
            ulong seed1 = (ulong)(str.Length > 0 ? (str[0] << 16) + str.Length : 0);
            return CityHash.CityHash.CityHash64WithSeeds(new string(str) + '\0', seed0, seed1) & STRING_ID_MASK;
        }
        
        private static ulong path_hash_code(ReadOnlySpan<char> path)
        {
            ReadOnlySpan<char> pathSpan = path;

            int finalBaseSegmentIndex = pathSpan.LastIndexOf('/');
            if (finalBaseSegmentIndex == -1)
            {
                finalBaseSegmentIndex = pathSpan.LastIndexOf('\\');
                if (finalBaseSegmentIndex == -1)
                    finalBaseSegmentIndex = 0;
            }
            
            ReadOnlySpan<char> finalSegment = pathSpan[finalBaseSegmentIndex..];

            int extIndex = finalSegment.IndexOf('.');
            if (extIndex == -1)
                extIndex = path.Length;
            else
                extIndex = finalBaseSegmentIndex + extIndex;
            
            ReadOnlySpan<char> extSpan = path[extIndex..];

            pathSpan = path[..^extSpan.Length];
            
            // "user flag"
            if (path.StartsWith(ASSET_PATH))
            {
                pathSpan = pathSpan[ASSET_PATH.Length..];
            }

            ulong baseHash = CityHashPathCodeInner(pathSpan) & PATH_CODE_BASE_MASK;

            if (extSpan.Length > 0 && extSpan[0] == '.')
                extSpan = extSpan[1..];
            ulong extensionHash = CityHashPathCodeInner(extSpan) << PATH_CODE_EXTENSION_OFFSET;
            return extensionHash | baseHash;
        }

        private static ulong ff_path_code_set_userflag(ulong hash, int userFlag)
        {
            ulong mask = unchecked((ulong)(userFlag == 0 ? 0L : -1L));
            return mask & PATH_CODE_USER_FLAG_MASK | hash & PATH_CODE_USER_FLAG_ANTIMASK;
        }

        /// ========================
        /// PRIVATE FUNCTIONS
        /// ========================

        // fox::fs::impl::PathCodeResolver::IsImplicitRuntimeProject
        // fox::fs::impl::PathCodeResolver::FindKnownProject
        private static string[] RuntimeProjectList =
        {
            "fox",
            "fox_export",
            "tpp",
            "sh",
            "mgo",
        };

        private static bool IsImplicitRuntimeProject(ReadOnlySpan<char> path)
        {
            int assetsIndex = path.IndexOf(ASSET_PATH);
            if (assetsIndex == -1)
                return false;

            path = path[ASSET_PATH.Length..];
            int nextSlashIndex = path.IndexOf('/');
            if (nextSlashIndex == -1)
                return false;

            path = path[..nextSlashIndex];

            foreach (var project in RuntimeProjectList)
                if (path.Equals(project, StringComparison.Ordinal))
                    return true;

            return false;
        }
        
        private static ulong PathCodeInner(ReadOnlySpan<char> path)
        {
            ulong code;
            if (path.StartsWith(ASSET_PATH))
            {
                code = path_hash_code(path);
                if (IsImplicitRuntimeProject(path))
                    return code;
                else
                    return ff_path_code_set_userflag(code, 1);
            }
            else
            {
                if (path.Length == 0)
                    return 0;
                
                bool mustReallocate = false;
                foreach (var c in path)
                {
                    if (c == '\\')
                    {
                        mustReallocate = true;
                        break;
                    }
                }
                
                if (mustReallocate)
                {
                    string modified = new string(path);
                    modified.Replace('\\', '/');

                    ReadOnlySpan<char> span = modified.AsSpan();
                    int starterPrefix = modified.IndexOf("./");
                    if (starterPrefix != -1)
                        span = span[2..];

                    code = path_hash_code(span);
                    code = ff_path_code_set_userflag(code, 1);
                    return code;
                }
                else
                {
                    int starterPrefix = path.IndexOf("./");
                    if (starterPrefix != -1)
                        path = path[2..];
                    
                    code = path_hash_code(path);
                    code = ff_path_code_set_userflag(code, 1);
                    return code;
                }
            }
        }

        /// ========================
        /// PUBLIC FUNCTIONS
        /// ========================

        public static ulong PathCode(ReadOnlySpan<char> str)
        {
            if (str == null)
                return 0;
            
            if (str.Length > 2 && str.StartsWith("0x"))
            {
                ReadOnlySpan<char> subStr = str[2..];
                if (ulong.TryParse(subStr, NumberStyles.HexNumber, null, out ulong rawVar))
                    return rawVar;
            }
            
            return PathCodeInner(str);
        }
        
        public static uint PathCode32(ReadOnlySpan<char> str)
        {
            if (str.Length > 2 && str.StartsWith("0x"))
            {
                ReadOnlySpan<char> subStr = str[2..];
                if (uint.TryParse(subStr, NumberStyles.HexNumber, null, out uint rawVar))
                    return rawVar;
            }
            
            return (uint)PathCodeInner(str);
        }

        public static ulong StringId(ReadOnlySpan<char> str)
        {
            if (str.Length > 2 && str.StartsWith("0x"))
            {
                ReadOnlySpan<char> subStr = str[2..];
                if (ulong.TryParse(subStr, NumberStyles.HexNumber, null, out ulong rawVar))
                    return rawVar;
            }
            
            return CityHashStrCodeInner(str);
        }

        public static uint StringId32(ReadOnlySpan<char> str)
        {
            if (str.Length > 2 && str.StartsWith("0x"))
            {
                ReadOnlySpan<char> subStr = str[2..];
                if (uint.TryParse(subStr, NumberStyles.HexNumber, null, out uint rawVar))
                    return rawVar;
            }
            
            return (uint)CityHashStrCodeInner(str);
        }
    }
}