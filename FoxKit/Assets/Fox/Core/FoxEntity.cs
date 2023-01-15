using UnityEngine;

namespace Fox.Core
{
    [ExecuteInEditMode]
    public class FoxEntity : MonoBehaviour
    {
        [SerializeReference]
        public Entity Entity;
    }
}