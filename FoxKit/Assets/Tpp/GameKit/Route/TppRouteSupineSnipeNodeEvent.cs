using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSupineSnipeNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SupineSnipe");
		public override StrCode32 GetId() => Id;

		public static TppRouteSupineSnipeNodeEvent Deserialize(FileStreamReader reader) => new TppRouteSupineSnipeNodeEvent { binaryData = new StaticArray<uint>(new uint[] { reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32(), reader.ReadUInt32() }), };
	}
}
