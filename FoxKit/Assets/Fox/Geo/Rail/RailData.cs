using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Splines;

namespace Fox.Geo
{
    [Serializable]
    public struct RailNoteData
    {
        public float Position;
        public float Extension;
        public string Name;
        public RailFile.RailNoteType Condition;
    }

    [RequireComponent(typeof(SplineContainer))]
    public class RailData : MonoBehaviour
    {
        public bool TrimNotes = true;
        
        public RailNoteData[] Notes;

        private static readonly Color NoteColor = new(1f, 0.6f, 0f);

        private void DrawGizmos(bool isSelected)
        {
            if (Notes is null || Notes.Length == 0)
                return;

            Spline spline = GetComponent<SplineContainer>().Spline;
            if (spline is null || spline.Count == 0)
                return;

            float length = spline.GetLength();

            Gizmos.color = isSelected ? Color.white : NoteColor;

            uint repeatCount = 0;
            float lastPosition = float.NaN;
            foreach (RailNoteData note in Notes)
            {
                if (TrimNotes && note.Position > (length + 0.5f))
                    continue;
                
                Vector3 localPosition = spline.GetPointAtLinearDistance(0f, note.Position, out _);
                Vector3 worldPosition = transform.TransformPoint(localPosition);

                Gizmos.DrawSphere(worldPosition, 0.1f);

                if (note.Position == lastPosition)
                    repeatCount++;
                else
                    repeatCount = 0;
                
                worldPosition += Vector3.up * repeatCount * 0.2f;

                if (!isSelected)
                    Handles.Label(worldPosition, $"{note.Name} = {note.Extension}");

                lastPosition = note.Position;
            }
        }

        private void OnDrawGizmos() => DrawGizmos(false);

        private void OnDrawGizmosSelected() => DrawGizmos(true);
    }
}
