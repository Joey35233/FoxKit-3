using GraphProcessor;
using UnityEngine;

namespace FoxKit.Fx.Editor.Nodes
{
    [System.Serializable, NodeMenuItem("Material/LightInfluence")]
    public class FxLightInfluenceMaterialNode : BaseNode
    {
        [Output(name = "Output0")]
        public float Output0;

        [SerializeField]
        private float AmbientRate;

        [SerializeField]
        private float CameraFadeInFar;

        [SerializeField]
        private float CameraFadeInNear;

        [SerializeField]
        private float CameraZOffset;

        [SerializeField]
        private float DirectionalLightRate;

        [SerializeField]
        private bool Opaque;

        [SerializeField]
        private float PointLightRate;

        [SerializeField]
        private bool ReceiveShadowMap;

        [SerializeField]
        private int ShaderType;

        [SerializeField]
        private bool SoftBlend;

        [SerializeField]
        private float SoftBlendFactor;

        [SerializeField]
        private bool TextureAnimeBlend;

        [SerializeField]
        private float TextureAnimeBlendFrame;

        [SerializeField]
        private uint TextureAnimeBlendHeight;

        [SerializeField]
        private uint TextureAnimeBlendWidth;

        [SerializeField]
        private bool TextureAnimeClamp;

        [SerializeField]
        private bool TextureAnimeRandomStart;

        [SerializeField]
        private string TextureFile;

        public override string name => "LightInfluence";
    }
}