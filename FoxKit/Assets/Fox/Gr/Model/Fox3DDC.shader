Shader "Fox/Gr/Fox3DDC"
{
    Properties
    {
        _MainTex("Base_Tex_SRGB", 2D) = "white" {}
        [NoScaleOffset] _BumpMap("NormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _SpecularMap("SpecularMap_Tex_LIN", 2D) = "white" {}
        _NormalUVSet("NormalMap UV set", Float) = 0
        _Glossiness("Smoothness without SpecularMap", Range(0, 1)) = 0.5
        _F0("F0 from material_params.fmtt", Range(0, 1)) = 0.04
        [NoScaleOffset] _DirtyMap("Dirty_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _LayerTex("Layer_Tex_SRGB", 2D) = "white" {}
        [NoScaleOffset] _LayerMask("LayerMask_Tex_LIN", 2D) = "white" {}
        _LayerRepeat("Layer Repeat (U, V)", Vector) = (1, 1, 0, 0)
        _LayerShift("Layer Shift (U, V)", Vector) = (0, 0, 0, 0)
        [NoScaleOffset] _MetalicLayer("MetalicLayer_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _MetalicBacteria("MetalicBacteria_Tex_LIN", 2D) = "black" {}
        _MimeticCenter("MimeticCenter", Vector) = (0, 0, 0, 0)
        _MimeticRadius("Mimetic radius (min, max, inner min, inner max)", Vector) = (0, 1, 0, 0)
        _MimeticAlpha("Mimetic alpha (radius min, max, offset)", Vector) = (0, 1, 0, 0)
        _EdgeRoughness("EdgeRoughness", Float) = 1
        _EdgeTrans("EdgeTrans", Float) = 1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        ZWrite Off
        Offset -1, -1

        CGPROGRAM
        #pragma surface surf FoxDecal alpha:fade vertex:vert
        #pragma shader_feature_local _SPECULARMAP
        #pragma shader_feature_local _ _RUST_DIRTY _DIRTY
        #pragma shader_feature_local _METALIC_BACTERIA
        #pragma shader_feature_local _LAYER_MULTIPLY
        #pragma target 4.0

        #include "UnityPBSLighting.cginc"
        #include "UnityStandardUtils.cginc"

        sampler2D _MainTex;
        sampler2D _BumpMap;
        sampler2D _SpecularMap;
        float _NormalUVSet;
        half _Glossiness;
        half _F0;
        sampler2D _DirtyMap;
        sampler2D _LayerTex;
        sampler2D _LayerMask;
        float4 _LayerRepeat;
        float4 _LayerShift;
        sampler2D _MetalicLayer;
        sampler2D _MetalicBacteria;
        float4 _MimeticCenter;
        float4 _MimeticRadius;
        float4 _MimeticAlpha;
        half _EdgeRoughness;
        half _EdgeTrans;

        static const half3 RustColor = half3(0.505882353, 0.301960784, 0.192156863);
        static const half3 DustColor = half3(0.2, 0.196078431, 0.192156863);
        static const half3 BloodColor = half3(0.2588, 0.04705, 0.043137);
        static const half RustRoughness = 0.98;
        static const half DustRoughness = 0.98;
        static const half BloodRoughness = 0.2;
        static const float MimeticPositionScale = 10;

        struct Input
        {
            float2 uv_MainTex;
            float4 normalAndLayerUV;
            float3 objectPosFox;
            float4 color : COLOR;
            float3 viewDir;
        };

        half4 LightingFoxDecal(SurfaceOutputStandardSpecular s, float3 viewDir, UnityGI gi)
        {
            s.Normal = normalize(s.Normal);
            half oneMinusReflectivity = 1 - SpecularStrength(s.Specular);
            half4 color = UNITY_BRDF_PBS(s.Albedo, s.Specular, oneMinusReflectivity, s.Smoothness, s.Normal, viewDir, gi.light, gi.indirect);
            color.a = s.Alpha;
            return color;
        }

        void LightingFoxDecal_GI(SurfaceOutputStandardSpecular s, UnityGIInput data, inout UnityGI gi)
        {
            LightingStandardSpecular_GI(s, data, gi);
        }

        float2 FlipV(float2 uv)
        {
            return float2(uv.x, 1 - uv.y);
        }

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);

            float2 normalUV = v.texcoord.xy;
            if (_NormalUVSet == 1)
                normalUV = v.texcoord1.xy;
            if (_NormalUVSet == 2)
                normalUV = v.texcoord2.xy;
            o.normalAndLayerUV.xy = FlipV(normalUV);
            o.normalAndLayerUV.zw = FlipV((v.texcoord1.xy + _LayerShift.xy) * _LayerRepeat.xy);
            o.objectPosFox = float3(-v.vertex.x, v.vertex.y, v.vertex.z);
            o.color = v.color;
        }

        void surf(Input IN, inout SurfaceOutputStandardSpecular o)
        {
            fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
            half3 albedo = baseColor.rgb;
            half alpha = baseColor.a;

        #ifdef _METALIC_BACTERIA
            float mimeticDistance = length(IN.objectPosFox * MimeticPositionScale - _MimeticCenter.xyz);
            half bacteria = tex2D(_MetalicBacteria, IN.uv_MainTex).g;
            half bareAmount = saturate(bacteria + saturate((mimeticDistance - _MimeticRadius.x) / (_MimeticRadius.y - _MimeticRadius.x)) * 2 - 1);
            half coverage = bareAmount;
            if (_MimeticRadius.w != 0)
                coverage += bacteria * saturate(1 - (mimeticDistance - _MimeticRadius.z) / (_MimeticRadius.w - _MimeticRadius.z));
            half4 metalicLayer = tex2D(_MetalicLayer, IN.uv_MainTex);
            half metalicRate = saturate(1 - coverage) * metalicLayer.a;
            albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(albedo), metalicLayer.rgb, metalicRate));
            half mimeticAlphaRate = 1 - (mimeticDistance - _MimeticAlpha.x) / (_MimeticAlpha.y - _MimeticAlpha.x) - bareAmount;
            alpha = saturate(alpha * saturate(1 + mimeticAlphaRate * _MimeticAlpha.z));
        #endif
        #ifdef _LAYER_MULTIPLY
            half4 layerColor = tex2D(_LayerTex, IN.normalAndLayerUV.zw);
            half layerAmount = tex2D(_LayerMask, IN.uv_MainTex).r * layerColor.a;
            half3 gammaAlbedo = LinearToGammaSpace(albedo);
            albedo = GammaToLinearSpace(lerp(gammaAlbedo, gammaAlbedo * LinearToGammaSpace(layerColor.rgb), layerAmount));
        #endif

            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.normalAndLayerUV.xy));

        #ifdef _SPECULARMAP
            half4 specularMap = tex2D(_SpecularMap, IN.uv_MainTex);
            half roughness = specularMap.g;
            o.Specular = _F0 * specularMap.r;
        #else
            half roughness = 1 - _Glossiness;
            o.Specular = _F0;
        #endif

        #ifdef _RUST_DIRTY
            half3 dirtAmount = IN.color.rgb * tex2D(_DirtyMap, IN.uv_MainTex).rgb;
            half3 dirtGamma = LinearToGammaSpace(albedo);
            dirtGamma = lerp(dirtGamma, RustColor, dirtAmount.b);
            dirtGamma = lerp(dirtGamma, DustColor, dirtAmount.g);
            dirtGamma = lerp(dirtGamma, BloodColor, dirtAmount.r);
            albedo = GammaToLinearSpace(dirtGamma);
            roughness = lerp(roughness, RustRoughness, dirtAmount.b);
            roughness = lerp(roughness, DustRoughness, dirtAmount.g);
            roughness = lerp(roughness, BloodRoughness, dirtAmount.r);
        #endif
        #ifdef _DIRTY
            half3 dirtyTexture = tex2D(_DirtyMap, IN.uv_MainTex).rgb;
            half3 dirtAmount = IN.color.rgb * dirtyTexture;
            half3 roughnessMask = IN.color.rgb;
        #ifdef _METALIC_BACTERIA
            roughnessMask = max(half3(0, metalicRate, 0), IN.color.rgb);
        #endif
            half3 roughnessAmount = roughnessMask * dirtyTexture;
            half wetAlbedoScale = lerp(0.93, 0.73, saturate((roughness * 255 - 205) / 25));
            half wetRoughnessScale = 0.66 * saturate((roughness * 255 - 170) / 60);
            half3 dirtGamma = LinearToGammaSpace(albedo);
            dirtGamma = lerp(dirtGamma, dirtGamma * wetAlbedoScale, dirtAmount.b);
            dirtGamma = lerp(dirtGamma, DustColor, dirtAmount.g);
            dirtGamma = lerp(dirtGamma, BloodColor, dirtAmount.r);
            albedo = GammaToLinearSpace(dirtGamma);
            roughness = lerp(roughness, roughness * wetRoughnessScale, roughnessAmount.b);
            roughness = lerp(roughness, DustRoughness, roughnessAmount.g);
            roughness = lerp(roughness, BloodRoughness, roughnessAmount.r);
        #endif
        #ifdef _METALIC_BACTERIA
            half edgeGrazing = pow(saturate(1 - dot(normalize(o.Normal), normalize(IN.viewDir))), _EdgeRoughness);
            half edgeAlpha = lerp(alpha, alpha * _EdgeTrans, edgeGrazing);
            if (_EdgeRoughness == 0)
                edgeAlpha = 0;
            alpha = edgeAlpha;
        #endif

            o.Albedo = albedo;
            o.Alpha = alpha;
            o.Smoothness = 1 - roughness;
            o.Occlusion = 1;
        }
        ENDCG
    }
    FallBack Off
}
