using UnityEditor;
using UnityEngine;

namespace Fox.Anim
{
    public partial class MtarFile
    {
        private static unsafe AnimationCurve CreateCurve(TrackUnit* trackUnit) => new AnimationCurve
        {
            preWrapMode = WrapMode.Clamp,
            postWrapMode = trackUnit->Flags.HasFlag(TrackUnit.UnitFlags.Loop) ? WrapMode.Loop : WrapMode.Once
        };
        
        public static unsafe AnimationClip Convert(byte[] file)
        {
            fixed (byte* fileData = file)
            {
                MtarHeader* header = (MtarHeader*)fileData;

                if (header->Flags.HasFlag(MtarHeader.FeatureFlags.New))
                {
                    TrackHeader* layoutTrack = header->GetLayoutTrack();
                    if (layoutTrack == null)
                        return null;
                    
                    // Pick first file and read MTAR metadata for it
                    Mtar2FileHeader* fileHeader = header->GetFile2Headers();
                    
                    // Make Unity animation clip
                    AnimationClip clip = new AnimationClip
                    {
                        name = fileHeader->Path.ToString()
                    };

                    // Read GANI data
                    Gani2TrackHeader* trackHeader = (Gani2TrackHeader*)((byte*)header + fileHeader->DataOffset);
                    Gani2TrackData* gani2TrackDataArray;
                    { 
                        byte* paramEndPtr = (byte*)trackHeader + sizeof(Gani2TrackHeader) + trackHeader->ParamCount * sizeof(Gani2Param) + header->TrackCount * sizeof(TrackUnit.UnitFlags);
				
                        ulong intPtr = (ulong)paramEndPtr;
                        intPtr += (uint)sizeof(Gani2TrackData) - 1u;
                        intPtr &= unchecked((ulong)(-(long)sizeof(Gani2TrackData)));
                        gani2TrackDataArray = (Gani2TrackData*)intPtr;
                    }
                    
                    uint absTrackDataIndex = 0;
                    for (uint i = 0; i < layoutTrack->ChannelCount; i++)
                    {
                        TrackUnit* trackUnit = layoutTrack->GetUnit(i);

                        // Hack to get Unity to bind the root transform properly
                        if (trackUnit->Name == ConversionUtils.RootUnitName)
                        {
                            Debug.Assert(trackUnit->SegmentCount == 2);

                            {
                                TrackData* trackData = trackUnit->GetData(ConversionUtils.RootRotSegmentIndex);
                                Gani2TrackData* gani2TrackData = gani2TrackDataArray + absTrackDataIndex;
                                ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);
                                
                                Debug.Assert(trackData->Type == TrackType.QuatDiff);
                                
                                double time = 0;
                            
                                AnimationCurve curveX = CreateCurve(trackUnit);
                                AnimationCurve curveY = CreateCurve(trackUnit);
                                AnimationCurve curveZ = CreateCurve(trackUnit);
                                AnimationCurve curveW = CreateCurve(trackUnit);
                                
                                ulong inoutBitstreamPos = 0;
                                
                                Quaternion keyValue = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);

                                curveX.AddKey((float)time, keyValue.x);
                                curveY.AddKey((float)time, keyValue.y);
                                curveZ.AddKey((float)time, keyValue.z);
                                curveW.AddKey((float)time, keyValue.w);

                                if (!trackHeader->GetUnitFlags(i).HasFlag(TrackUnit.UnitFlags.NoFrames))
                                {
                                    while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                    {
                                        byte frameCount = (byte)TrackData.ReadUnalignedBits(trackDataBlob, ref inoutBitstreamPos, 8);
                                        time += frameCount * TrackData.PlaybackRate;

                                        Quaternion diff = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);
                                        keyValue *= diff;

                                        curveX.AddKey((float)time, keyValue.x);
                                        curveY.AddKey((float)time, keyValue.y);
                                        curveZ.AddKey((float)time, keyValue.z);
                                        curveW.AddKey((float)time, keyValue.w);
                                    }
                                }

                                for (int l = 0; l < curveX.keys.Length; l++)
                                {
                                    AnimationUtility.SetKeyLeftTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyRightTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyLeftTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyRightTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyLeftTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyRightTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyLeftTangentMode(curveW, l, AnimationUtility.TangentMode.Linear);
                                    AnimationUtility.SetKeyRightTangentMode(curveW, l, AnimationUtility.TangentMode.Linear);
                                }
                                
                                clip.SetCurve("", typeof(Transform), "m_LocalRotation.x", curveX);
                                clip.SetCurve("", typeof(Transform), "m_LocalRotation.y", curveY);
                                clip.SetCurve("", typeof(Transform), "m_LocalRotation.z", curveZ);
                                clip.SetCurve("", typeof(Transform), "m_LocalRotation.w", curveW);

                                absTrackDataIndex++;
                            }

                            {
                                TrackData* trackData = trackUnit->GetData(ConversionUtils.RootPosSegmentIndex);
                                Gani2TrackData* gani2TrackData = gani2TrackDataArray + absTrackDataIndex;
                                ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);
                                
                                Debug.Assert(trackData->Type == TrackType.RootPos);
                                
                                double time = 0;
                            
                                AnimationCurve curveX = CreateCurve(trackUnit);
                                AnimationCurve curveY = CreateCurve(trackUnit);
                                AnimationCurve curveZ = CreateCurve(trackUnit);
                                
                                byte* dataBlob = (byte*)trackDataBlob;
                                
                                Vector3 keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                curveX.AddKey((float)time, keyValue.x);
                                curveY.AddKey((float)time, keyValue.y);
                                curveZ.AddKey((float)time, keyValue.z);

                                if (!trackHeader->GetUnitFlags(i).HasFlag(TrackUnit.UnitFlags.NoFrames))
                                {
                                    while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                    {
                                        byte frameCount = *dataBlob; dataBlob++;
                                        time += frameCount * TrackData.PlaybackRate;

                                        keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                        keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                        curveX.AddKey((float)time, keyValue.x);
                                        curveY.AddKey((float)time, keyValue.y);
                                        curveZ.AddKey((float)time, keyValue.z);
                                    }
                                }
                                
                                clip.SetCurve("", typeof(Transform), "m_LocalPosition.x", curveX);
                                clip.SetCurve("", typeof(Transform), "m_LocalPosition.y", curveY);
                                clip.SetCurve("", typeof(Transform), "m_LocalPosition.z", curveZ);

                                absTrackDataIndex++;
                            }
                            
                            continue;
                        }

                        for (uint j = 0; j < trackUnit->SegmentCount; j++, absTrackDataIndex++)
                        {
                            // Parse TrackUnit
                            TrackData* trackData = trackUnit->GetData(j);
                            Gani2TrackData* gani2TrackData = gani2TrackDataArray + absTrackDataIndex;
                            ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);

                            double time = 0;
                            switch (trackData->Type)
                            {
                                case TrackType.Quat:
                                {
                                    AnimationCurve curveX = CreateCurve(trackUnit);
                                    AnimationCurve curveY = CreateCurve(trackUnit);
                                    AnimationCurve curveZ = CreateCurve(trackUnit);
                                    AnimationCurve curveW = CreateCurve(trackUnit);
                                    
                                    ulong inoutBitstreamPos = 0;
                                    
                                    Quaternion keyValue = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);
                                    
                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                    curveW.AddKey((float)time, keyValue.w);

                                    // string debugString = "";
                                    // if (absTrackDataIndex == 21)
                                    //     debugString += $"{frameTime + 1} {keyValue.w}, {keyValue.x}, {keyValue.y}, {keyValue.z}\n";

                                    if (!trackHeader->GetUnitFlags(i).HasFlag(TrackUnit.UnitFlags.NoFrames))
                                    {
                                        while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                        {
                                            byte frameCount = (byte)TrackData.ReadUnalignedBits(trackDataBlob, ref inoutBitstreamPos, 8);
                                            time += frameCount * TrackData.PlaybackRate;

                                            keyValue = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);
                                            
                                            // if (absTrackDataIndex == 21)
                                            //     debugString += $"{frameTime + 1} {keyValue.w}, {keyValue.x}, {keyValue.y}, {keyValue.z}\n";

                                            curveX.AddKey((float)time, keyValue.x);
                                            curveY.AddKey((float)time, keyValue.y);
                                            curveZ.AddKey((float)time, keyValue.z);
                                            curveW.AddKey((float)time, keyValue.w);
                                        }
                                    }
                                    
                                    // if (absTrackDataIndex == 21)
                                    //     Debug.Log(debugString);

                                    for (int l = 0; l < curveX.keys.Length; l++)
                                    {
                                        AnimationUtility.SetKeyLeftTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyRightTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyLeftTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyRightTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyLeftTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyRightTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyLeftTangentMode(curveW, l, AnimationUtility.TangentMode.Linear);
                                        AnimationUtility.SetKeyRightTangentMode(curveW, l, AnimationUtility.TangentMode.Linear);
                                    }
                                    
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalRotation.x", curveX);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalRotation.y", curveY);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalRotation.z", curveZ);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalRotation.w", curveW);

                                    break;
                                }
                                case TrackType.Vector3:
                                case TrackType.RootPos:
                                {      
                                    AnimationCurve curveX = CreateCurve(trackUnit);
                                    AnimationCurve curveY = CreateCurve(trackUnit);
                                    AnimationCurve curveZ = CreateCurve(trackUnit);
                                    
                                    byte* dataBlob = (byte*)trackDataBlob;
                                    
                                    Vector3 keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                    keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);

                                    if (!trackHeader->GetUnitFlags(i).HasFlag(TrackUnit.UnitFlags.NoFrames))
                                    {
                                        while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                        {
                                            byte frameCount = *dataBlob; dataBlob++;
                                            time += frameCount * TrackData.PlaybackRate;

                                            keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                            keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                            curveX.AddKey((float)time, keyValue.x);
                                            curveY.AddKey((float)time, keyValue.y);
                                            curveZ.AddKey((float)time, keyValue.z);
                                        }
                                    }
                                    
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalPosition.x", curveX);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalPosition.y", curveY);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(i, j), typeof(Transform), "m_LocalPosition.z", curveZ);
                                
                                    break;
                                }
                            }
                        }
                    }
 
                    //clip.EnsureQuaternionContinuity();
                    return clip;
                }
            }

            return null;
        }
    }
}