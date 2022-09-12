using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace JL
{
    //[CustomEditor(typeof(Transform))]
    [CanEditMultipleObjects]
    public class CustomTransformInspector : Editor
    {
        Vector3Field positionField;
        Vector3Field rotationField;
        Vector3Field scaleField;

        struct MixedHelper
        {
            public bool x;
            public bool y;
            public bool z;
        }

        public override VisualElement CreateInspectorGUI()
        {
            VisualElement root = new VisualElement();

            positionField = new Vector3Field("Position");
            root.Add(positionField);
            positionField.RegisterValueChangedCallback(eventData =>
            {
                foreach (GameObject selected in Selection.gameObjects)
                {
                    Undo.RecordObject(selected.transform, "ChangePosition");
                    selected.transform.localPosition = eventData.newValue;
                }
            });

            rotationField = new Vector3Field("Rotation");
            root.Add(rotationField);
            rotationField.RegisterValueChangedCallback(eventData =>
            {
                foreach (GameObject selected in Selection.gameObjects)
                {
                    Undo.RecordObject(selected.transform, "ChangeRotation");
                    TransformUtils.SetInspectorRotation(selected.transform, eventData.newValue);
                }
            });

            scaleField = new Vector3Field("Scale");
            root.Add(scaleField);
            scaleField.RegisterValueChangedCallback(eventData =>
            {
                foreach (GameObject selected in Selection.gameObjects)
                {
                    Undo.RecordObject(selected.transform, "ChangeScale");
                    selected.transform.localScale = eventData.newValue;
                }
            });

            OnSceneGUI();

            Label label = new Label("It's working");
            root.Add(label);

            return root;
        }


        private void OnSceneGUI()
        {
            Vector3 displayPos;
            Vector3 displayRot;
            Vector3 displayScale;

            if (!Selection.activeGameObject || !Selection.activeGameObject.transform) return;

            Transform mainT = Selection.activeGameObject.transform;
            displayPos = mainT.localPosition;
            displayRot = TransformUtils.GetInspectorRotation(mainT);
            displayScale = mainT.localScale;

            MixedHelper posMixed = new MixedHelper();
            MixedHelper rotMixed = new MixedHelper();
            MixedHelper scaleMixed = new MixedHelper();

            foreach (GameObject selected in Selection.gameObjects)
            {
                Transform t = selected.transform;

                if (displayPos.x != t.localPosition.x) posMixed.x = true;
                if (displayPos.y != t.localPosition.y) posMixed.y = true;
                if (displayPos.z != t.localPosition.z) posMixed.z = true;

                Vector3 rotation = TransformUtils.GetInspectorRotation(t);

                if (displayRot.x != rotation.x) rotMixed.x = true;
                if (displayRot.y != rotation.y) rotMixed.y = true;
                if (displayRot.z != rotation.z) rotMixed.z = true;

                if (displayScale.x != t.localScale.x) scaleMixed.x = true;
                if (displayScale.y != t.localScale.y) scaleMixed.y = true;
                if (displayScale.z != t.localScale.z) scaleMixed.z = true;
            }

            positionField.SetValueWithoutNotify(displayPos);
            rotationField.SetValueWithoutNotify(displayRot);
            scaleField.SetValueWithoutNotify(displayScale);

            XYZisMixed(positionField, posMixed);
            XYZisMixed(rotationField, rotMixed);
            XYZisMixed(scaleField, scaleMixed);
        }

        void XYZisMixed(Vector3Field vector3Field, MixedHelper mixed)
        {
            ShowMixed(vector3Field, "x", mixed.x);
            ShowMixed(vector3Field, "y", mixed.y);
            ShowMixed(vector3Field, "z", mixed.z);
        }
        void ShowMixed(Vector3Field vector3Field, string axis, bool mixed)
        {
            TextInputBaseField<float> inputText = vector3Field.Q<FloatField>($"unity-{axis}-input")
                                .Q<TextInputBaseField<float>>();
            inputText.showMixedValue = mixed;
        }
    }
}