using UnityEngine;

namespace Fox.Core
{
    [ExecuteInEditMode]
    public class FoxEntity : MonoBehaviour
    {
        [SerializeReference]
        public Entity Entity;

        private void Awake()
        {
            Entity.Awake(this.gameObject);
        }

        private void Start()
        {
            Entity.Start(this.gameObject);
        }
    }
}