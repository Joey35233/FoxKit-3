using UnityEngine;

namespace Fox.Core
{
    public static class GameObjectExtensions
    {
        public static T GetEntity<T>(this GameObject gameObject) where T : Entity
        {
            var entityComponent = gameObject.GetComponent<FoxEntity>();

            return entityComponent.Entity as T;
        }

        public static FoxEntity GetEntityComponent<T>(this GameObject gameObject) where T : Entity
        {
            var entityComponent = gameObject.GetComponent<FoxEntity>();

            return entityComponent.Entity is T ? entityComponent : null;
        }
    }
}