﻿using UnityEngine;

namespace Fox.Core
{
    public partial class TransformData : Data
    {
        protected partial bool Get_inheritTransform() => flags.HasFlag(TransformData_Flags.ENABLE_INHERIT_TRANSFORM);
        protected partial void Set_inheritTransform(bool value) { if (value) flags |= TransformData_Flags.ENABLE_INHERIT_TRANSFORM; else flags &= ~TransformData_Flags.ENABLE_INHERIT_TRANSFORM; }

        protected partial bool Get_visibility() => flags.HasFlag(TransformData_Flags.ENABLE_VISIBILITY);
        protected partial void Set_visibility(bool value) { if (value) flags |= TransformData_Flags.ENABLE_VISIBILITY; else flags &= ~TransformData_Flags.ENABLE_VISIBILITY; }

        protected partial bool Get_selection() => flags.HasFlag(TransformData_Flags.ENABLE_SELECTION);
        protected partial void Set_selection(bool value) { if (value) flags |= TransformData_Flags.ENABLE_SELECTION; else flags &= ~TransformData_Flags.ENABLE_SELECTION; }

        protected partial UnityEngine.Matrix4x4 Get_worldMatrix() => throw new System.NotImplementedException();

        protected partial UnityEngine.Matrix4x4 Get_worldTransform() => throw new System.NotImplementedException();

        public override void InitializeGameObject(GameObject gameObject)
        {
            TransformEntity transformEntity = this.transform.Get();
            if (transformEntity == null)
            {
                Debug.LogWarning($"{this.name}: transform is null");
                return;
            }

            gameObject.transform.position = transformEntity.translation;
            gameObject.transform.rotation = transformEntity.rotQuat;
            gameObject.transform.localScale = transformEntity.scale;
        }
    }
}