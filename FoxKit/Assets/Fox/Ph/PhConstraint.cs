using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraint : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 defaultPosition_Get() => param == null ? Vector3.zero : param.GetDefaultPosition();
        private partial void defaultPosition_Set(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetDefaultPosition(value);
        }
    }
}
