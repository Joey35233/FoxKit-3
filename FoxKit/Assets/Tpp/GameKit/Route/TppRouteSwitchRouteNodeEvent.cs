using Fox.Fio;
using Fox.GameService;
using Fox.Kernel;

namespace Tpp.GameKit
{
	public partial class TppRouteSwitchRouteNodeEvent : GsRouteDataNodeEvent
	{
		public static readonly StrCode32 Id = new StrCode32("SwitchRoute");
		public override StrCode32 GetId() => Id;

        public static TppRouteSwitchRouteNodeEvent Deserialize(UnityEngine.GameObject gameObject, uint[] binaryData)
        {
            TppRouteSwitchRouteNodeEvent result = gameObject.AddComponent<TppRouteSwitchRouteNodeEvent>();

            StrCode32 routeName;
            StrCode32 function;
            StrCode32 argument;
            unsafe
            {
                fixed (uint* binaryDataPtr = binaryData)
                {
                    uint* ptr = binaryDataPtr;
                    routeName = *(StrCode32*)ptr;
                    ptr += 1;
                    function = *(StrCode32*)ptr;
                    ptr += 1;
                    argument = *(StrCode32*)ptr;
                }
            }

            result.routeName = new String(routeName.ToString());
            result.function = new String(function.ToString());
            result.argument = new String(argument.ToString());

            return result;
        }
    }
}
