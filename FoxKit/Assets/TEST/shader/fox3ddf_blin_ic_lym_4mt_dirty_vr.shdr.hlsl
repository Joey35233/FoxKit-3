// #line 6 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"


#define USE_VIEWDIR

// #line 6 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"


#define USE_SUBUV
#define USE_VCOL

#include "fox3ddf_blin_4mt.shdr.hlsl"


// #line 16 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"


// J - include
#include "LayerBlend.h.hlsl"

// #line 19 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"






// #line 27 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"


// #line 37 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"




Texture2D g_tex_layer			: TEXUNIT4;
Texture2D g_tex_layerMask		: TEXUNIT5;
SamplerState g_sampler_layer		: SAMPLERUNIT4;
SamplerState g_sampler_layerMask	: SAMPLERUNIT5;



// #line 51 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"


// #line 64 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"



Texture2D g_tex_Dirty			: TEXUNIT6;
SamplerState g_sampler_Dirty			: SAMPLERUNIT6;


// #line 76 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"


// #line 89 "..\Gr\Dg\shader\fox3ddf_blin_ly_mul_4mt_dirty.shdr.hlsl"



// #line 9 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"







// #line 20 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"


// #line 34 "..\Gr\Dg\shader\fox3ddf_blin_ic_lym_4mt_dirty.shdr.hlsl"






// J - PANIC WHAT IS HAPPENING