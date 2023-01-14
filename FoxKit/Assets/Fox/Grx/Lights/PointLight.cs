using Fox.Kernel;
using UnityEngine;

namespace Fox.Grx
{
    public partial class PointLight : Fox.Core.TransformData
    {
        protected partial bool Get_enable() => FlagUtils.GetFlag(lightFlags, 0);
        protected partial void Set_enable(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 0, value); }

        protected partial PointLight_PackingGeneration Get_packingGeneration()
        {
            sbyte packingGeneration = (sbyte)(lightFlags >> 24);
            if (packingGeneration == -1)
                return PointLight_PackingGeneration.GENERATION_ALL;
            else
                return (PointLight_PackingGeneration)packingGeneration;
        }
        protected partial void Set_packingGeneration(PointLight_PackingGeneration value) 
        {
            if (value == PointLight_PackingGeneration.GENERATION_ALL)
            {
                lightFlags |= 0xFF000000;
            }
            else
            {
                lightFlags ^= (uint)(-((int)value ^ lightFlags) & (0xFF << 24));
            }
        }

        protected partial bool Get_castShadow() => FlagUtils.GetFlag(lightFlags, 1);
        protected partial void Set_castShadow(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 1, value); }

        protected partial bool Get_isBounced() => FlagUtils.GetFlag(lightFlags, 2);
        protected partial void Set_isBounced(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 2, value); }

        protected partial bool Get_showObject() => FlagUtils.GetFlag(lightFlags, 4);
        protected partial void Set_showObject(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 4, value); }

        protected partial bool Get_showRange() => FlagUtils.GetFlag(lightFlags, 5);
        protected partial void Set_showRange(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 5, value); }

        protected partial bool Get_isDebugLightVolumeBound() => FlagUtils.GetFlag(lightFlags, 6);
        protected partial void Set_isDebugLightVolumeBound(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 6, value); }

        protected partial bool Get_hasSpecular() => FlagUtils.GetFlag(lightFlags, 3);
        protected partial void Set_hasSpecular(bool value) { lightFlags = FlagUtils.SetFlag(lightFlags, 3, value); }

        public override void InitializeGameObject(GameObject gameObject)
        {
            gameObject.AddComponent<PointLightGizmo>();
            base.InitializeGameObject(gameObject);
        }
    }
}