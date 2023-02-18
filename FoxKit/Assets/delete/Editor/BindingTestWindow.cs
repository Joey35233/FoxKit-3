using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Fox.Editor
{
    public class BindingTestClass : ScriptableObject
    {
        public short val;
    }

    public class BindingTestWindow : EditorWindow
    {
        [MenuItem("FoxKit/Debug/BindingTestWindow")]
        private static void Init()
        {
            BindingTestWindow window = EditorWindow.GetWindow<BindingTestWindow>(true, "BindingTestWindow");
            window.Draw();
            window.Show();
        }

        private SerializedObject serializedObject;
        private Int16Field field;

        public void Draw()
        {
            var visualInput = new VisualElement();

            BindingTestClass testClass = ScriptableObject.CreateInstance<BindingTestClass>();
            serializedObject = new SerializedObject(testClass);

            field = new Int16Field
            {
                bindingPath = "val"
            };
            _ = field.RegisterValueChangedCallback<short>((ChangeEvent<short> evt) => Debug.Log($"v: changed"));
            _ = field.RegisterValueChangedCallback<int>((ChangeEvent<int> evt) => Debug.Log($"sp: changed"));
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
            serializedObject.FindProperty("val").intValue = unchecked(-100);
            _ = serializedObject.ApplyModifiedProperties();

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
