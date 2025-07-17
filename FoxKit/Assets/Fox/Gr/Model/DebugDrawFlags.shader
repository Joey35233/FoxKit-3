Shader "Fox/Gr/DebugDrawFlags"
{
    Properties
    {
        [PerRendererData] DrawFlags("DrawFlags", Integer) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        struct Input
        {
            float2 uv;
        };

        uint DrawFlags;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = (DrawFlags >> 6 & 1) == 0 ? float3(1, 0, 0) : float3(0, 0, 1);

            o.Metallic = 0;
            o.Smoothness = 0.5;
            o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
