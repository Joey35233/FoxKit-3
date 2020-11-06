using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public class StringMap<T> : IEnumerable<StringMap<T>.Cell>
    {
        private class Cell
        {
            public String Key;
            public Cell cUnknown0;
            public Cell cUnknown1;
            public Cell cUnknown2;
            public T Value;
        }

        private List<Cell> Cells;

        public T this[String key]
        {
            get => GetT(key);
        }
        private T GetT(String key)
        {
            throw new System.NotImplementedException();
            return Cells[0].Value;
        }

        public bool TryGet(String key, out T value)
        {
            throw new System.NotImplementedException();
            value = Cells[0].Value;
        }

        public void Insert(String key, T value)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeHashSize(uint newSize)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        internal bool ContainsKey(String name)
        {
            throw new NotImplementedException();
        }
    }
}