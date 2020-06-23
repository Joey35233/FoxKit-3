using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

using GraphProcessor;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Material/LightInfluence")]
    public class FxLightInfluenceMaterialNode : BaseNode
    {
        [Output(name = "Output0")]
        public float Output0;

        [SerializeField]
        float AmbientRate;

        [SerializeField]
        float CameraFadeInFar;

        [SerializeField]
        float CameraFadeInNear;

        [SerializeField]
        float CameraZOffset;

        [SerializeField]
        float DirectionalLightRate;

        [SerializeField]
        bool Opaque;

        [SerializeField]
        float PointLightRate;

        [SerializeField]
        bool ReceiveShadowMap;

        [SerializeField]
        int ShaderType;

        [SerializeField]
        bool SoftBlend;

        [SerializeField]
        float SoftBlendFactor;

        [SerializeField]
        bool TextureAnimeBlend;

        [SerializeField]
        float TextureAnimeBlendFrame;

        [SerializeField]
        uint TextureAnimeBlendHeight;

        [SerializeField]
        uint TextureAnimeBlendWidth;

        [SerializeField]
        bool TextureAnimeClamp;

        [SerializeField]
        bool TextureAnimeRandomStart;

        [SerializeField]
        string TextureFile;

        public override string name => "LightInfluence";
    }
}