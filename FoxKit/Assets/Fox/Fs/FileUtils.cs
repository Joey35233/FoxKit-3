using UnityEditor;

namespace Fox.Fs
{
    public static class FileUtils
    {
        public static string OpenFilePanel(string title, string extension) => EditorUtility.OpenFilePanel(title, Fox.Fs.FsModule.ExternalBasePath, extension);
        
        public static string SaveFilePanel(string title, string name, string extension) => EditorUtility.SaveFilePanel(title, Fox.Fs.FsModule.UnityBasePath, name, extension);
    }
}