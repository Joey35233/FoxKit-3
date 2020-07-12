using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
<<<<<<< HEAD:FoxKit/Assets/FoxKit/Fox/PathFileNameCode.cs
    public struct PathFileNameCode
=======
    [Serializable]
    public struct StrCode
>>>>>>> entity-dev:FoxKit/Assets/FoxKit/Fox/StrCode.cs
    {
        [SerializeField]
        private ulong hash;

        public PathFileNameCode(string str)
        {
            hash = Hashing.PathFileNameCode(str);
        }
    }
}