using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public struct PathFileNameCode
    {
        ulong hash;

        public PathFileNameCode(string str)
        {
            hash = Hashing.PathFileNameCode(str);
        }
    }
}