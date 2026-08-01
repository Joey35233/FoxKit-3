using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

namespace Fox.Geo
{
    public class RailFileWriter
    {
        public unsafe byte[] Write(UnityEngine.SceneManagement.Scene scene)
        {
            GameObject[] railObjects = scene.GetRootGameObjects();
            uint railCount = (uint)railObjects.Length;

            Spline[] splines = new Spline[railCount];
            RailNoteData[][] notesArrays = new RailNoteData[railCount][];

            uint vertexCount = 0;
            uint noteCount = 0;
            uint extensionCount = 0;
            for (uint i = 0; i < railCount; i++)
            {
                Spline spline = railObjects[i].GetComponent<SplineContainer>().Spline;
                RailNoteData[] notes = railObjects[i].GetComponent<RailData>().Notes;

                splines[i] = spline;
                notesArrays[i] = notes;

                vertexCount += (uint)spline.Count;
                noteCount += (uint)notes.Length;
                extensionCount += (uint)notes.Length * 2;
            }

            long dataSize = AlignmentUtils.Align(sizeof(RailFile.Header), 0x10)
                            + railCount * sizeof(RailFile.RailDef)
                            + vertexCount * sizeof(RailFile.RailVertex)
                            + noteCount * sizeof(RailFile.RailNote)
                            + extensionCount * sizeof(uint);
            
            byte[] data = new byte[dataSize];
            fixed (byte* dataPtr = data)
            {
                RailFile.Header* header = (RailFile.Header*)dataPtr;
                header->Signature = RailFile.Signature;
                header->Version = RailFile.FormatVersion.V2;
                header->RailCount = (ushort)railCount;

                RailFile.RailDef* rails = (RailFile.RailDef*)AlignmentUtils.Align((byte*)(header + 1), 0x10);
                RailFile.RailVertex* vertices = (RailFile.RailVertex*)(rails + railCount);
                RailFile.RailNote* notes = (RailFile.RailNote*)(vertices + vertexCount);
                uint* extensions = (uint*)(notes + noteCount);

                //uint writeOffset = (uint)sizeof(RailFile.Header) + (uint)sizeof(RailFile.RailDef) * railCount;
                for (uint i = 0; i < railCount; i++)
                {
                    Spline spline = splines[i];
                    RailNoteData[] noteData = notesArrays[i];
                    
                    RailFile.RailDef* rail = rails + i;

                    rail->VerticesOffset = (uint)((byte*)vertices - dataPtr);
                    rail->VertexCount = (ushort)spline.Count;

                    Vector3 boundsMin = Vector3.zero;
                    Vector3 boundsMax = Vector3.zero;
                    float arcLength = 0f;
                    for (int j = 0; j < spline.Count; j++)
                    {
                        BezierKnot knot = spline[j];

                        // BezierKnots store mirorred tangents in Rotation, TangentIn/Out is +/-Vector3.forward * length
                        float3 tangentOut = math.rotate(knot.Rotation, knot.TangentOut);
                        Vector3 tangent = Math.UnityToFoxVector3((Vector3)tangentOut * 3f);
                        Vector3 position = Math.UnityToFoxVector3(knot.Position);

                        vertices[j].Position = position;
                        vertices[j].ArcLength = arcLength;
                        vertices[j].Tangent = tangent;
                        vertices[j].TangentLength = tangent.magnitude;

                        if (j == 0)
                            boundsMin = boundsMax = position;
                        else
                        {
                            boundsMin = Vector3.Min(boundsMin, position);
                            boundsMax = Vector3.Max(boundsMax, position);
                        }

                        arcLength += spline.GetCurveLength(j);
                    }
                    vertices += rail->VertexCount;

                    rail->Min = boundsMin;
                    rail->Max = boundsMax;

                    rail->NotesOffset = (uint)((byte*)notes - dataPtr);
                    rail->NoteCount = (ushort)noteData.Length;

                    for (uint j = 0; j < (uint)noteData.Length; j++)
                    {
                        notes[j].Position = noteData[j].Position;
                        notes[j].ExtensionStartIndex = (ushort)j;
                        notes[j].Id = GeoModule.GetRailNoteId(noteData[j].Name);
                        notes[j].Type = noteData[j].Condition;
                    }
                    notes += rail->NoteCount;

                    rail->ExtensionsOffset = (uint)((byte*)extensions - dataPtr);
                    
                    extensions += rail->NoteCount * 2;
                }
            }

            return data;
        }
    }
}