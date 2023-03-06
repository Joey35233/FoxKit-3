using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;
using UnityEngine;

namespace Tpp.GameKit
{
	public partial class TppRouteTakeHostageOutOfVehicleNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("TakeHostageOutOfVehicle");
		public override StrCode32 GetId() => Id;

        public static TppRouteTakeHostageOutOfVehicleNodeEvent Deserialize(FileStreamReader reader)
        {
            uint unknown = reader.ReadUInt32();
            Debug.Assert(unknown == 0);

            var result = new TppRouteTakeHostageOutOfVehicleNodeEvent { unknown = unknown, message = new String(reader.ReadStrCode32().ToString()), routeName = new String(reader.ReadStrCode32().ToString()) };

            reader.SkipPadding(4);

            return result;
        }
    }
}
