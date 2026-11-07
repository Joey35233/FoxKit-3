using System;
using System.Collections.Generic;
using Fox.Core.Utils;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;

namespace Fox.Geo
{
    public class RailFileWriter
    {
        public unsafe byte[] Write(Scene scene, TaskLogger logger = null)
        {
            GameObject[] rootGameObjects = scene.GetRootGameObjects();
            List<SplineContainer> containers = new List<SplineContainer>(rootGameObjects.Length);
            foreach (GameObject rootGameObject in rootGameObjects)
                if (rootGameObject.TryGetComponent(out SplineContainer splineContainer))
                    containers.Add(splineContainer);

            int railCount = containers.Count;

            if (railCount > ushort.MaxValue)
            {
                logger?.AddError("Too many rails to export.");
                return null;
            }

            Spline[] splines = new Spline[railCount];
            RailNoteData[][] noteDataArrays = new RailNoteData[railCount][];
            uint totalVertexCount = 0;
            uint totalNoteCount = 0;
            long totalExtensionsWriteSize = 0;
            for (int i = 0; i < railCount; i++)
            {
                Spline spline = containers[i].Spline;
                RailNoteData[] sourceNoteDatas = containers[i].GetComponent<RailData>()?.Notes ?? Array.Empty<RailNoteData>();

                splines[i] = spline;

                totalVertexCount += (uint)spline.Count;

                if (spline.Count > ushort.MaxValue || sourceNoteDatas.Length > ushort.MaxValue)
                {
                    logger?.AddError($"Rail {i} has too many vertices or notes to export.");
                    return null;
                }
                
                // Preserve the supplied order at equal distances (e.g. end, then start).
                int[] noteOrder = new int[sourceNoteDatas.Length];
                for (int j = 0; j < noteOrder.Length; j++)
                    noteOrder[j] = j;
                
                Array.Sort(noteOrder, (a, b) =>
                {
                    int distance = sourceNoteDatas[a].Position.CompareTo(sourceNoteDatas[b].Position);
                    return distance != 0 ? distance : a.CompareTo(b);
                });
                
                RailNoteData[] sortedNoteDatas = new RailNoteData[sourceNoteDatas.Length];
                int extensionCount = 0;
                for (int j = 0; j < sortedNoteDatas.Length; j++)
                {
                    sortedNoteDatas[j] = sourceNoteDatas[noteOrder[j]];

                    switch (sortedNoteDatas[j].Flags)
                    {
                        case RailFile.RailNoteFlags.None: 
                        case RailFile.RailNoteFlags.Start:
                            extensionCount++;
                            break;
                        default:
                            break;
                    }
                }
                
                noteDataArrays[i] = sortedNoteDatas;
                totalNoteCount += (uint)sortedNoteDatas.Length;
                
                if (extensionCount > 0)
                    totalExtensionsWriteSize += AlignmentUtils.Align((long)extensionCount * sizeof(float), 32);
            }

            long dataSize = AlignmentUtils.Align(sizeof(RailFile.Header), 0x10)
                            + railCount * sizeof(RailFile.RailDef)
                            + totalVertexCount * sizeof(RailFile.RailVertex)
                            + totalNoteCount * sizeof(RailFile.RailNote)
                            + totalExtensionsWriteSize;

            byte[] data = new byte[dataSize];
            fixed (byte* dataPtr = data)
            {
                RailFile.Header* header = (RailFile.Header*)dataPtr;
                header->Signature = RailFile.Signature;
                header->Version = RailFile.FormatVersion.V2;
                header->RailCount = (ushort)railCount;

                RailFile.RailDef* rails = (RailFile.RailDef*)AlignmentUtils.Align((byte*)(header + 1), 0x10);
                RailFile.RailVertex* vertices = (RailFile.RailVertex*)(rails + railCount);
                RailFile.RailNote* notes = (RailFile.RailNote*)(vertices + totalVertexCount);
                uint* extensionData = (uint*)(notes + totalNoteCount);

                Span<int> spanExtensionIndices = stackalloc int[GeoModule.MaxRailNoteTypes];
                for (uint i = 0; i < railCount; i++)
                {
                    Spline spline = splines[i];

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
                    rail->ExtensionsOffset = (uint)((byte*)extensionData - dataPtr);

                    RailNoteData[] noteDatas = noteDataArrays[i];
                    rail->NoteCount = (ushort)noteDatas.Length;
                    float* extensions = (float*)extensionData;
                    int extensionCount = 0;
                    spanExtensionIndices.Fill(-1);
                    for (ushort j = 0; j < rail->NoteCount; j++)
                    {
                        RailNoteData noteData = noteDatas[j];

                        int typeId = GeoModule.GetRailNoteTypeId(noteData.Name);

                        if (float.IsNaN(noteData.Position) || float.IsInfinity(noteData.Position) || noteData.Position < 0)
                        {
                            logger?.AddError($"Rail {i} has an invalid note '{noteData.Name}'.");
                            return null;
                        }

                        int extensionIndex;
                        switch (noteData.Flags)
                        {
                            case RailFile.RailNoteFlags.None:
                                extensionIndex = extensionCount++;

                                *extensions++ = noteData.Extension;
                                break;
                            case RailFile.RailNoteFlags.Start:
                                if (spanExtensionIndices[typeId] >= 0)
                                {
                                    logger?.AddError($"Rail {i} has overlapping notes of type {typeId}.");
                                    return null;
                                }

                                extensionIndex = extensionCount++;
                                spanExtensionIndices[typeId] = extensionIndex;

                                *extensions++ = noteData.Extension;
                                break;
                            case RailFile.RailNoteFlags.End:
                                extensionIndex = spanExtensionIndices[typeId];
                                if (extensionIndex < 0)
                                {
                                    logger?.AddError($"Rail {i} has an end note without a start.");
                                    return null;
                                }

                                spanExtensionIndices[typeId] = -1;
                                break;
                            default:
                                logger?.AddError($"Rail {i} has invalid note flags {noteData.Flags}.");
                                return null;
                        }

                        notes[j] = new RailFile.RailNote
                        {
                            Position = noteData.Position,
                            ExtensionStartIndex = (ushort)extensionIndex,
                            TypeId = (byte)typeId,
                            Flags = noteData.Flags,
                        };
                    }

                    notes += rail->NoteCount;

                    // Ensure extension array is closed by the time all notes have been written
                    foreach (int active in spanExtensionIndices)
                    {
                        if (active >= 0)
                        {
                            logger?.AddError($"Rail {i} has a start note without an end.");
                            return null;
                        }
                    }

                    if (extensionCount > 0)
                        extensionData += AlignmentUtils.Align((long)extensionCount * sizeof(float), 32) / sizeof(uint);
                }
            }

            return data;
        }
    }
}
