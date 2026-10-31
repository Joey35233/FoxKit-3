namespace Tpp.GameCore
{
    public partial class TppHeli2Parameter
    {
        public Fox.StringMap<Fox.Core.FilePtr> FcnpFiles => fcnpFiles;
        public Fox.StringMap<Fox.Core.FilePtr> FmdlFiles => fmdlFiles;
        public Fox.StringMap<Fox.Core.FilePtr> FovaFiles => fovaFiles;
        public Fox.StringMap<Fox.Core.FilePtr> GsklFiles => gsklFiles;
        public Fox.Core.FilePtr MtarFile { get => mtarFile; set => mtarFile = value; }
        public Fox.StringMap<Fox.Core.FilePtr> PartsFiles => partsFiles;
        public Fox.StringMap<Fox.Core.FilePtr> VfxFiles => vfxFiles;
    }
}
