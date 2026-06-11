using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Core
{
    public partial class TransformData : Data
    {
        public override void Reset()
        {
            /*if (!transform)
                SetTransform(TransformEntity.GetDefault());*/

            flags |= TransformData_Flags.ENABLE_VISIBILITY;
            flags |= TransformData_Flags.ENABLE_SELECTION;
            flags |= TransformData_Flags.ENABLE_INHERIT_TRANSFORM;
        }
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
            transformData.gameObject.transform.SetParent((this as UnityEngine.MonoBehaviour).transform);
        }

        public void SetTransform(TransformEntity transformEntity)
        {
            this.transform = transformEntity;
            transformEntity.SetOwner(this);

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

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);
            
            OnDeserializeTransformEntity();
        }

        private void OnDeserializeTransformEntity()
        {
            if (this.parent)
                this.gameObject.transform.SetParent(this.parent.transform, false);

            if (transform)
            {
                TransformEntity transformEntity = transform;
                transformEntity.translation = Math.FoxToUnityVector3(transformEntity.translation);
                transformEntity.rotQuat = Math.FoxToUnityQuaternion(transformEntity.rotQuat);
                transformEntity.scale = transformEntity.scale;
                //transformEntity.name = transform.GetType().Name;

                SetTransform(transformEntity);
            }
        }

        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            // Get GameObject's parent
            UnityEngine.Transform transform = this.gameObject.transform;

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
            var exportChildren = new System.Collections.Generic.List<Entity>();

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