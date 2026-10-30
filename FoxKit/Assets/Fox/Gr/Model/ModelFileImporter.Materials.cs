using System;
using System.Collections.Generic;
using Fox.Fio;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;

namespace Fox.Gr
{
    public partial class ModelFileImporter
    {
        private const float SupportedModelVersion = 2.04f;

        private const uint AlphaTestMeshFlag = 0x80;

        private const uint TwoSidedMeshFlag = 0x20;

        private const float AlphaCutoff = 0.5f;

        private const string DecalTechniquePrefix = "fox3DDC_";

        private const string TppDecalTechniquePrefix = "tpp3DDC_";

        private const string Fox3DDFShaderPath = "Assets/Fox/Gr/Model/Fox3DDF.shader";

        private const string Fox3DDCShaderPath = "Assets/Fox/Gr/Model/Fox3DDC.shader";

        private const string Fox3DFWShaderPath = "Assets/Fox/Gr/Model/Fox3DFW.shader";

        private const string GlowTechniquePrefix = "fox3DFW_Constant";

        private const string ScrollGlowTechniquePrefix = "tpp3DFW_Constant_Scroll";

        private const string MetalicBacteriaPartPrefix = "MetalicBacteria";

        private const string Fox3DFWGlassShaderPath = "Assets/Fox/Gr/Model/Fox3DFWGlass.shader";

        private const string GlassTechniquePrefix = "fox3DFW_Glass";

        private const string MetalicBacteriaGlassTechniquePrefix = "tpp3DFW_MetalicBacteriaGlass";

        private const string Fox3DFWLitShaderPath = "Assets/Fox/Gr/Model/Fox3DFWLit.shader";

        private const string Fox3DFWUnlitShaderPath = "Assets/Fox/Gr/Model/Fox3DFWUnlit.shader";

        private static readonly string[,] LitTechniqueKeywords =
        {
            { "fox3DFW_Lambert", "" },
            { "fox3DFW_WaterCover", "_WATER_COVER" },
            { "tpp3DFW_PrimRiverModel", "_RIVER" },
        };

        private static readonly string[,] UnlitTechniqueKeywords =
        {
            { "fox3DFW_ParallaxReflection", "_PARALLAX_REFLECTION" },
            { "tpp3DFW_Moon", "_MOON" },
            { "tpp3DFW_Star", "_STAR" },
            { "tpp3DFW_Constant_Sky", "_SKY" },
            { "tpp3DFW_StaticSky", "_SKY" },
            { "tpp3DFW_GenerativeClouds", "_CLOUDS" },
            { "tpp3DFW_TargetMarker", "_TARGET_MARKER" },
            { "tpp3DFW_VolginFire", "_VOLGIN_FIRE" },
        };

        private const string ShadowProxyTechniquePrefix = "fox3DNDW_";

        private const string MaterialParamsPath = "/Assets/fox/effect/gr_pic/material_params.fmtt";

        private const int MaterialParamsEntrySize = 0x20;

        private const int MaterialParamsF0Offset = 0x0;

        private const int MaterialParamsTranslucentOffset = 0x1C;

        private const int MaterialParamsAnisotropicRoughnessOffset = 0x1C;

        private const int NoMaterialId = -1;

        private const uint MaterialParamVectorSize = 0x10;

        private const float TextureGammaDecode = 1;

        private const float TextureGammaEncode = 2;

        private static readonly Dictionary<StrCode, string> TextureSlotByParam = new Dictionary<StrCode, string>
        {
            { new StrCode("Shift_Tex_LIN"), "_ShiftMap" },
            { new StrCode("LensHeight_Tex_LIN"), "_LensHeightMap" },
            { new StrCode("Base_Tex2_SRGB"), "_IrisTex" },
            { new StrCode("ViewReflection_Tex_LIN"), "_ViewReflection" },
            { new StrCode("InternalNormalMap_Tex_NRM"), "_InternalNormalMap" },
            { new StrCode("CoverTranslucentMap_Tex_LIN"), "_CoverMask" },
            { new StrCode("EdgeMask_Tex_LIN"), "_EdgeMask" },
            { new StrCode("MetalicBacteria_Tex_LIN"), "_MetalicBacteria" },
            { new StrCode("BurnPattern_Tex_LIN"), "_BurnPattern" },
            { new StrCode("CylindricalLayer_Tex_LIN"), "_CylindricalLayer" },
            { new StrCode("LightAdd_Tex_LIN"), "_LightAddTex" },
            { new StrCode("ScrolMask_Tex_LIN"), "_ScrollMask" },
            { new StrCode("SpheremapReflection_Tex_LIN"), "_SphereReflection" },
            { new StrCode("AnimMask_Tex_LIN"), "_AnimMask" },
            { new StrCode("SecondBase_Tex_SRGB"), "_SecondBaseTex" },
            { new StrCode("Height_Tex_LIN"), "_HeightMap" },
            { new StrCode("Gradient_Tex_LIN"), "_GradientTex" },
            { new StrCode("Fire_Tex_LIN"), "_FireTex" },
            { new StrCode("Burn_Tex_LIN"), "_BurnTex" },
            { new StrCode("Distortion_Tex_LIN"), "_DistortionTex" },
        };

        private static string FindTechniqueKeyword(string[,] techniqueKeywords, string technique)
        {
            for (int i = 0; i < techniqueKeywords.GetLength(0); i++)
            {
                if (technique.StartsWith(techniqueKeywords[i, 0], StringComparison.Ordinal))
                    return techniqueKeywords[i, 1];
            }
            return null;
        }

        private StrCode ReadTechniqueName(ref FmdlDef def, FileStreamReader reader, ushort platformAliasIndex)
        {
            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MaterialPlatformAliases, platformAliasIndex));
            ushort shaderNameIndex = reader.ReadUInt16();
            ushort techniqueNameIndex = reader.ReadUInt16();
            return ReadNameForIndex(ref def, reader, techniqueNameIndex);
        }

        private static Vector4 ReadVectorParam(ref FmdlDef def, FileStreamReader reader, ushort valueIndex)
        {
            long? bufferPosition = def.GetBufferPosition(BufferType.MaterialParams);
            if (bufferPosition == null)
                return Vector4.zero;

            reader.Seek(bufferPosition.Value + valueIndex * MaterialParamVectorSize);
            return new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }

        private static ulong ReadTexturePathCode(ref FmdlDef def, FileStreamReader reader, uint textureRefIndex)
        {
            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.TextureRefs, textureRefIndex));
            ushort nameIndex = reader.ReadUInt16();
            ushort pathIndex = reader.ReadUInt16();

            reader.Seek(def.GetFeaturePositionForIndex(FeatureType.PathHashes, pathIndex));
            return reader.ReadUInt64();
        }

        private static Texture LoadTexture(ref FmdlDef def, FileStreamReader reader, AssetImportContext context, uint textureRefIndex, string materialName, Action<string> logWarning)
        {
            ulong pathCode = ReadTexturePathCode(ref def, reader, textureRefIndex);
            string foxPath = FtexPathIndex.GetFoxPath(pathCode);
            if (foxPath == null)
            {
                logWarning($"{materialName}: texture 0x{pathCode:X16} isn't in the game folder.");
                return null;
            }

            string ddsPath = System.IO.Path.ChangeExtension(Fox.Fs.FileSystem.GetUnityPathFromFoxPath(foxPath), ".dds");
            if (!System.IO.File.Exists(ddsPath))
            {
                context.DependsOnSourceAsset(ddsPath);
                return null;
            }

            context.DependsOnArtifact(ddsPath);
            return AssetDatabase.LoadAssetAtPath<Texture>(ddsPath);
        }

        private static void FlipTextureVertically(Material material)
        {
            material.mainTextureScale = new Vector2(1, -1);
            material.mainTextureOffset = new Vector2(0, 1);
        }

        private static void MakeCutout(Material material)
        {
            material.SetOverrideTag("RenderType", "TransparentCutout");
            material.EnableKeyword("_ALPHATEST_ON");
            material.SetFloat("_Cutoff", AlphaCutoff);
            material.renderQueue = (int)RenderQueue.AlphaTest;
        }

        private static void MakeTwoSided(Material material)
        {
            material.SetFloat("_Cull", (float)CullMode.Off);
            material.doubleSidedGI = true;
        }

        private static Shader LoadShader(AssetImportContext context, string shaderPath, Shader fallback, Action<string> logWarning)
        {
            context.DependsOnArtifact(shaderPath);
            Shader shader = AssetDatabase.LoadAssetAtPath<Shader>(shaderPath);
            if (shader == null)
            {
                logWarning($"{shaderPath} is missing, using {fallback.name}.");
                return fallback;
            }

            return shader;
        }

        private static string GetTechniqueText(StrCode techniqueName)
        {
            if (HashDictionary.TryGetValue(techniqueName, out string technique))
                return technique;

            return string.Empty;
        }

        private static string GetLayerKeyword(string[] techniqueParts)
        {
            if (Array.IndexOf(techniqueParts, "LayerBl") >= 0)
                return "_LAYER_BLEND";
            if (Array.IndexOf(techniqueParts, "LayerSRGBBl") >= 0)
                return "_LAYER_SRGB_BLEND";
            if (Array.IndexOf(techniqueParts, "LayerMul") >= 0)
                return "_LAYER_MULTIPLY";
            if (Array.IndexOf(techniqueParts, "Cloth") >= 0)
                return "_LAYER_MULTIPLY";

            return null;
        }

        private static int GetMaterialMapIdCount(string[] techniqueParts)
        {
            if (Array.IndexOf(techniqueParts, "4MT") >= 0)
                return 4;
            if (Array.IndexOf(techniqueParts, "3MT") >= 0)
                return 3;
            if (Array.IndexOf(techniqueParts, "2MT") >= 0)
                return 2;

            return 1;
        }

        private static void SetUVSets(Material material, string[] techniqueParts, bool hasLayer)
        {
            bool hasMaskUV = Array.IndexOf(techniqueParts, "MaskUV") >= 0;
            bool hasNormalUV = Array.IndexOf(techniqueParts, "NrmUV") >= 0 || Array.IndexOf(techniqueParts, "DirtyNrmUV") >= 0;
            bool hasNormalLayerMaskUV = Array.IndexOf(techniqueParts, "NrmLyMskUV") >= 0;
            bool hasVertexColorBurn = Array.IndexOf(techniqueParts, "VC") >= 0;
            bool hasNormalMaskUV = Array.IndexOf(techniqueParts, "NrmMaskUV") >= 0;

            float normalUVSet = 0;
            if (hasNormalLayerMaskUV)
                normalUVSet = 1;
            else if (hasNormalUV && hasLayer)
                normalUVSet = 2;
            else if (hasNormalUV || hasNormalMaskUV)
                normalUVSet = 1;
            else if (hasVertexColorBurn)
                normalUVSet = 2;

            if (hasNormalMaskUV)
                material.SetFloat("_SubNormalMaskOnNormalUV", 1);

            float layerMaskUVSet = 0;
            if (hasMaskUV && hasNormalUV)
                layerMaskUVSet = 3;
            else if (hasMaskUV)
                layerMaskUVSet = 2;

            material.SetFloat("_NormalUVSet", normalUVSet);
            material.SetFloat("_LayerMaskUVSet", layerMaskUVSet);
        }

        private static void SetGlowOptions(Material material, string[] techniqueParts)
        {
            if (Array.IndexOf(techniqueParts, "Auto") >= 0)
            {
                material.SetFloat("_AutoExposure", 1);
                material.EnableKeyword("_AUTO_EXPOSURE");
            }
            if (Array.IndexOf(techniqueParts, "Add") >= 0)
                material.SetFloat("_DstBlend", (float)BlendMode.One);
            if (Array.IndexOf(techniqueParts, "NDR") >= 0)
            {
                material.SetFloat("_NoExposure", 1);
                material.EnableKeyword("_NO_EXPOSURE");
            }
            if (Array.IndexOf(techniqueParts, "Gradation") >= 0)
                material.EnableKeyword("_GRADATION");
        }

        private static void SetGlowTextureGamma(Material material, string[] techniqueParts, bool isDecodedByUnity)
        {
            bool isDecodedByGame = Array.IndexOf(techniqueParts, "ConstantSRGB") >= 0 || Array.IndexOf(techniqueParts, "NDR") >= 0;
            if (isDecodedByGame && !isDecodedByUnity)
            {
                material.SetFloat("_TextureGamma", TextureGammaDecode);
                material.EnableKeyword("_TEXTUREGAMMA_DECODE");
            }
            else if (!isDecodedByGame && isDecodedByUnity)
            {
                material.SetFloat("_TextureGamma", TextureGammaEncode);
                material.EnableKeyword("_TEXTUREGAMMA_ENCODE");
            }
        }

        private static void SetGlassOptions(Material material, string[] techniqueParts)
        {
            if (Array.IndexOf(techniqueParts, "GlassColor") >= 0)
            {
                material.SetFloat("_UseGlassColor", 1);
                material.EnableKeyword("_GLASS_COLOR");
            }
        }

        private static bool IsMetalicBacteria(string[] techniqueParts)
        {
            foreach (string part in techniqueParts)
            {
                if (part.StartsWith(MetalicBacteriaPartPrefix, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }

        private static Vector4 MirrorX(Vector4 foxVector)
        {
            return new Vector4(-foxVector.x, foxVector.y, foxVector.z, foxVector.w);
        }

        private static void SetFoxFeatures(Material material, string[] techniqueParts)
        {
            if (Array.IndexOf(techniqueParts, "Hair") >= 0 || Array.IndexOf(techniqueParts, "MetalicBacteriaHair") >= 0)
                material.EnableKeyword("_HAIR");
            else if (Array.IndexOf(techniqueParts, "Eye") >= 0)
                material.EnableKeyword("_EYE");
            else if (Array.IndexOf(techniqueParts, "Reflector") >= 0)
                material.EnableKeyword("_REFLECTOR");
            else if (Array.IndexOf(techniqueParts, "LightCover") >= 0)
                material.EnableKeyword("_LIGHT_COVER");
            else if (Array.IndexOf(techniqueParts, "CurtainShadowPictures") >= 0)
                material.EnableKeyword("_CURTAIN_SHADOW");
            else if (Array.IndexOf(techniqueParts, "TempolaryView") >= 0)
                material.EnableKeyword("_TEMPOLARY_VIEW");
            else if (Array.IndexOf(techniqueParts, "TempolaryAlbedoView") >= 0)
                material.EnableKeyword("_TEMPOLARY_ALBEDO_VIEW");

            bool isFastLeaf = Array.IndexOf(techniqueParts, "FastLeaf") >= 0 || Array.IndexOf(techniqueParts, "FastLeafNormal") >= 0;
            bool isFastWave2 = Array.IndexOf(techniqueParts, "FastWave2") >= 0;
            bool isWave = isFastWave2 || Array.IndexOf(techniqueParts, "FastWave") >= 0 || Array.IndexOf(techniqueParts, "NormalWave") >= 0;
            if (isFastLeaf || isWave)
                material.EnableKeyword("_CONSTANT_SRM");
            if (isFastLeaf)
                material.EnableKeyword("_VERTEX_COLOR_ALBEDO");
            if (isFastWave2)
                material.EnableKeyword("_FOLIAGE_SWAY_U");
            else if (isWave)
                material.EnableKeyword("_FOLIAGE_SWAY");

            if (Array.IndexOf(techniqueParts, "Cloth") >= 0)
                material.SetFloat("_SubNormalOnUV1", 1);
            if (Array.IndexOf(techniqueParts, "DirectiveAlpha") >= 0)
                material.EnableKeyword("_DIRECTIVE_ALPHA");
            if (Array.IndexOf(techniqueParts, "EdgeTrans") >= 0 || IsMetalicBacteria(techniqueParts))
                material.EnableKeyword("_EDGE_ALPHA");
            if (IsMetalicBacteria(techniqueParts))
                material.EnableKeyword("_METALIC_BACTERIA");
            if (Array.IndexOf(techniqueParts, "BurnInvisible") >= 0)
                material.EnableKeyword("_BURN_INVISIBLE");
            if (Array.IndexOf(techniqueParts, "BulletMark") >= 0)
                material.EnableKeyword("_BULLET_MARK");
        }

        private static bool TryReadMaterialParam(int materialId, int valueOffset, Action<string> logWarning, out float value)
        {
            value = 0;
            string tablePath = Fox.Fs.FileSystem.GetExternalPathFromFoxPath(MaterialParamsPath);
            if (!System.IO.File.Exists(tablePath))
            {
                logWarning($"{tablePath} is missing, the material keeps the shader's default.");
                return false;
            }

            byte[] table = System.IO.File.ReadAllBytes(tablePath);
            int offset = materialId * MaterialParamsEntrySize + valueOffset;
            if (materialId < 0 || offset + sizeof(float) > table.Length)
            {
                logWarning($"Material id {materialId} isn't in {tablePath}, the material keeps the shader's default.");
                return false;
            }

            value = BitConverter.ToSingle(table, offset);
            return true;
        }

        private static Vector4 ReadMaterialMapF0(float baseF0, int[] materialMapIds, int materialMapIdCount, Action<string> logWarning)
        {
            var f0Values = new Vector4();
            float previousF0 = baseF0;
            for (int i = 0; i < materialMapIds.Length; i++)
            {
                bool isUsedId = i + 1 < materialMapIdCount && materialMapIds[i] != NoMaterialId;
                if (isUsedId && TryReadMaterialParam(materialMapIds[i], MaterialParamsF0Offset, logWarning, out float f0))
                    previousF0 = f0;
                f0Values[i] = previousF0;
            }

            return f0Values;
        }

        public static List<ulong> ReadTexturePathCodes(string modelPath)
        {
            var pathCodes = new List<ulong>();

            using var reader = new FileStreamReader(System.IO.File.OpenRead(modelPath));
            if (reader.ReadUInt32() != 0x4C444D46u) // "FMDL"
                return pathCodes;
            if (reader.ReadSingle() != SupportedModelVersion)
                return pathCodes;

            FmdlDef def = FmdlDef.Read(reader, 0, message => { }, message => { });

            uint textureRefCount = def.GetFeatureCount(FeatureType.TextureRefs);
            for (uint i = 0; i < textureRefCount; i++)
                pathCodes.Add(ReadTexturePathCode(ref def, reader, i));

            return pathCodes;
        }

        private Material[] ReadMaterials(ref FmdlDef def, FileStreamReader reader, AssetImportContext context, Action<string> logWarning)
        {
            uint materialCount = def.GetFeatureCount(FeatureType.MaterialInstanceHeaders);
            var materials = new Material[materialCount];
            Shader standardShader = Shader.Find("Standard");
            Shader foxShader = LoadShader(context, Fox3DDFShaderPath, standardShader, logWarning);
            Shader decalShader = LoadShader(context, Fox3DDCShaderPath, foxShader, logWarning);
            Shader glowShader = LoadShader(context, Fox3DFWShaderPath, foxShader, logWarning);
            Shader glassShader = LoadShader(context, Fox3DFWGlassShaderPath, foxShader, logWarning);
            Shader litShader = LoadShader(context, Fox3DFWLitShaderPath, foxShader, logWarning);
            Shader unlitShader = LoadShader(context, Fox3DFWUnlitShaderPath, foxShader, logWarning);

            for (uint i = 0; i < materialCount; i++)
            {
                reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MaterialInstanceHeaders, i));

                ushort nameIndex = reader.ReadUInt16();

                reader.SkipPadding(2);

                
                if (!def.ValidateFeatureIndex(FeatureType.MaterialInstanceHeaders, FeatureType.NameHashes, nameIndex)) return null;

                StrCode nameHash = ReadNameForIndex(ref def, reader, nameIndex);

                ushort platformAliasIndex = reader.ReadUInt16();
                byte textureParamCount = reader.ReadByte();
                byte vectorParamCount = reader.ReadByte();
                ushort textureParamsStartIndex = reader.ReadUInt16();
                ushort vectorParamsStartIndex = reader.ReadUInt16();

                string technique = GetTechniqueText(ReadTechniqueName(ref def, reader, platformAliasIndex));
                string[] techniqueParts = technique.Split('_');
                bool isDecal = technique.StartsWith(DecalTechniquePrefix, StringComparison.Ordinal) || technique.StartsWith(TppDecalTechniquePrefix, StringComparison.Ordinal);
                bool isGlow = technique.StartsWith(GlowTechniquePrefix, StringComparison.Ordinal) || technique.StartsWith(ScrollGlowTechniquePrefix, StringComparison.Ordinal);
                bool isGlass = technique.StartsWith(GlassTechniquePrefix, StringComparison.Ordinal) || technique.StartsWith(MetalicBacteriaGlassTechniquePrefix, StringComparison.Ordinal);
                string litKeyword = FindTechniqueKeyword(LitTechniqueKeywords, technique);
                string unlitKeyword = FindTechniqueKeyword(UnlitTechniqueKeywords, technique);
                bool isLit = litKeyword != null;
                bool isUnlit = unlitKeyword != null;
                bool isShadowProxy = technique.StartsWith(ShadowProxyTechniquePrefix, StringComparison.Ordinal);
                bool isRustDirty = Array.IndexOf(techniqueParts, "RustDirty") >= 0;
                bool isDirty = Array.IndexOf(techniqueParts, "Dirty") >= 0;
                bool isMetalicBacteria = IsMetalicBacteria(techniqueParts);
                bool isBurnInvisible = Array.IndexOf(techniqueParts, "BurnInvisible") >= 0;
                bool isCurtain = Array.IndexOf(techniqueParts, "CurtainShadowPictures") >= 0;
                bool isHair = Array.IndexOf(techniqueParts, "Hair") >= 0 || Array.IndexOf(techniqueParts, "MetalicBacteriaHair") >= 0;
                int materialMapIdCount = GetMaterialMapIdCount(techniqueParts);
                string layerKeyword = GetLayerKeyword(techniqueParts);

                Material material;
                if (isDecal)
                    material = new Material(decalShader);
                else if (isGlow)
                    material = new Material(glowShader);
                else if (isGlass)
                    material = new Material(glassShader);
                else if (isLit)
                    material = new Material(litShader);
                else if (isUnlit)
                    material = new Material(unlitShader);
                else
                    material = new Material(foxShader);

                if (HashDictionary.TryGetValue(nameHash, out string materialName))
                    material.name = materialName;
                else
                    material.name = nameHash.ToString();

                SetUVSets(material, techniqueParts, layerKeyword != null);
                if (layerKeyword != null)
                    material.SetFloat("_SubNormalMaskFromLayer", 1);
                if (isGlow)
                    SetGlowOptions(material, techniqueParts);
                if (isGlass)
                    SetGlassOptions(material, techniqueParts);
                if (isLit && litKeyword.Length > 0)
                    material.EnableKeyword(litKeyword);
                if (isLit && Array.IndexOf(techniqueParts, "PrimRiverModelTwoLayer") >= 0)
                    material.EnableKeyword("_RIVER_TWO_LAYER");
                if (isUnlit)
                    material.EnableKeyword(unlitKeyword);
                if (unlitKeyword == "_TARGET_MARKER" || unlitKeyword == "_VOLGIN_FIRE")
                    material.SetFloat("_DstBlend", (float)BlendMode.One);
                if (!isGlow && !isGlass && !isLit && !isUnlit)
                    SetFoxFeatures(material, techniqueParts);

                for (uint j = 0; j < textureParamCount; j++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MaterialParams, textureParamsStartIndex + j));
                    ushort paramNameIndex = reader.ReadUInt16();
                    ushort textureRefIndex = reader.ReadUInt16();
                    StrCode paramName = ReadNameForIndex(ref def, reader, paramNameIndex);

                    if (paramName == "Base_Tex_SRGB" || paramName == "Base_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.mainTexture = texture;
                    }
                    else if (paramName == "NormalMap_Tex_NRM")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_BumpMap", texture);
                            material.EnableKeyword("_NORMALMAP");
                        }
                    }
                    else if (paramName == "SpecularMap_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_SpecularMap", texture);
                            material.EnableKeyword("_SPECULARMAP");
                        }
                    }
                    else if (paramName == "SubNormalMap_Tex_NRM")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_SubNormalMap", texture);
                            material.EnableKeyword("_SUBNORMALMAP");
                        }
                    }
                    else if (paramName == "SmallSubNormalMap_Tex_NRM")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_SmallSubNormalMap", texture);
                            material.EnableKeyword("_SMALLSUBNORMALMAP");
                        }
                    }
                    else if (paramName == "SubNormalMask_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_SubNormalMask", texture);
                    }
                    else if (paramName == "Layer_Tex_SRGB")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null && layerKeyword != null)
                        {
                            material.SetTexture("_LayerTex", texture);
                            material.EnableKeyword(layerKeyword);
                        }
                    }
                    else if (paramName == "LayerMask_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_LayerMask", texture);
                    }
                    else if (paramName == "Mask_Tex_LIN" && (isGlow || isShadowProxy))
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.mainTexture = texture;
                    }
                    else if (paramName == "Mask_Tex_LIN" && isBurnInvisible)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_InvisibleMask", texture);
                    }
                    else if (paramName == "Mask_Tex_LIN" && (unlitKeyword == "_MOON" || unlitKeyword == "_STAR"))
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.mainTexture = texture;
                    }
                    else if (paramName == "Mask_Tex_LIN" && isUnlit)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_AlphaMask", texture);
                    }
                    else if (paramName == "Mask_Tex_LIN" && isLit)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_RiverMask", texture);
                    }
                    else if (paramName == "Translucent_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_TranslucentMap", texture);
                            material.EnableKeyword("_TRANSLUCENT");
                        }
                    }
                    else if (paramName == "MatParamMap_Tex_LIN" && materialMapIdCount > 1)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_MaterialMap", texture);
                            material.EnableKeyword("_MATERIALMAP");
                        }
                    }
                    else if (paramName == "BurningMap_Tex_SRGB")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_BurningMap", texture);
                            material.EnableKeyword("_BURN");
                        }
                    }
                    else if (paramName == "CharcoalMap_Tex_SRGB")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture("_CharcoalMap", texture);
                    }
                    else if (paramName == "Dirty_Tex_LIN" && isRustDirty)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_DirtyMap", texture);
                            material.EnableKeyword("_RUST_DIRTY");
                        }
                    }
                    else if (paramName == "Dirty_Tex_LIN" && isCurtain)
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_DirtyMap", texture);
                            material.EnableKeyword("_BLOOD_DIRTY");
                        }
                    }
                    else if (paramName == "Dirty_Tex_LIN" && (isDirty || isMetalicBacteria))
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_DirtyMap", texture);
                            material.EnableKeyword("_DIRTY");
                        }
                    }
                    else if (paramName == "TensionSubNormalMap_Tex_NRM")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_TensionSubNormalMap", texture);
                            if (Array.IndexOf(techniqueParts, "MetalicBacteriaInnerNormal") >= 0)
                                material.EnableKeyword("_SUBNORMAL_FADE");
                            else
                                material.EnableKeyword("_TENSION");
                        }
                    }
                    else if (paramName == "MetalicLayer_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_MetalicLayer", texture);
                            material.EnableKeyword("_METALIC_LAYER");
                        }
                    }
                    else if (paramName == "ScrollLayer_Tex_LIN")
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                        {
                            material.SetTexture("_ScrollLayer", texture);
                            material.EnableKeyword("_SCROLL_LAYER");
                        }
                    }
                    else if (TextureSlotByParam.TryGetValue(paramName, out string textureSlot))
                    {
                        Texture texture = LoadTexture(ref def, reader, context, textureRefIndex, material.name, logWarning);
                        if (texture != null)
                            material.SetTexture(textureSlot, texture);
                    }
                }

                if (isGlow && material.mainTexture != null)
                    SetGlowTextureGamma(material, techniqueParts, material.mainTexture.isDataSRGB);

                

                Vector2 uvRepeat = Vector2.one;
                Vector2 uvShift = Vector2.zero;
                Vector2 subNormalRepeat = Vector2.one;
                bool hasSubNormalRepeat = false;
                float subNormalBlend = 1;
                Vector2 smallSubNormalRepeat = Vector2.one;
                int[] materialMapIds = { NoMaterialId, NoMaterialId, NoMaterialId };
                int baseMaterialId = NoMaterialId;
                Vector2 layerShiftBL = Vector2.zero;
                Vector4 mimeticRadius = new Vector4(0, 1, 0, 0);
                Vector4 mimeticAlpha = new Vector4(0, 1, 0, 0);
                Vector4 metalicRepeat = Vector4.one;
                Vector4 cylinderScale = new Vector4(1, 1, 0, 0);
                Vector4 lightScale = Vector4.zero;
                Vector4 uvWindow = new Vector4(0, 0, 1, 1);
                for (uint j = 0; j < vectorParamCount; j++)
                {
                    reader.Seek(def.GetFeaturePositionForIndex(FeatureType.MaterialParams, vectorParamsStartIndex + j));
                    ushort paramNameIndex = reader.ReadUInt16();
                    ushort valueIndex = reader.ReadUInt16();
                    StrCode paramName = ReadNameForIndex(ref def, reader, paramNameIndex);
                    Vector4 value = ReadVectorParam(ref def, reader, valueIndex);

                    if (paramName == "URepeat_UV")
                        uvRepeat.x = value.x;
                    else if (paramName == "VRepeat_UV")
                        uvRepeat.y = value.x;
                    else if (paramName == "UShift_UV")
                        uvShift.x = value.x;
                    else if (paramName == "VShift_UV")
                        uvShift.y = value.x;
                    else if (paramName == "URepeat_SubNorm_UV")
                    {
                        subNormalRepeat.x = value.x;
                        hasSubNormalRepeat = true;
                    }
                    else if (paramName == "VRepeat_SubNorm_UV")
                    {
                        subNormalRepeat.y = value.x;
                        hasSubNormalRepeat = true;
                    }
                    else if (paramName == "SubNormal_Blend")
                        subNormalBlend = value.x;
                    else if (paramName == "URepeat_SmallSubNorm_UV")
                        smallSubNormalRepeat.x = value.x;
                    else if (paramName == "VRepeat_SmallSubNorm_UV")
                        smallSubNormalRepeat.y = value.x;
                    else if (paramName == "SmallSubNormal_Blend")
                        material.SetFloat("_SmallSubNormalBlend", value.x);
                    else if (paramName == "SelfColor")
                        material.SetVector("_SelfColor", value);
                    else if (paramName == "SelfColorIntensity")
                        material.SetFloat("_SelfColorIntensity", value.x);
                    else if (paramName == "SelfColorIntensityMin")
                        material.SetFloat("_SelfColorIntensityMin", value.x);
                    else if (paramName == "SelfColorIntensityMax")
                        material.SetFloat("_SelfColorIntensityMax", value.x);
                    else if (paramName == "ToneMapExposureMin")
                        material.SetFloat("_ToneMapExposureMin", value.x);
                    else if (paramName == "ToneMapExposureMax")
                        material.SetFloat("_ToneMapExposureMax", value.x);
                    else if (paramName == "ReflectionColor")
                        material.SetVector("_ReflectionColor", value);
                    else if (paramName == "GlassColor")
                        material.SetVector("_GlassColor", value);
                    else if (paramName == "GlassRoughness")
                        material.SetFloat("_GlassRoughness", value.x);
                    else if (paramName == "MinRoughness")
                    {
                        material.SetFloat("_MinRoughness", value.x);
                        material.EnableKeyword("_MICROROUGHNESS");
                    }
                    else if (paramName == "RoughnessFrequency")
                        material.SetFloat("_RoughnessFrequency", value.x);
                    else if (paramName == "BurningBlend")
                        material.SetFloat("_BurningBlend", value.x);
                    else if (paramName == "Add_Roughness")
                        material.SetFloat("_AddRoughness", value.x);
                    else if (paramName == "Incidence_Color")
                    {
                        material.SetVector("_IncidenceColor", value);
                        material.EnableKeyword("_INCIDENCE");
                    }
                    else if (paramName == "Incidence_Roughness")
                        material.SetFloat("_IncidenceRoughness", value.x);
                    else if (paramName == "MatParamIndex_0")
                    {
                        baseMaterialId = (int)value.x;
                        if (TryReadMaterialParam(baseMaterialId, MaterialParamsF0Offset, logWarning, out float f0))
                            material.SetFloat("_F0", f0);
                    }
                    else if (paramName == "UShiftBL_UV")
                        layerShiftBL.x = value.x;
                    else if (paramName == "VShiftBL_UV")
                        layerShiftBL.y = value.x;
                    else if (paramName == "TensionRate")
                        material.SetFloat("_TensionRate", value.x);
                    else if (paramName == "TensionShift")
                        material.SetFloat("_TensionShift", value.x);
                    else if (paramName == "Anistropic_Diffusion")
                        material.SetFloat("_AnisotropicDiffusion", value.x);
                    else if (paramName == "HairShiftScale")
                        material.SetFloat("_HairShiftScale", value.x);
                    else if (paramName == "HeightScale")
                        material.SetFloat("_HeightScale", value.x);
                    else if (paramName == "AnglePow")
                        material.SetFloat("_AnglePow", value.x);
                    else if (paramName == "StartFadeDot")
                        material.SetFloat("_StartFadeDot", value.x);
                    else if (paramName == "EndFadeDot")
                        material.SetFloat("_EndFadeDot", value.x);
                    else if (paramName == "EdgeRoughness")
                        material.SetFloat("_EdgeRoughness", value.x);
                    else if (paramName == "EdgeTrans")
                        material.SetFloat("_EdgeTrans", value.x);
                    else if (paramName == "Specular_Value")
                        material.SetFloat("_SpecularValue", value.x);
                    else if (paramName == "Roughness_Value")
                        material.SetFloat("_RoughnessValue", value.x);
                    else if (paramName == "Translucent_Value")
                    {
                        material.SetFloat("_TranslucentValue", value.x);
                        material.SetFloat("_TranslucentFromValue", 1);
                        material.EnableKeyword("_TRANSLUCENT");
                    }
                    else if (paramName == "WindDir")
                        material.SetVector("_WindDir", MirrorX(value));
                    else if (paramName == "WindOffset")
                        material.SetVector("_WindOffset", MirrorX(value));
                    else if (paramName == "WindAnimTime")
                        material.SetFloat("_WindAnimTime", value.x);
                    else if (paramName == "WindAmplitude")
                        material.SetFloat("_WindAmplitude", value.x);
                    else if (paramName == "WindRandAmplitude")
                        material.SetFloat("_WindRandAmplitude", value.x);
                    else if (paramName == "WeightDiffusion")
                        material.SetFloat("_WeightDiffusion", value.x);
                    else if (paramName == "WeightOffset")
                        material.SetFloat("_WeightOffset", value.x);
                    else if (paramName == "WeightDiffusionU")
                        material.SetFloat("_WeightDiffusionU", value.x);
                    else if (paramName == "WeightOffsetU")
                        material.SetFloat("_WeightOffsetU", value.x);
                    else if (paramName == "NormalRotRate")
                        material.SetFloat("_NormalRotRate", value.x);
                    else if (paramName == "TempolaryBaseColor")
                        material.SetVector("_TempolaryBaseColor", value);
                    else if (paramName == "MimeticCenter")
                        material.SetVector("_MimeticCenter", value);
                    else if (paramName == "MimeticRadiusMin")
                        mimeticRadius.x = value.x;
                    else if (paramName == "MimeticRadiusMax")
                        mimeticRadius.y = value.x;
                    else if (paramName == "InnerMimeticRadiusMin")
                        mimeticRadius.z = value.x;
                    else if (paramName == "InnerMimeticRadiusMax")
                        mimeticRadius.w = value.x;
                    else if (paramName == "MimeticRateAlphaRadiusMin")
                        mimeticAlpha.x = value.x;
                    else if (paramName == "MimeticRateAlphaRadiusMax")
                        mimeticAlpha.y = value.x;
                    else if (paramName == "MimeticAlphaOffseet")
                        mimeticAlpha.z = value.x;
                    else if (paramName == "URepeatMetalic_UV")
                        metalicRepeat.x = value.x;
                    else if (paramName == "VRepeatMetalic_UV")
                        metalicRepeat.y = value.x;
                    else if (paramName == "URepeatMetalicAlpha_UV")
                        metalicRepeat.z = value.x;
                    else if (paramName == "VRepeatMetalicAlpha_UV")
                        metalicRepeat.w = value.x;
                    else if (paramName == "BurnColor")
                        material.SetVector("_BurnColor", value);
                    else if (paramName == "AlphaMax")
                        material.SetFloat("_AlphaMax", value.x);
                    else if (paramName == "MaskColorAdd")
                        material.SetFloat("_MaskColorAdd", value.x);
                    else if (paramName == "Radius")
                        material.SetFloat("_BulletRadius", value.x);
                    else if (paramName == "DirType")
                        material.SetFloat("_BulletDirType", value.x);
                    else if (paramName == "CylinderCenter")
                        material.SetVector("_CylinderCenter", value);
                    else if (paramName == "CylinderScale_U")
                        cylinderScale.x = value.x;
                    else if (paramName == "CylinderScale_V")
                        cylinderScale.y = value.x;
                    else if (paramName == "CylinderShiftAngle")
                        material.SetFloat("_CylinderShiftAngle", value.x);
                    else if (paramName == "CylinderShiftAngleUp")
                        material.SetFloat("_CylinderShiftAngleUp", value.x);
                    else if (paramName == "LightScale_0")
                        lightScale.x = value.x;
                    else if (paramName == "LightScale_1")
                        lightScale.y = value.x;
                    else if (paramName == "ShadowColor")
                        material.SetVector("_ShadowColor", value);
                    else if (paramName == "LightColor")
                        material.SetVector("_LightColor", value);
                    else if (paramName == "WaterTrans")
                        material.SetFloat("_WaterTrans", value.x);
                    else if (paramName == "WaterRoughness")
                        material.SetFloat("_WaterRoughness", value.x);
                    else if (paramName == "Umin")
                        uvWindow.x = value.x;
                    else if (paramName == "Vmin")
                        uvWindow.y = value.x;
                    else if (paramName == "Umax")
                        uvWindow.z = value.x;
                    else if (paramName == "Vmax")
                        uvWindow.w = value.x;
                    else if (paramName == "DistortionVelocity")
                        material.SetFloat("_DistortionVelocity", value.x);
                    else if (paramName == "DistortionAmount")
                        material.SetFloat("_DistortionAmount", value.x);
                    else if (paramName == "FireLayerIntensity")
                        material.SetFloat("_FireLayerIntensity", value.x);
                    else if (paramName == "BurnLayerIntensity")
                        material.SetFloat("_BurnLayerIntensity", value.x);
                    else if (paramName == "TopColor")
                        material.SetVector("_TopColor", value);
                    else if (paramName == "BottomColor")
                        material.SetVector("_BottomColor", value);
                    else if (paramName == "MatParamIndex_1")
                        materialMapIds[0] = (int)value.x;
                    else if (paramName == "MatParamIndex_2")
                        materialMapIds[1] = (int)value.x;
                    else if (paramName == "MatParamIndex_3")
                        materialMapIds[2] = (int)value.x;
                }

                if (materialMapIdCount > 1)
                    material.SetVector("_MaterialMapF0", ReadMaterialMapF0(material.GetFloat("_F0"), materialMapIds, materialMapIdCount, logWarning));

                if (!hasSubNormalRepeat)
                    subNormalRepeat = uvRepeat;
                material.SetVector("_SubNormalRepeat", subNormalRepeat);
                material.SetFloat("_SubNormalBlend", subNormalBlend);
                material.SetVector("_SmallSubNormalRepeat", smallSubNormalRepeat);
                material.SetVector("_LayerRepeat", uvRepeat);
                material.SetVector("_LayerShift", uvShift);

                if (baseMaterialId != NoMaterialId && material.IsKeywordEnabled("_TRANSLUCENT")
                    && TryReadMaterialParam(baseMaterialId, MaterialParamsTranslucentOffset, logWarning, out float translucentFloor))
                    material.SetFloat("_TranslucentFloor", translucentFloor);
                if (baseMaterialId != NoMaterialId && isHair
                    && TryReadMaterialParam(baseMaterialId, MaterialParamsAnisotropicRoughnessOffset, logWarning, out float anisotropicRoughness))
                    material.SetFloat("_AnisotropicRoughness", anisotropicRoughness);
                if (isHair)
                    material.SetVector("_ShiftRepeat", uvRepeat);
                if (Array.IndexOf(techniqueParts, "SubNormAnim") >= 0 || litKeyword == "_WATER_COVER")
                    material.SetVector("_SubNormalShift", uvShift);
                if (unlitKeyword == "_MOON")
                    material.SetVector("_UVWindow", uvWindow);
                if (isBurnInvisible)
                {
                    material.SetVector("_InvisibleShift", uvShift);
                    material.SetVector("_LayerShift", layerShiftBL);
                }
                if (isMetalicBacteria)
                {
                    material.SetVector("_MimeticRadius", mimeticRadius);
                    material.SetVector("_MimeticAlpha", mimeticAlpha);
                    material.SetVector("_MetalicRepeat", metalicRepeat);
                }
                if (isCurtain)
                {
                    material.SetVector("_CylinderScale", cylinderScale);
                    material.SetVector("_LightScale", lightScale);
                }
                if (isGlow)
                    material.SetVector("_ScrollUV", new Vector4(uvRepeat.x, uvRepeat.y, uvShift.x, uvShift.y));

                FlipTextureVertically(material);
                if (Array.IndexOf(techniqueParts, "UVSCroll") >= 0)
                    material.mainTextureOffset = new Vector2(uvShift.x, 1 - uvShift.y);

                materials[i] = material;
                context.AddObjectToAsset($"Material{i}", material);
            }

            return materials;
        }
    }
}
