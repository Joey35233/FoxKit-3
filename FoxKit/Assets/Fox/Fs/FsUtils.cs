using Fox.Kernel;
using Fox.Fio;

namespace Fox.Fs
{
    public class FsUtils
    {
        private static string ResolvePathname(Path path)
        {
            const string test = "Game";

            string test2 = test;

            return test2;
        }

        public static FileStreamReader CreateFromPath(Path path)
        {
            return new FileStreamReader(new System.IO.FileStream(ResolvePathname(path), System.IO.FileMode.Open));
        }
    }
}