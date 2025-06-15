using Fox.Fio;
using Fox;
using UnityEngine;

namespace Fox.Fs
{
    public class FileSystem
    {
        public const string GameFolderPath = "Assets/Game";

        public static string GetRelativeToBasePath(string basePath, string sourcePath)
        {
            int index = sourcePath.LastIndexOf(basePath);
            string result = sourcePath.Substring(index + basePath.Length);

            return result;
        }
    
        public static string ResolvePathname(string path)
        {
            Debug.Assert(path.StartsWith('/'));
            
            string fullPath = GameFolderPath + path;
            if (fullPath.EndsWith(".fox2"))
                fullPath += ".unity";
    
            return fullPath;
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