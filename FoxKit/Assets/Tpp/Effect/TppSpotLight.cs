using Fox;
using Fox.Core;
using Fox.Kernel;
using UnityEngine;
using CsSystem = System;

namespace Tpp.Effect
{
    public partial class TppSpotLight : Fox.Core.TransformData
    {
        protected partial bool Get_enable() => throw new CsSystem.NotImplementedException();
        protected partial void Set_enable(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial TppSpotLight_PackingGeneration Get_packingGeneration() => throw new CsSystem.NotImplementedException();
        protected partial void Set_packingGeneration(TppSpotLight_PackingGeneration value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_castShadow() => throw new CsSystem.NotImplementedException();
        protected partial void Set_castShadow(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_isBounced() => throw new CsSystem.NotImplementedException();
        protected partial void Set_isBounced(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_showObject() => throw new CsSystem.NotImplementedException();
        protected partial void Set_showObject(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_showRange() => throw new CsSystem.NotImplementedException();
        protected partial void Set_showRange(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_isDebugLightVolumeBound() => throw new CsSystem.NotImplementedException();
        protected partial void Set_isDebugLightVolumeBound(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_useAutoDimmer() => throw new CsSystem.NotImplementedException();
        protected partial void Set_useAutoDimmer(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial bool Get_hasSpecular() => throw new CsSystem.NotImplementedException();
        protected partial void Set_hasSpecular(bool value) { throw new CsSystem.NotImplementedException(); }

        protected partial Path Get_importFilePath() => throw new CsSystem.NotImplementedException();
        protected partial void Set_importFilePath(Path value) { throw new CsSystem.NotImplementedException(); }

        public override void InitializeGameObject(GameObject gameObject)
        {
            gameObject.AddComponent<TppSpotLightGizmo>();
            base.InitializeGameObject(gameObject);
        }
    }
}
