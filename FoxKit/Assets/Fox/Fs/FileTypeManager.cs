using Fox;

namespace Fox.Fs
{
    internal class FileTypeManager
    {
        private struct FileTypeInfo
        {
            public string Extension;
            public System.Func<string, string> NameResolver;
        }

        private readonly StringMap<FileTypeInfo> TypeExtensionMap;

        public void RegisterFileType(string extension, System.Func<string, string> nameResolver)
        {
            var info = new FileTypeInfo { Extension = extension, NameResolver = nameResolver };

            TypeExtensionMap.Insert(extension, info);
        }
    }
}