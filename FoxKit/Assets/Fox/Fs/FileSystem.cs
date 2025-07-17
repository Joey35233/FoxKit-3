using System;
using System.IO;
using System.Linq;
using Fox.Fio;
using Fox;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fox.Fs
{
    // Working nomenclature
    // *External* paths refer to unpacked game files stored outside of Unity - an example is C:/Program Files (x86)/Steam/steamapps/common/MGS_TPP/master/chunk0_dat/Assets/tpp/pack/...
    // *Fox* paths refer to all types of paths found in DataSets, such as /Assets/tpp/level/location/afgh/block_common/afgh_common.fox2 and /Assets/tpp/pack/location/afgh/pack_common/afgh_common.fpk
    // *Unity* paths refer to files stored within Unity, such as Assets/Game/Assets/tpp/level/location/afgh/block_common/afgh_common.fox2.unity
    public static class FileSystem
    {
        public static string GetFoxPathFromExternalPath(string externalPath)
        {
            string basePath = FsConfig.Instance.ExternalBasePath;
            
            int index = externalPath.IndexOf(basePath, StringComparison.Ordinal);
            if (index < 0)
                return null;
            
            string result = externalPath[(index + basePath.Length)..];

            return result;
        }

        public static string GetExternalPathFromFoxPath(string foxPath)
        {
            string basePath = FsConfig.Instance.ExternalBasePath;

            string result = basePath + foxPath;
            
            return result;
        }
        
        public static string GetUnityPathFromFoxPath(string foxPath)
        {
            string basePath = FsConfig.Instance.UnityBasePath;

            string resolvedPath = ResolveFoxPath(foxPath);
            
            string result = basePath + resolvedPath;
            
            return result;
        }
    
        private static string ResolveFoxPath(string path)
        {
            Debug.Assert(path.StartsWith('/'));
            
            // Very basic handling
            if (path.EndsWith(".fox2"))
                path += ".unity";
    
            return path;
        }

        public static ReadOnlySpan<byte> ReadExternalFile(string foxPath)
        {
            string externalPath = GetExternalPathFromFoxPath(foxPath);
            return File.ReadAllBytes(externalPath);
        }

        public static ReadOnlySpan<byte> ReadFile(string foxPath)
        {
            string unityPath = GetUnityPathFromFoxPath(foxPath);
            return File.ReadAllBytes(unityPath);
        }

        public static bool TryCopyImportAsset(string foxPath, bool createDirectory = true)
        {
            string externalPath = GetExternalPathFromFoxPath(foxPath);
            string unityPath = GetUnityPathFromFoxPath(foxPath);

            if (createDirectory)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(unityPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }

            if (!File.Exists(unityPath))
                File.Copy(externalPath, unityPath, false);

            return true;
        }

        public static bool TryImportAsset(Scene scene, string foxPath, bool overwrite = true, bool createDirectory = true)
        {
            string unityPath = GetUnityPathFromFoxPath(foxPath);
            if (overwrite == false && System.IO.File.Exists(unityPath))
                return false;

            if (createDirectory)
            {
                string directoryPath = System.IO.Path.GetDirectoryName(unityPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }
            }

            scene.name = System.IO.Path.GetFileNameWithoutExtension(foxPath);
            EditorSceneManager.SaveScene(scene, unityPath);

            return true;
        }

        // Utilities
        public static void OpenExternalFolder()
        {
            string path = FsConfig.Instance.ExternalBasePath;
            
            EditorUtility.RevealInFinder(path);
        }
        
        public static void OpenUnityFolder()
        {
            string path = FsConfig.Instance.UnityBasePath;
            
            UnityEngine.Object folder = AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(path);
            AssetDatabase.OpenAsset(folder);
        }
        
    //
    //     internal static FileStreamReader CreateFromPath(Path path, System.Text.Encoding encoding) => new(new System.IO.FileStream(ResolvePathname(path), System.IO.FileMode.Open), encoding);
    //
    //     private void RegisterImportFileExtension(string extension, System.Func<string, string> nameResolver)
    //     {
    //         // TODO
    //     }
    }
}