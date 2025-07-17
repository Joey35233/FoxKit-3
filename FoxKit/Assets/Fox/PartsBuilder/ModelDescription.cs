namespace Fox.PartsBuilder
{
    public partial class ModelDescription
    {
        public override void Reset()
        {
            base.Reset();
            lodFarPixelSize = -1;
            lodNearPixelSize = -1;
            lodPolygonSize = -1;
            drawRejectionLevel = ModelDescription_DrawRejectionLevel.DEFAULT;
            rejectFarRangeShadowCast = ModelDescription_RejectFarRangeShadowCast.DEFAULT;
        }
    }
}
