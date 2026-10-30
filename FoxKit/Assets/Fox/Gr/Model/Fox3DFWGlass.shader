Shader "Fox/Gr/Fox3DFWGlass"
{
    Properties
    {
        _MainTex("Base_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _BumpMap("NormalMap_Tex_NRM", 2D) = "bump" {}
        _ReflectionColor("ReflectionColor", Vector) = (1, 1, 1, 1)
        _GlassColor("GlassColor", Vector) = (1, 1, 1, 1)
        _GlassRoughness("GlassRoughness", Range(0, 1)) = 0
        _F0("F0 from material_params.fmtt", Range(0, 1)) = 0.882
        [Toggle(_GLASS_COLOR)] _UseGlassColor("GlassColor technique", Float) = 0
        [Enum(UnityEngine.Rendering.CullMode)] _Cull("Cull", Float) = 2
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        ZWrite Off
        Cull [_Cull]

        CGPROGRAM
        #pragma surface surf FoxGlass alpha:fade
        #pragma shader_feature_local _GLASS_COLOR
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _BumpMap;
        float4 _ReflectionColor;
        float4 _GlassColor;
        float _GlassRoughness;
        float _F0;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldRefl;
            INTERNAL_DATA
        };

        half4 LightingFoxGlass(SurfaceOutput s, half3 viewDir, UnityGI gi)
        {
            half lightDotNormal = saturate(dot(gi.light.dir, s.Normal));
            half halfDotNormal = max(dot(normalize(gi.light.dir + viewDir), s.Normal), 0.0001);
            half3 diffuse = lightDotNormal * gi.light.color;
            half3 specular = lightDotNormal * pow(halfDotNormal, s.Specular) * gi.light.color;

            half4 color;
            color.rgb = s.Albedo * diffuse + specular;
        #ifdef UNITY_LIGHT_FUNCTION_APPLY_INDIRECT
            color.rgb += s.Albedo * gi.indirect.diffuse;
        #endif
            color.a = s.Alpha;
            return color;
        }

        void LightingFoxGlass_GI(SurfaceOutput s, UnityGIInput data, inout UnityGI gi)
        {
            gi = UnityGlobalIllumination(data, 1.0, s.Normal);
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));

            float3 reflectionDirection = WorldReflectionVector(IN, o.Normal);
            half3 reflection = DecodeHDR(UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, reflectionDirection), unity_SpecCube0_HDR) * _ReflectionColor.rgb;
        #ifdef _GLASS_COLOR
            reflection *= baseColor.rgb;
            half opacity = baseColor.a;
        #else
            half opacity = baseColor.r;
        #endif

            half cosValue = saturate(dot(o.Normal, normalize(IN.viewDir)));
            half fresnel = saturate(_F0 + (1 - _F0) * exp2((-5.55473 * cosValue - 6.98316) * cosValue));

            half3 glassColor = lerp(_GlassColor.rgb, reflection, fresnel);
            o.Albedo = lerp(reflection, glassColor, _GlassColor.a);
            o.Specular = exp2(lerp(12, 1, _GlassRoughness));
            o.Alpha = fresnel * opacity;
        }
        ENDCG
    }
    FallBack Off
}
