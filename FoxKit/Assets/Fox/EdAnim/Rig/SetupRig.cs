using System;
using Fox.Anim;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Object = UnityEngine.Object;

namespace Fox.EdAnim
{
    public static class SetupRigMenu
    {
        [MenuItem("Fox/Anim/Setup Rig")]
        private static unsafe void OnImportAsset()
        {
            if (Selection.transforms.Length < 1)
            {
                return;
            }
            
            Transform target = Selection.transforms[0];
            if (Selection.transforms.Length > 1)
            {
                Debug.LogWarning($"Multiple objects selected. Applying RigDrivers to first: {target.name}.");
            }
            
            string assetPath = EditorUtility.OpenFilePanel("Setup rig", "Assets", "frig");
            if (System.String.IsNullOrEmpty(assetPath))
            {
                return;
            }

            byte[] dataArray = System.IO.File.ReadAllBytes(assetPath);
            fixed (byte* fileData = dataArray)
            {
                RigFileHeader* header = (RigFileHeader*)fileData;
                Debug.Assert(header->Version == 102);
                
                // Create Unity rig
                RigBuilder rigBuilder = target.gameObject.GetComponent<RigBuilder>();
                if (rigBuilder != null)
                    rigBuilder.Clear();
                else
                    rigBuilder = target.gameObject.AddComponent<RigBuilder>();

                // The animator auto-added by adding a RigBuilder component starts with applyRootMotion off.
                Animator animator = target.gameObject.GetComponent<Animator>();
                animator.applyRootMotion = true;
                
                BoneRenderer boneRenderer = target.gameObject.GetComponent<BoneRenderer>();
                if (boneRenderer == null)
                    boneRenderer = target.gameObject.AddComponent<BoneRenderer>();
                
                Transform[] bones = target.GetComponentInChildren<SkinnedMeshRenderer>().bones;

                boneRenderer.transforms = bones;

                GameObject rigObject = target.Find(ConversionUtils.RigFolderName)?.gameObject;
                if (rigObject != null)
                    GameObject.DestroyImmediate(rigObject);
                rigObject = new GameObject(ConversionUtils.RigFolderName);
                rigObject.transform.SetParent(target);
                
                // Create Rig
                Rig rigComponent = rigObject.AddComponent<Rig>();
                rigComponent.weight = 1.0f;
                
                // TODO: Add to RigBuilder
                if (rigBuilder.layers.Count != 0)
                    rigBuilder.layers.Clear();
                rigBuilder.layers.Add(new RigLayer(rigComponent));
                
                // Create the "folders." These must be deterministic and independent of the specific rig so all animations can target them.
                GameObject unitFolder = new GameObject(ConversionUtils.UnitsFolderName);
                unitFolder.transform.SetParent(rigObject.transform);

                // Stores all of the track proxies and also make a local creation function to make making proxies less painful
                Transform segmentProxyFolder = new GameObject(ConversionUtils.SegmentFolderName).transform;
                segmentProxyFolder.SetParent(rigObject.transform);
                Transform CreateSegmentProxy(uint unitIndex, uint trackIndex)
                {
                    Transform proxy = new GameObject(ConversionUtils.GetSegmentNameString(unitIndex, trackIndex)).transform;
                    proxy.SetParent(segmentProxyFolder.transform);

                    return proxy;
                }

                int* rigUnitDefOffsets = (int*)(header + 1);
                for (uint i = 0; i < header->RigUnitCount; i++)
                {
                    RigUnitType* unitHead = (RigUnitType*)(fileData + rigUnitDefOffsets[i]);

                    if (*unitHead == RigUnitType.Root)
                        continue;
                    
                    GameObject unitObject = new GameObject(ConversionUtils.GetUnitNameString(i));
                    unitObject.transform.SetParent(unitFolder.transform);
                    
                    switch (*unitHead)
                    {
                        case RigUnitType.Root:
                            break;
                        case RigUnitType.Orientation:
                            {
                                RigOrientationDef* unitDef = (RigOrientationDef*)unitHead;
                                
                                RigOrientationPoseUnit unit = unitObject.AddComponent<RigOrientationPoseUnit>();
                                
                                // Index bones
                                Transform bone = bones[unitDef->SkelIndex];
                                unit.data.Target = bone;
                                
                                // Create track proxies
                                Transform rotationTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.Source = rotationTrackProxy;
                            }
                            break;
                        case RigUnitType.TwoBone:
                            {
                                RigTwoBone* unitDef = (RigTwoBone*)unitHead;
                                    
                                RigTwoBonePoseUnit unit = unitObject.AddComponent<RigTwoBonePoseUnit>();
                                    
                                // Index bones
                                Transform upper = bones[unitDef->UpperSkelIndex];
                                unit.data.UpperTarget = upper;
                                
                                Transform mid = bones[unitDef->MidSkelIndex];
                                unit.data.MidTarget = mid;
                                
                                Transform effector = bones[unitDef->EffectorSkelIndex];
                                unit.data.EffectorTarget = effector;
                                
                                Transform effectorPositionTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.EffectorPositionSource = effectorPositionTrackProxy;
                                
                                Transform polePositionTrackProxy = CreateSegmentProxy(i, 1);
                                unit.data.PoleRotationSource = polePositionTrackProxy;

                                unit.data.ChainPlaneNormal = Kernel.Math.FoxToUnityVector3(unitDef->ChainPlaneNormal);
                            }
                            break;
                        case RigUnitType.LocalOrientation:
                            {
                                RigOrientationDef* unitDef = (RigOrientationDef*)unitHead;
                                    
                                RigLocalOrientationPoseUnit unit = unitObject.AddComponent<RigLocalOrientationPoseUnit>();
                                    
                                // Index bones
                                Transform bone = bones[unitDef->SkelIndex];
                                unit.data.Target = bone;
                                    
                                // Create track proxies
                                Transform rotationTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.Source = rotationTrackProxy;
                            }
                            break;
                        case RigUnitType.LocalTransform:
                            {
                                RigTransformDef* unitDef = (RigTransformDef*)unitHead;
                                
                                RigLocalTransformPoseUnit unit = unitObject.AddComponent<RigLocalTransformPoseUnit>();
                                
                                // Index bones
                                Transform bone = bones[unitDef->SkelIndex];
                                unit.data.Target = bone;
                                
                                // Create track proxies
                                Transform rotationTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.RotationSource = rotationTrackProxy;
                                
                                Transform positionTrackProxy = CreateSegmentProxy(i, 1);
                                unit.data.PositionSource = positionTrackProxy;
                            }
                            break;
                        case RigUnitType.Unknown6:
                            break;
                        case RigUnitType.Transform:
                            {
                                RigTransformDef* unitDef = (RigTransformDef*)unitHead;
                                
                                RigTransformPoseUnit unit = unitObject.AddComponent<RigTransformPoseUnit>();
                                
                                // Index bones
                                Transform bone = bones[unitDef->SkelIndex];
                                unit.data.Target = bone;
                                
                                // Create track proxies
                                Transform rotationTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.RotationSource = rotationTrackProxy;
                                
                                Transform positionTrackProxy = CreateSegmentProxy(i, 1);
                                unit.data.PositionSource = positionTrackProxy;
                            }
                            break;
                        case RigUnitType.Arm:
                            {
                                RigArmDef* unitDef = (RigArmDef*)unitHead;
                                    
                                RigArmPoseUnit unit = unitObject.AddComponent<RigArmPoseUnit>();
                                    
                                // Index bones
                                Transform shoulder = bones[unitDef->ShoulderSkelIndex];
                                unit.data.ShoulderTarget = shoulder;
                                
                                Transform uarm = bones[unitDef->UpperSkelIndex];
                                unit.data.UpperArmTarget = uarm;
                                
                                Transform larm = bones[unitDef->LowerSkelIndex];
                                unit.data.LowerArmTarget = larm;
                                
                                Transform effector = bones[unitDef->EffectorSkelIndex];
                                unit.data.EffectorTarget = effector;
                                    
                                // Create track proxies
                                Transform shoulderRotationTrackProxy = CreateSegmentProxy(i, 0);
                                unit.data.ShoulderRotationSource = shoulderRotationTrackProxy;
                                
                                Transform effectorPositionTrackProxy = CreateSegmentProxy(i, 1);
                                unit.data.EffectorPositionSource = effectorPositionTrackProxy;
                                
                                Transform polePositionTrackProxy = CreateSegmentProxy(i, 2);
                                unit.data.PoleRotationSource = polePositionTrackProxy;

                                unit.data.ChainPlaneNormal = Kernel.Math.FoxToUnityVector3(unitDef->ChainPlaneNormal);
                            }
                            break;
                        case RigUnitType.Unknown9:
                            break;
                        case RigUnitType.Unknown10:
                            break;
                        case RigUnitType.List:
                            break;
                        case RigUnitType.Unknown12:
                            break;
                        default:
                            Debug.Assert(false);
                            break;
                    }
                }
            }
        }
    }
}
