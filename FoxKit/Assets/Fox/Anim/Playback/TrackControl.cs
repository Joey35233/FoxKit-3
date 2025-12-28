using System;
using Fox.Core;
using UnityEditor;
using UnityEngine;
using Transform = UnityEngine.Transform;

namespace Fox.Anim
{
    internal static unsafe class TrackControl
    {
        private static AnimationCurve CreateCurve(UnitFlags unitFlags) => new AnimationCurve
        {
            preWrapMode = WrapMode.Clamp,
            postWrapMode = unitFlags.HasFlag(UnitFlags.Loop) ? WrapMode.Loop : WrapMode.Once
        };

        private static void EnsureLinearTangents(AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ)
        {
            for (int l = 0; l < curveX.keys.Length; l++)
            {
                AnimationUtility.SetKeyLeftTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                AnimationUtility.SetKeyRightTangentMode(curveX, l, AnimationUtility.TangentMode.Linear);
                AnimationUtility.SetKeyLeftTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                AnimationUtility.SetKeyRightTangentMode(curveY, l, AnimationUtility.TangentMode.Linear);
                AnimationUtility.SetKeyLeftTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
                AnimationUtility.SetKeyRightTangentMode(curveZ, l, AnimationUtility.TangentMode.Linear);
            }
        }

        private static void EnsureLinearTangents(AnimationCurve curveX, AnimationCurve curveY, AnimationCurve curveZ, AnimationCurve curveW)
        {
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
        }
        
        public static void PopulateClip(AnimationClip clip, TrackHeader* trackHeader, ReadOnlySpan<MotionPointList2> motionPointList)
        {
            for (uint unitId = 0, segmentId = 0; unitId < trackHeader->UnitCount; unitId++)
            {
                TrackUnit* unit = trackHeader->GetUnit(unitId);
                UnitFlags unitFlags = unit->Flags;
                    
                // TODO: Generalize
                MotionPointList2 mtp = new MotionPointList2();
                bool foundMTP = false;
                foreach (var entry in motionPointList)
                {
                    if (entry.Name == unit->Name)
                    {
                        mtp = entry;
                        foundMTP = true;
                        break;
                    }
                }

                string propertyPath = unit->Name.ToString();
                if (foundMTP)
                {
                    propertyPath = $"{CommonDefs.MTPFolderName}/{mtp.Name.ToString()}{CommonDefs.MTPParentSeparator}{mtp.ParentName.ToString()}";
                }

                for (uint j = 0; j < unit->SegmentCount; j++, segmentId++)
                {
                    TrackData* segment = unit->GetSegment(segmentId);
                    
                    ushort* segmentData = (ushort*)((byte*)segment + segment->DataOffset);

                    bool isFullPrecision = segment->ComponentBitSize == 32;
                    double time = 0;
                    switch (segment->Type)
                    {
                        case SegmentType.Quat:
                        case SegmentType.QuatDiff:
                        {
                            AnimationCurve curveX = CreateCurve(unitFlags);
                            AnimationCurve curveY = CreateCurve(unitFlags);
                            AnimationCurve curveZ = CreateCurve(unitFlags);
                            AnimationCurve curveW = CreateCurve(unitFlags);
                            
                            ulong inoutBitstreamPos = 0;
                            
                            Quaternion keyValue = TrackData.ReadUnalignedQuaternion(segmentData, ref inoutBitstreamPos, segment->ComponentBitSize);
                            
                            curveX.AddKey((float)time, keyValue.x);
                            curveY.AddKey((float)time, keyValue.y);
                            curveZ.AddKey((float)time, keyValue.z);
                            curveW.AddKey((float)time, keyValue.w);

                            if (!unitFlags.HasFlag(UnitFlags.IsStatic))
                            {
                                while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                {
                                    byte frameCount = (byte)TrackData.ReadUnalignedBits(segmentData, ref inoutBitstreamPos, 8);
                                    time += frameCount * TrackData.PlaybackRate;
                                    
                                    keyValue = TrackData.ReadUnalignedQuaternion(segmentData, ref inoutBitstreamPos, segment->ComponentBitSize);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                    curveW.AddKey((float)time, keyValue.w);
                                }
                            }

                            // TODO: Tangents != interpolation (see: `weightedMode` for more)
                            if (!unitFlags.HasFlag(UnitFlags.HermiteVectorInterpolation))
                            {
                                EnsureLinearTangents(curveX, curveY, curveZ, curveW);
                            }
                            
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.x", curveX);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.y", curveY);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.z", curveZ);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.w", curveW);

                            break;
                        }
                        case SegmentType.Vector3:
                        case SegmentType.VectorDiff:
                        {      
                            AnimationCurve curveX = CreateCurve(unitFlags);
                            AnimationCurve curveY = CreateCurve(unitFlags);
                            AnimationCurve curveZ = CreateCurve(unitFlags);

                            Vector3 keyValue = TrackData.ReadVector3(ref segmentData, isFullPrecision);

                            curveX.AddKey((float)time, keyValue.x);
                            curveY.AddKey((float)time, keyValue.y);
                            curveZ.AddKey((float)time, keyValue.z);

                            if (!unitFlags.HasFlag(UnitFlags.IsStatic))
                            {
                                while (time < trackHeader->FrameCount * TrackData.PlaybackRate)
                                {
                                    byte frameCount = *(byte*)segmentData;
                                    segmentData = (ushort*)((byte*)segmentData + 1);
                                    
                                    time += frameCount * TrackData.PlaybackRate;

                                    keyValue = TrackData.ReadVector3(ref segmentData, isFullPrecision);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                }
                            }

                            // TODO: Tangents != interpolation (see: `weightedMode` for more)
                            if (!unitFlags.HasFlag(UnitFlags.HermiteVectorInterpolation))
                            {
                                EnsureLinearTangents(curveX, curveY, curveZ);
                            }

                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.x", curveX);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.y", curveY);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.z", curveZ);
                        
                            break;
                        }
                    }
                }
            }
        }
        
        public static void PopulateClip(AnimationClip clip, TrackHeader* commonTrackHeader, TrackMiniHeader* miniTrackHeader)
        {
            // The mini version's track data lies after the array of params and flags, aligned to the nearest 4-byte boundary
            TrackMiniParam* trackParams = (TrackMiniParam*)(miniTrackHeader + 1);
            UnitFlags* unitFlagArray = (UnitFlags*)(trackParams + miniTrackHeader->ParamCount);
            
            TrackMiniData* miniSegments = (TrackMiniData*)(unitFlagArray + commonTrackHeader->UnitCount);
            miniSegments = (TrackMiniData*)AlignmentUtils.Align((ulong)miniSegments, (uint)sizeof(TrackMiniData));
            
            for (uint unitId = 0, segmentId = 0; unitId < commonTrackHeader->UnitCount; unitId++)
            {
                TrackUnit* unit = commonTrackHeader->GetUnit(unitId);
                UnitFlags unitFlags = unitFlagArray[unitId];

                for (uint j = 0; j < unit->SegmentCount; j++, segmentId++)
                {
                    TrackData* segment = unit->GetSegment(segmentId);
                    TrackMiniData* miniSegment = miniSegments + segmentId;
                    ushort* segmentData = (ushort*)((byte*)miniSegment + miniSegment->DataOffset);
                    
                    // TODO: Temp validate root unit
                    if (unit->Name == CommonDefs.RootUnitName)
                        Debug.Assert(unit->SegmentCount == 2);

                    bool isFullPrecision = miniSegment->ComponentBitSize == 32;
                    double time = 0;
                    switch (segment->Type)
                    {
                        case SegmentType.Quat:
                        case SegmentType.QuatDiff:
                        {
                            AnimationCurve curveX = CreateCurve(unitFlags);
                            AnimationCurve curveY = CreateCurve(unitFlags);
                            AnimationCurve curveZ = CreateCurve(unitFlags);
                            AnimationCurve curveW = CreateCurve(unitFlags);
                            
                            ulong inoutBitstreamPos = 0;
                            
                            Quaternion keyValue = TrackData.ReadUnalignedQuaternion(segmentData, ref inoutBitstreamPos, miniSegment->ComponentBitSize);
                            
                            curveX.AddKey((float)time, keyValue.x);
                            curveY.AddKey((float)time, keyValue.y);
                            curveZ.AddKey((float)time, keyValue.z);
                            curveW.AddKey((float)time, keyValue.w);

                            if (!unitFlags.HasFlag(UnitFlags.IsStatic))
                            {
                                while (time < miniTrackHeader->FrameCount * TrackData.PlaybackRate)
                                {
                                    byte frameCount = (byte)TrackData.ReadUnalignedBits(segmentData, ref inoutBitstreamPos, 8);
                                    time += frameCount * TrackData.PlaybackRate;
                                    
                                    keyValue = TrackData.ReadUnalignedQuaternion(segmentData, ref inoutBitstreamPos, miniSegment->ComponentBitSize);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                    curveW.AddKey((float)time, keyValue.w);
                                }
                            }

                            // TODO: Tangents != interpolation (see: `weightedMode` for more)
                            if (!unitFlags.HasFlag(UnitFlags.HermiteVectorInterpolation))
                            {
                                EnsureLinearTangents(curveX, curveY, curveZ, curveW);
                            }
                            
                            string propertyPath = unitId == 0 ? "" : CommonDefs.GetSegmentNamePropertyPath(unitId, segmentId);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.x", curveX);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.y", curveY);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.z", curveZ);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalRotation.w", curveW);

                            break;
                        }
                        case SegmentType.Vector3:
                        case SegmentType.VectorDiff:
                        {      
                            AnimationCurve curveX = CreateCurve(unitFlags);
                            AnimationCurve curveY = CreateCurve(unitFlags);
                            AnimationCurve curveZ = CreateCurve(unitFlags);

                            Vector3 keyValue = TrackData.ReadVector3(ref segmentData, isFullPrecision);

                            curveX.AddKey((float)time, keyValue.x);
                            curveY.AddKey((float)time, keyValue.y);
                            curveZ.AddKey((float)time, keyValue.z);

                            if (!unitFlags.HasFlag(UnitFlags.IsStatic))
                            {
                                while (time < miniTrackHeader->FrameCount * TrackData.PlaybackRate)
                                {
                                    byte frameCount = *(byte*)segmentData;
                                    segmentData = (ushort*)((byte*)segmentData + 1);
                                    
                                    time += frameCount * TrackData.PlaybackRate;

                                    keyValue = TrackData.ReadVector3(ref segmentData, isFullPrecision);

                                    curveX.AddKey((float)time, keyValue.x);
                                    curveY.AddKey((float)time, keyValue.y);
                                    curveZ.AddKey((float)time, keyValue.z);
                                }
                            }

                            // TODO: Tangents != interpolation (see: `weightedMode` for more)
                            if (!unitFlags.HasFlag(UnitFlags.HermiteVectorInterpolation))
                            {
                                EnsureLinearTangents(curveX, curveY, curveZ);
                            }

                            string propertyPath = unitId == 0 ? "" : CommonDefs.GetSegmentNamePropertyPath(unitId, segmentId);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.x", curveX);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.y", curveY);
                            clip.SetCurve(propertyPath, typeof(Transform), "m_LocalPosition.z", curveZ);
                        
                            break;
                        }
                    }
                }
            }
        }
    }
}