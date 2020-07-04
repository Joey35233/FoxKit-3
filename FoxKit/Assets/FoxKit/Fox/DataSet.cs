namespace Fox
{
    using System;
    using UnityEngine;

    [Serializable]
    public class DataSet : Data
    {
        // FIXME This should be StringMap<EntityPtr<Data>>
        [SerializeReference]
        public StringMap<Data> dataList = new StringMap<Data>();
    }
}