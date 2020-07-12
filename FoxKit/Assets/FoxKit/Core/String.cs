using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public class String
    {
        public string CString { get; private set; } // ASCII

        public uint Length { get; private set; }

        public ulong Hash { get; private set; }

        public String()
        {
            CString = "";
            Length = 0;
            Hash = Hashing.StrCode("");
        }

        public String(string name)
        {
            if (name != null)
            {
                CString = name;
                Length = (uint)name.Length;
                Hash = Hashing.StrCode(name);
            }
            else
            {
                CString = "";
                Length = 0;
                Hash = Hashing.StrCode("");
            }
        }
    }
}