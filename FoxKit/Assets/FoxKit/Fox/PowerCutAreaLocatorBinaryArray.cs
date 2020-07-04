namespace Fox
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class PowerCutAreaLocatorBinaryArray
    {
        [SerializeReference]
        public List<PowerCutAreaLocatorBinary> locators = new List<PowerCutAreaLocatorBinary>();

        public PowerCutAreaLocatorBinaryArray(int capacity)
        {
            this.locators = new List<PowerCutAreaLocatorBinary>(capacity);
        }

        public PowerCutAreaLocatorBinaryArray()
        {
            this.locators = new List<PowerCutAreaLocatorBinary>();
        }
    }
}