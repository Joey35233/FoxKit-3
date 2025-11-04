using UnityEngine;

namespace Tpp.Effect
{
    public partial class TppTrapExecChangeVolumetricFogCallbackDataElement
    {
        public override void Reset()
        {
            base.Reset();
            funcName = "ChangeTppVolumetricFog";   //rlc ASSUMPTION, no vanilla uses afaik
            //resident TppGlobalVolumetricFogParam
            color = Color.white;
            density = 0.0005f;
        }
    }
}
