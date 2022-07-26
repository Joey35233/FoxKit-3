namespace Fox.Core
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FoxEntity : MonoBehaviour
    {
        [SerializeReference]
        public Entity Entity; 
    }
}