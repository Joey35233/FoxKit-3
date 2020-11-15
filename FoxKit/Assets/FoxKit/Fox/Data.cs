using Fox;

namespace Fox
{
    [System.Serializable]
    public class Data : Entity
    {
        public string name;
        public EntityHandle dataSet = EntityHandle.Empty();
    }
}