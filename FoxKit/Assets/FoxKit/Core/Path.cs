using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public class Path
    {
        public string CString { get; private set; } // ASCII

        public uint Length { get; private set; }

        public PathFileNameCode Hash { get; private set; }

        public Path()
        {
            CString = "";
            Length = 0;
            Hash = new PathFileNameCode("");
        }

        public Path(string name)
        {
            if (name != null)
            {
                CString = name;
                Length = (uint)name.Length;
                Hash = new PathFileNameCode(name);
            }
            else
            {
                CString = "";
                Length = 0;
                Hash = new PathFileNameCode("");
            }
        }
    }
}