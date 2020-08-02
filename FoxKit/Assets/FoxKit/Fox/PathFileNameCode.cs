using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    [Serializable]
    public struct PathFileNameCode
    {
        [SerializeField]
        private ulong hash;

        public PathFileNameCode(string str)
        {
            hash = Hashing.PathFileNameCode(str);
        }
    }
}