using UnityEngine;
using UnityEditor;

namespace Fox.Tactical
{
    [CustomEditor(typeof(GkTacticalActionGizmo))]
    public class GkTacticalActionEditor : Editor
    {
        void OnSceneGUI()
        {
            GkTacticalActionGizmo t = target as GkTacticalActionGizmo;

            // Set the colour of the next handle to be drawn
            Handles.color = Color.magenta;

            EditorGUI.BeginChangeCheck();
            for (int i = 0; i < t.Waypoints.Length; i++)
            {
                Vector3 lookTarget = Handles.PositionHandle(t.Waypoints[i], Quaternion.identity);

                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(target, "Changed Look Target");
                    t.Waypoints[i] = lookTarget;
                    t.Update();
                }
            }
        }
    }
}
