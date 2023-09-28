using Fox.Core.Utils;
using Fox.Kernel;
using System;
using UnityEditor;
using UnityEngine;
using Math = Fox.Kernel.Math;

namespace Fox.Core
{
    public partial class TransformData : Data
    {
        private partial bool Get_inheritTransform() => flags.HasFlag(TransformData_Flags.ENABLE_INHERIT_TRANSFORM);
        private partial void Set_inheritTransform(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_INHERIT_TRANSFORM;
            else
                flags &= ~TransformData_Flags.ENABLE_INHERIT_TRANSFORM;
        }

        private partial bool Get_visibility() => flags.HasFlag(TransformData_Flags.ENABLE_VISIBILITY);
        private partial void Set_visibility(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_VISIBILITY;
            else
                flags &= ~TransformData_Flags.ENABLE_VISIBILITY;
        }

        private partial bool Get_selection() => flags.HasFlag(TransformData_Flags.ENABLE_SELECTION);
        private partial void Set_selection(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_SELECTION;
            else
                flags &= ~TransformData_Flags.ENABLE_SELECTION;
        }

        private partial UnityEngine.Matrix4x4 Get_worldMatrix() => throw new System.NotImplementedException();

        private partial UnityEngine.Matrix4x4 Get_worldTransform() => throw new System.NotImplementedException();

        public void AddChild(TransformData transformData)
        {
            (transformData as UnityEngine.MonoBehaviour).transform.SetParent((this as UnityEngine.MonoBehaviour).transform);
        }

        public void SetTransform(TransformEntity transform)
        {
            this.transform = new EntityPtr<TransformEntity>(transform);
            transform.SetOwner(this);

            UpdateTransform();
        }

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            UpdateTransform();

            base.OnDeserializeEntity(gameObject, logger);
        }

        private void UpdateTransform()
        {
            if (transform.IsNull())
                SetTransform(TransformEntity.GetDefault());

            TransformEntity transformEntity = transform.Get();
            transformEntity.translation = Math.FoxToUnityVector3(transformEntity.translation);
            transformEntity.rotQuat = Math.FoxToUnityQuaternion(transformEntity.rotQuat);
            transformEntity.scale = transformEntity.scale;

            if (inheritTransform)
            {
                gameObject.transform.localPosition = transformEntity.translation;
                gameObject.transform.localRotation = transformEntity.rotQuat;
                gameObject.transform.localScale = transformEntity.scale;
            }
            else
            {
                gameObject.transform.position = transformEntity.translation;
                gameObject.transform.rotation = transformEntity.rotQuat;
                gameObject.transform.localScale = transformEntity.scale;
            }
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            // Get GameObject's parent
            UnityEngine.Transform transform = this.gameObject.GetComponent<UnityEngine.Transform>();

            Entity exportParent = null;
            UnityEngine.Transform parentTransform = transform.parent;
            if (parentTransform != null)
            {
                TransformData parentTransformData = parentTransform.GetComponent<TransformData>();
                if (parentTransformData != null)
                {
                    exportParent = parentTransformData;
                }
            }

            context.OverrideProperty(nameof(parent), exportParent);

            // Get child GameObjects
            var exportChildren = new DynamicArray<Entity>();

            foreach (UnityEngine.Transform child in transform)
            {
                TransformData childTransformData = child.GetComponent<TransformData>();
                if (childTransformData != null)
                {
                    Entity exportChild = childTransformData;
                    exportChildren.Add(exportChild);
                }
            }

            context.OverrideProperty(nameof(children), exportChildren);
        }
    }
}