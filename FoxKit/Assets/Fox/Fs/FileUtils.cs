using UnityEditor;

namespace Fox.Fs
{
    public static class FileUtils
    {
        public static string OpenFilePanel(string title, string directory, string extension) => EditorUtility.OpenFilePanel(title, Fox.Fs.FsModule.ExternalBasePath, extension);
    }
}