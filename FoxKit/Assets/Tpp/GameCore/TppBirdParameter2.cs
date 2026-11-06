using System.Collections.Generic;

namespace Tpp.GameCore
{
    public partial class TppBirdParameter2
    {
        public List<Fox.Core.FilePtr> FovaFiles => fovaFiles;
        public Fox.Core.FilePtr MtarFile { get => mtarFile; set => mtarFile = value; }
        public Fox.Core.FilePtr PartsFile { get => partsFile; set => partsFile = value; }
        public Fox.StringMap<Fox.Core.FilePtr> VfxFiles => vfxFiles;
    }
}
