using UnityEngine.Rendering;
using UnityEngine;
using System.Collections.Generic;

namespace FoxKit.TEST
{
    public class FoxRenderer
    {
        ScriptableRenderContext Context;

        CommandBuffer Buffer = new CommandBuffer { name = typeof(FoxRenderer).Name };

        public static List<GrRenderPlugin> Plugins = new List<GrRenderPlugin>();

        private Material CopyDepthBuffer_Material;
        private int CopyDepthBuffer_inTexture = Shader.PropertyToID("inTexture");

        private Material CopyRenderBuffer_Material;
        private int CopyRenderBuffer_inImage = Shader.PropertyToID("inImage");

        public FoxRenderer()
        {
            Plugins.Clear();
            Plugins.Add(new GrPluginGlobalVolumetricFog());
            Plugins.Add(new GrPluginDeferredGeometry());
            Plugins.Add(new GrPluginLineIntegralSSAO());
            Plugins.Add(new GrPluginSphericalHarmonics());
            Plugins.Add(new GrPluginTonemap());

            CopyDepthBuffer_Material = new Material(Shader.Find("Fox/CopyDepthBuffer"));

            CopyRenderBuffer_Material = new Material(Shader.Find("Fox/CopyRenderBuffer"));
        }

        public void Render(ScriptableRenderContext context, Camera camera)
        {
            Context = context;

            // To get to Unity FoV number to put in Editor Window: 2*atan(sensorHeight/(2 * focalLength)) * camera.pixelHeight / camera.pixelWidth
            {
                float near = camera.nearClipPlane;
                float far = camera.farClipPlane;

                // Hardcoded MGSV camera info
                const float focalLength = 21;
                const float sensorHeight = 24; // I think this actually might be the width, which would make the camera vertical
                const float sensorWidth = 36;

                camera.usePhysicalProperties = true;
                camera.focalLength = focalLength;
                camera.sensorSize = new Vector2(sensorHeight, sensorWidth);

                Matrix4x4 projectionMatrixDXDepth = Matrix4x4.zero;
                projectionMatrixDXDepth[0, 0] = focalLength / (sensorHeight / 2);
                projectionMatrixDXDepth[1, 1] = projectionMatrixDXDepth[0, 0] * camera.pixelWidth / camera.pixelHeight;
                projectionMatrixDXDepth[2, 2] = near / (far - near);
                projectionMatrixDXDepth[2, 3] = (near * far) / (far - near);
                projectionMatrixDXDepth[3, 2] = -1;

                Matrix4x4 projectionMatrixGLDepth = Matrix4x4.zero;
                projectionMatrixGLDepth[0, 0] = focalLength / (sensorHeight / 2);
                projectionMatrixGLDepth[1, 1] = projectionMatrixGLDepth[0, 0] * camera.pixelWidth / camera.pixelHeight;
                projectionMatrixGLDepth[2, 2] = -(far + near) / (far - near);
                projectionMatrixGLDepth[2, 3] = -2 * (near * far) / (far - near);
                projectionMatrixGLDepth[3, 2] = -1;

                // Set existing camera to 
                camera.projectionMatrix = projectionMatrixGLDepth;

                // Scene selection outline uses custom matrices defined in C++ (credit: HDRP) so we modify the FoV to emulate the perfect correct matrix.
                camera.fieldOfView = 2 * Mathf.Atan(1f / projectionMatrixDXDepth[1, 1]) * Mathf.Rad2Deg;
#if UNITY_EDITOR
                // The scene picker does not care about even the FoV settings - it relies directly on the scene camera settings FoV value. Set that, too.
                if (UnityEditor.SceneView.currentDrawingSceneView != null)
                    UnityEditor.SceneView.currentDrawingSceneView.cameraSettings.fieldOfView = camera.fieldOfView;
#endif

                DgShaderDefine.SetGlobalMatrix(Buffer, DgShaderDefine.ConstantId.M_VIEW, camera.worldToCameraMatrix);
                DgShaderDefine.SetGlobalMatrix(Buffer, DgShaderDefine.ConstantId.M_PROJECTION, projectionMatrixDXDepth);
                DgShaderDefine.SetGlobalMatrix(Buffer, DgShaderDefine.ConstantId.M_PROJECTIONVIEW, projectionMatrixDXDepth * camera.worldToCameraMatrix);
                DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_EYEPOS, camera.transform.position);
                DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_VIEWPORTSIZE, new Vector4(camera.pixelWidth, camera.pixelHeight, camera.nearClipPlane, camera.farClipPlane));
                DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_PROJECTIONPARAM, new Vector4(1f / projectionMatrixDXDepth[0, 0], 1f / projectionMatrixDXDepth[1, 1], projectionMatrixDXDepth[2, 3], -projectionMatrixDXDepth[2, 2]));
            }

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            Context.SetupCameraProperties(camera);

            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_SYSTEMPARAM, Vector4.zero);
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERINFO, new Vector4(camera.pixelWidth, camera.pixelHeight, 0, 0));
            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_RENDERBUFFER_SIZE, new Vector4(camera.pixelWidth, camera.pixelHeight, 1f / camera.pixelWidth, 1f / camera.pixelHeight));

            DgShaderDefine.SetGlobalVector(Buffer, DgShaderDefine.ConstantId.V_EXPOSURE, new Vector4(0, 0, 0.00008f, 0));

            foreach (GrRenderPlugin plugin in Plugins)
                plugin.Render(Context, camera);

            Buffer.SetRenderTarget(BuiltinRenderTextureType.CameraTarget);

            Buffer.SetGlobalTexture(CopyDepthBuffer_inTexture, (Plugins[1] as GrPluginDeferredGeometry).DepthBuffer);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, CopyDepthBuffer_Material);

            DgShaderDefine.SetVector(CopyRenderBuffer_Material, DgShaderDefine.ConstantId.V_LOCALPARAM3, new Vector4(0, 0, 1, 1));
            Buffer.SetGlobalTexture(CopyRenderBuffer_inImage, (Plugins[4] as GrPluginTonemap).Output);
            Buffer.DrawMesh(DgUtils.FullscreenMesh, Matrix4x4.identity, CopyRenderBuffer_Material);

            Context.ExecuteCommandBuffer(Buffer);
            Buffer.Clear();

            //Context.DrawSkybox(camera);

            Context.DrawWireOverlay(camera);

            Context.DrawUIOverlay(camera);
            Context.DrawGizmos(camera, GizmoSubset.PreImageEffects);
            Context.DrawGizmos(camera, GizmoSubset.PostImageEffects);

            camera.ResetProjectionMatrix();
            Context.SetupCameraProperties(camera);

            Context.Submit();
        }
    }
}