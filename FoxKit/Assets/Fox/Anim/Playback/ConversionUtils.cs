using Fox.Kernel;

namespace Fox.Anim
{
    public static class ConversionUtils
    {
        public const string RigFolderName = "RIG";
        
        public const string UnitName = "Unit";
        public const string SegmentName = "Segment";
        
        public const string UnitsFolderName = UnitName + "s";
        public const string SegmentFolderName = SegmentName + "s";

        public static StrCode32 RootUnitName = new StrCode32("RIG_ROOT");
        public static uint RootRotSegmentIndex = 0;
        public static uint RootPosSegmentIndex = 1;
        
        public static string GetUnitNameString(uint unitIndex)
        {
            return $"{UnitName}[{unitIndex:0000}]";
        }
        
        public static string GetUnitNamePropertyPath(uint unitIndex)
        {
            return $"{RigFolderName}/{SegmentFolderName}/{GetUnitNameString(unitIndex)}";
        }
        
        public static string GetSegmentNameString(uint unitIndex, uint segmentIndex)
        {
            return $"{SegmentName}[{unitIndex:0000}][{segmentIndex:0000}]";
        }
        
        public static string GetSegmentNamePropertyPath(uint unitIndex, uint trackIndex)
        {
            return $"{RigFolderName}/{SegmentFolderName}/{GetSegmentNameString(unitIndex, trackIndex)}";
        }
    }
}