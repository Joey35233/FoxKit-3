namespace Tpp.GameCore
{
    public partial class TppParasite2Parameter
    {
        public Fox.StringMap<Fox.Core.FilePtr> FmdlFiles => fmdlFiles;
        public Fox.StringMap<Fox.Core.FilePtr> GeomFiles => geomFiles;
        public Fox.Core.FilePtr MotionGraphFile { get => motionGraphFile; set => motionGraphFile = value; }
        public Fox.Core.FilePtr MtarFile { get => mtarFile; set => mtarFile = value; }
        public Fox.Core.FilePtr PartsFile { get => partsFile; set => partsFile = value; }
        public Fox.StringMap<Fox.Core.FilePtr> PartsFiles => partsFiles;
        public Fox.StringMap<Fox.Core.FilePtr> VfxFiles => vfxFiles;
    }
}
