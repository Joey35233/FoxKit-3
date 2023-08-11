using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace FoxKit.TEST
{
	public class GrPluginGlobalVolumetricFog : GrRenderPlugin
	{
		public override string Name => "GlobalVolumetricFog";

		CommandBuffer Buffer;

		private static class TextureIds
		{
		}

		private static class RtIds
		{
			public static int inInterruptTexture = Shader.PropertyToID("inInterruptTexture");

			public static int g_tex_fog = Shader.PropertyToID("g_tex_fog");
		}

		private static class ShaderIds
		{
			public static ShaderTagId MAIN = new ShaderTagId("MAIN");
		}

		public RenderTargetIdentifier InterruptTexture;
		public RenderTargetIdentifier FogTexture;

		private Mesh FogMesh;
		private Material FogMaterial;

		public GrPluginGlobalVolumetricFog()
		{
			Buffer = new CommandBuffer { name = Name };

			FogMesh = AssetDatabase.LoadAssetAtPath<Mesh>("Assets/TEST/Assets/VolFogMesh.obj");
			FogMaterial = new Material(Shader.Find("Fox/VolFog_TppVolFog"));
		}

        public override void Render(ScriptableRenderContext context, Camera camera)
        {
			Buffer.GetTemporaryRT(RtIds.g_tex_fog, 512, 256, 0, FilterMode.Point, UnityEngine.Experimental.Rendering.GraphicsFormat.R16G16B16A16_UNorm);
			FogTexture = new RenderTargetIdentifier(RtIds.g_tex_fog);

			Buffer.GetTemporaryRT(RtIds.inInterruptTexture, 512, 512, 0, FilterMode.Point, UnityEngine.Experimental.Rendering.GraphicsFormat.B8G8R8A8_UNorm);
			InterruptTexture = new RenderTargetIdentifier(RtIds.inInterruptTexture);

			// Draw rain interrupt texture
			Buffer.Blit(Texture2D.whiteTexture, InterruptTexture);

			Buffer.SetRenderTarget(FogTexture);

            // Draw fog LUT
            // ----------------------------------------

            // Base variables
            float density = 0.003f;
            float near = 0;
            float power = 0.9f;
            var color = new Vector4(0.3f, 0.6f, 1, 1);
            var skyAlbedo = new Vector4(2, 2, 2, 1);
            Vector3 sunColor = new Vector3(79104.000000f, 70784.000000f, 55584.000000f) / Mathf.PI;
            var atsh_c00 = new Vector3(16560.000000f, 18240.000000f, 23888.000000f);
            var atsh_c11 = new Vector3(-2360.000000f, 1256.000000f, 6948.000000f);
            var atsh_c22 = new Vector3(-415.250000f, -414.500000f, -387.750000f);
            float mieAnisotropy = 0.6f;
            float fogDirLightGain = 3;
            float skyLightGain = 1;
            float luminance = 6;
            float fogExposure = 0.0003f / 5.22714f;
            float exposureOffset = 0;
            var rayleighScattering = new Vector3(0.1f, 0.8f, 1.5f);
            var mieScattering = new Vector3(0.05f, 0.05f, 0.05f);

            // Intermediates
            float realExposure = fogExposure * Mathf.Pow(2, exposureOffset);
            float farDistance = (density <= 1e06f | power <= 1e-05f) ? 1000000f : Mathf.Clamp(near + Mathf.Pow(-(float)System.Math.Log(0.0003906488) / density, 1.0f / power), 0, Single.MaxValue);

            // Shader inputs
            Vector3 cameraPos = camera.transform.position;
            Vector3 sunDir = RenderSettings.sun is not null ? -RenderSettings.sun.transform.forward : -Vector3.up;
            float representativeDensity = density;
            float mieRatio = 0.3f;
            float sunIntensity = sunColor.magnitude * fogDirLightGain * realExposure;
            Vector3 skyLum = Vector3.Scale((0.28209478f * atsh_c00 + 0.48860252f * atsh_c11 + 0.31539157f * 2 * atsh_c22) / Mathf.PI, skyAlbedo/*.rgb*/) * skyAlbedo.w * skyLightGain * realExposure;
            Vector3 selfLum = color * color.w * luminance * realExposure;
            Vector3 betaM = mieScattering;
            Vector3 betaR = rayleighScattering;
            Vector3 betaU = Vector3.one;
            {
                Vector3 sum = betaM + betaR + betaU;
                float largestComponent = Mathf.Max(sum.x, sum.y, sum.z);
                if (largestComponent > 1e-06)
                {
                    betaM /= largestComponent;
                    betaR /= largestComponent;
                    betaU /= largestComponent;
                }

                betaM *= representativeDensity;
                betaR *= representativeDensity;
                betaU *= representativeDensity;
            }
            float mieK = 1.55f * mieAnisotropy - 0.55f * Mathf.Pow(mieAnisotropy, 3);

            float invLogFarDistance = 1f / Mathf.Log(farDistance, 2);

            // TODO: do betaX above care about their coefficients' beta values?
            {
                //sunIntensity

                float rayleighW = 1.0f;
                float mieW = 1.0f;
                float selfColorA = 1.0f; // selfColor is Entity version of TWPF selfLum I think

                Vector3 rayleigh = rayleighScattering * rayleighW;
                Vector3 mie = mieScattering * mieW;

                Vector4 expSelfColor = selfLum * selfColorA * luminance * realExposure;

                Vector3 onePlusMR = Vector3.one + mie + rayleigh;
            }
            float normalizeFactor = 0.63949f;

            var rainProj = new Matrix4x4
            (
                new Vector4(-1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, -0.0000125001561f, 1),
                new Vector4(0, 0, 0.05f, 0)
            );

            var rainView = new Matrix4x4
            (
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 0, -1, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(-cameraPos.x, -cameraPos.z, cameraPos.y + 35f, 1)
            );

            Matrix4x4 rainViewProj = rainView.transpose * rainProj.transpose;

            // Set variables
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL0, new Vector4(representativeDensity, mieRatio, near, sunIntensity));
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL1, new Vector4(skyLum.x, skyLum.y, skyLum.z, power));
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL2, new Vector4(betaM.x, betaM.y, betaM.z, mieK));
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL3, new Vector4(betaR.x, betaR.y, betaR.z, betaU.x));
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL4, rainViewProj.GetRow(3));
            DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_MATERIAL7, new Vector4(selfLum.x, selfLum.y, selfLum.z, 0));


            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_FOGPARAM1, new Vector4(invLogFarDistance, normalizeFactor, 0, 0));
			DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM0, new Vector4(cameraPos.x, cameraPos.y, cameraPos.z, 1));
			DgShaderDefine.SetVector(FogMaterial, DgShaderDefine.ConstantId.V_LOCALPARAM1, new Vector4(sunDir.x, sunDir.y, sunDir.z, 0));
			Buffer.SetViewMatrix(camera.cameraToWorldMatrix); // Uses m_view to transform viewPos to worldPos so set the view matrix as the inverse view matrix

            Buffer.SetGlobalTexture(RtIds.inInterruptTexture, InterruptTexture);

            Buffer.DrawMesh(FogMesh, Matrix4x4.identity, FogMaterial);

            // Reset and submit
            // ----------------------------------------

            // Reset view to normal
            Buffer.SetViewMatrix(camera.worldToCameraMatrix);

			context.ExecuteCommandBuffer(Buffer);
			Buffer.Clear();

			context.Submit();
		}
	}
}