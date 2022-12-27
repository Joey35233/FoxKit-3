using UnityEngine;
using Fox.Kernel;
using String = Fox.Kernel.String;

namespace Fox.Core
{
    public partial class DataElement : Fox.Core.Entity
    {
        public void SetOwner(Data entity)
        {
            owner = EntityHandle.Get(entity);
        }
    }
}