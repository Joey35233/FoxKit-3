Shader "Fox/Gr/Fox3DFWUnlit"
{
    Properties
    {
        _MainTex("Base_Tex_SRGB or Mask_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _HeightMap("Height_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _AlphaMask("Mask_Tex_LIN", 2D) = "white" {}
        _HeightScale("HeightScale", Float) = 0
        _SelfColor("SelfColor", Vector) = (1, 1, 1, 1)
        _SelfColorIntensity("SelfColorIntensity", Float) = 1
        _ExposureValue("Preview exposure (EV)", Float) = 12
        _UVWindow("Moon UV window (Umin, Vmin, Umax, Vmax)", Vector) = (0, 0, 1, 1)
        [NoScaleOffset] _GradientTex("Gradient_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _FireTex("Fire_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _BurnTex("Burn_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _DistortionTex("Distortion_Tex_LIN", 2D) = "black" {}
        _DistortionVelocity("DistortionVelocity", Float) = 0
        _DistortionAmount("DistortionAmount", Float) = 0
        _FireLayerIntensity("FireLayerIntensity", Float) = 1
        _BurnLayerIntensity("BurnLayerIntensity", Float) = 1
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
            #pragma shader_feature_local _ _PARALLAX_REFLECTION _MOON _STAR _SKY _CLOUDS _TARGET_MARKER _VOLGIN_FIRE
            #pragma target 4.0

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _HeightMap;
            sampler2D _AlphaMask;
            float _HeightScale;
            half4 _SelfColor;
            float _SelfColorIntensity;
            float _ExposureValue;
            float4 _UVWindow;
            sampler2D _GradientTex;
            sampler2D _FireTex;
            sampler2D _BurnTex;
            sampler2D _DistortionTex;
            float _DistortionVelocity;
            float _DistortionAmount;
            half _FireLayerIntensity;
            half _BurnLayerIntensity;

            static const float ParallaxScale = 0.25;
            static const float StarMinMagnitude = 7.0;
            static const float StarMaxMagnitude = -1.44;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 rawUV : TEXCOORD1;
                float3 viewDirTS : TEXCOORD2;
                float3 worldPos : TEXCOORD3;
                float4 screenPos : TEXCOORD4;
                fixed4 color : COLOR0;
            };

            v2f vert(appdata_full v)
            {
                v2f o;
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.rawUV = v.texcoord.xy;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w * unity_WorldTransformParams.w;
                float3 worldView = UnityWorldSpaceViewDir(o.worldPos);
                o.viewDirTS = float3(dot(worldTangent, worldView), dot(worldBinormal, worldView), dot(worldNormal, worldView));
                o.screenPos = ComputeScreenPos(o.pos);
                o.color = v.color;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float exposure = exp2(-_ExposureValue);
            #if defined(_PARALLAX_REFLECTION)
                float3 view = normalize(i.viewDirTS);
                float height = (1 - tex2D(_HeightMap, i.uv).g) + 1;
                float2 uv = saturate(i.uv + view.xy * height * abs(_HeightScale) * ParallaxScale / view.z);
                if (_HeightScale < 0)
                {
                    uv = i.screenPos.xy / i.screenPos.w;
                    uv.x = 1 - uv.x;
                }
                half3 color = tex2D(_MainTex, uv).rgb;
                half alpha = tex2D(_AlphaMask, i.uv).g;
            #elif defined(_MOON)
                half4 moon = tex2D(_MainTex, i.uv);
                half3 color = moon.rgb * _SelfColor.rgb * _SelfColorIntensity * exposure;
                half alpha = moon.a * _SelfColor.a;
                alpha *= step(_UVWindow.x, i.rawUV.x) * step(_UVWindow.y, i.rawUV.y) * step(i.rawUV.x, _UVWindow.z) * step(i.rawUV.y, _UVWindow.w);
            #elif defined(_STAR)
                half4 star = tex2D(_MainTex, i.uv);
                float magnitudeScale = (StarMaxMagnitude - StarMinMagnitude) / 5.0 * 6.6438562;
                float3 intensity = exp2(magnitudeScale * i.color.a) * _SelfColor.rgb;
                half3 color = star.rgb * i.color.rgb * intensity * exposure;
                half alpha = star.a * saturate(intensity.g) * _SelfColor.a;
            #elif defined(_SKY)
                half3 color = DecodeHDR(UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, normalize(i.worldPos - _WorldSpaceCameraPos)), unity_SpecCube0_HDR);
                half alpha = 1;
            #elif defined(_CLOUDS)
                half3 color = 0;
                half alpha = 0;
            #elif defined(_TARGET_MARKER)
                half4 gradient = tex2D(_GradientTex, i.uv);
                half3 color = _SelfColor.rgb * gradient.rgb * _SelfColorIntensity * exposure;
                half alpha = _SelfColor.a * gradient.a;
            #elif defined(_VOLGIN_FIRE)
                float2 distortion = (tex2D(_DistortionTex, i.uv + _Time.y * _DistortionVelocity).rg * 2 - 1) * _DistortionAmount;
                half3 color = tex2D(_FireTex, i.uv + distortion).rgb * _FireLayerIntensity + tex2D(_BurnTex, i.uv).rgb * _BurnLayerIntensity;
                half alpha = tex2D(_AlphaMask, i.uv).g;
            #else
                half4 texel = tex2D(_MainTex, i.uv);
                half3 color = texel.rgb;
                half alpha = texel.a;
            #endif
                return half4(color * alpha, alpha);
            }
            ENDCG
        }
    }
    FallBack Off
}
