using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

using Fox.Core;

namespace Fox.Editor
{
    public class BindingTestClass : ScriptableObject
    {
        public short val;
    }

    public class BindingTestWindow : EditorWindow
    {
        [MenuItem("FoxKit/Debug/BindingTestWindow")]
        static void Init()
        {
            var window = EditorWindow.GetWindow<BindingTestWindow>(true, "BindingTestWindow");
            window.Draw();
            window.Show();
        }

        SerializedObject serializedObject;

        Int16Field field;

        public void Draw()
        {
            VisualElement visualInput = new VisualElement();

            var testClass = ScriptableObject.CreateInstance<BindingTestClass>();
            serializedObject = new SerializedObject(testClass);

            field = new Int16Field();
            field.bindingPath = "val";
            field.RegisterValueChangedCallback<short>((ChangeEvent<short> evt) => Debug.Log($"v: changed"));
            field.RegisterValueChangedCallback<int>((ChangeEvent<int> evt) => Debug.Log($"sp: changed"));
            visualInput.Add(field);

            var mbutton1 = new Button { text = "murder1" };
            mbutton1.clicked += murder1;
            visualInput.Add(mbutton1);

            var mbutton2 = new Button { text = "murder2" };
            mbutton2.clicked += murder2;
            visualInput.Add(mbutton2);

            var pbutton = new Button { text = "print" };
            pbutton.clicked += print;
            visualInput.Add(pbutton);

            visualInput.Bind(serializedObject);

            rootVisualElement.Add(visualInput);
        }

        private void murder1()
        {
            serializedObject.FindProperty("val").intValue = unchecked((int)-100);
            serializedObject.ApplyModifiedProperties();

            return;
        }

        private void murder2()
        {
            field.value = 101;

            return;
        }

        private void print()
        {
            Debug.Log($"SP: {unchecked((short)serializedObject.FindProperty("val").intValue)}, v: {field.value}");

            return;
        }
    }
}
