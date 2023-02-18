using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tpp.GameKit
{
    [Serializable]
    public class PowerCutAreaLocatorBinaryArray
    {
        [SerializeReference]
        public List<PowerCutAreaLocatorBinary> locators = new();

        public PowerCutAreaLocatorBinaryArray(int capacity)
        {
            locators = new List<PowerCutAreaLocatorBinary>(capacity);
        }

        public PowerCutAreaLocatorBinaryArray()
        {
            locators = new List<PowerCutAreaLocatorBinary>();
        }
    }
}