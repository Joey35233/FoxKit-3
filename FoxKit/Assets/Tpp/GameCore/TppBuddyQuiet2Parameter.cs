namespace Tpp.GameCore
{
    public partial class TppBuddyQuiet2Parameter
    {
        public Fox.Core.FilePtr PartsFile { get => partsFile; set => partsFile = value; }
        public Fox.StringMap<Fox.Core.FilePtr> VfxFiles => vfxFiles;
    }
}
