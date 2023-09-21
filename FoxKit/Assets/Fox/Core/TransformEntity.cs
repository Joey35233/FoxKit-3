using UnityEngine;

namespace Fox.Core
{
    public partial class TransformEntity : Fox.Core.DataElement
    {
        public static TransformEntity GetDefault() => new() { translation = Vector3.zero, rotQuat = Quaternion.identity, scale = Vector3.one };

        protected partial UnityEngine.Vector3 Get_scale() => transform_scale;
        protected partial void Set_scale(UnityEngine.Vector3 value) => transform_scale = value;

        protected partial UnityEngine.Quaternion Get_rotQuat() => Kernel.Math.FoxToUnityQuaternion(transform_rotation_quat);
        protected partial void Set_rotQuat(UnityEngine.Quaternion value) => transform_rotation_quat = Kernel.Math.UnityToFoxQuaternion(value);

        protected partial UnityEngine.Vector3 Get_translation() => Kernel.Math.FoxToUnityVector3(transform_translation);
        protected partial void Set_translation(UnityEngine.Vector3 value) => transform_translation = Kernel.Math.FoxToUnityVector3(value);

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            var parent = this.owner.Entity as TransformData;
            if (parent == null)
            {
                // TODO What do we do about orphaned transforms?
                return;
            }

            UnityEngine.Transform gameObjectTransform = gameObject.GetComponent<UnityEngine.Transform>();

            Vector3 exportPosition = parent.inheritTransform ? gameObjectTransform.position : gameObjectTransform.localPosition;
            Quaternion exportRotation = parent.inheritTransform ? gameObjectTransform.rotation : gameObjectTransform.localRotation;

            context.OverrideProperty(nameof(transform_translation), Kernel.Math.UnityToFoxVector3(exportPosition));
            context.OverrideProperty(nameof(transform_rotation_quat), Kernel.Math.UnityToFoxQuaternion(exportRotation));
            context.OverrideProperty(nameof(transform_scale), gameObjectTransform.localScale);
        }
    }
}