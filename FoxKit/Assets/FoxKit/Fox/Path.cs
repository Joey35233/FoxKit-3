using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Fox
{
    [Serializable, StructLayout(LayoutKind.Explicit, Size = 16, CharSet = CharSet.Ansi)]
    public class Path
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
            Empty = new Path
            {
                _cString = string.Empty,
                _length = 0,
                _hash = new PathFileNameCode(string.Empty)
            };
        }

        private Path()
        {

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
                this._cString = Empty.CString;
                this._length = Empty.Length;
                this._hash = Empty.Hash;
            }
        }
    }
}