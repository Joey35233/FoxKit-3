using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteRelaxedIdleActNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("RelaxedIdleAct");
		public override StrCode32 GetId() => Id;

        public static TppRouteRelaxedIdleActNodeEvent Deserialize(FileStreamReader reader)
        {
            var result = new TppRouteRelaxedIdleActNodeEvent { animationName = new String(reader.ReadStrCode32().ToString()), unknown = reader.ReadUInt16() };

            Debug.Assert(result.unknown == 0);

            reader.SkipPadding(10);

            return result;
        }
    }
}
