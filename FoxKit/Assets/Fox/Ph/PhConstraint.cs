using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhConstraint : Fox.Ph.PhSubObject
    {
        private partial UnityEngine.Vector3 Get_defaultPosition() => param == null ? Vector3.zero : param.GetDefaultPosition();
        private partial void Set_defaultPosition(UnityEngine.Vector3 value)
        {
            if (param == null)
                return;

            param.SetDefaultPosition(value);
        }
    }
}
