using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fox.Kernel;

namespace Fox.Core
{
    public class FoxEntity : MonoBehaviour
    {
        [SerializeReference]
        public Entity Entity;
    }
}