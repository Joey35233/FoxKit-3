using Fox;

namespace Fox.Fs
{
    

        // private static readonly List<string> FileExtensions = new()
        // {
        //     "1.ftexs",
        //     "1.nav2",
        //     "2.ftexs",
        //     "3.ftexs",
        //     "4.ftexs",
        //     "5.ftexs",
        //     "6.ftexs",
        //     "ag.evf",
        //     "aia",
        //     "aib",
        //     "aibc",
        //     "aig",
        //     "aigc",
        //     "aim",
        //     "aip",
        //     "ait",
        //     "atsh",
        //     "bnd",
        //     "bnk",
        //     "cc.evf",
        //     "clo",
        //     "csnav",
        //     "dat",
        //     "des",
        //     "dnav",
        //     "dnav2",
        //     "eng.lng",
        //     "ese",
        //     "evb",
        //     "evf",
        //     "fag",
        //     "fage",
        //     "fago",
        //     "fagp",
        //     "fagx",
        //     "fclo",
        //     "fcnp",
        //     "fcnpx",
        //     "fdes",
        //     "fdmg",
        //     "ffnt",
        //     "fmdl",
        //     "fmdlb",
        //     "fmtt",
        //     "fnt",
        //     "fova",
        //     "fox",
        //     "fox2",
        //     "fpk",
        //     "fpkd",
        //     "fpkl",
        //     "frdv",
        //     "fre.lng",
        //     "frig",
        //     "frt",
        //     "fsd",
        //     "fsm",
        //     "fsml",
        //     "fsop",
        //     "fstb",
        //     "ftex",
        //     "fv2",
        //     "fx.evf",
        //     "fxp",
        //     "gani",
        //     "geom",
        //     "ger.lng",
        //     "gpfp",
        //     "grxla",
        //     "grxoc",
        //     "gskl",
        //     "htre",
        //     "info",
        //     "ita.lng",
        //     "jpn.lng",
        //     "json",
        //     "lad",
        //     "ladb",
        //     "lani",
        //     "las",
        //     "lba",
        //     "lng",
        //     "lpsh",
        //     "lua",
        //     "mas",
        //     "mbl",
        //     "mog",
        //     "mtar",
        //     "mtl",
        //     "nav2",
        //     "nta",
        //     "obr",
        //     "obrb",
        //     "param",
        //     "parts",
        //     "path",
        //     "pftxs",
        //     "ph",
        //     "phep",
        //     "phsd",
        //     "por.lng",
        //     "qar",
        //     "rbs",
        //     "rdb",
        //     "rdf",
        //     "rnav",
        //     "rus.lng",
        //     "sad",
        //     "sand",
        //     "sani",
        //     "sbp",
        //     "sd.evf",
        //     "sdf",
        //     "sim",
        //     "simep",
        //     "snav",
        //     "spa.lng",
        //     "spch",
        //     "sub",
        //     "subp",
        //     "tgt",
        //     "tre2",
        //     "txt",
        //     "uia",
        //     "uif",
        //     "uig",
        //     "uigb",
        //     "uil",
        //     "uilb",
        //     "utxl",
        //     "veh",
        //     "vfx",
        //     "vfxbin",
        //     "vfxdb",
        //     "vnav",
        //     "vo.evf",
        //     "vpc",
        //     "wem",
        //     "wmv",
        //     "xml",
        // };
        //
        // private static readonly Dictionary<ulong, string> ExtensionDictionary = FileExtensions.ToDictionary(ext => Hashing.PathFileNameCode(ext) & 0x1FFF);
        //
        // private string GetExtension()
        // {
        //     _ = (ushort)((hash >> 51) & 0x1FFF);
        //
        //     _ = ExtensionDictionary.TryGetValue(hash, out string result);
        //
        //     return result;
        // }
    
    // internal class FileTypeManager
    // {
    //     private struct FileTypeInfo
    //     {
    //         public string Extension;
    //         public System.Func<string, string> NameResolver;
    //     }
    //
    //     private readonly StringMap<FileTypeInfo> TypeExtensionMap;
    //
    //     public void RegisterFileType(string extension, System.Func<string, string> nameResolver)
    //     {
    //         var info = new FileTypeInfo { Extension = extension, NameResolver = nameResolver };
    //
    //         TypeExtensionMap.Insert(extension, info);
    //     }
    // }
}