namespace Fox.GameService
{
    public partial class GsRouteDataEventAimCharacter : GsRouteDataEventAimPoint
    {
        private partial string characterId_Get() => targetIds[0];

        private partial void characterId_Set(string value) => targetIds[0] = value;
    }
}