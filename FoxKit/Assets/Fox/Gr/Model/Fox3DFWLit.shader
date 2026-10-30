Shader "Fox/Gr/Fox3DFWLit"
{
    Properties
    {
        _MainTex("Base_Tex_SRGB or Base_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _BumpMap("NormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _SubNormalMap("SubNormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _SubNormalMask("SubNormalMask_Tex_LIN", 2D) = "white" {}
        _SubNormalRepeat("SubNormal Repeat (U, V)", Vector) = (1, 1, 0, 0)
        _SubNormalShift("SubNormal Shift (U, V)", Vector) = (0, 0, 0, 0)
        _SubNormalBlend("SubNormal_Blend", Float) = 1
        [NoScaleOffset] _SphereReflection("SpheremapReflection_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _AnimMask("AnimMask_Tex_LIN", 2D) = "white" {}
        _WaterTrans("WaterTrans", Float) = 0
        _WaterRoughness("WaterRoughness", Float) = 0.5
        _IncidenceRoughness("Incidence_Roughness", Float) = 1
        [NoScaleOffset] _SecondBaseTex("SecondBase_Tex_SRGB", 2D) = "black" {}
        [NoScaleOffset] _RiverMask("Mask_Tex_LIN", 2D) = "black" {}
        [Enum(UnityEngine.Rendering.CullMode)] _Cull("Cull", Float) = 2
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" "IgnoreProjector"="True" }
        Blend One OneMinusSrcAlpha
        ZWrite Off
        Cull [_Cull]

        Pass
        {
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma shader_feature_local _ _WATER_COVER _RIVER
            #pragma shader_feature_local _RIVER_TWO_LAYER
            #pragma target 4.0

            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            sampler2D _BumpMap;
            sampler2D _SubNormalMap;
            sampler2D _SubNormalMask;
            float4 _SubNormalRepeat;
            float4 _SubNormalShift;
            half _SubNormalBlend;
            sampler2D _SphereReflection;
            sampler2D _AnimMask;
            half _WaterTrans;
            half _WaterRoughness;
            half _IncidenceRoughness;
            sampler2D _SecondBaseTex;
            sampler2D _RiverMask;

            static const half RiverShininess = 512;

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float2 rawUV : TEXCOORD1;
                float4 tSpace0 : TEXCOORD2;
                float4 tSpace1 : TEXCOORD3;
                float4 tSpace2 : TEXCOORD4;
                UNITY_SHADOW_COORDS(5)
                UNITY_FOG_COORDS(6)
            };

            float2 FlipV(float2 uv)
            {
                return float2(uv.x, 1 - uv.y);
            }

            v2f vert(appdata_full v)
            {
                v2f o;
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.rawUV = v.texcoord.xy;
                float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                float3 worldNormal = UnityObjectToWorldNormal(v.normal);
                float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
                float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w * unity_WorldTransformParams.w;
                o.tSpace0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
                o.tSpace1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
                o.tSpace2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);
                UNITY_TRANSFER_SHADOW(o, v.texcoord1.xy);
                UNITY_TRANSFER_FOG(o, o.pos);
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float3 worldPos = float3(i.tSpace0.w, i.tSpace1.w, i.tSpace2.w);
                half4 baseColor = tex2D(_MainTex, i.uv);
                half3 normalTexture = UnpackNormal(tex2D(_BumpMap, i.uv));
                half3 normal = normalTexture;
            #ifdef _WATER_COVER
                half3 subNormal = UnpackNormal(tex2D(_SubNormalMap, FlipV(i.rawUV * _SubNormalRepeat.xy + _SubNormalShift.xy)));
                normal.xy += subNormal.xy * tex2D(_SubNormalMask, i.uv).r * _SubNormalBlend;
                normal = normalize(normal);
            #endif
                float3 worldNormal = normalize(float3(dot(i.tSpace0.xyz, normal), dot(i.tSpace1.xyz, normal), dot(i.tSpace2.xyz, normal)));
                float3 lightDir = _WorldSpaceLightPos0.xyz;
                float3 viewDir = normalize(UnityWorldSpaceViewDir(worldPos));
                UNITY_LIGHT_ATTENUATION(atten, i, worldPos)
                half lightDotNormal = saturate(dot(worldNormal, lightDir));
                half3 diffuse = _LightColor0.rgb * lightDotNormal * atten;
                half3 ambient = ShadeSH9(float4(worldNormal, 1));
                half3 halfVector = normalize(lightDir + viewDir);
                half halfDotNormal = saturate(dot(worldNormal, halfVector));

            #if defined(_WATER_COVER)
                half3 flatTexture = normalize(normalTexture);
                half alpha = saturate(pow(saturate(1 - flatTexture.z * flatTexture.z), _IncidenceRoughness));
                alpha = max(alpha, _WaterTrans) * baseColor.g * tex2D(_AnimMask, FlipV(i.rawUV + _SubNormalShift.xy)).g;
                half3 viewReflection = normalize(mul((float3x3)UNITY_MATRIX_V, reflect(-viewDir, worldNormal)));
                half3 reflection = tex2D(_SphereReflection, viewReflection.xy * 0.5 + 0.5).rgb;
                half shininess = exp2(lerp(12, 1, _WaterRoughness));
                half3 specular = _LightColor0.rgb * pow(halfDotNormal, shininess) * (shininess + 2.04) / (8 * UNITY_PI) * atten;
                half3 color = reflection * (diffuse + ambient) + specular;
            #elif defined(_RIVER)
                half3 albedo = baseColor.rgb;
            #ifdef _RIVER_TWO_LAYER
                half4 secondColor = tex2D(_SecondBaseTex, i.uv);
                half secondAmount = tex2D(_RiverMask, i.uv).g * secondColor.a;
                albedo = lerp(albedo, secondColor.rgb, secondAmount);
            #endif
                half fresnel = 0.3 + 0.7 * pow(1 - lightDotNormal, 5);
                half3 specular = _LightColor0.rgb * pow(halfDotNormal, RiverShininess) * atten * fresnel;
                half3 cube = DecodeHDR(UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, reflect(-viewDir, worldNormal)), unity_SpecCube0_HDR);
                half cubeFresnel = 0.02 + 0.98 * pow(1 - saturate(dot(worldNormal, viewDir)), 5);
                half3 color = albedo * (diffuse * (1 - fresnel) + ambient) + specular + cube * cubeFresnel;
                half alpha = baseColor.a;
            #else
                half3 color = baseColor.rgb * (diffuse + ambient);
                half alpha = baseColor.a;
            #endif
                half4 result = half4(color * alpha, alpha);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, result, fixed4(unity_FogColor.rgb * alpha, alpha));
                return result;
            }
            ENDCG
        }
    }
    FallBack Off
}
