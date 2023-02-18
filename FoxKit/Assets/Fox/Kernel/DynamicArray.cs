using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox.Kernel
{
    [System.Serializable]
    public class DynamicArray<T> : IList<T>, IList
    {
        [SerializeField]
        private List<T> _list;

        public int Capacity => _list.Capacity;

        public int Count => _list.Count;

        public bool IsReadOnly => false;

        bool IList.IsFixedSize => false;

        bool IList.IsReadOnly => IsReadOnly;

        int ICollection.Count => _list.Count;

        bool ICollection.IsSynchronized => throw new NotImplementedException();

        object ICollection.SyncRoot => throw new NotImplementedException();

        object IList.this[int index] { get => this[index]; set => _list[index] = (T)value; }
        public T this[int index] { get => _list[index]; set => _list[index] = value; }

        public int IndexOf(T item) => _list.IndexOf(item);

        public void Insert(int index, T item) => _list.Insert(index, item);

        public void RemoveAt(int index) => _list.RemoveAt(index);

        public void Add(T item) => _list.Add(item);

        public void Clear() => _list.Clear();

        public bool Contains(T item) => _list.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _list.CopyTo(array, arrayIndex);

        public bool Remove(T item) => _list.Remove(item);

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _list.GetEnumerator();

        int IList.Add(object value)
        {
            Add((T)value);
            return Count - 1;
        }

        void IList.Clear() => Clear();

        bool IList.Contains(object value) => Contains((T)value);

        int IList.IndexOf(object value) => IndexOf((T)value);

        void IList.Insert(int index, object value) => Insert(index, (T)value);

        void IList.Remove(object value) => Remove((T)value);

        void IList.RemoveAt(int index) => RemoveAt(index);

        void ICollection.CopyTo(Array array, int index) => CopyTo((T[])array, index);

        public DynamicArray()
        {
            _list = new List<T>();
        }

        public DynamicArray(int capacity)
        {
            _list = new List<T>(capacity);
        }
    }
}