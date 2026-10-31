using System.Collections.Generic;

namespace Tpp.GameCore
{
    public partial class TppBearParameter
    {
        public List<Fox.Core.FilePtr> FovaFiles => fovaFiles;
        public Fox.Core.FilePtr MogFile { get => mogFile; set => mogFile = value; }
        public Fox.Core.FilePtr MtarFile { get => mtarFile; set => mtarFile = value; }
        public Fox.Core.FilePtr PartsFile { get => partsFile; set => partsFile = value; }
    }
}
