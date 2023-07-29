// #line 4 "..\Gr\Dg\shader\GammaTransformation.h"
#ifndef _GAMMA_TRANSFORMATION_H_
#define _GAMMA_TRANSFORMATION_H_


// #line 11 "..\Gr\Dg\shader\GammaTransformation.h"

half3 GammaCorrection(float3 linearRGB)
{

// #line 24 "..\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(linearRGB, 0.0031308);
	return (half3)((mask * (linearRGB * 12.92)) + ((1 - mask) * (1.055 * pow(max(linearRGB, 0.00001), (1.0 / 2.4)) - 0.055)));
}



// #line 35 "..\Gr\Dg\shader\GammaTransformation.h"

float3 GammaDecode(float3 inSRGB)
{

// #line 48 "..\Gr\Dg\shader\GammaTransformation.h"
	float3 mask = step(inSRGB, 0.03928);
	return (half3)(mask * (inSRGB / 12.92)) + ((1 - mask) * (pow(max((inSRGB + 0.055) / 1.055, 0.00001), 2.4)));
}



// #line 59 "..\Gr\Dg\shader\GammaTransformation.h"

float GammaDecodeF(float f)
{
	float linear_f;
	linear_f = ((f <= 0.03928) ? f / 12.92 : pow(abs((f + 0.055) / 1.055), 2.4));
	return linear_f;
}

#endif	// ifndef _GAMMA_TRANSFORMATION_H_