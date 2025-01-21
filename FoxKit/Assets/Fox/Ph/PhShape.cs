using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;

namespace Fox.Ph
{
    public partial class PhShape : Fox.Ph.PhSubObject
    {
        private PhShapeParam shapeParam => param;

        private partial UnityEngine.Vector3 Get_offset() => shapeParam.GetOffset();
        private partial void Set_offset(UnityEngine.Vector3 value) => shapeParam.SetOffset(value);

        private partial UnityEngine.Quaternion Get_rotation() => shapeParam.GetRotation();
        private partial void Set_rotation(UnityEngine.Quaternion value) => shapeParam.SetRotation(value);

        public override void OnDeserializeEntity(GameObject gameObject, TaskLogger logger)
        {
            base.OnDeserializeEntity(gameObject, logger);

            offset = Fox.Math.FoxToUnityVector3(offset);
            rotation = Fox.Math.FoxToUnityQuaternion(rotation);
        }

        public override void OverridePropertiesForExport(EntityExportContext context)
        {
            base.OverridePropertiesForExport(context);

            context.OverrideProperty(nameof(offset), Fox.Math.UnityToFoxVector3(offset));
            context.OverrideProperty(nameof(rotation), Fox.Math.UnityToFoxQuaternion(rotation));
        }
    }
}
