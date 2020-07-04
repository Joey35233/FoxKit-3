namespace Fox
{
    using System;
    using UnityEngine;

    [Serializable]
    public class Data : Entity
    {
        public Fox.String name;

        // FIXME This should be an EntityHandle
        [SerializeReference]
        public DataSet dataSet;
    }
}