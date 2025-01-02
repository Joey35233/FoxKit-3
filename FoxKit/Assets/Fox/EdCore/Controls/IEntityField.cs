using System;
using Fox.Core;
using UnityEditor;
using UnityEngine.UIElements;

namespace Fox.EdCore
{
    internal interface IEntityField : IFoxField
    {
        public event Action<VisualElement, SerializedObject> OnBuildHeader;
        public event Action<VisualElement, SerializedObject> OnBuildBody;
        public event Action<VisualElement, SerializedObject> OnBuildFooter;
        
        void Build(SerializedObject serializedObject);
    }
}