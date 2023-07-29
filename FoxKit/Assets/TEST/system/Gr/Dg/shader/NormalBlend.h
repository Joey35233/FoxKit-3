// #line 4 "..\Gr\Dg\shader\NormalBlend.h"
#ifndef NORMAL_BLEND_H_
#define NORMAL_BLEND_H_




// #line 17 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendSubNormal(Texture2D normalTexture, float2 texcoordNormal,
	Texture2D subnormalTexture, float2 texcoordRepeat,
	float mask,
	float subnormalBlendRate, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;

	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTexture(normalTexture, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTexture(subnormalTexture, texcoordNormal * texcoordRepeat).xy
		* (half2)mask.xx * (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}



// #line 58 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendSubNormalWithSampler(Texture2D normalTexture, SamplerState normalSampler, float2 texcoordNormal,
	Texture2D subnormalTexture, SamplerState subnormalSampler, float2 texcoordRepeat,
	float mask,
	float subnormalBlendRate, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;

	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTextureWithSampler(normalTexture, normalSampler, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTextureWithSampler(subnormalTexture, subnormalSampler, texcoordNormal * texcoordRepeat).xy
		* (half2)mask.xx * (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}



// #line 98 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendSubNormalAnim(Texture2D normalTexture, float2 texcoordNormal,
	Texture2D subnormalTexture, float2 texcoordRepeat, float2 texcoordShift,
	float mask,
	float subnormalBlendRate, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;

	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTexture(normalTexture, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTexture(subnormalTexture, (texcoordNormal + texcoordShift) * texcoordRepeat).xy
		* (half2)mask.xx * (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}


// #line 139 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendSubNormalAnimWithSampler(Texture2D normalTexture, SamplerState normalSampler, float2 texcoordNormal,
	Texture2D subnormalTexture, SamplerState subnormalSampler, float2 texcoordRepeat, float2 texcoordShift,
	float mask,
	float subnormalBlendRate, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;

	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTextureWithSampler(normalTexture, normalSampler, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTextureWithSampler(subnormalTexture, subnormalSampler, (texcoordNormal + texcoordShift) * texcoordRepeat).xy
		* (half2)mask.xx * (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}


// #line 176 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendTensionSubNormal(Texture2D normalTexture, float2 texcoordNormal,
	Texture2D subnormalTexture,
	float subnormalBlendRate, float subnormalShift, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;





	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTexture(normalTexture, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTexture(subnormalTexture, texcoordNormal * float2(0.5, 1) + float2(subnormalShift, 0)).xy
		* (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}


// #line 218 "..\Gr\Dg\shader\NormalBlend.h"

half3 BlendTensionSubNormalWithSampler(Texture2D normalTexture, SamplerState normalSampler, float2 texcoordNormal,
	Texture2D subnormalTexture, SamplerState subnormalSampler,
	float subnormalBlendRate, float subnormalShift, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, outNormal;





	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTextureWithSampler(normalTexture, normalSampler, texcoordNormal);
	normal.xy += (half2)(GetNormalFromTextureWithSampler(subnormalTexture, subnormalSampler, texcoordNormal * float2(0.5, 1) + float2(subnormalShift, 0)).xy
		* (half2)subnormalBlendRate.xx);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}



// #line 260 "..\Gr\Dg\shader\NormalBlend.h"

half3 FadeBlendSubNormalWithSampler(Texture2D normalTexture, SamplerState normalSampler, float2 texcoordNormal,
	Texture2D subnormalTexture, SamplerState subnormalSampler,
	float subnormalBlendRate, half face,
	half3 inAxisTransform0,
	half3 inAxisTransform1,
	half3 inAxisTransform2)
{
	half3 normal, subNormal, outNormal;

	inAxisTransform2.xyz *= face;
	normal.xyz = GetNormalFromTextureWithSampler(normalTexture, normalSampler, texcoordNormal);
	subNormal.xyz = GetNormalFromTextureWithSampler(subnormalTexture, subnormalSampler, texcoordNormal);
	normal = (half3)lerp(normal, subNormal, subnormalBlendRate);
	normal.xyz = (half3)normalize(normal.xyz);


	normal.xyz = (half3)(
		normalize(inAxisTransform0.xyz) * normal.xxx +
		normalize(inAxisTransform1.xyz) * normal.yyy +
		normalize(inAxisTransform2.xyz) * normal.zzz);
	outNormal.xyz = (half3)normalize(normal.xyz);

	return outNormal;

}

#endif	// ifndef NORMAL_BLEND_H_