using System.Collections.Generic;

namespace Fox.Kernel
{
    public static class Hashing
    {
        public enum Dictionary
        {
            Sqar = 0,
        };

        private static readonly Dictionary<ulong, string>[] Dictionaries = new Dictionary<ulong, string>[1];

        static Hashing()
        {
            //Dictionaries[0] = InitDictionary("https://raw.githubusercontent.com/TinManTex/mgsv-lookup-strings/master/GzsTool/qar_dictionary.txt");
        }

        //private static Dictionary<ulong, string> InitDictionary(string uri)
        //{
        //    var dictionary = new Dictionary<ulong, string>();

        //    var fileName = uri.Substring(uri.LastIndexOf('/') + 1);
        //    var file = "C:\\Users\\joey3\\Documents\\New Project\\" + fileName;
        //    if (File.Exists(file))
        //    {
        //        var lines = File.ReadAllLines(file);

        //        foreach (var line in lines)
        //        {
        //            dictionary.Add(PathFileNameAndExtCode(line), line);
        //        }
        //    }
        //    else
        //    {
        //        var dictString = new WebClient().DownloadString(uri);
        //        var splitDict = dictString.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        //        foreach (var line in splitDict)
        //            dictionary.Add(PathFileNameAndExtCode(line), line);

        //        File.WriteAllLines(file, splitDict);
        //    }

        //    return dictionary;
        //}

        public static string Unhash(ulong hash, Dictionary dictionary)
        {
            if (!Dictionaries[(uint)dictionary].TryGetValue(hash, out string str))
                str = hash.ToString("x16");
            return str;
        }

        public static ulong StrCode(string name)
        {
            const ulong seed0 = 0x9ae16a3b2f90404f;
            ulong seed1 = (ulong)(name.Length > 0 ? (name[0] << 16) + name.Length : 0);
            return CityHash.CityHash.CityHash64WithSeeds(name + '\0', seed0, seed1) & 0xFFFFFFFFFFFF;
        }

        public static uint StrCode32(string name) => (uint)StrCode(name);

        public static ulong PathFileNameCode(string path)
        {
            ulong mask = 0x0000000000000000;

            if (path.StartsWith("/Assets/"))
            {
                path = path[8..];

                if (path.StartsWith("tpptest"))
                    mask = 0x0004000000000000;
            }
            else
            {
                path = path.TrimStart('/');

                mask = 0x0004000000000000;
            }

            const ulong seed0 = 0x9ae16a3b2f90404f;
            ulong seed1 = 0;
            for (int i = path.Length - 1, j = 0; i >= 0 && j < sizeof(ulong); i--, j++)
            {
                seed1 |= (ulong)path[i] << (j * 8);
            }

            ulong hash = CityHash.CityHash.CityHash64WithSeeds(path, seed0, seed1) & 0x3FFFFFFFFFFFF;
            return hash | mask;
        }

        public static uint PathFileNameCode32(string path) => (uint)PathFileNameCode(path);

        public static ulong PathFileNameAndExtCode(string path)
        {
            int periodIndex = path.IndexOf('.');
            return periodIndex > -1 ? ((PathFileNameCode(path[(periodIndex + 1)..]) & 0x1FFF) << 51) | PathFileNameCode(path[..periodIndex]) : StrCode(path);
        }

        public static ulong PathFileNameAndExtCode(string path, string extension) => ((PathFileNameCode(extension) & 0x1FFF) << 51) | PathFileNameCode(path);
    }
}