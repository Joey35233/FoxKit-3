using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox.Kernel
{
    [System.Serializable]
    public class StaticArray<T> : IList<T>, IList
    {
        [SerializeField]
        private List<T> _list;

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        bool IList.IsFixedSize => true;

        bool IList.IsReadOnly => IsReadOnly;

        int ICollection.Count => _list.Count;

        bool ICollection.IsSynchronized => throw new NotImplementedException();

        object ICollection.SyncRoot => throw new NotImplementedException();

        object IList.this[int index] { get => this[index]; set => throw new NotImplementedException(); }
        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int IndexOf(T item) => _list.IndexOf(item);

        public void Insert(int index, T item)
        {
            if (index < Count)
                _list.Insert(index, item);
            else
                throw new ArgumentOutOfRangeException();
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
                _list.RemoveAt(index);
            else
                throw new ArgumentOutOfRangeException();
        }

        public void Add(T item) => throw new NotImplementedException();

        public void Clear() => _list.Clear();

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public bool Remove(T item) => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        int IList.Add(object value) => throw new NotImplementedException();

        void IList.Clear() => Clear();

        bool IList.Contains(object value) => throw new NotImplementedException();

        int IList.IndexOf(object value) => throw new NotImplementedException();

        void IList.Insert(int index, object value)
        {
            if (index < Count)
                _list.Insert(index, (T)value);
            else
                throw new ArgumentOutOfRangeException();
        }

        void IList.Remove(object value) => throw new NotImplementedException();

        void IList.RemoveAt(int index) => throw new NotImplementedException();

        void ICollection.CopyTo(Array array, int index) => throw new NotImplementedException();

        public StaticArray(int capacity)
        {
            _list = new List<T>(capacity);
            for (int i = 0; i < capacity; i++)
                _list.Add(default);
        }
    }
}