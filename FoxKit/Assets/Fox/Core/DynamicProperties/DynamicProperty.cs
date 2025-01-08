using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fox.Core
{
    public abstract class DynamicProperty : MonoBehaviour

    {
        public string Name;

        public abstract Value GetValue();
    }
}