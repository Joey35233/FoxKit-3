using Fox.Core.Utils;
using Fox.Kernel;
using UnityEngine;

namespace Fox.Core
{
    public partial class TransformData : Data
    {
        protected partial bool Get_inheritTransform() => flags.HasFlag(TransformData_Flags.ENABLE_INHERIT_TRANSFORM);
        protected partial void Set_inheritTransform(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_INHERIT_TRANSFORM;
            else
                flags &= ~TransformData_Flags.ENABLE_INHERIT_TRANSFORM;
        }

        protected partial bool Get_visibility() => flags.HasFlag(TransformData_Flags.ENABLE_VISIBILITY);
        protected partial void Set_visibility(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_VISIBILITY;
            else
                flags &= ~TransformData_Flags.ENABLE_VISIBILITY;
        }

        protected partial bool Get_selection() => flags.HasFlag(TransformData_Flags.ENABLE_SELECTION);
        protected partial void Set_selection(bool value)
        {
            if (value)
                flags |= TransformData_Flags.ENABLE_SELECTION;
            else
                flags &= ~TransformData_Flags.ENABLE_SELECTION;
        }

        protected partial UnityEngine.Matrix4x4 Get_worldMatrix() => throw new System.NotImplementedException();

        protected partial UnityEngine.Matrix4x4 Get_worldTransform() => throw new System.NotImplementedException();

        public void AddChild(TransformData transformData)
        {
            children.Add(EntityHandle.Get(transformData));
            transformData.parent = EntityHandle.Get(this);
        }

        public DynamicArray<EntityHandle> GetChildren() => children;

        public void SetTransform(TransformEntity transform)
        {
            this.transform = new EntityPtr<TransformEntity>(transform);
            transform.SetOwner(this);
        }

        public override void InitializeGameObject(GameObject gameObject, TaskLogger logger)
        {
            TransformEntity transformEntity = transform.Get();
            if (transformEntity == null)
            {
                return;
            }

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

            base.InitializeGameObject(gameObject, logger);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            // Get GameObject's parent
            UnityEngine.Transform transform = this.gameObject.GetComponent<UnityEngine.Transform>();

            var exportParent = EntityHandle.Empty;
            UnityEngine.Transform parentTransform = transform.parent;
            if (parentTransform != null)
            {
                TransformData parentTransformData = parentTransform.GetComponent<TransformData>();
                if (parentTransformData != null)
                {
                    exportParent = EntityHandle.Get(parentTransformData);
                }
            }

            context.OverrideProperty(nameof(parent), exportParent);

            // Get child GameObjects
            var exportChildren = new DynamicArray<EntityHandle>();
            foreach (UnityEngine.Transform child in transform)
            {
                TransformData childTransformData = child.GetComponent<TransformData>();
                if (childTransformData != null)
                {
                    var exportChild = EntityHandle.Get(childTransformData);
                    exportChildren.Add(exportChild);
                }
            }

            context.OverrideProperty(nameof(children), exportChildren);
        }
    }
}