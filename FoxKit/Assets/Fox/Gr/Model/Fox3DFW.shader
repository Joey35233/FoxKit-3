Shader "Fox/Gr/Fox3DFW"
{
    Properties
    {
        _MainTex("Base_Tex_SRGB or Mask_Tex_LIN", 2D) = "white" {}
        _SelfColor("SelfColor", Vector) = (1, 1, 1, 1)
        _SelfColorIntensity("SelfColorIntensity", Float) = 1
        _SelfColorIntensityMin("SelfColorIntensityMin", Float) = 1
        _SelfColorIntensityMax("SelfColorIntensityMax", Float) = 1
        _ToneMapExposureMin("ToneMapExposureMin", Float) = 0
        _ToneMapExposureMax("ToneMapExposureMax", Float) = 1
        _ExposureValue("Preview exposure (EV)", Float) = 12
        [Toggle(_AUTO_EXPOSURE)] _AutoExposure("Auto exposure", Float) = 0
        [Toggle(_NO_EXPOSURE)] _NoExposure("No exposure (NDR)", Float) = 0
        [KeywordEnum(None, Decode, Encode)] _TextureGamma("Texture gamma", Float) = 0
        _TopColor("TopColor", Vector) = (1, 1, 1, 1)
        _BottomColor("BottomColor", Vector) = (1, 1, 1, 1)
        [NoScaleOffset] _ScrollLayer("ScrollLayer_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _ScrollMask("ScrolMask_Tex_LIN", 2D) = "black" {}
        _ScrollUV("Scroll UV (repeat U, V, shift U, V)", Vector) = (1, 1, 0, 0)
        [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend("Destination blend", Float) = 10
        [Enum(UnityEngine.Rendering.CullMode)] _Cull("Cull", Float) = 2
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Blend One [_DstBlend]
        ZWrite Off
        Cull [_Cull]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma shader_feature_local _AUTO_EXPOSURE
            #pragma shader_feature_local _NO_EXPOSURE
            #pragma shader_feature_local _TEXTUREGAMMA_NONE _TEXTUREGAMMA_DECODE _TEXTUREGAMMA_ENCODE
            #pragma shader_feature_local _GRADATION
            #pragma shader_feature_local _SCROLL_LAYER

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            half4 _TopColor;
            half4 _BottomColor;
            sampler2D _ScrollLayer;
            sampler2D _ScrollMask;
            float4 _ScrollUV;
            float4 _SelfColor;
            float _SelfColorIntensity;
            float _SelfColorIntensityMin;
            float _SelfColorIntensityMax;
            float _ToneMapExposureMin;
            float _ToneMapExposureMax;
            float _ExposureValue;

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 rawUV : TEXCOORD1;
            };

            float2 FlipV(float2 uv)
            {
                return float2(uv.x, 1 - uv.y);
            }

            v2f vert(appdata_base v)
            {
                v2f o;
                o.position = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.rawUV = v.texcoord.xy;
                return o;
            }

            float GetIntensity()
            {
            #ifdef _AUTO_EXPOSURE
                float exposureRange = max(_ToneMapExposureMax - _ToneMapExposureMin, 0.0001);
                float t = saturate((_ExposureValue - _ToneMapExposureMin) / exposureRange);
                return lerp(_SelfColorIntensityMin, _SelfColorIntensityMax, t);
            #else
                return _SelfColorIntensity * exp2(-_ExposureValue);
            #endif
            }

            half4 frag(v2f i) : SV_Target
            {
                half4 texel = tex2D(_MainTex, i.uv);
                half4 color = texel;
            #if defined(_TEXTUREGAMMA_DECODE)
                color.rgb = half3(GammaToLinearSpaceExact(color.r), GammaToLinearSpaceExact(color.g), GammaToLinearSpaceExact(color.b));
            #elif defined(_TEXTUREGAMMA_ENCODE)
                color.rgb = half3(LinearToGammaSpaceExact(color.r), LinearToGammaSpaceExact(color.g), LinearToGammaSpaceExact(color.b));
            #endif
            #ifdef _GRADATION
                half3 gradient = lerp(_TopColor.rgb, _BottomColor.rgb, 1 - i.rawUV.y);
                color = half4(GammaToLinearSpaceExact(gradient.r), GammaToLinearSpaceExact(gradient.g), GammaToLinearSpaceExact(gradient.b), texel.g);
            #endif
            #ifdef _SCROLL_LAYER
                half3 scrollLayer = tex2D(_ScrollLayer, FlipV((i.rawUV + _ScrollUV.zw) * _ScrollUV.xy)).rgb;
                color.rgb += scrollLayer * tex2D(_ScrollMask, i.uv).r;
            #endif
                color *= _SelfColor;
            #ifndef _NO_EXPOSURE
                color.rgb *= GetIntensity();
            #endif
                return half4(color.rgb * color.a, color.a);
            }
            ENDCG
        }
    }
}
