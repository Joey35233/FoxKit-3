using UnityEditor;
using UnityEngine;

namespace FoxKit.TEST
{
	internal class FoxShaderEditor : ShaderGUI
	{
		private static class Styles
		{
            public static string TexturesText = "Textures";

            public static string ParametersText = "Parameters";
		}

        public static class Ids
        {
            public static int Base_Tex_SRGB = Shader.PropertyToID("Base_Tex_SRGB");
            public static int g_tex_diffuse = Shader.PropertyToID("g_tex_diffuse");

            public static int NormalMap_Tex_NRM = Shader.PropertyToID("NormalMap_Tex_NRM");
            public static int g_tex_normal = Shader.PropertyToID("g_tex_normal");

            public static int SpecularMap_Tex_LIN = Shader.PropertyToID("SpecularMap_Tex_LIN");
            public static int g_tex_srm = Shader.PropertyToID("g_tex_srm");

            public static int MatParamMap_Tex_LIN = Shader.PropertyToID("MatParamMap_Tex_LIN");
            public static int g_tex_materialmap = Shader.PropertyToID("g_tex_materialmap");

            public static int Layer_Tex_SRGB = Shader.PropertyToID("Layer_Tex_SRGB");
            public static int g_tex_layer = Shader.PropertyToID("g_tex_layer");
            
            public static int LayerMask_Tex_LIN = Shader.PropertyToID("LayerMask_Tex_LIN");
            public static int g_tex_layerMask = Shader.PropertyToID("g_tex_layerMask");

            public static int Dirty_Tex_LIN = Shader.PropertyToID("Dirty_Tex_LIN");
            public static int g_tex_Dirty = Shader.PropertyToID("g_tex_Dirty");
        }

        private static Texture g_tex_mesh;
        private static Texture g_MaterialTexture;

        private Texture g_tex_diffuse;
        private Texture g_tex_normal;
        private Texture g_tex_srm;
        private Texture g_tex_materialmap;
        private Texture g_tex_layer;
        private Texture g_tex_layerMask;
        private Texture g_tex_Dirty;

        static FoxShaderEditor()
        {
            g_tex_mesh = AssetDatabase.LoadAssetAtPath<Texture>("Assets/TEST/gr_dither_nrt_32b.dds");
            Shader.SetGlobalTexture("g_tex_mesh", g_tex_mesh);

            g_tex_mesh = AssetDatabase.LoadAssetAtPath<Texture>("Assets/TEST/materials_alp_rgba32_nomip_nrt.exr");
            Shader.SetGlobalTexture("g_MaterialTexture", g_MaterialTexture);
        }

        MaterialEditor MaterialEditor;
		
		public override void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
		{
            MaterialEditor = materialEditor;

			var material = materialEditor.target as Material;

            DrawEditor(material);
		}

        private void FillBuffers(Material material)
        {
            // SObject
            {
                //var buffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, 1, 208);
                //var data = new Vector4[13];

                //Matrix4x4 world = material.GetMatrix("unity_ObjectToWorld");
                //Matrix4x4 viewWorld = Camera.current.worldToCameraMatrix * world;

                //// m_viewWorld
                //data[0] = viewWorld.GetRow(0);
                //data[1] = viewWorld.GetRow(1);
                //data[2] = viewWorld.GetRow(2);
                //data[3] = viewWorld.GetRow(3);
                //// m_world
                //data[4] = world.GetRow(0);
                //data[5] = world.GetRow(1);
                //data[6] = world.GetRow(2);
                //data[7] = world.GetRow(3);
                //// m_useWeightCount
                //data[8] = new Vector4(0, 0, 0, 0);
                //// m_localParam

            }
        }

		public void DrawEditor(Material material)
		{
			// Use default labelWidth
			EditorGUIUtility.labelWidth = 0f;

			GUILayout.Label(Styles.TexturesText, EditorStyles.boldLabel);

            {
                g_tex_diffuse = material.GetTexture(Ids.Base_Tex_SRGB);
                g_tex_diffuse = (Texture)EditorGUILayout.ObjectField("Base_Tex_SRGB", g_tex_diffuse, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.Base_Tex_SRGB, g_tex_diffuse);
                material.SetTexture(Ids.g_tex_diffuse, g_tex_diffuse);
            }

            {
                g_tex_normal = material.GetTexture(Ids.NormalMap_Tex_NRM);
                g_tex_normal = (Texture)EditorGUILayout.ObjectField("NormalMap_Tex_NRM", g_tex_normal, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.NormalMap_Tex_NRM, g_tex_normal);
                material.SetTexture(Ids.g_tex_normal, g_tex_normal);
            }

            {
                g_tex_srm = material.GetTexture(Ids.SpecularMap_Tex_LIN);
                g_tex_srm = (Texture)EditorGUILayout.ObjectField("SpecularMap_Tex_LIN", g_tex_srm, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.SpecularMap_Tex_LIN, g_tex_srm);
                material.SetTexture(Ids.g_tex_srm, g_tex_srm);
            }

            {
                g_tex_materialmap = material.GetTexture(Ids.MatParamMap_Tex_LIN);
                g_tex_materialmap = (Texture)EditorGUILayout.ObjectField("MatParamMap_Tex_LIN", g_tex_materialmap, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.MatParamMap_Tex_LIN, g_tex_materialmap);
                material.SetTexture(Ids.g_tex_materialmap, g_tex_materialmap);
            }

            {
                g_tex_layer = material.GetTexture(Ids.Layer_Tex_SRGB);
                g_tex_layer = (Texture)EditorGUILayout.ObjectField("Layer_Tex_SRGB", g_tex_layer, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.Layer_Tex_SRGB, g_tex_layer);
                material.SetTexture(Ids.g_tex_layer, g_tex_layer);
            }

            {
                g_tex_layerMask = material.GetTexture(Ids.LayerMask_Tex_LIN);
                g_tex_layerMask = (Texture)EditorGUILayout.ObjectField("LayerMask_Tex_LIN", g_tex_layerMask, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.LayerMask_Tex_LIN, g_tex_layerMask);
                material.SetTexture(Ids.g_tex_layerMask, g_tex_layerMask);
            }

            {
                g_tex_Dirty = material.GetTexture(Ids.Dirty_Tex_LIN);
                g_tex_Dirty = (Texture)EditorGUILayout.ObjectField("Dirty_Tex_LIN", g_tex_Dirty, typeof(Texture), true, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                material.SetTexture(Ids.Dirty_Tex_LIN, g_tex_Dirty);
                material.SetTexture(Ids.g_tex_Dirty, g_tex_Dirty);
            }

            GUILayout.Label(Styles.ParametersText, EditorStyles.boldLabel);

            FillBuffers(material);
		}
	}
}
