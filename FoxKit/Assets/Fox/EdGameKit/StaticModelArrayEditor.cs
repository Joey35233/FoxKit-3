using Fox;
using Fox.GameKit;
using UnityEngine;
using UnityEditor;

namespace Fox.EdGameKit
{
    [CustomEditor(typeof(StaticModelArray))]
    public class StaticModelArrayEditor : Fox.EdCore.EntityEditor
    {
        private int SelectedInstanceIndex = -1;

        private void OnSceneGUI()
        {
            StaticModelArray modelArray = (StaticModelArray)target;

            if (modelArray.transforms == null || modelArray.transforms.Count == 0)
                return;

            for (int i = 0; i < modelArray.transforms.Count; i++)
            {
                Matrix4x4 matrix = modelArray.transforms[i];
                Vector3 position = matrix.GetColumn(3);
                Quaternion rotation = Quaternion.LookRotation(matrix.GetColumn(2), matrix.GetColumn(1));
                Vector3 scale = new Vector3(matrix.GetColumn(0).magnitude, matrix.GetColumn(1).magnitude, matrix.GetColumn(2).magnitude);

                // Draw a handle for each instance
                if (Handles.Button(position, Quaternion.identity, 0.1f, 0.1f, Handles.SphereHandleCap))
                {
                    SelectedInstanceIndex = i;
                }

                // If selected, show position handles
                if (SelectedInstanceIndex == i)
                {
                    EditorGUI.BeginChangeCheck();
                    Vector3 newPosition = Handles.PositionHandle(position, rotation);
                    Quaternion newRotation = Handles.RotationHandle(rotation, position);

                    if (EditorGUI.EndChangeCheck())
                    {
                        Matrix4x4 newMatrix = Matrix4x4.TRS(newPosition, newRotation, scale);
                        modelArray.UpdateInstance(i, newMatrix);
                        EditorApplication.QueuePlayerLoopUpdate();
                    }
                }
            }
        }

        // public override void OnInspectorGUI()
        // {
        //     base.OnInspectorGUI();
        //
        //     StaticModelArray modelArray = (StaticModelArray)target;
        //
        //     if (GUILayout.Button("Add Instance"))
        //     {
        //         modelArray.AddInstance(Vector3.zero, Quaternion.identity, Vector3.one);
        //     }
        //
        //     if (GUILayout.Button("Clear Instances"))
        //     {
        //         modelArray.transforms.Clear();
        //     }
        // }
    }
}