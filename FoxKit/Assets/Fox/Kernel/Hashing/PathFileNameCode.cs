using System;

using UnityEngine;

namespace Fox.Kernel
{
    [Serializable]
#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
#pragma warning disable CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
    public struct PathFileNameCode
#pragma warning restore CS0661 // Type defines operator == or operator != but does not override Object.GetHashCode()
#pragma warning restore CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)
    {
        [SerializeField]
        private ulong hash;

        public PathFileNameCode(string str)
        {
            hash = Hashing.PathFileNameCode(str);
        }

        public static bool TryParse(string str, out PathFileNameCode outValue)
        {
            //outValue = null;
            return ulong.TryParse(str, out outValue.hash);
        }

        public static bool operator==(PathFileNameCode a, PathFileNameCode b)
        {
            return a.hash == b.hash;
        }

        public static bool operator!=(PathFileNameCode a, PathFileNameCode b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return hash.ToString("x");
        }
    }
}