using System;
using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    public interface IEntityField : IFoxField
    {
        public void Build(SerializedObject serializedObject);
    }
}