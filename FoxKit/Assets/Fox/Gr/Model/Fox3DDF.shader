Shader "Fox/Gr/Fox3DDF"
{
    Properties
    {
        _MainTex("Base_Tex_SRGB", 2D) = "white" {}
        [NoScaleOffset] _BumpMap("NormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _SpecularMap("SpecularMap_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _SubNormalMap("SubNormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _SubNormalMask("SubNormalMask_Tex_LIN", 2D) = "white" {}
        _SubNormalRepeat("SubNormal Repeat (U, V)", Vector) = (1, 1, 0, 0)
        _SubNormalShift("SubNormal Shift (U, V)", Vector) = (0, 0, 0, 0)
        _SubNormalBlend("SubNormal_Blend", Float) = 1
        [Toggle] _SubNormalOnUV1("SubNormal uses UV1", Float) = 0
        [Toggle] _SubNormalMaskOnNormalUV("SubNormal mask uses the normal UV", Float) = 0
        [NoScaleOffset] _SmallSubNormalMap("SmallSubNormalMap_Tex_NRM", 2D) = "bump" {}
        _SmallSubNormalRepeat("SmallSubNormal Repeat (U, V)", Vector) = (1, 1, 0, 0)
        _SmallSubNormalBlend("SmallSubNormal_Blend", Float) = 1
        [NoScaleOffset] _TensionSubNormalMap("TensionSubNormalMap_Tex_NRM", 2D) = "bump" {}
        _TensionRate("TensionRate", Float) = 0
        _TensionShift("TensionShift", Float) = 0
        [NoScaleOffset] _LayerTex("Layer_Tex_SRGB", 2D) = "white" {}
        [NoScaleOffset] _LayerMask("LayerMask_Tex_LIN", 2D) = "white" {}
        _LayerRepeat("Layer Repeat (U, V)", Vector) = (1, 1, 0, 0)
        _LayerShift("Layer Shift (U, V)", Vector) = (0, 0, 0, 0)
        [NoScaleOffset] _TranslucentMap("Translucent_Tex_LIN", 2D) = "black" {}
        _TranslucentFloor("Translucent floor from material_params.fmtt", Range(0, 1)) = 0
        [Toggle] _TranslucentFromValue("Translucency from Translucent_Value", Float) = 0
        _TranslucentValue("Translucent_Value", Float) = 0
        _NormalUVSet("NormalMap UV set", Float) = 0
        _LayerMaskUVSet("LayerMask UV set", Float) = 0
        [Toggle] _SubNormalMaskFromLayer("SubNormal masks come from LayerMask", Float) = 0
        _Glossiness("Smoothness without SpecularMap", Range(0, 1)) = 0.5
        _SpecularValue("Specular_Value", Float) = 1
        _RoughnessValue("Roughness_Value", Float) = 0.5
        _MinRoughness("MinRoughness", Range(0, 1)) = 0.5
        _RoughnessFrequency("RoughnessFrequency", Float) = 1
        [NoScaleOffset] _BurningMap("BurningMap_Tex_SRGB", 2D) = "black" {}
        [NoScaleOffset] _CharcoalMap("CharcoalMap_Tex_SRGB", 2D) = "black" {}
        _BurningBlend("BurningBlend", Range(0, 1)) = 0.7
        _AddRoughness("Add_Roughness", Range(0, 1)) = 0.25
        [NoScaleOffset] _DirtyMap("Dirty_Tex_LIN", 2D) = "black" {}
        _IncidenceColor("Incidence_Color", Vector) = (1, 1, 1, 0)
        _IncidenceRoughness("Incidence_Roughness", Float) = 1
        [NoScaleOffset] _ShiftMap("Shift_Tex_LIN", 2D) = "gray" {}
        _ShiftRepeat("Hair shift repeat (U, V)", Vector) = (1, 1, 0, 0)
        _HairShiftScale("HairShiftScale", Float) = 0
        _AnisotropicDiffusion("Anistropic_Diffusion", Float) = 1
        _AnisotropicRoughness("Anisotropic roughness from material_params.fmtt", Range(0, 1)) = 0.5
        [NoScaleOffset] _LensHeightMap("LensHeight_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _IrisTex("Base_Tex2_SRGB", 2D) = "black" {}
        [NoScaleOffset] _ViewReflection("ViewReflection_Tex_LIN", 2D) = "black" {}
        _HeightScale("HeightScale", Float) = 0
        _AnglePow("AnglePow", Float) = 1
        [NoScaleOffset] _InternalNormalMap("InternalNormalMap_Tex_NRM", 2D) = "bump" {}
        [NoScaleOffset] _CoverMask("CoverTranslucentMap_Tex_LIN", 2D) = "white" {}
        _StartFadeDot("StartFadeDot", Float) = 1
        _EndFadeDot("EndFadeDot", Float) = 0
        [NoScaleOffset] _EdgeMask("EdgeMask_Tex_LIN", 2D) = "white" {}
        _EdgeRoughness("EdgeRoughness", Float) = 1
        _EdgeTrans("EdgeTrans", Float) = 1
        _WindDir("WindDir (x mirrored for Unity)", Vector) = (1, 0, 0, 0)
        _WindAnimTime("WindAnimTime", Float) = 0
        _WindSpeed("Preview wind speed (0 = still)", Float) = 0
        _WindAmplitude("WindAmplitude", Float) = 0
        _WindRandAmplitude("WindRandAmplitude", Float) = 1
        _WindOffset("WindOffset (x mirrored for Unity)", Vector) = (0, 0, 0, 0)
        _WeightDiffusion("WeightDiffusion", Float) = 1
        _WeightOffset("WeightOffset", Float) = 0
        _WeightDiffusionU("WeightDiffusionU", Float) = 1
        _WeightOffsetU("WeightOffsetU", Float) = 0
        _NormalRotRate("NormalRotRate", Float) = 0
        _TempolaryBaseColor("TempolaryBaseColor", Vector) = (1, 1, 1, 0)
        [NoScaleOffset] _MetalicLayer("MetalicLayer_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _MetalicBacteria("MetalicBacteria_Tex_LIN", 2D) = "black" {}
        _MetalicRepeat("Metalic repeat (layer U, V, bacteria U, V)", Vector) = (1, 1, 1, 1)
        _MimeticCenter("MimeticCenter", Vector) = (0, 0, 0, 0)
        _MimeticRadius("Mimetic radius (min, max, inner min, inner max)", Vector) = (0, 1, 0, 0)
        _MimeticAlpha("Mimetic alpha (radius min, max, offset)", Vector) = (0, 1, 0, 0)
        [NoScaleOffset] _BurnPattern("BurnPattern_Tex_LIN", 2D) = "black" {}
        [NoScaleOffset] _InvisibleMask("Mask_Tex_LIN", 2D) = "black" {}
        _InvisibleShift("Invisible mask shift (U, V)", Vector) = (0, 0, 0, 0)
        _BurnColor("BurnColor", Vector) = (0, 0, 0, 0)
        _AlphaMax("AlphaMax", Float) = 1
        _MaskColorAdd("MaskColorAdd", Float) = 0
        _BulletRadius("Radius", Float) = 1
        _BulletDirType("DirType", Float) = 0
        [NoScaleOffset] _CylindricalLayer("CylindricalLayer_Tex_LIN", 2D) = "white" {}
        [NoScaleOffset] _LightAddTex("LightAdd_Tex_LIN", 2D) = "white" {}
        _CylinderCenter("CylinderCenter", Vector) = (0, 0, 0, 0)
        _CylinderScale("Cylinder scale (U, V)", Vector) = (1, 1, 0, 0)
        _CylinderShiftAngle("CylinderShiftAngle", Float) = 0
        _CylinderShiftAngleUp("CylinderShiftAngleUp", Float) = 0
        _LightScale("Light scale (0, 1)", Vector) = (0, 0, 0, 0)
        _ShadowColor("ShadowColor", Vector) = (0, 0, 0, 0)
        _LightColor("LightColor", Vector) = (0, 0, 0, 0)
        _F0("F0 from material_params.fmtt", Range(0, 1)) = 0.04
        [NoScaleOffset] _MaterialMap("MatParamMap_Tex_LIN", 2D) = "black" {}
        _MaterialMapF0("F0 of MatParamIndex 1, 2, 3", Vector) = (0.04, 0.04, 0.04, 0)
        _Cutoff("Alpha Cutoff", Range(0, 1)) = 0.5
        [Enum(UnityEngine.Rendering.CullMode)] _Cull("Cull", Float) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Cull [_Cull]

        CGINCLUDE
        #include "UnityCG.cginc"
        #include "Lighting.cginc"
        #include "AutoLight.cginc"
        #include "UnityPBSLighting.cginc"
        #include "UnityStandardUtils.cginc"

        sampler2D _MainTex;
        float4 _MainTex_ST;
        sampler2D _BumpMap;
        sampler2D _SpecularMap;
        sampler2D _SubNormalMap;
        sampler2D _SubNormalMask;
        float4 _SubNormalRepeat;
        float4 _SubNormalShift;
        half _SubNormalBlend;
        float _SubNormalOnUV1;
        float _SubNormalMaskOnNormalUV;
        sampler2D _SmallSubNormalMap;
        float4 _SmallSubNormalRepeat;
        half _SmallSubNormalBlend;
        sampler2D _TensionSubNormalMap;
        half _TensionRate;
        float _TensionShift;
        sampler2D _LayerTex;
        sampler2D _LayerMask;
        float4 _LayerRepeat;
        float4 _LayerShift;
        sampler2D _TranslucentMap;
        half _TranslucentFloor;
        float _TranslucentFromValue;
        half _TranslucentValue;
        float _NormalUVSet;
        float _LayerMaskUVSet;
        float _SubNormalMaskFromLayer;
        half _Glossiness;
        half _SpecularValue;
        half _RoughnessValue;
        half _MinRoughness;
        half _RoughnessFrequency;
        sampler2D _BurningMap;
        sampler2D _CharcoalMap;
        half _BurningBlend;
        half _AddRoughness;
        sampler2D _DirtyMap;
        half4 _IncidenceColor;
        half _IncidenceRoughness;
        sampler2D _ShiftMap;
        float4 _ShiftRepeat;
        half _HairShiftScale;
        half _AnisotropicDiffusion;
        half _AnisotropicRoughness;
        sampler2D _LensHeightMap;
        sampler2D _IrisTex;
        sampler2D _ViewReflection;
        float _HeightScale;
        half _AnglePow;
        sampler2D _InternalNormalMap;
        sampler2D _CoverMask;
        half _StartFadeDot;
        half _EndFadeDot;
        sampler2D _EdgeMask;
        half _EdgeRoughness;
        half _EdgeTrans;
        float4 _WindDir;
        float _WindAnimTime;
        float _WindSpeed;
        float _WindAmplitude;
        float _WindRandAmplitude;
        float4 _WindOffset;
        float _WeightDiffusion;
        float _WeightOffset;
        float _WeightDiffusionU;
        float _WeightOffsetU;
        float _NormalRotRate;
        half4 _TempolaryBaseColor;
        sampler2D _MetalicLayer;
        sampler2D _MetalicBacteria;
        float4 _MetalicRepeat;
        float4 _MimeticCenter;
        float4 _MimeticRadius;
        float4 _MimeticAlpha;
        sampler2D _BurnPattern;
        sampler2D _InvisibleMask;
        float4 _InvisibleShift;
        half4 _BurnColor;
        half _AlphaMax;
        half _MaskColorAdd;
        half _BulletRadius;
        half _BulletDirType;
        sampler2D _CylindricalLayer;
        sampler2D _LightAddTex;
        float4 _CylinderCenter;
        float4 _CylinderScale;
        float _CylinderShiftAngle;
        float _CylinderShiftAngleUp;
        half4 _LightScale;
        half4 _ShadowColor;
        half4 _LightColor;

        static const half3 RustColor = half3(0.505882353, 0.301960784, 0.192156863);
        static const half3 DustColor = half3(0.2, 0.196078431, 0.192156863);
        static const half3 BloodColor = half3(0.2588, 0.04705, 0.043137);
        static const half RustRoughness = 0.98;
        static const half DustRoughness = 0.98;
        static const half BloodRoughness = 0.2;
        static const float EyeParallaxScale = 0.25;
        static const half TempolaryRoughness = 164.0 / 255.0;
        static const half TempolaryCheckerRepeat = 5;
        static const float MimeticPositionScale = 10;
        half _F0;
        sampler2D _MaterialMap;
        half4 _MaterialMapF0;
        half _Cutoff;

        struct Input
        {
            float2 uv_MainTex;
            float4 layerAndMaskUV;
            float4 normalAndSubNormalUV;
            float2 smallSubNormalUV;
            float2 burnUV;
            float4 rawUV;
            float3 objectPosFox;
            float4 color : COLOR;
            float3 viewDir;
            float3 lightDirTS;
            float3 worldViewDir;
            half3 tangentToWorld0;
            half3 tangentToWorld1;
            half3 tangentToWorld2;
            float facing : VFACE;
        };

        struct SurfaceOutputFoxStandard
        {
            fixed3 Albedo;
            float3 Normal;
            half3 Emission;
            half3 Specular;
            half Smoothness;
            half Occlusion;
            fixed Alpha;
            half Translucency;
        };

        SurfaceOutputStandard ToStandard(SurfaceOutputFoxStandard s)
        {
            SurfaceOutputStandard standard;
            standard.Albedo = s.Albedo;
            standard.Normal = s.Normal;
            standard.Emission = s.Emission;
            standard.Metallic = 0;
            standard.Smoothness = s.Smoothness;
            standard.Occlusion = s.Occlusion;
            standard.Alpha = s.Alpha;
            return standard;
        }

        half4 LightingFoxStandard(SurfaceOutputFoxStandard s, float3 viewDir, UnityGI gi)
        {
            s.Normal = normalize(s.Normal);
            half oneMinusReflectivity = 1 - SpecularStrength(s.Specular);
            half4 color = UNITY_BRDF_PBS(s.Albedo, s.Specular, oneMinusReflectivity, s.Smoothness, s.Normal, viewDir, gi.light, gi.indirect);
            color.a = s.Alpha;
        #ifdef _TRANSLUCENT
            half lightDotNormal = dot(gi.light.dir, s.Normal);
            half wrappedLight = saturate(max(lightDotNormal + s.Translucency * (1 - lightDotNormal * lightDotNormal), s.Translucency * _TranslucentFloor));
            color.rgb += s.Albedo * gi.light.color * (wrappedLight - saturate(lightDotNormal));
        #endif
            return color;
        }

        void LightingFoxStandard_GI(SurfaceOutputFoxStandard s, UnityGIInput data, inout UnityGI gi)
        {
            LightingStandard_GI(ToStandard(s), data, gi);
        }

        float2 FlipV(float2 uv)
        {
            return float2(uv.x, 1 - uv.y);
        }

        float2 SelectUVSet(appdata_full v, float uvSet)
        {
            if (uvSet == 1)
                return v.texcoord1.xy;
            if (uvSet == 2)
                return v.texcoord2.xy;
            if (uvSet == 3)
                return v.texcoord3.xy;
            return v.texcoord.xy;
        }

        float3 TangentToWorldNormal(Input IN, float3 normal)
        {
            return normalize(float3(dot(IN.tangentToWorld0, normal), dot(IN.tangentToWorld1, normal), dot(IN.tangentToWorld2, normal)));
        }

        half GetCheckerPattern(float2 uv, half repeat)
        {
            half2 checker = step(0.5, frac(uv * repeat));
            return 1 - abs(checker.x - checker.y);
        }

        half GetBulletMarkAlpha(half alpha, float2 rawUV)
        {
            half adjustedAlpha = alpha * step(rawUV.x, _BulletRadius);
            if (_BulletDirType >= 0.25)
                adjustedAlpha = alpha * step(rawUV.y, _BulletRadius);
            if (_BulletDirType >= 0.5)
                adjustedAlpha = alpha * step(1 - _BulletRadius, rawUV.x);
            if (_BulletDirType >= 0.75)
                adjustedAlpha = alpha * step(1 - _BulletRadius, rawUV.y);
            return adjustedAlpha;
        }

        half2 GetBurnInvisible(float2 rawUV1)
        {
            half invisible = saturate(tex2D(_BurnPattern, FlipV(rawUV1)).g
                + (tex2D(_InvisibleMask, FlipV(rawUV1 + _InvisibleShift.xy)).g + _MaskColorAdd) * 2 - 1);
            half burnBlend = 1 - saturate(invisible - _AlphaMax) / (1 - _AlphaMax);
            invisible = saturate(invisible / _AlphaMax);
            half steppedAlpha = step(0.25, invisible) * 0.25;
            steppedAlpha += invisible + step(0.5, invisible) * 0.25;
            steppedAlpha += invisible + step(0.75, invisible) * 0.25;
            steppedAlpha += invisible + step(1, invisible) * 0.25;
            return half2(burnBlend, steppedAlpha);
        }

        void ApplyFoliageSway(inout appdata_full v)
        {
        #if defined(_FOLIAGE_SWAY) || defined(_FOLIAGE_SWAY_U)
            float weight = saturate(pow(saturate(1 - v.texcoord.y) + 1e-5, _WeightDiffusion) + _WeightOffset);
        #ifdef _FOLIAGE_SWAY_U
            weight *= saturate(pow(abs(v.texcoord.x) + 1e-5, _WeightDiffusionU) + _WeightOffsetU);
        #endif
            float swing = sin(_WindAnimTime + _Time.y * _WindSpeed + _WindOffset.x);
            float3 worldOffset = normalize(_WindDir.xyz) * (swing * _WindAmplitude * _WindRandAmplitude + _WindDir.w) * weight;
            worldOffset += weight * _WindOffset.xyz * _WindAmplitude;
            v.vertex.xyz += mul((float3x3)unity_WorldToObject, worldOffset);
            float3 worldNormal = UnityObjectToWorldNormal(v.normal);
            float3 raisedNormal = normalize(worldNormal + float3(0, 1, 0) * weight * _WindAmplitude);
            worldNormal = normalize(lerp(worldNormal, raisedNormal, abs(swing) * _NormalRotRate));
            v.normal = normalize(mul(worldNormal, (float3x3)unity_ObjectToWorld));
        #endif
        }

        half GetHairSpecular(Input IN, half specularMap)
        {
            half diffusion = exp2(lerp(7, 1, _AnisotropicRoughness)) * _AnisotropicDiffusion;
            half shift = tex2D(_ShiftMap, FlipV(IN.rawUV.xy * _ShiftRepeat.xy)).r * 2 - 1;
            half3 shiftedTangent = normalize(half3(1, shift * _HairShiftScale, 0));
            half3 view = normalize(IN.viewDir);
            half3 light = normalize(IN.lightDirTS);
            half3 halfVector = half3(dot(shiftedTangent, view), view.y, view.z) + half3(dot(shiftedTangent, light), light.y, light.z);
            half sinTheta = normalize(halfVector).y;
            half specular = pow(sqrt(1 - sinTheta * sinTheta), diffusion);
            return specular * pow(saturate(length(halfVector) * 10), 4) * specularMap;
        }

        half3 GetCurtainShadowPicture(Input IN, half3 colorGamma)
        {
            float3 direction = IN.objectPosFox - _CylinderCenter.xyz;
            float sinAngle;
            float cosAngle;
            sincos(radians(_CylinderShiftAngleUp), sinAngle, cosAngle);
            direction = mul(direction, float3x3(cosAngle, sinAngle, 0, -sinAngle, cosAngle, 0, 0, 0, 1));
            sincos(radians(_CylinderShiftAngle), sinAngle, cosAngle);
            direction = mul(direction, float3x3(cosAngle, 0, -sinAngle, 0, 1, 0, sinAngle, 0, cosAngle));
            direction = normalize(direction);
            float3 horizontal = normalize(float3(direction.x, 0, direction.z));
            float3 vertical = normalize(float3(direction.x, direction.y, 0));
            float2 uv = float2(acos(horizontal.x), acos(-direction.y));
            if (horizontal.z > 0)
                uv.x = UNITY_TWO_PI - uv.x;
            if (vertical.x > 0)
                uv.y = UNITY_TWO_PI - uv.y;
            uv /= float2(UNITY_TWO_PI, UNITY_PI);
            uv = saturate((uv - 0.5) * _CylinderScale.xy * float2(1, 0.5) + 0.5);
            half3 shadow = lerp(_ShadowColor.rgb, 1, tex2D(_CylindricalLayer, uv).r);
            half2 lightAdd = half2(tex2D(_LightAddTex, uv).r, tex2D(_LightAddTex, FlipV(IN.rawUV.zw)).g);
            lightAdd = lerp(1, lightAdd, _LightScale.xy);
            return colorGamma * (1 + shadow * lightAdd.x * lightAdd.y * _LightColor.rgb);
        }

        void vert(inout appdata_full v, out Input o)
        {
            UNITY_INITIALIZE_OUTPUT(Input, o);
            ApplyFoliageSway(v);

            float2 layerUV = (v.texcoord1.xy + _LayerShift.xy) * _LayerRepeat.xy;
            o.layerAndMaskUV.xy = FlipV(layerUV);
            o.layerAndMaskUV.zw = FlipV(SelectUVSet(v, _LayerMaskUVSet));

            float2 normalUV = SelectUVSet(v, _NormalUVSet);
            float2 subNormalUV = normalUV;
            if (_SubNormalOnUV1 > 0.5)
                subNormalUV = v.texcoord1.xy;
            o.normalAndSubNormalUV.xy = FlipV(normalUV);
            o.normalAndSubNormalUV.zw = FlipV(subNormalUV * _SubNormalRepeat.xy + _SubNormalShift.xy);
            o.smallSubNormalUV = FlipV(normalUV * _SmallSubNormalRepeat.xy);
            o.burnUV = FlipV(v.texcoord1.xy);
            o.rawUV = float4(v.texcoord.xy, v.texcoord1.xy);
            o.objectPosFox = float3(-v.vertex.x, v.vertex.y, v.vertex.z);
            o.color = v.color;
        }

        void surf(Input IN, inout SurfaceOutputFoxStandard o)
        {
            fixed4 baseColor = tex2D(_MainTex, IN.uv_MainTex);
            half3 albedo = baseColor.rgb;
            half alpha = baseColor.a;

        #ifdef _EYE
            float3 eyeView = normalize(IN.viewDir);
            half lensHeight = tex2D(_LensHeightMap, IN.uv_MainTex).g;
            float2 parallaxOffset = eyeView.xy * lensHeight * _HeightScale * EyeParallaxScale / eyeView.z;
            half3 iris = tex2D(_IrisTex, IN.uv_MainTex - parallaxOffset).rgb;
            half irisAmount = 1 - pow(1 - lensHeight, 4);
            albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(albedo), LinearToGammaSpace(iris), irisAmount));
        #endif
        #ifdef _LIGHT_COVER
            half3 internalNormal = UnpackNormal(tex2D(_InternalNormalMap, IN.normalAndSubNormalUV.xy));
            if (IN.facing < 0)
                internalNormal.z = -internalNormal.z;
            half3 coverReflection = reflect(-normalize(IN.worldViewDir), TangentToWorldNormal(IN, internalNormal));
            half3 coverCube = DecodeHDR(UNITY_SAMPLE_TEXCUBE(unity_SpecCube0, coverReflection), unity_SpecCube0_HDR);
            albedo = lerp(coverCube, albedo, tex2D(_CoverMask, IN.normalAndSubNormalUV.xy).r);
        #endif

        #if defined(_LAYER_BLEND) || defined(_LAYER_SRGB_BLEND) || defined(_LAYER_MULTIPLY)
            half4 layerColor = tex2D(_LayerTex, IN.layerAndMaskUV.xy);
            half layerAmount = tex2D(_LayerMask, IN.layerAndMaskUV.zw).r * layerColor.a;
        #endif
        #if defined(_LAYER_BLEND)
            albedo = lerp(albedo, layerColor.rgb, layerAmount);
        #elif defined(_LAYER_SRGB_BLEND)
            albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(albedo), LinearToGammaSpace(layerColor.rgb), layerAmount));
        #elif defined(_LAYER_MULTIPLY)
            half3 gammaAlbedo = LinearToGammaSpace(albedo);
            albedo = GammaToLinearSpace(lerp(gammaAlbedo, gammaAlbedo * LinearToGammaSpace(layerColor.rgb), layerAmount));
        #endif
        #ifdef _METALIC_BACTERIA
            float mimeticDistance = length(IN.objectPosFox * MimeticPositionScale - _MimeticCenter.xyz);
            half bacteria = tex2D(_MetalicBacteria, FlipV(IN.rawUV.xy * _MetalicRepeat.zw)).g;
            half bareAmount = saturate(bacteria + saturate((mimeticDistance - _MimeticRadius.x) / (_MimeticRadius.y - _MimeticRadius.x)) * 2 - 1);
            half coverage = bareAmount;
            if (_MimeticRadius.w != 0)
                coverage += bacteria * saturate(1 - (mimeticDistance - _MimeticRadius.z) / (_MimeticRadius.w - _MimeticRadius.z));
            half metalicRate = 0;
        #ifdef _METALIC_LAYER
            half4 metalicLayer = tex2D(_MetalicLayer, FlipV(IN.rawUV.xy * _MetalicRepeat.xy));
            metalicRate = saturate(1 - coverage) * metalicLayer.a;
            albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(albedo), metalicLayer.rgb, metalicRate));
        #endif
            half mimeticAlphaRate = 1 - (mimeticDistance - _MimeticAlpha.x) / (_MimeticAlpha.y - _MimeticAlpha.x) - bareAmount;
            alpha = saturate(alpha * saturate(1 + mimeticAlphaRate * _MimeticAlpha.z));
        #endif
        #ifdef _BURN
            half4 burnColor = tex2D(_BurningMap, IN.burnUV);
            half3 charcoalColor = tex2D(_CharcoalMap, IN.burnUV).rgb;
            half burningAmount = saturate((IN.color.r - 0.25) * 4 + burnColor.a);
            half burnedAmount = saturate((IN.color.r - 0.75) * 4 + burnColor.a);
            half3 unburntGamma = LinearToGammaSpace(albedo);
            half3 burntGamma = lerp(unburntGamma, LinearToGammaSpace(burnColor.rgb), _BurningBlend);
            half3 burnGamma = lerp(unburntGamma, burntGamma, burningAmount);
            burnGamma = lerp(burnGamma, LinearToGammaSpace(charcoalColor), burnedAmount);
            albedo = GammaToLinearSpace(burnGamma);
        #endif
        #ifdef _BURN_INVISIBLE
            half2 burnInvisible = GetBurnInvisible(IN.rawUV.zw);
            albedo = GammaToLinearSpace(saturate(lerp(LinearToGammaSpace(albedo), _BurnColor.rgb, burnInvisible.x)));
            alpha *= burnInvisible.y;
        #endif
        #ifdef _RUST_DIRTY
            half3 dirtAmount = IN.color.rgb * tex2D(_DirtyMap, IN.uv_MainTex).rgb;
            half3 dirtGamma = LinearToGammaSpace(albedo);
            dirtGamma = lerp(dirtGamma, RustColor, dirtAmount.b);
            dirtGamma = lerp(dirtGamma, DustColor, dirtAmount.g);
            dirtGamma = lerp(dirtGamma, BloodColor, dirtAmount.r);
            albedo = GammaToLinearSpace(dirtGamma);
        #endif
        #ifdef _VERTEX_COLOR_ALBEDO
            albedo = GammaToLinearSpace(LinearToGammaSpace(albedo) * IN.color.r);
        #endif
        #if defined(_TEMPOLARY_VIEW)
            albedo = GammaToLinearSpace(_TempolaryBaseColor.rgb * lerp(1, GetCheckerPattern(IN.rawUV.xy, TempolaryCheckerRepeat), _TempolaryBaseColor.a));
            alpha = 1;
        #endif
            o.Albedo = albedo;

        #if defined(_HAIR) || defined(_TEMPOLARY_VIEW) || defined(_TEMPOLARY_ALBEDO_VIEW)
            o.Normal = half3(0, 0, 1);
        #else
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.normalAndSubNormalUV.xy));
        #endif
        #ifdef _TENSION
            float2 tensionUV = float2(IN.normalAndSubNormalUV.x * 0.5 + _TensionShift, IN.normalAndSubNormalUV.y);
            half3 tensionNormal = UnpackNormal(tex2D(_TensionSubNormalMap, tensionUV));
            o.Normal = normalize(half3(o.Normal.xy + tensionNormal.xy * _TensionRate, o.Normal.z));
        #endif
        #if defined(_SUBNORMAL_FADE) && defined(_METALIC_BACTERIA)
            half3 fadeNormal = UnpackNormal(tex2D(_TensionSubNormalMap, IN.normalAndSubNormalUV.xy));
            o.Normal = normalize(lerp(o.Normal, fadeNormal, metalicRate));
        #endif
        #ifdef _SMALLSUBNORMALMAP
            half2 layerNormalMask = tex2D(_LayerMask, IN.normalAndSubNormalUV.xy).rg;
        #endif
        #ifdef _SUBNORMALMAP
        #ifdef _SMALLSUBNORMALMAP
            half subNormalMask = layerNormalMask.r;
        #else
            half subNormalMask = tex2D(_SubNormalMask, IN.uv_MainTex).g;
            if (_SubNormalMaskOnNormalUV > 0.5)
                subNormalMask = tex2D(_SubNormalMask, IN.normalAndSubNormalUV.xy).g;
            if (_SubNormalMaskFromLayer > 0.5)
                subNormalMask = tex2D(_LayerMask, IN.layerAndMaskUV.zw).g;
        #endif
        #ifdef _BURN
            subNormalMask *= burningAmount;
        #endif
            half3 subNormal = UnpackScaleNormal(tex2D(_SubNormalMap, IN.normalAndSubNormalUV.zw), _SubNormalBlend * subNormalMask);
            o.Normal = BlendNormals(o.Normal, subNormal);
        #endif
        #ifdef _SMALLSUBNORMALMAP
            half3 smallSubNormal = UnpackScaleNormal(tex2D(_SmallSubNormalMap, IN.smallSubNormalUV), _SmallSubNormalBlend * layerNormalMask.g);
            o.Normal = BlendNormals(o.Normal, smallSubNormal);
        #endif
            if (IN.facing < 0)
                o.Normal.z = -o.Normal.z;

        #ifdef _INCIDENCE
            half incidenceMask = tex2D(_SpecularMap, IN.uv_MainTex).r;
            half grazing = saturate(1 - dot(normalize(o.Normal), normalize(IN.viewDir)));
            half incidenceAmount = _IncidenceColor.a * incidenceMask * pow(grazing, _IncidenceRoughness);
            o.Albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(o.Albedo), _IncidenceColor.rgb, incidenceAmount));
        #endif
        #ifdef _EYE
            half3 viewNormal = mul((float3x3)UNITY_MATRIX_V, TangentToWorldNormal(IN, o.Normal));
            half3 viewReflection = tex2D(_ViewReflection, viewNormal.xy * 0.5 + 0.5).rgb;
            half eyeSpecular = tex2D(_SpecularMap, IN.uv_MainTex).r;
            o.Albedo = GammaToLinearSpace(saturate(LinearToGammaSpace(o.Albedo) + viewReflection * eyeSpecular));
        #endif

            half f0 = _F0;
        #ifdef _MATERIALMAP
            half materialThreshold = tex2D(_MaterialMap, IN.uv_MainTex).r;
            if (materialThreshold >= 0.25)
                f0 = _MaterialMapF0.x;
            if (materialThreshold >= 0.5)
                f0 = _MaterialMapF0.y;
            if (materialThreshold >= 0.75)
                f0 = _MaterialMapF0.z;
        #endif

        #if defined(_CONSTANT_SRM)
            half roughness = _RoughnessValue;
            half specularRate = _SpecularValue;
        #elif defined(_TEMPOLARY_VIEW) || defined(_TEMPOLARY_ALBEDO_VIEW)
            half roughness = TempolaryRoughness;
            half specularRate = 1;
        #elif defined(_SPECULARMAP)
            half4 specularMap = tex2D(_SpecularMap, IN.uv_MainTex);
            half roughness = specularMap.g;
            half specularRate = specularMap.r;
        #else
            half roughness = 1 - _Glossiness;
            half specularRate = 1;
        #endif
        #ifdef _HAIR
            specularRate = GetHairSpecular(IN, specularRate);
        #endif
        #ifdef _REFLECTOR
            specularRate *= pow(saturate(dot(normalize(o.Normal), normalize(IN.viewDir))), _AnglePow);
        #endif
            o.Specular = f0 * specularRate;
        #ifdef _BURN
            roughness = saturate(_AddRoughness * burningAmount + roughness);
        #endif
        #ifdef _RUST_DIRTY
            roughness = lerp(roughness, RustRoughness, dirtAmount.b);
            roughness = lerp(roughness, DustRoughness, dirtAmount.g);
            roughness = lerp(roughness, BloodRoughness, dirtAmount.r);
        #endif
        #ifdef _MICROROUGHNESS
            half viewDotNormal = dot(normalize(o.Normal), normalize(IN.viewDir));
            half grazingThreshold = 0.5 / _RoughnessFrequency;
            half grazingAmount = saturate((grazingThreshold - viewDotNormal) / (1 - grazingThreshold));
            roughness = lerp(roughness, _MinRoughness * roughness, grazingAmount);
        #endif
        #ifdef _DIRTY
            half3 dirtAmount = IN.color.rgb * tex2D(_DirtyMap, IN.uv_MainTex).rgb;
            half wetAlbedoScale = lerp(0.93, 0.73, saturate((roughness * 255 - 205) / 25));
            half wetRoughnessScale = 0.66 * saturate((roughness * 255 - 170) / 60);
            half3 dirtGamma = LinearToGammaSpace(o.Albedo);
            dirtGamma = lerp(dirtGamma, dirtGamma * wetAlbedoScale, dirtAmount.b);
            dirtGamma = lerp(dirtGamma, DustColor, dirtAmount.g);
            dirtGamma = lerp(dirtGamma, BloodColor, dirtAmount.r);
            o.Albedo = GammaToLinearSpace(dirtGamma);
            roughness = lerp(roughness, roughness * wetRoughnessScale, dirtAmount.b);
            roughness = lerp(roughness, DustRoughness, dirtAmount.g);
            roughness = lerp(roughness, BloodRoughness, dirtAmount.r);
        #endif
        #ifdef _BLOOD_DIRTY
            half3 dirtAmount = IN.color.rgb * tex2D(_DirtyMap, IN.uv_MainTex).rgb;
            o.Albedo = GammaToLinearSpace(lerp(LinearToGammaSpace(o.Albedo), BloodColor, dirtAmount.r));
            roughness = lerp(roughness, BloodRoughness, dirtAmount.r);
        #endif
        #ifdef _CURTAIN_SHADOW
            o.Albedo = GammaToLinearSpace(GetCurtainShadowPicture(IN, LinearToGammaSpace(o.Albedo)));
        #endif
            o.Smoothness = 1 - roughness;
            o.Occlusion = 1;

        #ifdef _EDGE_ALPHA
            half edgeGrazing = pow(saturate(1 - dot(normalize(o.Normal), normalize(IN.viewDir))), _EdgeRoughness);
            half edgeAlpha = lerp(alpha, alpha * _EdgeTrans, edgeGrazing * tex2D(_EdgeMask, IN.uv_MainTex).r);
            if (_EdgeRoughness == 0)
                edgeAlpha = 0;
            alpha = edgeAlpha;
        #endif
        #ifdef _DIRECTIVE_ALPHA
            half facingAmount = abs(dot(normalize(o.Normal), normalize(IN.viewDir)));
            alpha *= (facingAmount - _EndFadeDot) / (_StartFadeDot - _EndFadeDot);
        #endif
        #ifdef _BULLET_MARK
            alpha = GetBulletMarkAlpha(alpha, IN.rawUV.xy);
        #endif
        #ifdef _ALPHATEST_ON
            clip(alpha - _Cutoff);
        #endif

        #ifdef _TRANSLUCENT
            o.Translucency = tex2D(_TranslucentMap, IN.uv_MainTex).g;
            if (_TranslucentFromValue > 0.5)
                o.Translucency = _TranslucentValue;
        #endif
        }

        struct v2fForward
        {
            float4 pos : SV_POSITION;
            float2 uv : TEXCOORD0;
            float4 tSpace0 : TEXCOORD1;
            float4 tSpace1 : TEXCOORD2;
            float4 tSpace2 : TEXCOORD3;
            float4 layerAndMaskUV : TEXCOORD4;
            float4 normalAndSubNormalUV : TEXCOORD5;
            float4 smallSubNormalAndBurnUV : TEXCOORD6;
            half3 sh : TEXCOORD7;
            float4 lmap : TEXCOORD8;
            UNITY_LIGHTING_COORDS(9, 10)
            UNITY_FOG_COORDS(11)
            float4 rawUV : TEXCOORD12;
            float3 objectPosFox : TEXCOORD13;
            fixed4 color : COLOR0;
        };

        float3 GetLightDirection(float3 worldPos)
        {
        #ifdef USING_DIRECTIONAL_LIGHT
            return _WorldSpaceLightPos0.xyz;
        #else
            return normalize(UnityWorldSpaceLightDir(worldPos));
        #endif
        }

        v2fForward vertForward(appdata_full v)
        {
            v2fForward o;
            UNITY_INITIALIZE_OUTPUT(v2fForward, o);
            Input customData;
            vert(v, customData);
            o.layerAndMaskUV = customData.layerAndMaskUV;
            o.normalAndSubNormalUV = customData.normalAndSubNormalUV;
            o.smallSubNormalAndBurnUV = float4(customData.smallSubNormalUV, customData.burnUV);
            o.rawUV = customData.rawUV;
            o.objectPosFox = customData.objectPosFox;
            o.color = v.color;
            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

            float3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
            float3 worldNormal = UnityObjectToWorldNormal(v.normal);
            float3 worldTangent = UnityObjectToWorldDir(v.tangent.xyz);
            float3 worldBinormal = cross(worldNormal, worldTangent) * v.tangent.w * unity_WorldTransformParams.w;
            o.tSpace0 = float4(worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x);
            o.tSpace1 = float4(worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y);
            o.tSpace2 = float4(worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z);

        #ifdef LIGHTMAP_ON
            o.lmap.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
        #endif
        #ifdef DYNAMICLIGHTMAP_ON
            o.lmap.zw = v.texcoord2.xy * unity_DynamicLightmapST.xy + unity_DynamicLightmapST.zw;
        #endif
        #ifndef LIGHTMAP_ON
        #if UNITY_SHOULD_SAMPLE_SH && !UNITY_SAMPLE_FULL_SH_PER_PIXEL
        #ifdef VERTEXLIGHT_ON
            o.sh = Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
                unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
                unity_4LightAtten0, worldPos, worldNormal);
        #endif
            o.sh = ShadeSHPerVertex(worldNormal, o.sh);
        #endif
        #endif

            UNITY_TRANSFER_LIGHTING(o, v.texcoord1.xy);
            UNITY_TRANSFER_FOG(o, o.pos);
            return o;
        }

        SurfaceOutputFoxStandard GetSurface(v2fForward i, float facing, float3 worldViewDir, float3 worldLightDir)
        {
            half3 tangentToWorld0 = i.tSpace0.xyz;
            half3 tangentToWorld1 = i.tSpace1.xyz;
            half3 tangentToWorld2 = i.tSpace2.xyz;

            Input surfaceInput;
            UNITY_INITIALIZE_OUTPUT(Input, surfaceInput);
            surfaceInput.uv_MainTex = i.uv;
            surfaceInput.layerAndMaskUV = i.layerAndMaskUV;
            surfaceInput.normalAndSubNormalUV = i.normalAndSubNormalUV;
            surfaceInput.smallSubNormalUV = i.smallSubNormalAndBurnUV.xy;
            surfaceInput.burnUV = i.smallSubNormalAndBurnUV.zw;
            surfaceInput.rawUV = i.rawUV;
            surfaceInput.objectPosFox = i.objectPosFox;
            surfaceInput.color = i.color;
            surfaceInput.viewDir = tangentToWorld0 * worldViewDir.x + tangentToWorld1 * worldViewDir.y + tangentToWorld2 * worldViewDir.z;
            surfaceInput.lightDirTS = tangentToWorld0 * worldLightDir.x + tangentToWorld1 * worldLightDir.y + tangentToWorld2 * worldLightDir.z;
            surfaceInput.worldViewDir = worldViewDir;
            surfaceInput.tangentToWorld0 = tangentToWorld0;
            surfaceInput.tangentToWorld1 = tangentToWorld1;
            surfaceInput.tangentToWorld2 = tangentToWorld2;
        #if UNITY_VFACE_FLIPPED
            facing = -facing;
        #endif
            surfaceInput.facing = facing;

            SurfaceOutputFoxStandard o;
            UNITY_INITIALIZE_OUTPUT(SurfaceOutputFoxStandard, o);
            o.Normal = half3(0, 0, 1);
            o.Occlusion = 1;
            surf(surfaceInput, o);

            o.Normal = normalize(float3(dot(tangentToWorld0, o.Normal), dot(tangentToWorld1, o.Normal), dot(tangentToWorld2, o.Normal)));
            return o;
        }
        ENDCG

        Pass
        {
            Tags { "LightMode"="ForwardBase" }

            CGPROGRAM
            #pragma vertex vertForward
            #pragma fragment fragBase
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma shader_feature_local _ALPHATEST_ON
            #pragma shader_feature_local _SPECULARMAP
            #pragma shader_feature_local _SUBNORMALMAP
            #pragma shader_feature_local _SMALLSUBNORMALMAP
            #pragma shader_feature_local _INCIDENCE
            #pragma shader_feature_local _ _LAYER_BLEND _LAYER_SRGB_BLEND _LAYER_MULTIPLY
            #pragma shader_feature_local _MATERIALMAP
            #pragma shader_feature_local _TRANSLUCENT
            #pragma shader_feature_local _MICROROUGHNESS
            #pragma shader_feature_local _BURN
            #pragma shader_feature_local _ _RUST_DIRTY _DIRTY _BLOOD_DIRTY
            #pragma shader_feature_local _TENSION
            #pragma shader_feature_local _SUBNORMAL_FADE
            #pragma shader_feature_local _ _HAIR _EYE _REFLECTOR _LIGHT_COVER _CURTAIN_SHADOW _TEMPOLARY_VIEW _TEMPOLARY_ALBEDO_VIEW
            #pragma shader_feature_local _CONSTANT_SRM
            #pragma shader_feature_local _VERTEX_COLOR_ALBEDO
            #pragma shader_feature_local _ _FOLIAGE_SWAY _FOLIAGE_SWAY_U
            #pragma shader_feature_local _DIRECTIVE_ALPHA
            #pragma shader_feature_local _EDGE_ALPHA
            #pragma shader_feature_local _METALIC_BACTERIA
            #pragma shader_feature_local _METALIC_LAYER
            #pragma shader_feature_local _BURN_INVISIBLE
            #pragma shader_feature_local _BULLET_MARK
            #pragma target 5.0

            fixed4 fragBase(v2fForward i, float facing : VFACE) : SV_Target
            {
                float3 worldPos = float3(i.tSpace0.w, i.tSpace1.w, i.tSpace2.w);
                float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
                float3 worldLightDir = GetLightDirection(worldPos);
                SurfaceOutputFoxStandard o = GetSurface(i, facing, worldViewDir, worldLightDir);
                UNITY_LIGHT_ATTENUATION(atten, i, worldPos)

                UnityGI gi;
                UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
                gi.light.color = _LightColor0.rgb;
                gi.light.dir = worldLightDir;

                UnityGIInput giInput;
                UNITY_INITIALIZE_OUTPUT(UnityGIInput, giInput);
                giInput.light = gi.light;
                giInput.worldPos = worldPos;
                giInput.worldViewDir = worldViewDir;
                giInput.atten = atten;
            #if defined(LIGHTMAP_ON) || defined(DYNAMICLIGHTMAP_ON)
                giInput.lightmapUV = i.lmap;
            #endif
            #if UNITY_SHOULD_SAMPLE_SH && !UNITY_SAMPLE_FULL_SH_PER_PIXEL
                giInput.ambient = i.sh;
            #endif
                giInput.probeHDR[0] = unity_SpecCube0_HDR;
                giInput.probeHDR[1] = unity_SpecCube1_HDR;
            #if defined(UNITY_SPECCUBE_BLENDING) || defined(UNITY_SPECCUBE_BOX_PROJECTION)
                giInput.boxMin[0] = unity_SpecCube0_BoxMin;
            #endif
            #ifdef UNITY_SPECCUBE_BOX_PROJECTION
                giInput.boxMax[0] = unity_SpecCube0_BoxMax;
                giInput.probePosition[0] = unity_SpecCube0_ProbePosition;
                giInput.boxMax[1] = unity_SpecCube1_BoxMax;
                giInput.boxMin[1] = unity_SpecCube1_BoxMin;
                giInput.probePosition[1] = unity_SpecCube1_ProbePosition;
            #endif
                LightingFoxStandard_GI(o, giInput, gi);

                fixed4 color = LightingFoxStandard(o, worldViewDir, gi);
                UNITY_APPLY_FOG(i.fogCoord, color);
                UNITY_OPAQUE_ALPHA(color.a);
                return color;
            }
            ENDCG
        }

        Pass
        {
            Tags { "LightMode"="ForwardAdd" }
            Blend One One
            ZWrite Off

            CGPROGRAM
            #pragma vertex vertForward
            #pragma fragment fragAdd
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma shader_feature_local _ALPHATEST_ON
            #pragma shader_feature_local _SPECULARMAP
            #pragma shader_feature_local _SUBNORMALMAP
            #pragma shader_feature_local _SMALLSUBNORMALMAP
            #pragma shader_feature_local _INCIDENCE
            #pragma shader_feature_local _ _LAYER_BLEND _LAYER_SRGB_BLEND _LAYER_MULTIPLY
            #pragma shader_feature_local _MATERIALMAP
            #pragma shader_feature_local _TRANSLUCENT
            #pragma shader_feature_local _MICROROUGHNESS
            #pragma shader_feature_local _BURN
            #pragma shader_feature_local _ _RUST_DIRTY _DIRTY _BLOOD_DIRTY
            #pragma shader_feature_local _TENSION
            #pragma shader_feature_local _SUBNORMAL_FADE
            #pragma shader_feature_local _ _HAIR _EYE _REFLECTOR _LIGHT_COVER _CURTAIN_SHADOW _TEMPOLARY_VIEW _TEMPOLARY_ALBEDO_VIEW
            #pragma shader_feature_local _CONSTANT_SRM
            #pragma shader_feature_local _VERTEX_COLOR_ALBEDO
            #pragma shader_feature_local _ _FOLIAGE_SWAY _FOLIAGE_SWAY_U
            #pragma shader_feature_local _DIRECTIVE_ALPHA
            #pragma shader_feature_local _EDGE_ALPHA
            #pragma shader_feature_local _METALIC_BACTERIA
            #pragma shader_feature_local _METALIC_LAYER
            #pragma shader_feature_local _BURN_INVISIBLE
            #pragma shader_feature_local _BULLET_MARK
            #pragma target 5.0

            fixed4 fragAdd(v2fForward i, float facing : VFACE) : SV_Target
            {
                float3 worldPos = float3(i.tSpace0.w, i.tSpace1.w, i.tSpace2.w);
                float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
                float3 worldLightDir = GetLightDirection(worldPos);
                SurfaceOutputFoxStandard o = GetSurface(i, facing, worldViewDir, worldLightDir);
                UNITY_LIGHT_ATTENUATION(atten, i, worldPos)

                UnityGI gi;
                UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
                gi.light.color = _LightColor0.rgb * atten;
                gi.light.dir = worldLightDir;

                fixed4 color = LightingFoxStandard(o, worldViewDir, gi);
                color.a = 0;
                UNITY_APPLY_FOG_COLOR(i.fogCoord, color, fixed4(0, 0, 0, 0));
                UNITY_OPAQUE_ALPHA(color.a);
                return color;
            }
            ENDCG
        }

        Pass
        {
            Tags { "LightMode"="ShadowCaster" }

            CGPROGRAM
            #pragma vertex vertShadow
            #pragma fragment fragShadow
            #pragma multi_compile_shadowcaster
            #pragma shader_feature_local _ALPHATEST_ON
            #pragma shader_feature_local _ _FOLIAGE_SWAY _FOLIAGE_SWAY_U
            #pragma shader_feature_local _BURN_INVISIBLE
            #pragma shader_feature_local _BULLET_MARK
            #pragma target 5.0

            struct v2fShadow
            {
                V2F_SHADOW_CASTER;
                float2 uv : TEXCOORD1;
                float4 rawUV : TEXCOORD2;
            };

            v2fShadow vertShadow(appdata_full v)
            {
                v2fShadow o;
                UNITY_INITIALIZE_OUTPUT(v2fShadow, o);
                ApplyFoliageSway(v);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.rawUV = float4(v.texcoord.xy, v.texcoord1.xy);
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            fixed4 fragShadow(v2fShadow i) : SV_Target
            {
            #ifdef _ALPHATEST_ON
                half alpha = tex2D(_MainTex, i.uv).a;
            #ifdef _BURN_INVISIBLE
                alpha *= GetBurnInvisible(i.rawUV.zw).y;
            #endif
            #ifdef _BULLET_MARK
                alpha = GetBulletMarkAlpha(alpha, i.rawUV.xy);
            #endif
                clip(alpha - _Cutoff);
            #endif
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
