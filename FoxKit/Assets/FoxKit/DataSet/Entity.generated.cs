namespace Fox
{
    class Entity
    {
        private static EntityInfo entityInfo;

        static Entity()
        {
            entityInfo = new EntityInfo(new String("Entity"), null, -1, null, 2);
        }

        public static EntityInfo GetClassEntityInfo()
        {
            return entityInfo;
        }

        public Entity()
        {

        }
    }
}