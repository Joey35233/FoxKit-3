using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public struct StrCode
    {
        ulong hash;

        public StrCode(string str)
        {
            hash = Hashing.StrCode(str);
        }
    }
}