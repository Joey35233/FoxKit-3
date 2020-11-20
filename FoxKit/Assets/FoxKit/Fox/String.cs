using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size=1, CharSet=CharSet.Ansi)]
    public struct String
    {
        [SerializeField, FieldOffset(0)]
        private string cString;

        [SerializeField, FieldOffset(8)]
        private int length;

        [SerializeField, FieldOffset(11)]
        private bool isHash;

        [SerializeField, FieldOffset(12)]
        private StrCode hash;

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Fox.String Empty { get; }

        static String()
        {
            Empty = new String(string.Empty, 0, new StrCode(string.Empty));
        }

        public String(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this.cString = name;
                this.length = name.Length;
                this.hash = new StrCode(name);
            }
            else
            {
                this.cString = Empty.CString();
                this.length = Empty.length;
                this.hash = Empty.hash;
            }

            isHash = false;
        }

        public string CString() => this.cString;

        private String(string cString, int length, StrCode hash)
        {
            this.cString = cString;
            this.length = length;
            this.hash = hash;

            isHash = false;
        }

        public String(StrCode hash)
        {
            this.cString = null;
            this.length = -1;
            this.hash = hash;

            isHash = true;
        }

        public bool IsHash()
        {
            return IsHash();
        }
    }
}