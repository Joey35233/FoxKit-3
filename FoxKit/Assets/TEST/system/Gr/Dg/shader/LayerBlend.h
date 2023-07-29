// #line 4 "..\Gr\Dg\shader\LayerBlend.h"
#ifndef LAYER_BLEND_H_
#define LAYER_BLEND_H_




// #line 14 "..\Gr\Dg\shader\LayerBlend.h"

half3 MulLayerTexture_Mask(Texture2D layerTexture, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, SamplerLinear, texcoordLayer);


	return (half3)lerp(inColor.xyz, inColor.xyz * layerTex.xyz, mask * layerTex.aaa);
}

half3 MulLayerTexture_MaskWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, layerSampler, texcoordLayer);


	return (half3)lerp(inColor.xyz, inColor.xyz * layerTex.xyz, mask * layerTex.aaa);
}


// #line 40 "..\Gr\Dg\shader\LayerBlend.h"

half3 MulLayerTexture(Texture2D layerTexture, float2 texcoordLayer, Texture2D layerMaskTexture, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, SamplerLinear, texcoordMaskLayer);
	return MulLayerTexture_Mask(layerTexture, texcoordLayer, layerMask.x, inColor);
}

half3 MulLayerTextureWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, Texture2D layerMaskTexture, SamplerState layerMaskSampler, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, layerSampler, texcoordMaskLayer);
	return MulLayerTexture_MaskWithSampler(layerTexture, layerMaskSampler, texcoordLayer, layerMask.x, inColor);
}



// #line 63 "..\Gr\Dg\shader\LayerBlend.h"

half3 BlendLayerTexture_Mask(Texture2D layerTexture, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, SamplerLinear, texcoordLayer);

	layerTex.xyz = (half3)GammaDecode(layerTex.xyz);
	inColor.xyz = (half3)GammaDecode(inColor.xyz);

	return GammaCorrection(lerp(inColor.xyz, layerTex.xyz, mask.xxx * layerTex.aaa));

}

half3 BlendLayerTexture_MaskWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, layerSampler, texcoordLayer);

	layerTex.xyz = (half3)GammaDecode(layerTex.xyz);
	inColor.xyz = (half3)GammaDecode(inColor.xyz);

	return GammaCorrection(lerp(inColor.xyz, layerTex.xyz, mask.xxx * layerTex.aaa));

}


// #line 95 "..\Gr\Dg\shader\LayerBlend.h"

half3 BlendLayerTexture(Texture2D layerTexture, float2 texcoordLayer, Texture2D layerMaskTexture, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, SamplerLinear, texcoordMaskLayer);
	return BlendLayerTexture_Mask(layerTexture, texcoordLayer, layerMask.x, inColor);

}

half3 BlendLayerTextureWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, Texture2D layerMaskTexture, SamplerState layerMaskSampler, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, layerMaskSampler, texcoordMaskLayer);
	return BlendLayerTexture_MaskWithSampler(layerTexture, layerSampler, texcoordLayer, layerMask.x, inColor);

}


// #line 119 "..\Gr\Dg\shader\LayerBlend.h"

half3 SRGBBlendLayerTexture_Mask(Texture2D layerTexture, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, SamplerLinear, texcoordLayer);

	return (half3)lerp(inColor.xyz, layerTex.xyz, mask.xxx * layerTex.aaa);

}

half3 SRGBBlendLayerTexture_MaskWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, half mask,
	half3 inColor)
{
	half4 layerTex = TFetch2DH(layerTexture, layerSampler, texcoordLayer);

	return (half3)lerp(inColor.xyz, layerTex.xyz, mask.xxx * layerTex.aaa);

}


// #line 145 "..\Gr\Dg\shader\LayerBlend.h"

half3 SRGBBlendLayerTexture(Texture2D layerTexture, float2 texcoordLayer, Texture2D layerMaskTexture, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, SamplerLinear, texcoordMaskLayer);
	return SRGBBlendLayerTexture_Mask(layerTexture, texcoordLayer, layerMask.x, inColor);

}

half3 SRGBBlendLayerTextureWithSampler(Texture2D layerTexture, SamplerState layerSampler, float2 texcoordLayer, Texture2D layerMaskTexture, SamplerState layerMaskSampler, float2 texcoordMaskLayer,
	half3 inColor)
{
	half4 layerMask = TFetch2DH(layerMaskTexture, layerMaskSampler, texcoordMaskLayer);
	return SRGBBlendLayerTexture_MaskWithSampler(layerTexture, layerSampler, texcoordLayer, layerMask.x, inColor);

}

#endif	// ifndef LAYER_BLEND_H_