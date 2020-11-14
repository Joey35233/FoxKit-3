using Fox;
using System.Collections.Generic;

namespace Fox
{
    [System.Serializable]
    public class DataSet : Data
    {
        public List<Data> dataList = new List<Data>();
    }
}