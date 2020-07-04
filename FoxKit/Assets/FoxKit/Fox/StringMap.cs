using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Fox
{
    public class StringMap<T> : IEnumerable<StringMap<T>.Cell>
    {
        public class Cell
        {

        }

        IEnumerator<Cell> IEnumerable<Cell>.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

    }
}