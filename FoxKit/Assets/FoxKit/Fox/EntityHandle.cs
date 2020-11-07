namespace Fox
{
    [System.Serializable]
    public class EntityHandle
    {
        public static EntityHandle Get(Entity entity)
        {
            return new EntityHandle();
        }
    }
}
