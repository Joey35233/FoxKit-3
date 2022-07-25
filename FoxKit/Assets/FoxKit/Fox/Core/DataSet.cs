using System;
using UnityEngine;

namespace Fox.Core
{
    public partial class DataSet : Fox.Core.Data
    {
        public StringMap<EntityHandle> allocatedEntities { get; private set; } = new StringMap<EntityHandle>();
    }
}