using Fox.Core;
using Fox.Core.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace Fox.GameKit
{
    public partial class DecalArray : Fox.Core.TransformData
    {
        private partial bool Get_isDisableAlbedo() => throw new System.NotImplementedException();
        private partial void Set_isDisableAlbedo(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isPreserveAspect() => throw new System.NotImplementedException();
        private partial void Set_isPreserveAspect(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isWrap() => throw new System.NotImplementedException();
        private partial void Set_isWrap(bool value) => throw new System.NotImplementedException();

        private partial bool Get_showObject() => throw new System.NotImplementedException();
        private partial void Set_showObject(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isVisibleGeom() => throw new System.NotImplementedException();
        private partial void Set_isVisibleGeom(bool value) => throw new System.NotImplementedException();

        private partial bool Get_isSSDecal() => throw new System.NotImplementedException();
        private partial void Set_isSSDecal(bool value) => throw new System.NotImplementedException();

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