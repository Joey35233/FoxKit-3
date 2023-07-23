// #line 1 "..\Gr\Dg\shader\HdrColor.h.hlsl"
#ifndef HDR_COLOR_H
#define HDR_COLOR_H


// #line 6 "..\Gr\Dg\shader\HdrColor.h.hlsl"




// #line 12 "..\Gr\Dg\shader\HdrColor.h.hlsl"

half4 EncodeHDRColor(half3 color)
{
	half4	encodeColor;


	encodeColor.xyz = color.xyz;


	encodeColor.w = dot(color.xyz, LUMINANCE_VECTOR * (1.0h / HDR_LUM_SCALE));

	return encodeColor;
}



// #line 30 "..\Gr\Dg\shader\HdrColor.h.hlsl"

half3 DecodeHDRColor(half4 encodeColor)
{
	half	scale;
	half3	color;


	scale = max(1.0h, encodeColor.w * HDR_LUM_SCALE);
	color.xyz = encodeColor.xyz * scale;

	return color;
}

#endif	// ifndef HDR_COLOR_H