namespace FoxKit.Fx
{
    public enum UiNodePropType
    {
        INT8 = 0,
        UINT8 = 1,
        INT16 = 2,
        UINT16 = 3,
        INT32 = 4,
        UINT32 = 5,
        INT64 = 6,
        UINT64 = 7,
        FLOAT32 = 8,
        FLOAT64 = 9,
        BOOL = 10,
        STRING = 11,
        PATH = 12,
        ENTITY_PTR = 13,
        VECTOR3 = 14,
        VECTOR4 = 15,
        QUAT = 16,
        MATRIX3 = 17,
        MATRIX4 = 18,
        COLOR = 19,
        FILE_PTR = 20,
        ENTITY_HANDLE = 21,
        ENTITY_LINK = 22,
        INVALID = 23,
    }

    public enum FxRandomGatherType
    {
        Auto = 0,
        RelativeRootOffset = 1,
        AbsoluteValue = 2,
    }

    public enum FxVectorType
    {
        Vector = 0,
        Rotates = 1,
        Color = 2,
    }

    public enum FxRenderBlendMode
    {
        Alpha = 0,
        Add = 1,
        Sub = 2,
        Mul = 3,
        Min = 4,
        Opaque = 5,
    }

    public enum FxRenderSortMode
    {
        None = 0,
        SimpleSort = 1,
        OnePointSort = 2,
        LocalSort = 3,
    }

    public enum FxPlayModeType
    {
        OneShot = 0,
        Loop = 1,
        LoopFadeInOut = 2,
    }

    public enum FxUpdateType
    {
        Normal = 0,
        DividesFrames = 1,
        DrawTiming = 2,
    }

    public enum FxExecutionPriorityType
    {
        Must = 0,
        Normal = 1,
    }

    public enum FxBoundingBoxType
    {
        None = 0,
        TimeProgresses = 1,
        Stop = 2,
    }

    public enum FxSimulationMode
    {
        SimulationNormal,
        SimulationDecalPerf,
        SimulationMissileMove,
        SimulationCreateAndDestroyPerf,
        SimulationBulletLineMove,
        SimulationRpgWeaponMove,
        SimulationReceiveColorTest,
    }

    public enum FxShapeBoundBoxType
    {
        Manual = 0,
    }

    public enum FxRotateOrderTyoe
    {
        XyzOreder = 0,
    }

    public enum FxCameraLodType
    {
        CameraDistance = 0,
        CameraArea = 1,
        LodPriority = 2,
    }

    public enum FxLodEmitPriorityLevel
    {
        Level0 = 0,
        Level1 = 1,
        Level2 = 2,
        Level3 = 3,
        Level4 = 4,
        Level5 = 5,
        Level6 = 6,
        Level7 = 7,
        Level8 = 8,
        LevelMax = 9,
    }

    public enum FxGenerationFilterType
    {
        Generation7 = 0,
        Generation8 = 1,
        Generation9 = 2,
    }

    public enum FxVariationGenerationFilterType
    {
        None = 0,
        Generation7 = 1,
        Generation8 = 2,
    }
}
