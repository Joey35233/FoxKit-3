using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace FoxKit.DataSet
{
    class DataSet
    {
        public DataSet()
        {

        }

        public DataSet(byte[] data)
        {
            Data = data;
        }

        private byte[] Data;
    }
}