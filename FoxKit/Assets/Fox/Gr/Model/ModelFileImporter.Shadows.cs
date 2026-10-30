using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Rendering;

namespace Fox.Gr
{
    public partial class ModelFileImporter
    {
        private const uint ShadowModeMeshFlags = 0x300;

        private const uint NoShadowMode = 0x100;

        private const uint ShadowOnlyMode = 0x200;

        private const uint HiddenMode = 0x300;

        private const string FoxNothingShaderPath = "Assets/Fox/Gr/Model/FoxNothing.shader";

        private const string TwoSidedShadowMaterialSuffix = "_TwoSidedShadow";

        private static ShadowCastingMode GetShadowCastingMode(uint shadowMode)
        {
            if (shadowMode == NoShadowMode)
                return ShadowCastingMode.Off;
            if (shadowMode == ShadowOnlyMode)
                return ShadowCastingMode.ShadowsOnly;

            return ShadowCastingMode.On;
        }

        private static Material GetTwoSidedShadowMaterial(AssetImportContext context, Material material, Dictionary<Material, Material> twoSidedShadowMaterials)
        {
            if (twoSidedShadowMaterials.TryGetValue(material, out Material twoSidedMaterial))
                return twoSidedMaterial;

            twoSidedMaterial = new Material(material);
            twoSidedMaterial.name = material.name + TwoSidedShadowMaterialSuffix;
            MakeTwoSided(twoSidedMaterial);
            context.AddObjectToAsset($"TwoSidedShadow{twoSidedShadowMaterials.Count}", twoSidedMaterial);
            twoSidedShadowMaterials.Add(material, twoSidedMaterial);
            return twoSidedMaterial;
        }

        private static Renderer AddRendererCopy(Renderer source, GameObject target)
        {
            if (source is SkinnedMeshRenderer skinnedSource)
            {
                SkinnedMeshRenderer skinnedCopy = target.AddComponent<SkinnedMeshRenderer>();
                skinnedCopy.sharedMesh = skinnedSource.sharedMesh;
                skinnedCopy.bones = skinnedSource.bones;
                skinnedCopy.rootBone = skinnedSource.rootBone;
                skinnedCopy.localBounds = skinnedSource.localBounds;
                return skinnedCopy;
            }

            target.AddComponent<MeshFilter>().sharedMesh = source.GetComponent<MeshFilter>().sharedMesh;
            return target.AddComponent<MeshRenderer>();
        }

        private static void ApplyShadowModes(AssetImportContext context, Renderer mainRenderer, uint[] shadowModes, ref Material nothingMaterial, Dictionary<Material, Material> twoSidedShadowMaterials)
        {
            var distinctModes = new List<uint>();
            foreach (uint shadowMode in shadowModes)
            {
                if (!distinctModes.Contains(shadowMode))
                    distinctModes.Add(shadowMode);
            }

            if (distinctModes.Count == 1)
            {
                if (distinctModes[0] == HiddenMode)
                    mainRenderer.enabled = false;
                else
                    mainRenderer.shadowCastingMode = GetShadowCastingMode(distinctModes[0]);

                if (distinctModes[0] == ShadowOnlyMode)
                {
                    Material[] twoSidedMaterials = mainRenderer.sharedMaterials;
                    for (int i = 0; i < twoSidedMaterials.Length; i++)
                        twoSidedMaterials[i] = GetTwoSidedShadowMaterial(context, twoSidedMaterials[i], twoSidedShadowMaterials);
                    mainRenderer.sharedMaterials = twoSidedMaterials;
                }
                return;
            }

            if (nothingMaterial == null)
            {
                context.DependsOnArtifact(FoxNothingShaderPath);
                nothingMaterial = new Material(AssetDatabase.LoadAssetAtPath<Shader>(FoxNothingShaderPath));
                nothingMaterial.name = "FoxNothing";
                context.AddObjectToAsset("FoxNothing", nothingMaterial);
            }

            Material[] allMaterials = mainRenderer.sharedMaterials;
            bool mainRendererUsed = false;
            foreach (uint shadowMode in distinctModes)
            {
                if (shadowMode == HiddenMode)
                    continue;

                Renderer renderer = mainRenderer;
                if (mainRendererUsed)
                {
                    var child = new GameObject($"{mainRenderer.name}_{GetShadowCastingMode(shadowMode)}");
                    child.transform.SetParent(mainRenderer.transform, false);
                    renderer = AddRendererCopy(mainRenderer, child);
                }
                mainRendererUsed = true;

                var materials = new Material[allMaterials.Length];
                for (int i = 0; i < materials.Length; i++)
                {
                    if (shadowModes[i] != shadowMode)
                        materials[i] = nothingMaterial;
                    else if (shadowMode == ShadowOnlyMode)
                        materials[i] = GetTwoSidedShadowMaterial(context, allMaterials[i], twoSidedShadowMaterials);
                    else
                        materials[i] = allMaterials[i];
                }

                renderer.sharedMaterials = materials;
                renderer.shadowCastingMode = GetShadowCastingMode(shadowMode);
            }
        }
    }
}
