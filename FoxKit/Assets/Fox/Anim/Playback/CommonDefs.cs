using Fox;

namespace Fox.Anim
{
    public static class CommonDefs
    {
        // Rig
        public const string RigFolderName = "RIG";
        
        public const string UnitName = "Unit";
        public const string SegmentName = "Segment";
        
        public const string UnitsFolderName = UnitName + "s";
        public const string SegmentFolderName = SegmentName + "s";

        public static StrCode32 RootUnitName = new StrCode32("RIG_ROOT");
        
        // MTP
        public const string MTPFolderName = "MTP";
        public const string MTPFolderPath = "MTP/";

        public const char MTPParentSeparator = '|';
        
        public static string GetUnitNameString(uint unitId)
        {
            return $"{UnitName}[{unitId:0000}]";
        }
        
        public static string GetUnitNamePropertyPath(uint unitId)
        {
            return $"{RigFolderName}/{SegmentFolderName}/{GetUnitNameString(unitId)}";
        }
        
        public static string GetSegmentNameString(uint unitId, uint segmentId)
        {
            return $"{SegmentName}[{unitId:0000}][{segmentId:0000}]";
        }
        
        public static string GetSegmentNamePropertyPath(uint unitId, uint segmentId)
        {
            return $"{RigFolderName}/{SegmentFolderName}/{GetSegmentNameString(unitId, segmentId)}";
        }
    }
}