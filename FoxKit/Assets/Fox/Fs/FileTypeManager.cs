using Fox.Kernel;

namespace Fox.Fs
{
    internal class FileTypeManager
    {
        private struct FileTypeInfo
        {
            public String Extension;
            public System.Func<String, String> NameResolver;
        }

        private readonly StringMap<FileTypeInfo> TypeExtensionMap;

        public void RegisterFileType(String extension, System.Func<String, String> nameResolver)
        {
            var info = new FileTypeInfo { Extension = extension, NameResolver = nameResolver };

            TypeExtensionMap.Insert(extension, info);
        }
    }
}