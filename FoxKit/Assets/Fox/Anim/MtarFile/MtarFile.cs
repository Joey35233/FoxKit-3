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
                    
                    // Pick file 1028 and read MTAR metadata for it - 35ac42b3641df /Assets/tpp/motion/SI_game/fani/bodies/snap/snapnon/snapnon_s_dh_lp
                    Mtar2FileHeader* fileHeader = header->GetFile2Headers() + 1028;
                    
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
                    
                    uint segmentId = 0;
                    for (uint unitId = 0; unitId < layoutTrack->UnitCount; unitId++)
                    {
                        TrackUnit* unit = layoutTrack->GetUnit(unitId);

                        // Hack to get Unity to bind the root transform properly
                        if (unit->Name == ConversionUtils.RootUnitName)
                        {
                            Debug.Assert(unit->SegmentCount == 2);

                            {
                                TrackData* trackData = unit->GetSegment(ConversionUtils.RootRotSegmentIndex);
                                Gani2TrackData* gani2TrackData = gani2TrackDataArray + segmentId;
                                ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);
                                
                                Debug.Assert(trackData->Type == TrackType.QuatDiff);
                                
                                double time = 0;
                            
                                AnimationCurve curveX = CreateCurve(unit);
                                AnimationCurve curveY = CreateCurve(unit);
                                AnimationCurve curveZ = CreateCurve(unit);
                                AnimationCurve curveW = CreateCurve(unit);
                                
                                ulong inoutBitstreamPos = 0;
                                
                                Quaternion keyValue = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);

                                curveX.AddKey((float)time, keyValue.x);
                                curveY.AddKey((float)time, keyValue.y);
                                curveZ.AddKey((float)time, keyValue.z);
                                curveW.AddKey((float)time, keyValue.w);

                                if (!trackHeader->GetUnitFlags(unitId).HasFlag(TrackUnit.UnitFlags.NoFrames))
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

                                segmentId++;
                            }

                            {
                                TrackData* trackData = unit->GetSegment(ConversionUtils.RootPosSegmentIndex);
                                Gani2TrackData* gani2TrackData = gani2TrackDataArray + segmentId;
                                ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);
                                
                                Debug.Assert(trackData->Type == TrackType.VectorDiff);
                                
                                double time = 0;
                            
                                AnimationCurve curveX = CreateCurve(unit);
                                AnimationCurve curveY = CreateCurve(unit);
                                AnimationCurve curveZ = CreateCurve(unit);
                                
                                byte* dataBlob = (byte*)trackDataBlob;
                                
                                Vector3 keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                curveX.AddKey((float)time, keyValue.x);
                                curveY.AddKey((float)time, keyValue.y);
                                curveZ.AddKey((float)time, keyValue.z);

                                if (!trackHeader->GetUnitFlags(unitId).HasFlag(TrackUnit.UnitFlags.NoFrames))
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

                                segmentId++;
                            }
                            
                            continue;
                        }

                        for (uint j = 0; j < unit->SegmentCount; j++, segmentId++)
                        {
                            TrackData* trackData = unit->GetSegment(segmentId);
                            Gani2TrackData* gani2TrackData = gani2TrackDataArray + segmentId;
                            ushort* trackDataBlob = (ushort*)((byte*)gani2TrackData + gani2TrackData->DataOffset);

                            double time = 0;
                            switch (trackData->Type)
                            {
                                case TrackType.Quat:
                                {
                                    AnimationCurve curveX = CreateCurve(unit);
                                    AnimationCurve curveY = CreateCurve(unit);
                                    AnimationCurve curveZ = CreateCurve(unit);
                                    AnimationCurve curveW = CreateCurve(unit);
                                    
                                    ulong inoutBitstreamPos = 0;
                                    
                                    Quaternion keyValue = TrackData.ReadUnalignedQuaternion(trackDataBlob, ref inoutBitstreamPos, gani2TrackData->ComponentBitSize);
                                    
                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                    curveW.AddKey((float)time, keyValue.w);

                                    // string debugString = "";
                                    // if (absTrackDataIndex == 21)
                                    //     debugString += $"{frameTime + 1} {keyValue.w}, {keyValue.x}, {keyValue.y}, {keyValue.z}\n";

                                    if (!trackHeader->GetUnitFlags(unitId).HasFlag(TrackUnit.UnitFlags.NoFrames))
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
                                    
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalRotation.x", curveX);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalRotation.y", curveY);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalRotation.z", curveZ);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalRotation.w", curveW);

                                    break;
                                }
                                case TrackType.Vector3:
                                case TrackType.VectorDiff:
                                {      
                                    AnimationCurve curveX = CreateCurve(unit);
                                    AnimationCurve curveY = CreateCurve(unit);
                                    AnimationCurve curveZ = CreateCurve(unit);
                                    
                                    byte* dataBlob = (byte*)trackDataBlob;
                                    
                                    Vector3 keyValue = *(Vector3*)dataBlob; dataBlob += sizeof(Vector3);
                                    keyValue = Fox.Math.FoxToUnityVector3(keyValue);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);

                                    if (!trackHeader->GetUnitFlags(unitId).HasFlag(TrackUnit.UnitFlags.NoFrames))
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
                                    
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalPosition.x", curveX);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalPosition.y", curveY);
                                    clip.SetCurve(ConversionUtils.GetSegmentNamePropertyPath(unitId, segmentId), typeof(Transform), "m_LocalPosition.z", curveZ);
                                
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