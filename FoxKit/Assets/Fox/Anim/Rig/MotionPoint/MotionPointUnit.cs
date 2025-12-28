using System;
using System.Collections.Generic;
using PlasticGui.WorkspaceWindow.QueryViews.Changesets;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;
using Object = UnityEngine.Object;

namespace Fox.Anim
{
    [Unity.Burst.BurstCompile]
    public struct MotionPointUnitJob : IWeightedAnimationJob
    {
        public NativeArray<bool> IsGlobals;
        public NativeArray<ReadOnlyTransformHandle> Sources;
        public NativeArray<ReadWriteTransformHandle> Targets;

        private quaternion InverseRootRotation;
        private float3 InverseRootPosition;

        public FloatProperty jobWeight
        {
            get;
            set;
        }

        public void ProcessRootMotion(AnimationStream stream)
        {
        }

        public void ProcessAnimation(AnimationStream stream)
        {
            for (int i = 0; i < Sources.Length; i++)
            {
                ReadOnlyTransformHandle source = Sources[i];
                ReadWriteTransformHandle target = Targets[i];

                if (IsGlobals[i])
                {
                    Vector3 target_rgp = source.GetLocalPosition(stream);
                    Quaternion target_rgr = source.GetLocalRotation(stream);
            
                    target.SetPosition(stream, target_rgp);
                    target.SetRotation(stream, target_rgr);
                }
                else
                {
                    Vector3 target_rlp = source.GetLocalPosition(stream);
                    Quaternion target_rlr = source.GetLocalRotation(stream);
            
                    target.SetLocalPosition(stream, target_rlp);
                    target.SetLocalRotation(stream, target_rlr);
                }
            }
        }
    }

    [System.Serializable]
    public struct MotionPointUnitData : IAnimationJobData
    {
        [NonSerialized]
        public GameObject[] Sources;
        
        [NonSerialized]
        public GameObject[] Targets;

        public bool IsValid() => true;

        public void SetDefaultValues()
        {
            Sources = null;
            Targets = null;
        }
    }

    public class MotionPointUnitJobBinder : AnimationJobBinder<MotionPointUnitJob, MotionPointUnitData>
    {
        private MotionPointUnitData Data;
        
        private static Transform FindSkel(Transform parent, StrCode32 searchName)
        {
            foreach (Transform child in parent)
            {
                if (child.name is CommonDefs.RigFolderName or CommonDefs.MTPFolderName)
                    continue;
                
                StrCode nameHash = new StrCode(child.name);
                if ((StrCode32)nameHash == searchName)
                    return child;

                Transform result = FindSkel(child, searchName);
                if (result != null)
                    return result;
            }
            return null;
        }
        
        public override MotionPointUnitJob Create(Animator animator, ref MotionPointUnitData unitData, Component component)
        {
            AnimatorClipInfo[] clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            AnimatorClipInfo[] nextClipInfos = animator.GetNextAnimatorClipInfo(0);
            if (clipInfos.Length == 0 && nextClipInfos.Length == 0)
                return default;
            
            AnimatorClipInfo clipInfo = clipInfos.Length == 0 ? nextClipInfos[0] : clipInfos[0];
            
            EditorCurveBinding[] bindings = AnimationUtility.GetCurveBindings(clipInfo.clip);

            // Build set of all MTP tracks
            HashSet<string> mtpDescs = new HashSet<string>();
            for (uint i = 0; i < bindings.Length; i++)
            {
                string bindingPath = bindings[i].path;
                
                if (!bindingPath.StartsWith(CommonDefs.MTPFolderPath))
                    continue;

                mtpDescs.Add(bindingPath.Substring(CommonDefs.MTPFolderPath.Length));
            }

            // Job setup is called twice, not sure why, so make sure array is cleared.
            if (unitData.Sources != null)
                foreach (GameObject source in unitData.Sources)
                    Object.DestroyImmediate(source);
            unitData.Sources = new GameObject[mtpDescs.Count];
            
            // ""
            if (unitData.Targets != null)
                foreach (GameObject target in unitData.Targets)
                    Object.DestroyImmediate(target);
            unitData.Targets = new GameObject[mtpDescs.Count];

            var job = new MotionPointUnitJob();
            job.IsGlobals = new NativeArray<bool>(mtpDescs.Count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            job.Sources = new NativeArray<ReadOnlyTransformHandle>(mtpDescs.Count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            job.Targets = new NativeArray<ReadWriteTransformHandle>(mtpDescs.Count, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
            
            Transform root = animator.avatarRoot; 
            Transform MTPFolder = root.Find(CommonDefs.MTPFolderName); // TODO: Use the global version

            int mtpIndex = 0;
            foreach (string mtpDesc in mtpDescs)
            {
                string[] mtpParentList = mtpDesc.Split(CommonDefs.MTPParentSeparator);
                StrCode32 mtpName = new StrCode32(mtpParentList[0]);
                StrCode32 parentName = new StrCode32(mtpParentList[1]);
                bool isGlobal = parentName == new StrCode32("NONE->GLOBAL");

                // Clear existing source
                while (MTPFolder.Find(mtpDesc) is { } existingSource)
                    Object.DestroyImmediate(existingSource.gameObject);
                
                // Make new source
                Transform source = (unitData.Sources[mtpIndex] = new GameObject
                {
                    name = mtpDesc,
                    hideFlags = HideFlags.DontSave
                }).transform;
                source.SetParent(MTPFolder);
            
                // Clear existing target
                Transform targetParent = isGlobal ? root : FindSkel(root, parentName);
                string targetName = mtpName.ToString();
                while (targetParent.Find(targetName) is { } existingTarget)
                    Object.DestroyImmediate(existingTarget.gameObject);
                
                // Make new target
                Transform target = (unitData.Targets[mtpIndex] = new GameObject
                {
                    name = targetName,
                    hideFlags = HideFlags.DontSave
                }).transform;
                target.SetParent(targetParent);

                job.IsGlobals[mtpIndex] = isGlobal;
                job.Sources[mtpIndex] = ReadOnlyTransformHandle.Bind(animator, source);
                job.Targets[mtpIndex] = ReadWriteTransformHandle.Bind(animator, target);
                
                mtpIndex++;
            }

            Data = unitData;
                    
            return job;
        }

        public override void Destroy(MotionPointUnitJob unitJob)
        {
            if (Data.Sources != null)
                foreach (var source in Data.Sources)
                    Object.DestroyImmediate(source);
            
            if (Data.Targets != null)
                foreach (var target in Data.Targets)
                    Object.DestroyImmediate(target);

            unitJob.IsGlobals.Dispose();
            unitJob.Sources.Dispose();
            unitJob.Targets.Dispose();
        }
    }

    public class MotionPointUnit : RigConstraint<MotionPointUnitJob, MotionPointUnitData, MotionPointUnitJobBinder>
    {
        private void OnDrawGizmos()
        {
            if (data.Targets != null)
            {
                foreach (GameObject target in data.Targets)
                {
                    if (target != null)
                    {
                        Gizmos.matrix = target.transform.localToWorldMatrix;
                        Gizmos.color = Color.green;
                        Gizmos.DrawWireCube(Vector3.zero, 0.05f * Vector3.one);
                    }
                }
            }
        }
    }
}