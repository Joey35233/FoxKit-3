using Fox.Core;
using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;
using PropertyInfo = Fox.Core.PropertyInfo;

namespace Fox.EdCore.Testing
{
    public class TestClassField : BaseField<Object>
    {
        public TestClassField() : this(null, new VisualElement())
        {
        }
        
        public TestClassField(string label, VisualElement visualInput) : base(label, visualInput)
        {
            Button addButton = new Button();
            addButton.text = "Add";
            addButton.clicked += () =>
            {
                GameObject newGameObject = new GameObject();
                TestClass newTestClass = newGameObject.AddComponent<TestClass>();

                value = newTestClass;
            };
            visualInput.Add(addButton);
            
            TextField textField = new TextField();
            visualInput.Add(textField);
        }

        protected override void HandleEventTrickleDown(EventBase evt)
        {
            base.HandleEventTrickleDown(evt);
            
            // if (evt is changeevent)
        }
    }
}