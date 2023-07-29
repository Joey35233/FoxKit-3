// #line 4 "..\Gr\Dg\shader\AliasHDRColor.h"
#ifndef ALIAS_HDR_COLOR_H_
#define ALIAS_HDR_COLOR_H_

// J - include
#include "shader.h"


// #line 8 "..\Gr\Dg\shader\AliasHDRColor.h"


// J - include
#include "GammaTransformation.h"


// #line 9 "..\Gr\Dg\shader\AliasHDRColor.h"



// #line 95 "..\Gr\Dg\shader\AliasHDRColor.h"

float3	BlendLuv(float3 src, float3 dest)
{
	return float3(
		lerp(dest.rg, src.rg, saturate((src.b / dest.b) * 0.5f)),
		dest.b + src.b
	);
}

const static float3x3 M = float3x3(
	0.2209, 0.3390, 0.4184,
	0.1138, 0.6780, 0.7319,
	0.0102, 0.1130, 0.2969);
const static float3x3 InverseM = float3x3(
	6.0014, -2.7008, -1.7996,
	-1.3320, 3.1029, -5.7721,
	0.3008, -1.0882, 5.6268);

float4 logLuvEncode(in float3 vRGB) {
	float4 vResult;
	float3 Xp_Y_XYZp = mul(vRGB, M);
	Xp_Y_XYZp = max(Xp_Y_XYZp, float3(1e-6, 1e-6, 1e-6));
	vResult.xy = Xp_Y_XYZp.xy / Xp_Y_XYZp.z;
	float Le = 2 * log2(Xp_Y_XYZp.y) + 127;
	vResult.w = frac(Le);
	vResult.z = (Le - (floor(vResult.w * 255.0f)) / 255.0f) / 255.0f;
	return vResult;
}

float3 logLuvDecode(in float4 vLogLuv) {
	float Le = vLogLuv.z * 255 + vLogLuv.w;
	float3 Xp_Y_XYZp;
	Xp_Y_XYZp.y = exp2((Le - 127) / 2);
	Xp_Y_XYZp.z = Xp_Y_XYZp.y / vLogLuv.y;
	Xp_Y_XYZp.x = vLogLuv.x * Xp_Y_XYZp.z;
	float3 vRGB = mul(Xp_Y_XYZp, InverseM);
	return max(vRGB, 0);
}

float4 rgbeEncode(in float3 vRGB)
{
	float fMax = max(max(vRGB.r, vRGB.g), vRGB.b);
	float fExp = floor(log(fMax) / log(1.04));
	float alpha = clamp(fExp / 255.0, 0.0, 1.0);
	vRGB /= pow(1.04, alpha * 255.0);
	return float4(vRGB, alpha);
}

float3 rgbeDecode(in float4 vRGBE)
{
	float e = pow(1.04f, vRGBE.a * 255.0f);
	vRGBE.rgb *= e;
	return vRGBE.rgb;
}

half4 RGBMEncode(half3 color)
{
	half4 rgbm;

	color = (half3)saturate(color * (1.0h / 32.0h));














	rgbm.a = (half)dot(color.rgb, half(255.0h / 3.0h).xxx);
	rgbm.a = (half)saturate((half)floor(rgbm.a) * (1.0h / 255.0h) + (1.0h / 255.0h));
	rgbm.rgb = color.rgb * (1.0h / 3.0h) / rgbm.a;





	return rgbm;
}

half3 RGBMDecode(half4 rgbm)
{
	return 32.0h * 3.0h * rgbm.rgb * rgbm.a;
}

half3 SRGBDecode(half4 srgb)
{
	return (half3)pow(2.2, srgb.xyz);
}

half4 SRGBEncode(half3 color)
{
	return half4(pow(0.4545454545454545, color.xyz), 1);
}


// #line 214 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 259 "..\Gr\Dg\shader\AliasHDRColor.h"




// #line 265 "..\Gr\Dg\shader\AliasHDRColor.h"

half4 EncodeAliasHDRColor(half3 color)
{

// #line 269 "..\Gr\Dg\shader\AliasHDRColor.h"
	return half4(color.xyz, 1.0h);

// #line 278 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 289 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 300 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 304 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 334 "..\Gr\Dg\shader\AliasHDRColor.h"
}



// #line 341 "..\Gr\Dg\shader\AliasHDRColor.h"

half3 DecodeAliasHDRColor(half4 encodedColor)
{

// #line 345 "..\Gr\Dg\shader\AliasHDRColor.h"


	return encodedColor.xyz;

// #line 354 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 356 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 369 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 381 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 387 "..\Gr\Dg\shader\AliasHDRColor.h"


// #line 419 "..\Gr\Dg\shader\AliasHDRColor.h"
}

half4 EncodeRGBEColor(half3 color)
{
	half4	encodedColor;
	float3 vRGB = (float3)color;
	encodedColor = (half4)rgbeEncode(vRGB);
	return encodedColor;
}

half3 DecodeRGBEColor(half4 encodedColor)
{
	float4 vRGBE = (float4)encodedColor;
	half3 color = (half3)rgbeDecode(vRGBE);
	return color;
}

#endif	// ifndef ALIAS_HDR_COLOR_H_