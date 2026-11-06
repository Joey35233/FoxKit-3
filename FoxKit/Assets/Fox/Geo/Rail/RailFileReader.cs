using Fox.Core.Utils;
using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Splines;

namespace Fox.Geo
{
    public class RailFileReader
    {
        public unsafe UnityEngine.SceneManagement.Scene? Read(ReadOnlySpan<byte> data, TaskLogger logger)
        {
            fixed (byte* dataPtr = data)
            {
                RailFile.Header* header = (RailFile.Header*)dataPtr;

                if (header->Signature != RailFile.Signature)
                {
                    logger.AddError($"Read failed. Not a RAIL.");
                    return null;
                }

                if (header->Version != RailFile.FormatVersion.V2)
                {
                    logger.AddError($"Version {header->Version} isn't supported");
                    return null;
                }

                UnityEngine.SceneManagement.Scene scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

                RailFile.RailDef* rails = (RailFile.RailDef*)AlignmentUtils.Align((byte*)(header + 1), 0x10);
                for (int i = 0; i < header->RailCount; i++)
                {
                    RailFile.RailDef* rail = rails + i;

                    GameObject railObject = new GameObject($"Rail{i:D4}");

                    SplineContainer splineContainer = railObject.AddComponent<SplineContainer>();
                    Spline spline = splineContainer.Spline;
                    spline.Clear();

                    RailFile.RailVertex* vertices = (RailFile.RailVertex*)(dataPtr + rail->VerticesOffset);
                    for (int j = 0; j < rail->VertexCount; j++)
                    {
                        RailFile.RailVertex* vertex = vertices + j;

                        Vector3 position = Math.FoxToUnityVector3(vertex->Position);
                        Vector3 tangent = Math.FoxToUnityVector3(vertex->Tangent) / 3f;

                        spline.Add(new BezierKnot(position, -tangent, tangent), TangentMode.Mirrored);
                    }

                    RailFile.RailNote* notes = (RailFile.RailNote*)(dataPtr + rail->NotesOffset);
                    uint* extensions = (uint*)(dataPtr + rail->ExtensionsOffset);

                    RailNoteData[] noteDatas = new RailNoteData[rail->NoteCount];
                    for (int j = 0; j < rail->NoteCount; j++)
                    {
                        RailFile.RailNote* note = notes + j;
                        noteDatas[j] = new RailNoteData
                        {
                            Position = note->Position,
                            Extension = *(float*)(extensions + note->ExtensionStartIndex),
                            Name = GeoModule.RailNoteNames[note->Id],
                            Condition = note->Type,
                        };
                    }

                    RailData railData = railObject.AddComponent<RailData>();
                    railData.Notes = noteDatas;
                }

                return scene;
            }
        }
    }
}
