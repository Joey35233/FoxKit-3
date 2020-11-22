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
        private string _cString;
        public string CString
        {
            get => _cString;
        }

        [SerializeField, FieldOffset(8)]
        private int _length;
        public int Length
        {
            get => _length;
        }

        [SerializeField, FieldOffset(12)]
        private StrCode _hash;
        public StrCode Hash
        {
            get => _hash;
        }

        /// <summary>
        /// The empty string.
        /// </summary>
        public static Fox.String Empty { get; }

        static String()
        {
            Empty = new String { _cString = string.Empty, _hash = new StrCode(string.Empty), _length = 0 };
        }

        public String(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this._cString = name;
                this._length = name.Length;
                this._hash = new StrCode(name);
            }
            else
            {
                this = Empty;
            }
        }
    }
}