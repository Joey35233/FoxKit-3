using Fox.Kernel;
using Fox.Fio;
using UnityEngine;

namespace Fox.Fs
{
    public class FileSystem
    {
        public const string GameFolderPath = "Assets/Game";

        private static string ResolvePathname(Path path)
        {
            string fullPath;

            if (path.IsHashed())
            {
                //string extension = Hashing.
                fullPath = "";
            }
            else
            {
                Debug.Assert(path.CString.StartsWith('/'));

                fullPath = GameFolderPath + path.CString;
            }

            return fullPath;
        }

        internal static FileStreamReader CreateFromPath(Path path, System.Text.Encoding encoding)
        {
            return new FileStreamReader(new System.IO.FileStream(ResolvePathname(path), System.IO.FileMode.Open), encoding);
        }

        void RegisterImportFileExtension(String extension, System.Func<String, String> nameResolver)
        {

        }
    }
}