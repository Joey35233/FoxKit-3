using System.Threading;

namespace Fox
{
    public struct EntityHandle
    {
        uint placeholder;

        public static EntityHandle Get(Entity entity)
        {
            return new EntityHandle();
        }

        public static bool operator==(EntityHandle a, EntityHandle b)
        {
            return true;
        }

        public static bool operator!=(EntityHandle a, EntityHandle b)
        {
            return false;
        }
    }
}
