using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 1, CharSet = CharSet.Ansi)]
    public struct Path
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
        private PathFileNameCode _hash;
        public PathFileNameCode Hash
        {
            get => _hash;
        }

        /// <summary>
        /// The empty path.
        /// </summary>
        public static Fox.Path Empty { get; }

        static Path()
        {
            Empty = new Path { _cString = string.Empty, _hash = new PathFileNameCode(string.Empty), _length = 0 };
        }

        public Path(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                this._cString = name;
                this._length = name.Length;
                this._hash = new PathFileNameCode(name);
            }
            else
            {
                this = Empty;
            }
        }
    }
}