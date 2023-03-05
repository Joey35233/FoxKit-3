using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedIdleActNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedIdleAct");
		public override StrCode32 GetId() => Id;

		public static TppRouteRelaxedIdleActNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteRelaxedIdleActNodeEvent {
                animationAct = reader.ReadUInt32(),
                unknownB = reader.ReadUInt32(),
            };

            reader.SkipPadding(8);

            return result;
        }
    }
}
