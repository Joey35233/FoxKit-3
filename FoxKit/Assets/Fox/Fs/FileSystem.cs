using System;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Fox.Fs
{
    // Working nomenclature
    // *External* paths refer to unpacked game files stored outside of Unity - an example is C:/Program Files (x86)/Steam/steamapps/common/MGS_TPP/master/chunk0_dat/Assets/tpp/pack/...
    // *Virtual* paths refer to all types of paths found in DataSets, such as /Assets/tpp/level/location/afgh/block_common/afgh_common.fox2 and /Assets/tpp/pack/location/afgh/pack_common/afgh_common.fpk
    // *Unity* paths refer to files stored within Unity, such as Assets/Game/Assets/tpp/level/location/afgh/block_common/afgh_common.fox2.unity
    
    public enum ImportFileMode
    {
        // Import to Unity path with same relative path as in external source path
        PreserveImportPath,
        
        // Import to loose directory
        Loose,
        
        // Open as a new scene but do not import
        OpenDontSave,
    }
    
    public static class FileSystem
    {
        public static string GetVirtualPathFromExternalPath(string externalPath)
        {
            string basePath = FsModule.ExternalBasePath;
            
            int index = externalPath.IndexOf(basePath, StringComparison.Ordinal);
            if (index < 0)
                return null;
            
            string result = externalPath[(index + basePath.Length)..];

            return result;
        }

        public static string GetExternalPathFromVirtualPath(string virtualPath)
        {
            string basePath = FsModule.ExternalBasePath;

            string result = basePath + virtualPath;
            
            return result;
        }
        
        public static string GetUnityPathFromVirtualPath(string virtualPath)
        {
            string basePath = FsModule.UnityBasePath;

            string resolvedPath = ResolveVirtualPath(virtualPath);
            
            string result = basePath + resolvedPath;
            
            return result;
        }
        
        public static string GetLoosePathFromExternalPath(string externalPath)
        {
            string basePath = FsModule.LooseBasePath;

            // Bit of a hack - pretend like the virtualPath is just the file name and extension
            string virtualPath = $"/{System.IO.Path.GetFileName(externalPath)}";
            string resolvedPath = ResolveVirtualPath(virtualPath);
            
            string result = basePath + resolvedPath;
            
            return result;
        }
    
        private static string ResolveVirtualPath(string path)
        {
            Debug.Assert(path.StartsWith('/'));
            
            // Very basic handling
            if (path.EndsWith(".fox2"))
                path += ".unity";
    
            return path;
        }

        public static ReadOnlySpan<byte> ReadExternalFile(string virtualPath)
        {
            string externalPath = GetExternalPathFromVirtualPath(virtualPath);
            return File.ReadAllBytes(externalPath);
        }
        
        public static ReadOnlySpan<byte> ReadLooseFile(string externalPath)
        {
            return File.ReadAllBytes(externalPath);
        }

        public static ReadOnlySpan<byte> ReadFile(string virtualPath)
        {
            string unityPath = GetUnityPathFromVirtualPath(virtualPath);
            return File.ReadAllBytes(unityPath);
        }

        public static bool TryCopyImportAsset(string virtualPath, ImportFileMode importMode = ImportFileMode.PreserveImportPath, bool createDirectory = true)
        {
            string externalPath = GetExternalPathFromVirtualPath(virtualPath);
            string unityPath = GetUnityPathFromVirtualPath(virtualPath);

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

        // Path is virtualPath is import mode is not Loose
        public static bool TryImportAsset(Scene scene, string path, ImportFileMode importMode = ImportFileMode.PreserveImportPath, bool overwrite = true, bool createDirectory = true)
        {
            scene.name = System.IO.Path.GetFileNameWithoutExtension(path);

            switch (importMode)
            {
                case ImportFileMode.PreserveImportPath:
                {
                    string virtualPath = path;
                    string unityPath = GetUnityPathFromVirtualPath(virtualPath);
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
                    EditorSceneManager.SaveScene(scene, unityPath);
                }
                    break;
                case ImportFileMode.Loose:
                {
                    string externalPath = path;
                    string loosePath = GetLoosePathFromExternalPath(externalPath);
                    if (overwrite == false && System.IO.File.Exists(loosePath))
                        return false;
                    
                    EditorSceneManager.SaveScene(scene, loosePath);
                }
                break;
            case ImportFileMode.OpenDontSave:
                break;
            }

            return true;
        }
        
        public static bool TryImportAsset(AnimationClip[] clips, string virtualPath, bool overwrite = true, bool createDirectory = true)
        {
            // scene.name = System.IO.Path.GetFileNameWithoutExtension(virtualPath);

            string unityPath = GetUnityPathFromVirtualPath(virtualPath);
            if (overwrite == false && System.IO.Directory.Exists(unityPath))
                return false;

            if (createDirectory)
            {
                // Entire path is directory path
                if (!Directory.Exists(unityPath))
                {
                    Directory.CreateDirectory(unityPath);
                }
            }

            foreach (AnimationClip clip in clips)
            {
                AssetDatabase.CreateAsset(clip, System.IO.Path.Combine(unityPath, clip.name + ".gani.asset"));
            }
            AssetDatabase.SaveAssets();

            return true;
        }

        // Utilities
        public static void OpenExternalFolder()
        {
            string path = FsModule.ExternalBasePath;
            
            EditorUtility.RevealInFinder(path);
        }
        
        public static void OpenUnityFolder()
        {
            string path = FsModule.UnityBasePath;
            
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