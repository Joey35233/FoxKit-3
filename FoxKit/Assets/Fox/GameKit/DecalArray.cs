using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.GameKit
{
    public partial class DecalArray : Fox.Core.TransformData
    {
        private partial bool isDisableAlbedo_Get() => throw new System.NotImplementedException();
        private partial void isDisableAlbedo_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isPreserveAspect_Get() => throw new System.NotImplementedException();
        private partial void isPreserveAspect_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isWrap_Get() => throw new System.NotImplementedException();
        private partial void isWrap_Set(bool value) => throw new System.NotImplementedException();

        private partial bool showObject_Get() => throw new System.NotImplementedException();
        private partial void showObject_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isVisibleGeom_Get() => throw new System.NotImplementedException();
        private partial void isVisibleGeom_Set(bool value) => throw new System.NotImplementedException();

        private partial bool isSSDecal_Get() => throw new System.NotImplementedException();
        private partial void isSSDecal_Set(bool value) => throw new System.NotImplementedException();

        public override void OnDeserializeEntity(TaskLogger logger)
        {
            base.OnDeserializeEntity(logger);

            for (int i = 0; i < rotations.Count; i++)
                rotations[i] = Fox.Math.FoxToUnityQuaternion(rotations[i]);

            for (int i = 0; i < translations.Count; i++)
                translations[i] = Fox.Math.FoxToUnityVector3(translations[i]);
        }
        public override void OnSerializeEntity(EntityExportContext context)
        {
            base.OnSerializeEntity(context);

            List<Quaternion> _rotations = rotations;
            for (int i = 0; i < _rotations.Count; i++)
                _rotations[i] = Fox.Math.UnityToFoxQuaternion(_rotations[i]);
            context.OverrideProperty(nameof(rotations), _rotations);

            List<Vector3> _translations = translations;
            for (int i = 0; i < _translations.Count; i++)
                _translations[i] = Fox.Math.UnityToFoxVector3(_translations[i]);
            context.OverrideProperty(nameof(translations), _translations);
        }
    }
}